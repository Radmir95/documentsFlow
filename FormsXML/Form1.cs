using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML;

namespace FormsXML
{
    public partial class Form1 : Form
    {

        private DataSet ds;

        public Form1()
        {
            InitializeComponent();
            FormInitialize();
        }

        private void FormInitialize()
        {

            ds = new DataSet();
            TimeForNowLb.Text = "Сегодня: " +
            DateTime.Today.ToShortDateString();
            if (!File.Exists("chek.xml"))
                Dataset.Create("chek.xml");

            ds.ReadXml("chek.xml", XmlReadMode.ReadSchema);

            // установка источника данных для DataGridView для чеков
            dataGridView1.DataSource = ds.Tables["Чеки"];


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ds.WriteXml("chek.xml", XmlWriteMode.WriteSchema);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ввод информации о чеке
            // создание нового чека
            DataRow newrow = ds.Tables["Чеки"].NewRow();
            // заполнение атрибутов чека
            // для определения номера чека можно узнать
            // количество строк в таблице чеков
            newrow["НомерЧека"] = ds.Tables["Чеки"].Rows.Count + 1;
            // запоминаем номер чека
            int nom = (int)newrow["НомерЧека"];
            newrow["ДатаЧека"] = DateTime.Today;
            // запоминаем дату чека
            DateTime date = (DateTime)newrow["ДатаЧека"];
            newrow["Магазин"] = "Мой Магазин";
            newrow["ФИОКассира"] = "Сидорова С.С.";
            // пока не введены данные о записях чека,
            // общая стоимость равна 0
            newrow["ОбщаяСтоимость"] = 0;
            // записываем созданную запись в таблицу
            ds.Tables["Чеки"].Rows.Add(newrow);
            // выбираем новый чек в качестве текущего
            foreach (DataGridViewRow dgvr in dataGridView1.SelectedRows)
                dgvr.Selected = false;
            dataGridView1.Rows[dataGridView1.Rows.Count - 2].Selected =
            true;
            // вызываем диалог формирования записей чека
            AddChek dlg = new AddChek(nom, date, ds.Tables["ЗаписьЧека"]);
            dlg.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // если чек не был выбран, удалять нечего
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            //получение номера текущего выбранного чека
            int nom =
            (int)dataGridView1.SelectedRows[0].Cells["НомерЧека"].Value;
            //получение даты текущего выбранного чека
            DateTime date = (DateTime)dataGridView1.SelectedRows[0].
            Cells["ДатаЧека"].Value;
            // поиск чека по ключу
            DataRow dr = ds.Tables["Чеки"].Rows.Find
            (new object[] { (object)nom, (object)date });
            dr.Delete();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // если чек не был выбран, удалять нечего
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            //получение номера текущего выбранного чека
            int nom = (int)dataGridView1.SelectedRows[0].
            Cells["НомерЧека"].Value;
            //получение даты текущего выбранного чека
            DateTime date = (DateTime)dataGridView1.SelectedRows[0].
            Cells["ДатаЧека"].Value;
            // вызываем диалог показа детализации выбранного чека
            ViewChek dlg = new ViewChek(ds.Tables["ЗаписьЧека"],
            ds.Tables["Чеки"].Rows.Find(new object[] { nom, date }));
            dlg.ShowDialog();
        }
    }
}
