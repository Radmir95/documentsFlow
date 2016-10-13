using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsXML
{
    public partial class ViewChek : Form
    {
        public ViewChek(DataTable table, DataRow chek)
        {
            InitializeComponent();
            // показываем номер чека
            label_nomer.Text = "Номер чека: " + chek["НомерЧека"];
            // показываем дату чека
            label_date.Text = "Дата чека: " +
            ((DateTime)chek["ДатаЧека"]).ToShortDateString();
            // формирование DataGridView без автозаполнения
            // отмена генерации столбцов DataGridView
            dataGridView1.AutoGenerateColumns = false;
 // заполнение структуры таблицы записи
 // чека для dataGridView1
            foreach (DataColumn dc in table.Columns)
            {
                // последовательное создание столбцов
                // элемента управления dataGridView
                DataGridViewTextBoxColumn dgvc =
                new DataGridViewTextBoxColumn();
                // заголовок столбца
                dgvc.HeaderText = dc.Caption;
                // не добавляем столбцы с номером и датой чека
                if (dc.Caption.Equals("НомерЧека") ||
                dc.Caption.Equals("ДатаЧека"))
                    continue;
                // добавление столбца в коллекцию столбцов DataGridView
                dataGridView1.Columns.Add(dgvc);
            }
            // заполнение DataGridView данными чека
            // находим все дочерние записи для чека
            DataRow[] drs = chek.GetChildRows("СвязьЧека");
            // заполнение DataGridView данным из полученного массива
            foreach (DataRow dr in drs)
            {
                DataGridViewRow dgwr = new DataGridViewRow();
                dgwr.CreateCells(dataGridView1, dr["НомерЗаписиЧека"],
                dr["Товар"], dr["ЦенаТовара"], dr["Количество"],
                dr["Стоимость"]);
                dataGridView1.Rows.Add(dgwr);
            }
            // формирование записи об итоговой стоимости по чеку
            label_total.Text = "Итого: " +
            chek["ОбщаяСтоимость"] + " рублей";
        }

      
    }
}
