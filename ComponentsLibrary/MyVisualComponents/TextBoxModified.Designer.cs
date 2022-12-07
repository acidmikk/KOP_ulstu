namespace ComponentsLibrary.MyVisualComponents
{
    partial class TextBoxModified
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox = new System.Windows.Forms.TextBox();
            this.checkBoxNull = new System.Windows.Forms.CheckBox();
            this.labelData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(10, 37);
            this.textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(79, 23);
            this.textBox.TabIndex = 0;
            this.textBox.TextChanged += new System.EventHandler(this.TextBox_SelectedChanged);
            // 
            // checkBoxNull
            // 
            this.checkBoxNull.AutoSize = true;
            this.checkBoxNull.Location = new System.Drawing.Point(10, 68);
            this.checkBoxNull.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxNull.Name = "checkBoxNull";
            this.checkBoxNull.Size = new System.Drawing.Size(100, 19);
            this.checkBoxNull.TabIndex = 1;
            this.checkBoxNull.Text = "null значение";
            this.checkBoxNull.UseVisualStyleBackColor = true;
            this.checkBoxNull.CheckedChanged += new System.EventHandler(this.checkBoxNull_CheckedChanged);
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(7, 8);
            this.labelData.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(94, 15);
            this.labelData.TabIndex = 2;
            this.labelData.Text = "Введите данные";
            // 
            // TextBoxModified
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.checkBoxNull);
            this.Controls.Add(this.textBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TextBoxModified";
            this.Size = new System.Drawing.Size(117, 112);
            this.Load += new System.EventHandler(this.TextBoxModified_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.CheckBox checkBoxNull;
        private System.Windows.Forms.Label labelData;
    }
}
