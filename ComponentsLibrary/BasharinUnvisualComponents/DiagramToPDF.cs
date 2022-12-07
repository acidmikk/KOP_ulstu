using System.ComponentModel;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.Rendering;

namespace ComponentsLibrary.BasharinUnvisualComponents
{
    public partial class DiagramToPDF : Component
    {
        public DiagramToPDF()
        {
            InitializeComponent();
        }

        public DiagramToPDF(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CreateDocument(string filepath, string docname,
            string chartname, Area area, Dictionary<string, double> values)
        {
            var document = DefineCharts(docname, chartname, area, values);

            var renderer = new PdfDocumentRenderer(true)
            {
                Document = document
            };
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            renderer.RenderDocument();
            renderer.PdfDocument.Save(filepath);
        }
        public static Document DefineCharts(string docname, string chartname,
            Area area, Dictionary<string, double> values)
        {
            if (string.IsNullOrEmpty(docname) || string.IsNullOrEmpty(chartname) || values == null)
            {
                throw new Exception("Недостаточная заполненность данных");
            }

            Document document = new Document();
            document.AddSection();
            document.LastSection.AddParagraph(docname, "Heading1").Format.Font.Bold = true;

            Chart chart = new Chart(ChartType.Pie2D);
            chart.HeaderArea.AddParagraph(chartname);

            chart.Width = Unit.FromCentimeter(16);
            chart.Height = Unit.FromCentimeter(12);
            Series series = chart.SeriesCollection.AddSeries();
            series.Add(values.Values.ToArray());

            XSeries xseries = chart.XValues.AddXSeries();
            xseries.Add(values.Keys.ToArray());

            switch (area)
            {
                case Area.BOTTOM:
                    chart.FooterArea.AddLegend();
                    break;
                case Area.TOP:
                    chart.TopArea.AddLegend();
                    break;
                case Area.RIGHT:
                    chart.RightArea.AddLegend();
                    break;
                case Area.LEFT:
                    chart.LeftArea.AddLegend();
                    break;
            }
            chart.DataLabel.Type = DataLabelType.Percent;
            chart.DataLabel.Position = DataLabelPosition.OutsideEnd;

            document.LastSection.Add(chart);

            return document;
        }
    }
}