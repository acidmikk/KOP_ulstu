using ComponentsLibrary.MyUnvisualComponents.HelperModels;
using System.ComponentModel;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ComponentsLibrary.MyUnvisualComponents
{
    public partial class WordGistagram : Component
    {
        public WordGistagram()
        {
            InitializeComponent();
        }

        public WordGistagram(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Метод создания отчёта
        /// </summary>
        public void ReportSaveGistogram(string filename, string title, string nameGistogram,
            LocationLegend legend, List<TestData> list)
        {
            if (string.IsNullOrEmpty(filename) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(nameGistogram) || list.Count == 0)
            {
                throw new Exception("Поля пустые!");
            }
            CreateDoc(filename, title, nameGistogram, legend, list);

        }
        /// <summary>
        /// Создание документа
        /// </summary>
        private void CreateDoc(string fileName, string title, string nameDiagram, LocationLegend chartLegendPosition, List<TestData> list)
        {
            try
            {
                DocX document = DocX.Create(fileName);
                document.InsertParagraph(title);
                document.Paragraphs[0].Direction = Direction.RightToLeft;
                document.Paragraphs[0].Alignment = Alignment.center;
                document.Paragraphs[0].FontSize(20);
                document.Paragraphs[0].Bold();
                // создаём линейную диаграмму
                BarChart gistogramChart = new BarChart();
                // добавляем легенду 
                gistogramChart.AddLegend((ChartLegendPosition)chartLegendPosition, false);
                Series seriesFirst = new Series(nameDiagram);
                // заполняем данными
                seriesFirst.Bind(list, "name", "value");
                // создаём набор данных и добавляем на диаграмму
                gistogramChart.AddSeries(seriesFirst);
                document.InsertChart(gistogramChart);
                document.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
