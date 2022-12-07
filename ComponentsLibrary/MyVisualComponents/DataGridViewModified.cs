using ComponentsLibrary.RomanovaVisualComponents;
using System.Globalization;

namespace ComponentsLibrary.MyVisualComponents
{
    public partial class DataGridViewModified : UserControl
    {
        /// <summary>
        ///Инициализация DataGrid
        /// </summary>
        public DataGridViewModified()
        {
            InitializeComponent();
        }

        public int IndexRow
        {
            get { return dataGridView.SelectedRows[0].Index; }
            set
            {
                if (dataGridView.SelectedRows.Count <= value || value < 0)
                    throw new ArgumentException(string.Format("{0} is an invalid row index.", value));
                else
                {
                    dataGridView.ClearSelection();
                    dataGridView.Rows[value].Selected = true;
                }
            }
        }

        /// <summary>
        /// Метoд очистки строк DataGrid
        /// </summary>
        public void ClearDataGrid()
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
        }
        /// <summary>
        /// Метод конфигурации DataGridView. Отдельный метод для конфигурации столбцов.
        /// </summary>
        /// <param name="countColumn"></param>
        /// <param name=""></param>
        public void ConfigColumn(ColumnsDataGrid columnsData)
        {
            dataGridView.ColumnCount = columnsData.CountColumn;
            for (int i = 0; i < columnsData.CountColumn; i++)
            {
                dataGridView.Columns[i].Name = columnsData.NameColumn[i];
                dataGridView.Columns[i].Width = columnsData.Width[i];
                dataGridView.Columns[i].Visible = columnsData.Visible[i];
                dataGridView.Columns[i].DataPropertyName = columnsData.PropertiesObject[i];
            }
        }
        /// <summary>
        /// Полуение объекта из строки
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetSelectedObjectIntoRow<T>()
        {
            T objectMy = (T)Activator.CreateInstance(typeof(T));
            var propertiesObj = typeof(T).GetProperties();
            foreach (var properties in propertiesObj)
            {
                bool propIsExist = false;
                int columnIndex = 0;
                for (; columnIndex < dataGridView.Columns.Count; columnIndex++)
                {
                    if (dataGridView.Columns[columnIndex].DataPropertyName.ToString() == properties.Name)
                    {
                        propIsExist = true;
                        break;
                    }
                }
                if (!propIsExist) { throw new Exception("Не найдено свойство!"); };
                object value = dataGridView.SelectedRows[0].Cells[columnIndex].Value;
                if (properties.Name == "Id")
                {
                    value = Convert.ToInt32(value);
                } else if (properties.Name == "DateOut")
                {
                    value = DateTime.Parse(value.ToString());
                }
                properties.SetValue(objectMy, value);
            }
            return objectMy;
        }

        /// <summary>
        ///  Заполнение DataGridView построчно
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectMy"></param>

        public void AddRow<T>(T objectMy)
        {
            if (objectMy == null)
                return;

            var properties = objectMy.GetType().GetProperties();
            string[] values = new string[dataGridView.Columns.Count];
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                string propName = dataGridView.Columns[i].DataPropertyName.ToString();
                values[i] = objectMy.GetType().GetProperty(propName).GetValue(objectMy).ToString();
            }
            dataGridView.Rows.Add(values);
        }

        private void DataGrivViewModified_Load(object sender, EventArgs e)
        {

        }
    }
}
