namespace StackerLib
{
    partial class StackerBox
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsl_error = new System.Windows.Forms.Label();
            this.gb_commands = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmdManager1 = new Stackerlib.CmdManager();
            this.label17 = new System.Windows.Forms.Label();
            this.lblCPUStatus = new System.Windows.Forms.Label();
            this.Trans_Src = new System.Windows.Forms.TextBox();
            this.Trans_Dst = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.PutTo_Dest = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Src_TakeFrom = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabCellinfo = new System.Windows.Forms.TabControl();
            this.tabChoosenCell = new System.Windows.Forms.TabPage();
            this.addDetailGroup = new System.Windows.Forms.GroupBox();
            this.tbDetalFilter = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbProdCount = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.cbProducts = new System.Windows.Forms.ComboBox();
            this.dgvProdList = new System.Windows.Forms.DataGridView();
            this.ColDetal = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Push = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Take = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStackerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CellID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPoddon = new System.Windows.Forms.TabPage();
            this.dgvTelezhka = new System.Windows.Forms.DataGridView();
            this.ColDetalTel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColCountTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChangedTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIdTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStackerIDTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCellIDTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbDriveErrText = new System.Windows.Forms.TextBox();
            this.lblDrivestatus = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvVarlist = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.stacker1 = new Stackerlib.Stacker();
            this.btnTE = new System.Windows.Forms.Button();
            this.lblCapt5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnPower = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.labelStat = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gb_commands.SuspendLayout();
            this.tabCellinfo.SuspendLayout();
            this.tabChoosenCell.SuspendLayout();
            this.addDetailGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdList)).BeginInit();
            this.tabPoddon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelezhka)).BeginInit();
            this.tabControl3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarlist)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tsl_error);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 591);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 23);
            this.panel1.TabIndex = 41;
            // 
            // tsl_error
            // 
            this.tsl_error.AutoSize = true;
            this.tsl_error.Location = new System.Drawing.Point(3, 1);
            this.tsl_error.Name = "tsl_error";
            this.tsl_error.Size = new System.Drawing.Size(35, 13);
            this.tsl_error.TabIndex = 0;
            this.tsl_error.Text = "label2";
            // 
            // gb_commands
            // 
            this.gb_commands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_commands.Controls.Add(this.label18);
            this.gb_commands.Controls.Add(this.label16);
            this.gb_commands.Controls.Add(this.cmdManager1);
            this.gb_commands.Controls.Add(this.label17);
            this.gb_commands.Controls.Add(this.lblCPUStatus);
            this.gb_commands.Controls.Add(this.Trans_Src);
            this.gb_commands.Controls.Add(this.Trans_Dst);
            this.gb_commands.Controls.Add(this.button4);
            this.gb_commands.Controls.Add(this.button3);
            this.gb_commands.Controls.Add(this.PutTo_Dest);
            this.gb_commands.Controls.Add(this.button1);
            this.gb_commands.Controls.Add(this.Src_TakeFrom);
            this.gb_commands.Controls.Add(this.button2);
            this.gb_commands.Enabled = false;
            this.gb_commands.Location = new System.Drawing.Point(577, 319);
            this.gb_commands.Name = "gb_commands";
            this.gb_commands.Size = new System.Drawing.Size(407, 262);
            this.gb_commands.TabIndex = 40;
            this.gb_commands.TabStop = false;
            this.gb_commands.Text = "Команды";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(166, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "Очередь команд:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(8, 179);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "ячейки снизу вверх";
            // 
            // cmdManager1
            // 
            this.cmdManager1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdManager1.AutoSize = true;
            this.cmdManager1.Location = new System.Drawing.Point(153, 39);
            this.cmdManager1.Name = "cmdManager1";
            this.cmdManager1.Size = new System.Drawing.Size(235, 214);
            this.cmdManager1.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(8, 162);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(145, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Рекомендуется заполнять ";
            // 
            // lblCPUStatus
            // 
            this.lblCPUStatus.AutoSize = true;
            this.lblCPUStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCPUStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCPUStatus.Location = new System.Drawing.Point(6, 236);
            this.lblCPUStatus.Name = "lblCPUStatus";
            this.lblCPUStatus.Size = new System.Drawing.Size(51, 20);
            this.lblCPUStatus.TabIndex = 12;
            this.lblCPUStatus.Text = "label2";
            // 
            // Trans_Src
            // 
            this.Trans_Src.Location = new System.Drawing.Point(97, 103);
            this.Trans_Src.Name = "Trans_Src";
            this.Trans_Src.Size = new System.Drawing.Size(38, 20);
            this.Trans_Src.TabIndex = 10;
            // 
            // Trans_Dst
            // 
            this.Trans_Dst.Location = new System.Drawing.Point(97, 129);
            this.Trans_Dst.Name = "Trans_Dst";
            this.Trans_Dst.Size = new System.Drawing.Size(38, 20);
            this.Trans_Dst.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 103);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 46);
            this.button4.TabIndex = 12;
            this.button4.Text = "Переложить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Положить в";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PutTo_Dest
            // 
            this.PutTo_Dest.Location = new System.Drawing.Point(97, 77);
            this.PutTo_Dest.Name = "PutTo_Dest";
            this.PutTo_Dest.Size = new System.Drawing.Size(38, 20);
            this.PutTo_Dest.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Парковка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Src_TakeFrom
            // 
            this.Src_TakeFrom.Location = new System.Drawing.Point(97, 48);
            this.Src_TakeFrom.Name = "Src_TakeFrom";
            this.Src_TakeFrom.Size = new System.Drawing.Size(38, 20);
            this.Src_TakeFrom.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Взять из";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabCellinfo
            // 
            this.tabCellinfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCellinfo.Controls.Add(this.tabChoosenCell);
            this.tabCellinfo.Controls.Add(this.tabPoddon);
            this.tabCellinfo.Location = new System.Drawing.Point(577, 10);
            this.tabCellinfo.Name = "tabCellinfo";
            this.tabCellinfo.SelectedIndex = 0;
            this.tabCellinfo.Size = new System.Drawing.Size(506, 297);
            this.tabCellinfo.TabIndex = 39;
            this.tabCellinfo.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabCellinfo_Selecting);
            this.tabCellinfo.TabIndexChanged += new System.EventHandler(this.tabCellinfo_TabIndexChanged);
            // 
            // tabChoosenCell
            // 
            this.tabChoosenCell.Controls.Add(this.addDetailGroup);
            this.tabChoosenCell.Controls.Add(this.dgvProdList);
            this.tabChoosenCell.Location = new System.Drawing.Point(4, 22);
            this.tabChoosenCell.Name = "tabChoosenCell";
            this.tabChoosenCell.Padding = new System.Windows.Forms.Padding(3);
            this.tabChoosenCell.Size = new System.Drawing.Size(498, 271);
            this.tabChoosenCell.TabIndex = 0;
            this.tabChoosenCell.Text = "Выберите ячейку";
            this.tabChoosenCell.UseVisualStyleBackColor = true;
            // 
            // addDetailGroup
            // 
            this.addDetailGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addDetailGroup.Controls.Add(this.tbDetalFilter);
            this.addDetailGroup.Controls.Add(this.label12);
            this.addDetailGroup.Controls.Add(this.tbProdCount);
            this.addDetailGroup.Controls.Add(this.button9);
            this.addDetailGroup.Controls.Add(this.cbProducts);
            this.addDetailGroup.Enabled = false;
            this.addDetailGroup.Location = new System.Drawing.Point(16, 15);
            this.addDetailGroup.Name = "addDetailGroup";
            this.addDetailGroup.Size = new System.Drawing.Size(462, 64);
            this.addDetailGroup.TabIndex = 13;
            this.addDetailGroup.TabStop = false;
            this.addDetailGroup.Text = "Добавить деталь";
            // 
            // tbDetalFilter
            // 
            this.tbDetalFilter.Location = new System.Drawing.Point(11, 12);
            this.tbDetalFilter.Name = "tbDetalFilter";
            this.tbDetalFilter.Size = new System.Drawing.Size(206, 20);
            this.tbDetalFilter.TabIndex = 4;
            this.tbDetalFilter.Text = "Фильтр деталей";
            this.tbDetalFilter.TextChanged += new System.EventHandler(this.tbDetalFilter_TextChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(295, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "единиц";
            // 
            // tbProdCount
            // 
            this.tbProdCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProdCount.Location = new System.Drawing.Point(292, 12);
            this.tbProdCount.Name = "tbProdCount";
            this.tbProdCount.Size = new System.Drawing.Size(49, 20);
            this.tbProdCount.TabIndex = 2;
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.Location = new System.Drawing.Point(360, 12);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(96, 46);
            this.button9.TabIndex = 1;
            this.button9.Text = "Добавить";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // cbProducts
            // 
            this.cbProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProducts.DisplayMember = "name";
            this.cbProducts.FormattingEnabled = true;
            this.cbProducts.Location = new System.Drawing.Point(11, 36);
            this.cbProducts.Name = "cbProducts";
            this.cbProducts.Size = new System.Drawing.Size(275, 21);
            this.cbProducts.TabIndex = 0;
            this.cbProducts.ValueMember = "id";
            // 
            // dgvProdList
            // 
            this.dgvProdList.AllowUserToAddRows = false;
            this.dgvProdList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDetal,
            this.Push,
            this.Take,
            this.ColCount,
            this.ColChanged,
            this.ColID,
            this.ColStackerID,
            this.CellID});
            this.dgvProdList.Location = new System.Drawing.Point(16, 85);
            this.dgvProdList.MultiSelect = false;
            this.dgvProdList.Name = "dgvProdList";
            this.dgvProdList.ReadOnly = true;
            this.dgvProdList.RowHeadersWidth = 21;
            this.dgvProdList.Size = new System.Drawing.Size(462, 165);
            this.dgvProdList.TabIndex = 12;
            this.dgvProdList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdList_CellContentClick);
            // 
            // ColDetal
            // 
            this.ColDetal.DataPropertyName = "product_id";
            this.ColDetal.Frozen = true;
            this.ColDetal.HeaderText = "Деталь";
            this.ColDetal.Name = "ColDetal";
            this.ColDetal.ReadOnly = true;
            this.ColDetal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColDetal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColDetal.Width = 200;
            // 
            // Push
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Push.DefaultCellStyle = dataGridViewCellStyle1;
            this.Push.Frozen = true;
            this.Push.HeaderText = "";
            this.Push.Name = "Push";
            this.Push.ReadOnly = true;
            this.Push.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Push.Text = "Положить";
            this.Push.Width = 80;
            // 
            // Take
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Take.DefaultCellStyle = dataGridViewCellStyle2;
            this.Take.Frozen = true;
            this.Take.HeaderText = "";
            this.Take.Name = "Take";
            this.Take.ReadOnly = true;
            this.Take.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Take.Text = "Взять";
            this.Take.Width = 80;
            // 
            // ColCount
            // 
            this.ColCount.DataPropertyName = "count";
            this.ColCount.Frozen = true;
            this.ColCount.HeaderText = "Количество";
            this.ColCount.Name = "ColCount";
            this.ColCount.ReadOnly = true;
            this.ColCount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColCount.Width = 90;
            // 
            // ColChanged
            // 
            this.ColChanged.DataPropertyName = "changed";
            this.ColChanged.Frozen = true;
            this.ColChanged.HeaderText = "Изменено";
            this.ColChanged.Name = "ColChanged";
            this.ColChanged.ReadOnly = true;
            this.ColChanged.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "id";
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColStackerID
            // 
            this.ColStackerID.DataPropertyName = "stacker_id";
            this.ColStackerID.HeaderText = "STACKER_ID";
            this.ColStackerID.Name = "ColStackerID";
            this.ColStackerID.ReadOnly = true;
            this.ColStackerID.Visible = false;
            // 
            // CellID
            // 
            this.CellID.DataPropertyName = "cell_id";
            this.CellID.HeaderText = "CELL_ID";
            this.CellID.Name = "CellID";
            this.CellID.ReadOnly = true;
            this.CellID.Visible = false;
            // 
            // tabPoddon
            // 
            this.tabPoddon.Controls.Add(this.dgvTelezhka);
            this.tabPoddon.Location = new System.Drawing.Point(4, 22);
            this.tabPoddon.Name = "tabPoddon";
            this.tabPoddon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPoddon.Size = new System.Drawing.Size(498, 271);
            this.tabPoddon.TabIndex = 1;
            this.tabPoddon.Text = "На тележке";
            this.tabPoddon.UseVisualStyleBackColor = true;
            // 
            // dgvTelezhka
            // 
            this.dgvTelezhka.AllowUserToAddRows = false;
            this.dgvTelezhka.AllowUserToDeleteRows = false;
            this.dgvTelezhka.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTelezhka.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelezhka.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDetalTel,
            this.ColCountTel,
            this.ColChangedTel,
            this.ColIdTel,
            this.ColStackerIDTel,
            this.ColCellIDTel});
            this.dgvTelezhka.Location = new System.Drawing.Point(17, 15);
            this.dgvTelezhka.Name = "dgvTelezhka";
            this.dgvTelezhka.ReadOnly = true;
            this.dgvTelezhka.Size = new System.Drawing.Size(462, 215);
            this.dgvTelezhka.TabIndex = 0;
            // 
            // ColDetalTel
            // 
            this.ColDetalTel.DataPropertyName = "product_id";
            this.ColDetalTel.HeaderText = "Деталь";
            this.ColDetalTel.Name = "ColDetalTel";
            this.ColDetalTel.ReadOnly = true;
            this.ColDetalTel.Width = 200;
            // 
            // ColCountTel
            // 
            this.ColCountTel.DataPropertyName = "count";
            this.ColCountTel.HeaderText = "Количество";
            this.ColCountTel.Name = "ColCountTel";
            this.ColCountTel.ReadOnly = true;
            this.ColCountTel.Width = 80;
            // 
            // ColChangedTel
            // 
            this.ColChangedTel.DataPropertyName = "changed";
            this.ColChangedTel.HeaderText = "Изменено";
            this.ColChangedTel.Name = "ColChangedTel";
            this.ColChangedTel.ReadOnly = true;
            this.ColChangedTel.Width = 90;
            // 
            // ColIdTel
            // 
            this.ColIdTel.DataPropertyName = "id";
            this.ColIdTel.HeaderText = "ID";
            this.ColIdTel.Name = "ColIdTel";
            this.ColIdTel.ReadOnly = true;
            this.ColIdTel.Visible = false;
            // 
            // ColStackerIDTel
            // 
            this.ColStackerIDTel.DataPropertyName = "stacker_id";
            this.ColStackerIDTel.HeaderText = "STACKER_ID";
            this.ColStackerIDTel.Name = "ColStackerIDTel";
            this.ColStackerIDTel.ReadOnly = true;
            this.ColStackerIDTel.Visible = false;
            // 
            // ColCellIDTel
            // 
            this.ColCellIDTel.DataPropertyName = "cell_id";
            this.ColCellIDTel.HeaderText = "CELL_ID";
            this.ColCellIDTel.Name = "ColCellIDTel";
            this.ColCellIDTel.ReadOnly = true;
            this.ColCellIDTel.Visible = false;
            // 
            // tabControl3
            // 
            this.tabControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl3.Controls.Add(this.tabPage3);
            this.tabControl3.Controls.Add(this.tabPage5);
            this.tabControl3.Location = new System.Drawing.Point(2, 367);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(566, 218);
            this.tabControl3.TabIndex = 38;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbDriveErrText);
            this.tabPage3.Controls.Add(this.lblDrivestatus);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(558, 192);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Ошибки";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbDriveErrText
            // 
            this.tbDriveErrText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDriveErrText.Location = new System.Drawing.Point(9, 109);
            this.tbDriveErrText.Multiline = true;
            this.tbDriveErrText.Name = "tbDriveErrText";
            this.tbDriveErrText.ReadOnly = true;
            this.tbDriveErrText.Size = new System.Drawing.Size(533, 74);
            this.tbDriveErrText.TabIndex = 16;
            // 
            // lblDrivestatus
            // 
            this.lblDrivestatus.AutoSize = true;
            this.lblDrivestatus.Location = new System.Drawing.Point(6, 92);
            this.lblDrivestatus.Name = "lblDrivestatus";
            this.lblDrivestatus.Size = new System.Drawing.Size(70, 13);
            this.lblDrivestatus.TabIndex = 15;
            this.lblDrivestatus.Text = "lblDrivestatus";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(104, 6);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(155, 23);
            this.button8.TabIndex = 14;
            this.button8.Text = "Квитировать приводы";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(92, 23);
            this.button6.TabIndex = 13;
            this.button6.Text = "Квитировать";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvVarlist);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(558, 192);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Переменные";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvVarlist
            // 
            this.dgvVarlist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvVarlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVarlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9,
            this.changed});
            this.dgvVarlist.Location = new System.Drawing.Point(24, 24);
            this.dgvVarlist.Name = "dgvVarlist";
            this.dgvVarlist.Size = new System.Drawing.Size(567, 152);
            this.dgvVarlist.TabIndex = 0;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Переменная";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Значение";
            this.Column9.Name = "Column9";
            // 
            // changed
            // 
            this.changed.HeaderText = "Время последнего изменения";
            this.changed.Name = "changed";
            this.changed.Width = 150;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.stacker1);
            this.groupBox3.Controls.Add(this.btnTE);
            this.groupBox3.Controls.Add(this.lblCapt5);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lblMode);
            this.groupBox3.Controls.Add(this.btnPower);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.lblPosition);
            this.groupBox3.Controls.Add(this.shapeContainer1);
            this.groupBox3.Location = new System.Drawing.Point(3, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(568, 360);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Штабелер";
            // 
            // stacker1
            // 
            this.stacker1.cellsize = 25;
            this.stacker1.CellsNextPass = "1:5,127:6";
            this.stacker1.Floors = 6;
            this.stacker1.Group = 0;
            this.stacker1.InputCells = new int[0];
            this.stacker1.Location = new System.Drawing.Point(6, 15);
            this.stacker1.Name = "stacker1";
            this.stacker1.PoddonCells = new int[0];
            this.stacker1.Rows = 22;
            this.stacker1.Size = new System.Drawing.Size(550, 272);
            this.stacker1.TabIndex = 21;
            this.stacker1.TableCoords = null;
            this.stacker1.OnCellSelect += new Stackerlib.OnCellSelectDelegate(this.stacker1_OnCellSelect);
            this.stacker1.OnGetCellCount += new Stackerlib.OnGetCellCountDelegate(this.stacker1_OnGetCellCount);
            this.stacker1.OnClickStacker += new Stackerlib.OnClickStacker(this.stacker1_OnClickStacker);
            // 
            // btnTE
            // 
            this.btnTE.Location = new System.Drawing.Point(68, 291);
            this.btnTE.Name = "btnTE";
            this.btnTE.Size = new System.Drawing.Size(160, 23);
            this.btnTE.TabIndex = 19;
            this.btnTE.Text = "Тотальное редактирование";
            this.btnTE.UseVisualStyleBackColor = true;
            this.btnTE.Click += new System.EventHandler(this.btnTE_Click);
            // 
            // lblCapt5
            // 
            this.lblCapt5.AutoSize = true;
            this.lblCapt5.ForeColor = System.Drawing.Color.Red;
            this.lblCapt5.Location = new System.Drawing.Point(287, 331);
            this.lblCapt5.Name = "lblCapt5";
            this.lblCapt5.Size = new System.Drawing.Size(13, 13);
            this.lblCapt5.TabIndex = 32;
            this.lblCapt5.Text = "5";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(306, 333);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = " - Занята";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(160, 331);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = " - Загрузочные";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(34, 327);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = " - Приемные";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(306, 296);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(44, 13);
            this.lblMode.TabIndex = 26;
            this.lblMode.Text = "lblMode";
            // 
            // btnPower
            // 
            this.btnPower.BackColor = System.Drawing.Color.Maroon;
            this.btnPower.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPower.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPower.Location = new System.Drawing.Point(462, 291);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(94, 23);
            this.btnPower.TabIndex = 23;
            this.btnPower.Text = "POWER";
            this.btnPower.UseVisualStyleBackColor = false;
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "РЕЖИМ:";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(401, 326);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(155, 23);
            this.button7.TabIndex = 24;
            this.button7.Text = "Специальное управление";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(9, 293);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(35, 13);
            this.lblPosition.TabIndex = 22;
            this.lblPosition.Text = "label1";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 16);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape3,
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(562, 341);
            this.shapeContainer1.TabIndex = 27;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape3
            // 
            this.rectangleShape3.FillColor = System.Drawing.Color.Red;
            this.rectangleShape3.Location = new System.Drawing.Point(278, 310);
            this.rectangleShape3.Name = "rectangleShape3";
            this.rectangleShape3.Size = new System.Drawing.Size(24, 21);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape2.Location = new System.Drawing.Point(136, 311);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(19, 18);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.DimGray;
            this.rectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape1.Location = new System.Drawing.Point(8, 311);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(19, 16);
            // 
            // labelStat
            // 
            this.labelStat.AutoSize = true;
            this.labelStat.Location = new System.Drawing.Point(1037, 329);
            this.labelStat.Name = "labelStat";
            this.labelStat.Size = new System.Drawing.Size(35, 13);
            this.labelStat.TabIndex = 42;
            this.labelStat.Text = "label2";
            // 
            // StackerBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelStat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gb_commands);
            this.Controls.Add(this.tabCellinfo);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.groupBox3);
            this.Name = "StackerBox";
            this.Size = new System.Drawing.Size(1101, 614);
            this.Load += new System.EventHandler(this.StackerBox_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.StackerBox_Layout);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gb_commands.ResumeLayout(false);
            this.gb_commands.PerformLayout();
            this.tabCellinfo.ResumeLayout(false);
            this.tabChoosenCell.ResumeLayout(false);
            this.addDetailGroup.ResumeLayout(false);
            this.addDetailGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdList)).EndInit();
            this.tabPoddon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelezhka)).EndInit();
            this.tabControl3.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarlist)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label tsl_error;
        private System.Windows.Forms.GroupBox gb_commands;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private Stackerlib.CmdManager cmdManager1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblCPUStatus;
        private System.Windows.Forms.TextBox Trans_Src;
        private System.Windows.Forms.TextBox Trans_Dst;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox PutTo_Dest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Src_TakeFrom;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabCellinfo;
        private System.Windows.Forms.TabPage tabChoosenCell;
        private System.Windows.Forms.GroupBox addDetailGroup;
        private System.Windows.Forms.TextBox tbDetalFilter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbProdCount;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox cbProducts;
        private System.Windows.Forms.DataGridView dgvProdList;       
        private System.Windows.Forms.TabPage tabPoddon;
        private System.Windows.Forms.DataGridView dgvTelezhka;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbDriveErrText;
        private System.Windows.Forms.Label lblDrivestatus;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgvVarlist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn changed;
        private System.Windows.Forms.GroupBox groupBox3;
        private Stackerlib.Stacker stacker1;
        private System.Windows.Forms.Button btnTE;
        private System.Windows.Forms.Label lblCapt5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnPower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label lblPosition;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColDetalTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCountTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChangedTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStackerIDTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCellIDTel;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColDetal;
        private System.Windows.Forms.DataGridViewButtonColumn Push;
        private System.Windows.Forms.DataGridViewButtonColumn Take;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChanged;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStackerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CellID;
        private System.Windows.Forms.Label labelStat;
 
    }
}
