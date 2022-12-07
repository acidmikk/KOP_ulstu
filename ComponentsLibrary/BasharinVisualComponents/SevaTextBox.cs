namespace ComponentsLibrary.BasharinVisualComponents
{
    public partial class SevaTextBox : UserControl
    {
        public int? startRange;
        public int? endRange;
        private string error = string.Empty;
        private bool flagStart = false;
        private bool flagEnd = false;
        private event EventHandler TextChange;
        public SevaTextBox()
        {
            InitializeComponent();
            textBox1.TextChanged += (sender, e) => TextChange?.Invoke(sender, e);
        }
        public string Txt
        {
            get
            {
                if (IsCorrect())
                {
                    return textBox1.Text;
                }
                else
                {
                    error = "Ошибка диапазона";
                    return null;
                }

            }
            set
            {
                if (!IsCorrect()) textBox1.Text = value;
            }
        }

        private bool IsCorrect()
        {
            return textBox1.Text.Length >= StartRange && textBox1.Text.Length <= EndRange;
        }

        public int StartRange
        {

            get
            {
                if (startRange == null)
                {
                    if (!flagStart)
                    {
                        MessageBox.Show("StartRange не определен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        flagStart = true;
                    }
                    return 0;
                }
                else
                {
                    return (int)startRange;
                }
            }
            set
            {
                startRange = value;
            }
        }
        public int EndRange
        {
            get
            {
                if (endRange == null)
                {
                    if (!flagEnd)
                    {
                        MessageBox.Show("EndRange не определен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        flagEnd = true;
                    }
                    return 0;
                }
                else
                {
                    return (int)endRange;
                }
            }
            set
            {
                endRange = value;
            }
        }
    }
}
