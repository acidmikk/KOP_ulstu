using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsControlLibraryBasharin
{
    public partial class SevaTextBox : UserControl
    {
        public int MaxLenght { get; set; }
        public int MinLenght { get; set; }
        private string text { get; set; }
        private string Success = "Верно!";
        private string Wrong = "Не верно!";
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
                return textBox1.Text;
            }
            set
            {
                if (value.Length > MinLenght && value.Length < MaxLenght)
                    textBox1.Text = value;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = !checkBox1.Checked;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            text = textBox1.Text;
            if (text.Length > MinLenght && text.Length < MaxLenght)
            {
                label1.Text = Success;
            } else
            {
                label1.Text = Wrong;
            }
        }
    }
}
