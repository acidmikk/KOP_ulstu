using WinFormsControlLibraryBasharinLab2;

namespace KOP_5var
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonPic_Click(object sender, EventArgs e)
        {
            picToPDF.CreateDocument
                ("D:\\Documents\\proverka.pdf",
                "Голова",
                new string[] {
                                "D:\\pic\\e7kDmjYrIns.jpg",
                                "D:\\pic\\e.jpg"
                             }
                );
        }

        private void buttonTable_Click(object sender, EventArgs e)
        {
            Dictionary<int, int> rowMergeInfo = new() { { 0, 1 }, { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 2 } };
            Dictionary<int, int> rowHeightInfo = new() { { 0, 20 }, { 1, 10 }, { 2, 30 }, { 3, 20 }, { 4, 30 }, { 5, 20 }, { 6, 20 }, { 7, 15 } };
            Dictionary<Tuple<int, string>, List<string>> headers = new()
            {
                { Tuple.Create(0, "Идент."), new List<string>() },
                { Tuple.Create(1, "Город"), new List<string>()},
                { Tuple.Create(2, "Регион"), new List<string>(){"Область","Округ"} },
                { Tuple.Create(3, "Страна"), new List<string>() },
                { Tuple.Create(4, "Адрес"), new List<string>(){"Район","Улица","Дом" } }
            };

            List<City> cities = new()
            {
                new City { Id=1,Name = "Москва", Region = "Москва", Federal_District = "Центральный", Country = "Россия", Rayon="Центр", Street="Хорошая", Home_num=11},
                new City { Id=2,Name = "Казань", Region = "Татарстан", Federal_District = "Приволжский", Country = "Россия", Rayon="Центр", Street="Хорошая", Home_num=11},
                new City { Id=3,Name = "Владивосток", Region = "Приморский край", Federal_District = "Дальневосточный", Country = "Россия", Rayon="Центр", Street="Хорошая", Home_num=11},
            };
            tableToPDF.Order = new() { "Id", "Name", "Region", "Federal_District", "Country", "Rayon", "Street", "Home_num" };
            tableToPDF.CreateDocument("D:\\Documents\\proverka2.pdf", "Заголовок",
                rowMergeInfo, rowHeightInfo, headers, cities);
        }

        private void buttonDiagram_Click(object sender, EventArgs e)
        {
            Dictionary<string, double> values = new() {
                {"Данные 1", 9.0},
                {"Данные 2", 16.0},
                {"Данные 3", 24.0},
                {"Данные 4", 12.0},
                {"Данные 5", 19.0},
                {"Данные 6", 5.0}
            };

            diagramToPDF.CreateDocument("D:\\Documents\\proverka3.pdf", "Голова", "Диаграмма",
                Area.RIGHT, values);
        }
    }
}
