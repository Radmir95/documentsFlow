using System;

namespace FormsXML
{
    [Serializable]
    public class CheckZ
    {
        private string товар;
        private int ценаТовара;
        private int количество;
        private int стоимость;

        public CheckZ()
        {
            товар = "";
            ценаТовара = 0;
            количество = 0;
            стоимость = 0;

        }

        public CheckZ(string s, int price, int count, int cost)
        {

            товар = s;
            ценаТовара = price;
            количество = count;
            стоимость = cost;

        }

        public string Товар
        {
            
            get { return Товар; }
            set { товар = value; }

        }

        public int ЦенаТовара
        {
            
            get { return ЦенаТовара; }
            set { ценаТовара = value; }

        }

        public int Количество
        {
            get { return количество; }
            set { количество = value; }
        }
        public int Стоимость
        {
            get { return стоимость; }
            set { стоимость = value; }
        }

    }
}
