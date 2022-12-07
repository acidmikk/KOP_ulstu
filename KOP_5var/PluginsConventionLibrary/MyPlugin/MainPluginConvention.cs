using PluginsConventionLibrary.Plugins;
using System.ComponentModel.Composition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentsLibrary.MyUnvisualComponents;
using ComponentsLibrary.RomanovaUnvisualComponents;
using ComponentsLibrary.RomanovaVisualComponents;
using LibraryBusinessLogic.BusinessLogics;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using ComponentsLibrary.MyVisualComponents;
using PluginsConventionLibrary.Forms;
using ComponentsLibrary.BasharinUnvisualComponents;
using LibraryContracts.ViewModels;
using ComponentsLibrary.MyUnvisualComponents.HelperModels;

namespace PluginsConventionLibrary.MyPlugin
{
    [Export(typeof(IPluginsConvention))]
    public class MainPluginConvention : IPluginsConvention
    {
        private DataGridViewModified dataGridViewModified;
        private readonly IBookLogic _bookLogic;
        private readonly IAuthorLogic _authorLogic;

        public MainPluginConvention()
        {
            _bookLogic = new BookLogic();
            _authorLogic = new AuthorLogic();

            dataGridViewModified = new DataGridViewModified();
            var menu = new ContextMenuStrip();
            var shapeMenuItem = new ToolStripMenuItem("Авторы");
            menu.Items.Add(shapeMenuItem);
            shapeMenuItem.Click += (sender, e) =>
            {
                var formShape = new FormAuthor(_authorLogic);
                formShape.ShowDialog();
            };
            dataGridViewModified.ContextMenuStrip = menu;
            ReloadData();
        }

        /// Название плагина
        string IPluginsConvention.PluginName => PluginName();
        public string PluginName()
        {
            return "Книги";
        }

        public UserControl GetControl => dataGridViewModified;

        PluginsConventionElement IPluginsConvention.GetElement => GetElement();

        public PluginsConventionElement GetElement()
        {
            var book = dataGridViewModified.GetSelectedObjectIntoRow<MainPluginConventionElement>(); ;
            MainPluginConventionElement element = null;
            if (dataGridViewModified != null)
            {
                element = new MainPluginConventionElement
                {
                    Id = book.Id,
                    BookName = book.BookName,
                    Author = book.Author,
                    Image = book.Image,
                    DateOut = book.DateOut
                };
            }
            return (new PluginsConventionElement { Id = element.Id });
        }

        public Form GetForm(PluginsConventionElement element)
        {
            var formOrder = new FormBook(_bookLogic, _authorLogic);
            if (element != null)
            {
                formOrder.Id = element.Id;
            }
            return formOrder;
        }

        public bool DeleteElement(PluginsConventionElement element)
        {
            try
            {
                _bookLogic.Delete(new BookBindingModel { Id = element.Id });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void ReloadData()
        {
            dataGridViewModified.ClearDataGrid();
            dataGridViewModified.ClearDataGrid();
            ColumnsDataGrid column = new ColumnsDataGrid();
            column.CountColumn = 5;
            column.NameColumn = new string[] { "Id", "Название", "картинка", "Автор", "Дата публикации" };
            column.Width = new int[] { 50, 300, 0, 300, 130 };
            column.Visible = new bool[] { true, true, false, true, true };
            column.PropertiesObject = new string[] { "Id", "BookName", "Image", "Author", "DateOut" };
            dataGridViewModified.ConfigColumn(column);
            var list = _bookLogic.Read(null);
            if (list != null)
            {
                foreach (var book in list)
                {
                    dataGridViewModified.AddRow(book);
                }
            }
        }

        public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
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
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
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
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
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
                    }
                    else
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
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
