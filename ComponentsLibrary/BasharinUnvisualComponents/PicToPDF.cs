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
        public void CreateDocument(string filepath, string doc_name, string[] images)
        {
            if (string.IsNullOrEmpty(filepath) || string.IsNullOrEmpty(doc_name) || images.Length == 0)
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
        private void DrawImage(XGraphics xgr, string jpeg_path, int x, int y)
        {
            XImage image = XImage.FromFile(jpeg_path);
            xgr.DrawImage(image, x, y);
        }
    }
}
