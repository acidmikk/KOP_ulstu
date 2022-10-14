using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsControlLibraryBasharin
{
    public partial class SevaTextBox : UserControl
    {
        public int? MaxLenght { get; set; }
        public int? MinLenght { get; set; }
        private string text { get; set; }
        private string Success = "Верно!";
        private string Wrong = "Не верно!";
        private string error = string.Empty;
        public SevaTextBox()
        {
            InitializeComponent();
            textBox1.TextChanged += (sender, e) => _event?.Invoke(sender, e);
        }
        private event EventHandler _event;
        public event EventHandler EnterTextChanged
        {
            add
            {
                _event += value;
            }
            remove
            {
                _event -= value;
            }
        }
        public string SelectText
        {
            get
            {
                if ((MaxLenght != null && MinLenght != null) && textBox1.Text.Length > MinLenght && textBox1.Text.Length < MaxLenght)
                        return textBox1.Text;
                else
                {
                    MessageBox.Show("Не соответствует диапозону", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            set
            {
                if ((MaxLenght != null && MinLenght != null) && value.Length > MinLenght && value.Length < MaxLenght)
                    textBox1.Text = value;
            }
        }
    }
}
