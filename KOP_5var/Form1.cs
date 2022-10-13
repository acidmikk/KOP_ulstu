using WinFormsControlLibraryBasharin;

namespace KOP_5var
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            //For first element
            sevaCheckedListBox1.AddItem("Привет");
            sevaCheckedListBox1.AddItem("Мир");
            sevaCheckedListBox1.AddItem("!!!");

            //For second element
            sevaTextBox1.MinLenght = 5;
            sevaTextBox1.MaxLenght = 10;

            //For third element
            List<City> Citys = new List<City>();
            City City = new City();
            City.Country = "Россия";
            City.Federal_District = "Центральный";
            City.Region = "Москва";
            City.Name = "Москва";
            Citys.Add(City);
            City City1 = new City();
            City1.Country = "Россия";
            City1.Federal_District = "Приволжский";
            City1.Region = "Татарстан";
            City1.Name = "Казань";
            Citys.Add(City1);
            City City2 = new City();
            City2.Country = "Россия";
            City2.Federal_District = "Дальневосточный";
            City2.Region = "Приморский край";
            City2.Name = "Владивосток";
            Citys.Add(City2);
            sevaTreeView1.SetConfig(new List<string>() { "Country", "Federal_District", "Region", "Name" });
            foreach (City city in Citys)
            {
                sevaTreeView1.CreateTree(city);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var City = sevaTreeView1.GetSelectedNode<City>();
            MessageBox.Show(City.Country + " " + City.Federal_District + " " + City.Region + " " + City.Name);
        }
    }
}