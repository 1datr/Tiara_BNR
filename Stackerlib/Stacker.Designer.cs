namespace Stackerlib
{
    partial class Stacker
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
            this.components = new System.ComponentModel.Container();
            this.dgvRackLeft = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.взятьИзToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.положитьВToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvRackRight = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlStacker = new System.Windows.Forms.Panel();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.pnl_zahvat = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.pnl_kran = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRackLeft)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRackRight)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlStacker.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRackLeft
            // 
            this.dgvRackLeft.AllowUserToAddRows = false;
            this.dgvRackLeft.AllowUserToDeleteRows = false;
            this.dgvRackLeft.AllowUserToResizeColumns = false;
            this.dgvRackLeft.AllowUserToResizeRows = false;
            this.dgvRackLeft.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRackLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRackLeft.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvRackLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRackLeft.ColumnHeadersVisible = false;
            this.dgvRackLeft.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvRackLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvRackLeft.GridColor = System.Drawing.SystemColors.Control;
            this.dgvRackLeft.Location = new System.Drawing.Point(0, 0);
            this.dgvRackLeft.MultiSelect = false;
            this.dgvRackLeft.Name = "dgvRackLeft";
            this.dgvRackLeft.ReadOnly = true;
            this.dgvRackLeft.RowHeadersVisible = false;
            this.dgvRackLeft.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvRackLeft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRackLeft.Size = new System.Drawing.Size(516, 133);
            this.dgvRackLeft.TabIndex = 0;
            this.dgvRackLeft.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRackLeft_CellMouseClick);
            this.dgvRackLeft.SelectionChanged += new System.EventHandler(this.dgvRackLeft_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.взятьИзToolStripMenuItem,
            this.положитьВToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // взятьИзToolStripMenuItem
            // 
            this.взятьИзToolStripMenuItem.Name = "взятьИзToolStripMenuItem";
            this.взятьИзToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.взятьИзToolStripMenuItem.Text = "Взять из";
            this.взятьИзToolStripMenuItem.Click += new System.EventHandler(this.взятьИзToolStripMenuItem_Click);
            // 
            // положитьВToolStripMenuItem
            // 
            this.положитьВToolStripMenuItem.Name = "положитьВToolStripMenuItem";
            this.положитьВToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.положитьВToolStripMenuItem.Text = "Положить в";
            this.положитьВToolStripMenuItem.Click += new System.EventHandler(this.положитьВToolStripMenuItem_Click);
            // 
            // dgvRackRight
            // 
            this.dgvRackRight.AllowUserToAddRows = false;
            this.dgvRackRight.AllowUserToDeleteRows = false;
            this.dgvRackRight.AllowUserToResizeColumns = false;
            this.dgvRackRight.AllowUserToResizeRows = false;
            this.dgvRackRight.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRackRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRackRight.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvRackRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRackRight.ColumnHeadersVisible = false;
            this.dgvRackRight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvRackRight.Location = new System.Drawing.Point(0, 173);
            this.dgvRackRight.MultiSelect = false;
            this.dgvRackRight.Name = "dgvRackRight";
            this.dgvRackRight.ReadOnly = true;
            this.dgvRackRight.RowHeadersVisible = false;
            this.dgvRackRight.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvRackRight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRackRight.Size = new System.Drawing.Size(516, 133);
            this.dgvRackRight.TabIndex = 1;
            this.dgvRackRight.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRackRight_CellMouseClick);
            this.dgvRackRight.SelectionChanged += new System.EventHandler(this.dgvRackRight_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.pnlStacker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 133);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 40);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pnlStacker
            // 
            this.pnlStacker.BackColor = System.Drawing.Color.DarkGray;
            this.pnlStacker.Controls.Add(this.pnl_kran);
            this.pnlStacker.Controls.Add(this.shapeContainer1);
            this.pnlStacker.Location = new System.Drawing.Point(3, 3);
            this.pnlStacker.Name = "pnlStacker";
            this.pnlStacker.Size = new System.Drawing.Size(19, 19);
            this.pnlStacker.TabIndex = 4;
            this.pnlStacker.Click += new System.EventHandler(this.pnlStacker_Click);
            this.pnlStacker.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStacker_Paint);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.pnl_zahvat});
            this.shapeContainer1.Size = new System.Drawing.Size(19, 19);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // pnl_zahvat
            // 
            this.pnl_zahvat.BackColor = System.Drawing.Color.DimGray;
            this.pnl_zahvat.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.pnl_zahvat.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_zahvat.Location = new System.Drawing.Point(2, 8);
            this.pnl_zahvat.Name = "pnl_zahvat";
            this.pnl_zahvat.Size = new System.Drawing.Size(82, 3);
            this.pnl_zahvat.Click += new System.EventHandler(this.pnl_zahvat_Click);
            // 
            // pnl_kran
            // 
            this.pnl_kran.BackColor = System.Drawing.Color.DimGray;
            this.pnl_kran.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_kran.Location = new System.Drawing.Point(9, 0);
            this.pnl_kran.Name = "pnl_kran";
            this.pnl_kran.Size = new System.Drawing.Size(10, 19);
            this.pnl_kran.TabIndex = 1;
            this.pnl_kran.Click += new System.EventHandler(this.pnl_kran_Click);
            // 
            // Stacker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvRackRight);
            this.Controls.Add(this.dgvRackLeft);
            this.Name = "Stacker";
            this.Size = new System.Drawing.Size(516, 306);
            this.Load += new System.EventHandler(this.Stacker_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Stacker_Layout);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRackLeft)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRackRight)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlStacker.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRackLeft;
        private System.Windows.Forms.DataGridView dgvRackRight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem взятьИзToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem положитьВToolStripMenuItem;
        private System.Windows.Forms.Panel pnlStacker;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape pnl_zahvat;
        private System.Windows.Forms.Panel pnl_kran;
    }
}
