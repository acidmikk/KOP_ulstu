using ComponentsLibrary.MyVisualComponents;
using ComponentsLibrary.RomanovaVisualComponents;
using Database.Models;
using LibraryBusinessLogic.BusinessLogics;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using Unity;

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
                    CreateSimpleDoc();
                    break;
                case Keys.T:
                    CreateTableDoc();
                    break;
                case Keys.C:
                    CreateChartDoc();
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
            
        }
        private void CreateTableDoc()
        {
            // TODO узнать где сохранять
            
        }
        private void CreateWord()
        {
            // TODO узнать где сохранять
            
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
       CreateTableDoc();
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