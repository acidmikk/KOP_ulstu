namespace ComponentsLibrary.MyVisualComponents
{
    public partial class TextBoxModified : UserControl
    {
        /// <summary>
        /// Метод инициализации компонента
        /// </summary>
        public TextBoxModified()
        {
            InitializeComponent();
        }

        public double? ValueTextBox
        {
            get
            {
                if (checkBoxNull.Checked) return null;
                string textBoxValue = textBox.Text.ToString();
                double num;
                bool isDouble = Double.TryParse(textBoxValue, out num);
                if (!isDouble)
                {
                    throw new Exception("Ошибка! Не число");
                }
                return num;
            }
            set
            {
                if (value != null)
                {
                    textBox.Text = value.Value.ToString();
                    checkBoxNull.Checked = false;
                }
                else
                {
                    textBox.Text = string.Empty;
                    checkBoxNull.Checked = true;
                }
            }
        }

        public event EventHandler eventHandler;

        private void TextBox_SelectedChanged(object sender, System.EventArgs e)
        {
            eventHandler?.Invoke(sender, e);
        }

        /// <summary>
        /// Событие, которое вызывается при изменении элемента
        /// </summary>
        public event EventHandler SpecEvent
        {
            add { eventHandler += value; }
            remove { eventHandler += value; }
        }

        private void checkBoxNull_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNull.Checked)
            {
                textBox.ReadOnly = true;
                textBox.Clear();
            }
            else textBox.ReadOnly = false;
        }

        private void TextBoxModified_Load_1(object sender, EventArgs e)
        {

        }
    }
}
