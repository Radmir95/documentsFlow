using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using XML;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace FormsXML
{
    public partial class Form1 : Form
    {

        private DataSet _ds;

        public Form1()
        {
            InitializeComponent();
            FormInitialize();
        }

        private void FormInitialize()
        {

            _ds = new DataSet();
            TimeForNowLb.Text = @"Сегодня: " +
            DateTime.Today.ToShortDateString();
            if (!File.Exists("chek.xml"))
                Dataset.Create("chek.xml");

            _ds.ReadXml("chek.xml", XmlReadMode.ReadSchema);

            dataGridView1.DataSource = _ds.Tables["Чеки"];

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ds.WriteXml("chek.xml", XmlWriteMode.WriteSchema);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var newrow = _ds.Tables["Чеки"].NewRow();
            newrow["НомерЧека"] = _ds.Tables["Чеки"].Rows.Count + 1;
            var nom = (int)newrow["НомерЧека"];
            newrow["ДатаЧека"] = DateTime.Today;
            var date = (DateTime)newrow["ДатаЧека"];
            newrow["Магазин"] = "Аптека от склада";
            newrow["ФИОКассира"] = "Хуснутдинов Р.Р.";
            newrow["ОбщаяСтоимость"] = 0;
            _ds.Tables["Чеки"].Rows.Add(newrow);
            foreach (DataGridViewRow dgvr in dataGridView1.SelectedRows)
                dgvr.Selected = false;
            dataGridView1.Rows[dataGridView1.Rows.Count - 2].Selected =
            true;
            var dlg = new AddChek(nom, date, _ds.Tables["ЗаписьЧека"]);
            dlg.ShowDialog();

        }

        Check CreateCheck(int nom, DateTime date)
        {
            // поиск чека по ключу
            DataRow dr = _ds.Tables["Чеки"].Rows.Find
           (new object[] { (object)nom, (object)date });
            // создаем объект чека для последующей сериализации
            Check chek = new Check((int)dr["НомерЧека"],
            (DateTime)dr["ДатаЧека"],
            (string)dr["Магазин"],
            (string)dr["ФИОКассира"]);
            // выбираем все записи, соответствующие 
            // выбранному чеку - дочерние записи
            DataRow[] drs = dr.GetChildRows("СвязьЧека");
            foreach (DataRow d in drs)
            {
                // формируем объект записи чека и добавляем его 
                // в объект чека
                CheckZ z = new CheckZ((string)d["Товар"],
                (int)d["ЦенаТовара"],
                (int)d["Количество"],
                (int)d["Стоимость"]);
                chek.AddZ(z);
            }
            return chek;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
                return;
            var nom =
            (int)dataGridView1.SelectedRows[0].Cells["НомерЧека"].Value;
            var date = (DateTime)dataGridView1.SelectedRows[0].
            Cells["ДатаЧека"].Value;

            var dr = _ds.Tables["Чеки"].Rows.Find
            (new[] { nom, (object)date });

            dr.Delete();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
                return;
            var nom = (int)dataGridView1.SelectedRows[0].
            Cells["НомерЧека"].Value;
            var date = (DateTime)dataGridView1.SelectedRows[0].
            Cells["ДатаЧека"].Value;
            var dlg = new ViewChek(_ds.Tables["ЗаписьЧека"],
            _ds.Tables["Чеки"].Rows.Find(new object[] { nom, date }));
            dlg.ShowDialog();

        }

        private void serialBtn_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
                return;
            //получение номера текущего выбранного чека
            int nom = (int)dataGridView1.SelectedRows[0].
            Cells["НомерЧека"].Value;
            //получение даты текущего выбранного чека
            DateTime date = (DateTime)dataGridView1.SelectedRows[0].
            Cells["ДатаЧека"].Value;
            // инкапсуляция данных для сериализации
            Check chek = CreateCheck(nom, date);
            // вызов стандартного диалога сохранения файла
            SaveFileDialog dlg = new SaveFileDialog();
 if (dlg.ShowDialog() == DialogResult.OK)
            {
                // создание файлового потока, в который 
                // будет сериализоваться информация о чеке
                FileStream fs = new FileStream(dlg.FileName,
                FileMode.Create);
                // создание сериализатора
                SoapFormatter ser = new SoapFormatter();
                // сериализация объекта chek
                ser.Serialize(fs, chek);
                // закрытие файла
                fs.Close();
                MessageBox.Show("Сформирован файл " + dlg.FileName);
            }

        }
    }
}
