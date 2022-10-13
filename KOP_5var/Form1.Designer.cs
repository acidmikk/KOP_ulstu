namespace KOP_5var
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sevaCheckedListBox1 = new WinFormsControlLibraryBasharin.SevaCheckedListBox();
            this.sevaTextBox1 = new WinFormsControlLibraryBasharin.SevaTextBox();
            this.sevaTreeView1 = new WinFormsControlLibraryBasharin.SevaTreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sevaCheckedListBox1
            // 
            this.sevaCheckedListBox1.Location = new System.Drawing.Point(12, 12);
            this.sevaCheckedListBox1.Name = "sevaCheckedListBox1";
            this.sevaCheckedListBox1.SelectedElement = "";
            this.sevaCheckedListBox1.Size = new System.Drawing.Size(178, 159);
            this.sevaCheckedListBox1.TabIndex = 0;
            // 
            // sevaTextBox1
            // 
            this.sevaTextBox1.Location = new System.Drawing.Point(12, 177);
            this.sevaTextBox1.MaxLenght = 0;
            this.sevaTextBox1.MinLenght = 0;
            this.sevaTextBox1.Name = "sevaTextBox1";
            this.sevaTextBox1.SelectText = "";
            this.sevaTextBox1.Size = new System.Drawing.Size(242, 80);
            this.sevaTextBox1.TabIndex = 1;
            // 
            // sevaTreeView1
            // 
            this.sevaTreeView1.Location = new System.Drawing.Point(507, 12);
            this.sevaTreeView1.Name = "sevaTreeView1";
            this.sevaTreeView1.SelectedIndex = -1;
            this.sevaTreeView1.Size = new System.Drawing.Size(281, 207);
            this.sevaTreeView1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(507, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Изьять элемент";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sevaTreeView1);
            this.Controls.Add(this.sevaTextBox1);
            this.Controls.Add(this.sevaCheckedListBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WinFormsControlLibraryBasharin.SevaCheckedListBox sevaCheckedListBox1;
        private WinFormsControlLibraryBasharin.SevaTextBox sevaTextBox1;
        private WinFormsControlLibraryBasharin.SevaTreeView sevaTreeView1;
        private Button button1;
    }
}