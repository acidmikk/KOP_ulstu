using System.ComponentModel;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ComponentsLibrary.RomanovaUnvisualComponents
{
    public partial class RomanovaExcelDocument : Component
    {
        public RomanovaExcelDocument()
        {
            InitializeComponent();
        }

        public RomanovaExcelDocument(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CreateExcel(string file, string title, string[] text)
        {
            if (string.IsNullOrEmpty(file))
                throw new ArgumentException("Не указан путь к файлу");

            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Не указан заголовок документа");

            if (text == null || text.Length == 0)
                throw new ArgumentException("Массив с текстом пуст либо null");

            var xlApp = new Excel.Application(); 
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(); 
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1]; 
            xlWorkSheet.Cells[1, 1] = title;

            for (int i = 0; i < text.Length; i++)
            {
                xlWorkSheet.Cells[i + 3, 1] = text[i];
            }

            xlApp.Application.ActiveWorkbook.SaveAs(file);
            xlWorkBook.Close(true);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlApp);

            MessageBox.Show("Документ успешно создан!");
        }
    }
}
