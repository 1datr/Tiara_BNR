namespace Stackerlib
{
    partial class CmdManager
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
            this.dgvCmdlist = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCmdlist)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCmdlist
            // 
            this.dgvCmdlist.AllowUserToAddRows = false;
            this.dgvCmdlist.AllowUserToDeleteRows = false;
            this.dgvCmdlist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCmdlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCmdlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvCmdlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCmdlist.Location = new System.Drawing.Point(0, 0);
            this.dgvCmdlist.MultiSelect = false;
            this.dgvCmdlist.Name = "dgvCmdlist";
            this.dgvCmdlist.ReadOnly = true;
            this.dgvCmdlist.RowHeadersVisible = false;
            this.dgvCmdlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCmdlist.Size = new System.Drawing.Size(234, 289);
            this.dgvCmdlist.TabIndex = 0;
            this.dgvCmdlist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCmdlist_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Команда";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Яч.1";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Яч.2";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.Text = "*";
            this.Column4.UseColumnTextForButtonValue = true;
            this.Column4.Visible = false;
            this.Column4.Width = 30;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Text = "x";
            this.Column5.UseColumnTextForButtonValue = true;
            this.Column5.Width = 30;
            // 
            // CmdManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.dgvCmdlist);
            this.Name = "CmdManager";
            this.Size = new System.Drawing.Size(234, 289);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCmdlist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCmdlist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
    }
}
