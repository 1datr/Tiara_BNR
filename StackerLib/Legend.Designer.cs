namespace Stackerlib
{
    partial class Legend
    {
        /// <summary> 
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.Priem = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.Zagr = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNumber5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shapeContainer3 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.Zanyata = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(160, 195);
            this.flowLayoutPanel1.TabIndex = 45;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.shapeContainer1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(79, 29);
            this.panel1.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = " - Приемные";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.Priem});
            this.shapeContainer1.Size = new System.Drawing.Size(79, 29);
            this.shapeContainer1.TabIndex = 46;
            this.shapeContainer1.TabStop = false;
            // 
            // Priem
            // 
            this.Priem.FillColor = System.Drawing.SystemColors.HighlightText;
            this.Priem.FillGradientColor = System.Drawing.Color.Maroon;
            this.Priem.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.Priem.Location = new System.Drawing.Point(1, 2);
            this.Priem.Name = "Priem";
            this.Priem.Size = new System.Drawing.Size(29, 13);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.shapeContainer2);
            this.panel2.Location = new System.Drawing.Point(3, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(104, 32);
            this.panel2.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = " - Загрузочные";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.Zagr});
            this.shapeContainer2.Size = new System.Drawing.Size(104, 32);
            this.shapeContainer2.TabIndex = 41;
            this.shapeContainer2.TabStop = false;
            // 
            // Zagr
            // 
            this.Zagr.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.Zagr.Location = new System.Drawing.Point(1, 2);
            this.Zagr.Name = "Zagr";
            this.Zagr.Size = new System.Drawing.Size(29, 13);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblNumber5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.shapeContainer3);
            this.panel3.Location = new System.Drawing.Point(3, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(89, 31);
            this.panel3.TabIndex = 44;
            // 
            // lblNumber5
            // 
            this.lblNumber5.AutoSize = true;
            this.lblNumber5.BackColor = System.Drawing.Color.White;
            this.lblNumber5.ForeColor = System.Drawing.Color.Black;
            this.lblNumber5.Location = new System.Drawing.Point(3, 4);
            this.lblNumber5.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumber5.Name = "lblNumber5";
            this.lblNumber5.Size = new System.Drawing.Size(13, 13);
            this.lblNumber5.TabIndex = 45;
            this.lblNumber5.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = " - Занята";
            // 
            // shapeContainer3
            // 
            this.shapeContainer3.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer3.Name = "shapeContainer3";
            this.shapeContainer3.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.Zanyata});
            this.shapeContainer3.Size = new System.Drawing.Size(89, 31);
            this.shapeContainer3.TabIndex = 42;
            this.shapeContainer3.TabStop = false;
            // 
            // Zanyata
            // 
            this.Zanyata.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.Zanyata.Location = new System.Drawing.Point(1, 2);
            this.Zanyata.Name = "Zanyata";
            this.Zanyata.Size = new System.Drawing.Size(75, 23);
            // 
            // Legend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Legend";
            this.Size = new System.Drawing.Size(160, 195);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape Priem;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape Zagr;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape Zanyata;
        private System.Windows.Forms.Label lblNumber5;

    }
}
