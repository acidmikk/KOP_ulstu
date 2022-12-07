namespace ViewForm
{
    partial class FormBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancell = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxModified1 = new ComponentsLibrary.MyVisualComponents.ListBoxModified();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddImage = new System.Windows.Forms.Button();
            this.romanovaTextBox1 = new ComponentsLibrary.RomanovaVisualComponents.RomanovaTextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(8, 29);
            this.textBoxTitle.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(127, 23);
            this.textBoxTitle.TabIndex = 12;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(8, 11);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(94, 15);
            this.labelTitle.TabIndex = 13;
            this.labelTitle.Text = "Название книги";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(352, 196);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(78, 27);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancell
            // 
            this.buttonCancell.Location = new System.Drawing.Point(434, 196);
            this.buttonCancell.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancell.Name = "buttonCancell";
            this.buttonCancell.Size = new System.Drawing.Size(78, 27);
            this.buttonCancell.TabIndex = 15;
            this.buttonCancell.Text = "Отмена";
            this.buttonCancell.UseVisualStyleBackColor = true;
            this.buttonCancell.Click += new System.EventHandler(this.buttonCancell_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "ФИО автора";
            // 
            // listBoxModified1
            // 
            this.listBoxModified1.Location = new System.Drawing.Point(8, 71);
            this.listBoxModified1.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxModified1.Name = "listBoxModified1";
            this.listBoxModified1.Size = new System.Drawing.Size(117, 112);
            this.listBoxModified1.TabIndex = 17;
            this.listBoxModified1.ValueList = "";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(140, 29);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(183, 165);
            this.pictureBox.TabIndex = 18;
            this.pictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Обложка";
            // 
            // buttonAddImage
            // 
            this.buttonAddImage.Location = new System.Drawing.Point(140, 200);
            this.buttonAddImage.Name = "buttonAddImage";
            this.buttonAddImage.Size = new System.Drawing.Size(183, 23);
            this.buttonAddImage.TabIndex = 20;
            this.buttonAddImage.Text = "Добавить картинку";
            this.buttonAddImage.UseVisualStyleBackColor = true;
            this.buttonAddImage.Click += new System.EventHandler(this.buttonAddImage_Click);
            // 
            // romanovaTextBox1
            // 
            this.romanovaTextBox1.ChekDate = "";
            this.romanovaTextBox1.Location = new System.Drawing.Point(335, 29);
            this.romanovaTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.romanovaTextBox1.Name = "romanovaTextBox1";
            this.romanovaTextBox1.Size = new System.Drawing.Size(172, 56);
            this.romanovaTextBox1.TabIndex = 21;
            this.romanovaTextBox1.template = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Дата публикации";
            // 
            // FormBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 231);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.romanovaTextBox1);
            this.Controls.Add(this.buttonAddImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.listBoxModified1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancell);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormBook";
            this.Text = "Формирование книги";
            this.Load += new System.EventHandler(this.FormBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancell;
        private Label label1;
        private ComponentsLibrary.MyVisualComponents.ListBoxModified listBoxModified1;
        private PictureBox pictureBox;
        private Label label2;
        private Button buttonAddImage;
        private ComponentsLibrary.RomanovaVisualComponents.RomanovaTextBox romanovaTextBox1;
        private Label label3;
    }
}