using System.ComponentModel;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace ComponentsLibrary.BasharinUnvisualComponents
{
    public partial class PicToPDF : Component
    {
        public PicToPDF()
        {
            InitializeComponent();
        }

        public PicToPDF(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CreateDocument(string filepath, string doc_name, List<string> images)
        {
            if (string.IsNullOrEmpty(filepath) || string.IsNullOrEmpty(doc_name) || images.Count == 0)
            {
                throw new ArgumentNullException("Недостаточная заполненость данных");
            }

            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XFont font = new XFont("Robotic", 18, XFontStyle.BoldItalic);

            XGraphics xgr = XGraphics.FromPdfPage(page);
            xgr.DrawString(doc_name, font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height),
                          XStringFormats.TopCenter);

            foreach (string image in images)
            {
                DrawImage(xgr, image, 50, 50);
                page = document.AddPage();
                xgr = XGraphics.FromPdfPage(page);
            }
            document.Pages.RemoveAt(document.PageCount - 1);
            document.Save(filepath);
        }
        private void DrawImage(XGraphics xgr, string jpeg, int x, int y)
        {
            byte[] arrayimg = Convert.FromBase64String(jpeg);
            XImage image = XImage.FromStream(new MemoryStream(arrayimg));
            xgr.DrawImage(image, x, y);
        }
    }
}
