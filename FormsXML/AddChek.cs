using System;
using System.Data;
using System.Windows.Forms;

namespace FormsXML
{
    public partial class AddChek : Form
    {

        int nom; // номер текущего чека
        DateTime date; // дата текущего чека
        DataTable table; // таблица записей чека
        int count = 0; // количество записей чека
        int total_cost = 0; // общая стоимость чека
        //. . .
        public AddChek(int nom, DateTime date, DataTable table)
        {
            InitializeComponent();
            this.nom = nom;
            this.date = date;
            this.table = table;
            dataGridView1.AutoGenerateColumns = false;
            foreach (DataColumn dc in table.Columns)
            {
                var dgvc =
                    new DataGridViewTextBoxColumn();
                dgvc.HeaderText = dc.Caption;
                dataGridView1.Columns.Add(dgvc);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            var newrow = table.NewRow();
            newrow["НомерЗаписиЧека"] = count + 1;
            newrow["НомерЧека"] = nom;
            newrow["ДатаЧека"] = date;
            newrow["Товар"] = textBox_Tovar.Text;
            newrow["ЦенаТовара"] = int.Parse(textBox_Price.Text);
            newrow["Количество"] = int.Parse(textBox_Count.Text);
            newrow["Стоимость"] = (int)newrow["ЦенаТовара"]
            * (int)newrow["Количество"];
            var cost = (int)newrow["Стоимость"];
            table.Rows.Add(newrow);
            var dgwr = new DataGridViewRow();
            dgwr.CreateCells(dataGridView1, newrow["НомерЗаписиЧека"],
            newrow["НомерЧека"], newrow["ДатаЧека"], newrow["Товар"],
            newrow["ЦенаТовара"], newrow["Количество"],
            newrow["Стоимость"]);
            dataGridView1.Rows.Add(dgwr);
            textBox_Tovar.Text = "";
            textBox_Price.Text = "";
            textBox_Count.Text = "";
            total_cost = total_cost + cost;
            label_total.Text = "Итого: " + total_cost + " рублей";
            var dr = newrow.GetParentRow("СвязьЧека");
            dr["ОбщаяСтоимость"] = total_cost;
            count++;
        }


    }
}
