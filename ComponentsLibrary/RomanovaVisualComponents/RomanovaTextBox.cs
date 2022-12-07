using System.Text.RegularExpressions;

namespace ComponentsLibrary.RomanovaVisualComponents
{
    public partial class RomanovaTextBox : UserControl
    {

        public event EventHandler MyTextChanged;
        private string _template = string.Empty;
        public string _tip = string.Empty;
        public RomanovaTextBox()
        {
            InitializeComponent();
            textBox.TextChanged += (sender, e) => MyTextChanged?.Invoke(sender, e);
        }
        public string template
        {
            get { return _template; }
            set { _template = value; }
        }
        public string text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
        private bool IsRegex(string number)
        {
            return Regex.IsMatch(number, template);
        }
        public string ChekDate {
            get
            {
                if (IsRegex(textBox.Text)) return textBox.Text;
                else { throw new Exception("Ошибочка"); }

            }
            set
            {
                if (IsRegex(textBox.Text))
                    textBox.Text = value;
            }
        }

        public event EventHandler textBoxTextChanged
        {
            add
            {
                MyTextChanged += value;
            }
            remove
            {
                MyTextChanged -= value;
            }
        }


        public void Tip(string str) {
            toolTip.SetToolTip(textBox, str);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            Random random = new Random();
            textBox.BackColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
        }
    }
}
