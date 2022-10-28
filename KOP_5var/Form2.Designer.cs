namespace KOP_5var
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.buttonPic = new System.Windows.Forms.Button();
            this.buttonTable = new System.Windows.Forms.Button();
            this.buttonDiagram = new System.Windows.Forms.Button();
            this.picToPDF = new WinFormsControlLibraryBasharinLab2.PicToPDF(this.components);
            this.tableToPDF = new WinFormsControlLibraryBasharinLab2.TableToPDF(this.components);
            this.diagramToPDF = new WinFormsControlLibraryBasharinLab2.DiagramToPDF(this.components);
            this.SuspendLayout();
            // 
            // buttonPic
            // 
            this.buttonPic.Location = new System.Drawing.Point(12, 12);
            this.buttonPic.Name = "buttonPic";
            this.buttonPic.Size = new System.Drawing.Size(137, 53);
            this.buttonPic.TabIndex = 0;
            this.buttonPic.Text = "Pic to PDF";
            this.buttonPic.UseVisualStyleBackColor = true;
            this.buttonPic.Click += new System.EventHandler(this.buttonPic_Click);
            // 
            // buttonTable
            // 
            this.buttonTable.Location = new System.Drawing.Point(12, 71);
            this.buttonTable.Name = "buttonTable";
            this.buttonTable.Size = new System.Drawing.Size(137, 53);
            this.buttonTable.TabIndex = 1;
            this.buttonTable.Text = "Table to PDF";
            this.buttonTable.UseVisualStyleBackColor = true;
            this.buttonTable.Click += new System.EventHandler(this.buttonTable_Click);
            // 
            // buttonDiagram
            // 
            this.buttonDiagram.Location = new System.Drawing.Point(12, 130);
            this.buttonDiagram.Name = "buttonDiagram";
            this.buttonDiagram.Size = new System.Drawing.Size(137, 53);
            this.buttonDiagram.TabIndex = 2;
            this.buttonDiagram.Text = "Diagram to PDF";
            this.buttonDiagram.UseVisualStyleBackColor = true;
            this.buttonDiagram.Click += new System.EventHandler(this.buttonDiagram_Click);
            // 
            // tableToPDF
            // 
            this.tableToPDF.Order = null;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(162, 192);
            this.Controls.Add(this.buttonDiagram);
            this.Controls.Add(this.buttonTable);
            this.Controls.Add(this.buttonPic);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonPic;
        private Button buttonTable;
        private Button buttonDiagram;
        private WinFormsControlLibraryBasharinLab2.PicToPDF picToPDF;
        private WinFormsControlLibraryBasharinLab2.TableToPDF tableToPDF;
        private WinFormsControlLibraryBasharinLab2.DiagramToPDF diagramToPDF;
    }
}