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
            // сохраняем данные чека
            this.nom = nom;
            this.date = date;
            this.table = table;
            // устанавливаем отсутсвие скидки по умолчанию
            textBox_Discont.Text = "0";
            // делаем поле скидки недоступным
            textBox_Discont.Enabled = true;
            // показываем номер чека
            label_nomer.Text = "" + nom;
            // формирование DataGridView без автозаполнения
            // отмена генерации столбцов DataGridView
            dataGridView1.AutoGenerateColumns = false;
            // заполнение структуры таблицы записи чека для dataGridView1
            foreach (DataColumn dc in table.Columns)
            {
                // последовательное создание столбцов элемента управления
                DataGridViewTextBoxColumn dgvc =
                    new DataGridViewTextBoxColumn();
                // заголовок столбца
                dgvc.HeaderText = dc.Caption;
                // добавление столбца в коллекцию столбцов DataGridView
                dataGridView1.Columns.Add(dgvc);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            // вводим информацию о записи чека
            DataRow newrow = table.NewRow();
            newrow["НомерЗаписиЧека"] = count + 1;
            newrow["НомерЧека"] = nom;
            newrow["ДатаЧека"] = date;
            // считываем данные из текстовых полей о товаре,
            // количестве и цене
            newrow["Товар"] = textBox_Tovar.Text;
            newrow["ЦенаТовара"] = int.Parse(textBox_Price.Text);
            newrow["Количество"] = int.Parse(textBox_Count.Text);
            newrow["Стоимость"] = (int)newrow["ЦенаТовара"]
            * (int)newrow["Количество"];
            // запоминаем стоимость
            int cost = (int)newrow["Стоимость"];
            // добавляем запись о купленном товаре в таблицу
            table.Rows.Add(newrow);
            // добавляем новую строку в DataGridView c записями чека,
            // заполняем данными из новой строки таблицы
            DataGridViewRow dgwr = new DataGridViewRow();
            dgwr.CreateCells(dataGridView1, newrow["НомерЗаписиЧека"],
            newrow["НомерЧека"], newrow["ДатаЧека"], newrow["Товар"],
            newrow["ЦенаТовара"], newrow["Количество"],
            newrow["Стоимость"]);
            dataGridView1.Rows.Add(dgwr);
            // очищаем текстовые поля с данными нового покупаемого товара
            textBox_Tovar.Text = "";
            textBox_Price.Text = "";
            textBox_Count.Text = "";
            // корректировка общей стоимости
            total_cost = total_cost + cost;
            label_total.Text = "Итого: " + total_cost + " рублей";
            // корректировка общей стоимости в родительской таблице
            DataRow dr = newrow.GetParentRow("СвязьЧека");
            dr["ОбщаяСтоимость"] = total_cost;
            count++;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
