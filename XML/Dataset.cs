using System;
using System.Data;

namespace XML
{
    public class Dataset
    {

        public static void Create(string filePath)
        {
            var ds = new DataSet();
            var chek = new DataTable("Чеки");
            ds.Tables.Add(chek);
            var dc = new DataColumn("НомерЧека",
            Type.GetType("System.Int32"));
            ds.Tables["Чеки"].Columns.Add(dc);
            dc = new DataColumn("ДатаЧека", Type.GetType("System.DateTime"));
            ds.Tables["Чеки"].Columns.Add(dc);
            dc = new DataColumn("Магазин", Type.GetType("System.String"));
            ds.Tables["Чеки"].Columns.Add(dc);
            dc = new DataColumn("ФИОКассира", Type.GetType("System.String"));
            ds.Tables["Чеки"].Columns.Add(dc);
            dc = new DataColumn("ОбщаяСтоимость",
            Type.GetType("System.Int32"));
            ds.Tables["Чеки"].Columns.Add(dc);

            var key = new DataColumn[2]
{ ds.Tables["Чеки"].Columns["НомерЧека"],
ds.Tables["Чеки"].Columns["ДатаЧека"] };
            ds.Tables["Чеки"].PrimaryKey = key;
            ds.Tables.Add(new DataTable("ЗаписьЧека"));
            dc = new DataColumn("НомерЗаписиЧека",
            Type.GetType("System.Int32"));

            ds.Tables["ЗаписьЧека"].Columns.Add(dc);
            dc = new DataColumn("НомерЧека", Type.GetType("System.Int32"));
            ds.Tables["ЗаписьЧека"].Columns.Add(dc);
            dc = new DataColumn("ДатаЧека", Type.GetType("System.DateTime"));
            ds.Tables["ЗаписьЧека"].Columns.Add(dc);
            dc = new DataColumn("Товар", Type.GetType("System.String"));
            ds.Tables["ЗаписьЧека"].Columns.Add(dc);
            dc = new DataColumn("ЦенаТовара", Type.GetType("System.Int32"));
            ds.Tables["ЗаписьЧека"].Columns.Add(dc);
            dc = new DataColumn("Количество", Type.GetType("System.Int32"));
            ds.Tables["ЗаписьЧека"].Columns.Add(dc);
            dc = new DataColumn("Стоимость", Type.GetType("System.Int32"));
            ds.Tables["ЗаписьЧека"].Columns.Add(dc);
            key = new DataColumn[3]
            { ds.Tables["ЗаписьЧека"].Columns["НомерЗаписиЧека"],
ds.Tables["ЗаписьЧека"].Columns["НомерЧека"],
ds.Tables["ЗаписьЧека"].Columns["ДатаЧека"] };
            ds.Tables["ЗаписьЧека"].PrimaryKey = key;
            var rel = new DataRelation("СвязьЧека",
            new[]{ds.Tables["Чеки"].Columns["НомерЧека"],
ds.Tables["Чеки"].Columns["ДатаЧека"]},
            new[]{ds.Tables["ЗаписьЧека"].Columns["НомерЧека"],
ds.Tables["ЗаписьЧека"].Columns["ДатаЧека"]});
            ds.Relations.Add(rel);

            ds.WriteXml(filePath, XmlWriteMode.WriteSchema);

        }

    }
}
