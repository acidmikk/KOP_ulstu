using ComponentsLibrary.MyVisualComponents;
using ComponentsLibrary.RomanovaVisualComponents;
using ComponentsLibrary.BasharinUnvisualComponents;
using ComponentsLibrary.RomanovaUnvisualComponents;
using ComponentsLibrary.MyUnvisualComponents;
using Database.Models;
using LibraryBusinessLogic.BusinessLogics;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using Unity;
using ComponentsLibrary.MyUnvisualComponents.HelperModels;
using LibraryContracts.ViewModels;

namespace ViewForm
{
    public partial class FormMain : Form
    {
        private readonly IBookLogic _bookLogic;
        public FormMain(IBookLogic bookLogic)
        {
            InitializeComponent();
            _bookLogic = bookLogic;
            LoadData();
        }
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.A:
                    AddNewElement();
                    break;
                case Keys.U:
                    UpdateElement();
                    break;
                case Keys.D:
                    DeleteElement();
                    break;
                case Keys.S:
                    CreatePDF();
                    break;
                case Keys.T:
                    CreateExcel();
                    break;
                case Keys.C:
                    CreateWord();
                    break;
            }
        }
        public void LoadData()
        {
            try
            {
                dataGridViewModified1.ClearDataGrid();
                ColumnsDataGrid column = new ColumnsDataGrid();
                column.CountColumn = 5;
                column.NameColumn = new string[] { "Id", "Название", "картинка", "Автор", "Дата публикации" };
                column.Width = new int[] { 50, 300, 0, 300, 130 };
                column.Visible = new bool[] { true, true, false, true, true };
                column.PropertiesObject = new string[] { "Id", "BookName", "Image", "Author", "DateOut" };
                dataGridViewModified1.ConfigColumn(column);
                var list = _bookLogic.Read(null);
                if (list != null)
                {
                    foreach (var book in list)
                    {
                        dataGridViewModified1.AddRow(book);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddNewElement()
        {
            var form = Program.Container.Resolve<FormBook>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void UpdateElement()
        {
            var form = Program.Container.Resolve<FormBook>();
            form.Id = Convert.ToInt32(dataGridViewModified1.GetSelectedObjectIntoRow<Book>().Id);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void DeleteElement()
        {
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridViewModified1.GetSelectedObjectIntoRow<Book>().Id);
                try
                {
                    _bookLogic.Delete(new BookBindingModel { Id = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadData();
            }

        }
        private void CreatePDF()
        {
            // TODO узнать где сохранять
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
            var list = _bookLogic.Read(null);
            var list_images = new List<string>();
            foreach (var item in list)
            {
                list_images.Add(item.Image);
            }
            PicToPDF picToPDF = new PicToPDF();
            picToPDF.CreateDocument(fileName, "Обложки книг", list_images);
        }
        private void CreateExcel()
        {
            // TODO узнать где сохранять
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
            RomanovaExcelTable romanovaExcelTable = new RomanovaExcelTable();
            var dict = new List<MergeCells>();
            romanovaExcelTable.columnsName = new List<string>() { "Id", "BookName", "Author", "DateOut" };
            int[] arrayHeight = { 30, 30, 30, 30 };
            string[] arrayHeader3 = { "Идентификатор", "Название книги", "Автор", "Дата публикации" };
            var listBooks = new List<BookViewModel>();
            var list = _bookLogic.Read(null);
            foreach (var book in list)
            {
                listBooks.Add(book);
            }
            dict.Add(new MergeCells("Инфо о книге", new int[] { 1, 2, 3 }));

            romanovaExcelTable.CreateTableExcel(fileName, "Книги", dict, arrayHeight, arrayHeader3, listBooks);
        }
        private void CreateWord()
        {
            // TODO узнать где сохранять
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
            WordGistagram wordGistagram = new WordGistagram();
            List<TestData> data = new List<TestData>();
            var list = _bookLogic.Read(null);
            Dictionary<string, int> authors = new Dictionary<string, int>();
            foreach (var book in list)
            {
                if (!authors.ContainsKey(book.Author))
                {
                    authors[book.Author] = 1;
                } else
                {
                    authors[book.Author]++;
                }
            }
            foreach (var author in authors)
            {
                data.Add(new TestData { name = author.Key, value = author.Value });
            }
            LocationLegend legend = new LocationLegend();
            wordGistagram.ReportSaveGistogram(fileName, "Документ с гистограммой", "Авторы", legend, data);
        }
        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e) =>
       AddNewElement();
        private void UpdElementToolStripMenuItem_Click(object sender, EventArgs e) =>
       UpdateElement();
        private void DelElementToolStripMenuItem_Click(object sender, EventArgs e) =>
       DeleteElement();
        private void SimpleDocToolStripMenuItem_Click(object sender, EventArgs e) =>
       CreatePDF();
        private void TableDocToolStripMenuItem_Click(object sender, EventArgs e) =>
       CreateExcel();
        private void ChartDocToolStripMenuItem_Click(object sender, EventArgs e) =>
       CreateWord();

        private void авторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormAuthor>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}