namespace test
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.legend1 = new Stackerlib.Legend();
            this.stacker1 = new Stackerlib.Stacker();
            this.SuspendLayout();
            // 
            // legend1
            // 
            this.legend1.Location = new System.Drawing.Point(636, 12);
            this.legend1.Name = "legend1";
            this.legend1.Size = new System.Drawing.Size(109, 89);
            this.legend1.Stk = null;
            this.legend1.TabIndex = 0;
            // 
            // stacker1
            // 
            this.stacker1.AutoSize = true;
            this.stacker1.cellsize = 20;
            this.stacker1.CellsNextPass = "";
            this.stacker1.Delta = 2;
            this.stacker1.Floors = 5;
            this.stacker1.Group = 1;
            this.stacker1.InputCells = new int[0];
            this.stacker1.Location = new System.Drawing.Point(150, 143);
            this.stacker1.MaximumSize = new System.Drawing.Size(104, 37);
            this.stacker1.MinimumSize = new System.Drawing.Size(104, 37);
            this.stacker1.Name = "stacker1";
            this.stacker1.OccupiedColor = System.Drawing.Color.Empty;
            this.stacker1.PoddonCells = new int[0];
            this.stacker1.Rows = 5;
            this.stacker1.Size = new System.Drawing.Size(104, 37);
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(252)))), ((int)(((byte)(200)))));
            this.stacker1.StyleInput = dataGridViewCellStyle1;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(206)))), ((int)(((byte)(231)))));
            this.stacker1.StylePoddon = dataGridViewCellStyle2;
            this.stacker1.TabIndex = 1;
            this.stacker1.TableCoords = null;
            this.stacker1.TB = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 353);
            this.Controls.Add(this.stacker1);
            this.Controls.Add(this.legend1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Stackerlib.Legend legend1;
        private Stackerlib.Stacker stacker1;
    }
}

