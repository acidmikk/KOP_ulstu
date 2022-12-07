using LibraryBusinessLogic.BusinessLogics;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;

namespace ViewForm
{
    public partial class FormAuthor : Form
    {
        private readonly IAuthorLogic authorLogic;
        List<AuthorBindingModel> list;

        public FormAuthor(IAuthorLogic _authorLogic)
        {
            InitializeComponent();
            authorLogic = _authorLogic;
            list = new List<AuthorBindingModel>();
        }

        private void LoadData()
        {
            try
            {
                var list1 = authorLogic.Read(null);
                list.Clear();
                foreach (var item in list1)
                {
                    list.Add(new AuthorBindingModel
                    {
                        Id = item.Id,
                        AuthorName = item.AuthorName,
                    });
                }
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormShape_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var typeName = (string)dataGridView.CurrentRow.Cells[1].Value;
            if (!string.IsNullOrEmpty(typeName))
            {
                if (dataGridView.CurrentRow.Cells[0].Value != null)
                {
                    authorLogic.CreateOrUpdate(new AuthorBindingModel()
                    {
                        Id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value),
                        AuthorName = (string)dataGridView.CurrentRow.Cells[1].EditedFormattedValue
                    });
                }
                else
                {
                    authorLogic.CreateOrUpdate(new AuthorBindingModel()
                    {
                        AuthorName = (string)dataGridView.CurrentRow.Cells[1].EditedFormattedValue
                    });
                }
            }
            else
            {
                MessageBox.Show("Введена пустая строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert)
            {
                if (dataGridView.Rows.Count == 0)
                {
                    list.Add(new AuthorBindingModel());
                    dataGridView.DataSource = new List<AuthorBindingModel>(list);
                    dataGridView.CurrentCell = dataGridView.Rows[0].Cells[1];
                    return;
                }
                if (dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[1].Value != null)
                {
                    list.Add(new AuthorBindingModel());
                    dataGridView.DataSource = new List<AuthorBindingModel>(list);
                    dataGridView.CurrentCell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[1];
                    return;
                }
            }
            if (e.KeyData == Keys.Delete)
            {
                if (MessageBox.Show("Удалить выбранный элемент", "Удаление",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    authorLogic.Delete(new AuthorBindingModel() { Id = (int)dataGridView.CurrentRow.Cells[0].Value });
                    LoadData();
                }
            }
        }
    }
}
