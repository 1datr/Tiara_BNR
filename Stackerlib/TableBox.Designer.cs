namespace Stackerlib
{
    partial class TableBox
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabCellinfo = new System.Windows.Forms.TabControl();
            this.tabChoosenCell = new System.Windows.Forms.TabPage();
            this.addDetailGroup = new System.Windows.Forms.GroupBox();
            this.tbDetalFilter = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button_add = new System.Windows.Forms.Button();
            this.tbProdCount = new System.Windows.Forms.TextBox();
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
            this.dgvTelezh = new System.Windows.Forms.DataGridView();
            this.cbTelezhProducts = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelezhkaGroup = new System.Windows.Forms.GroupBox();
            this.tbTelezhkaProducts = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbProdCountTelezhka = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.cbTelezhkaProducts = new System.Windows.Forms.ComboBox();
            this.dgvTelezhka = new System.Windows.Forms.DataGridView();
            this.ColDetalTel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColCountTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChangedTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIdTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStackerIDTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCellIDTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCellinfo.SuspendLayout();
            this.tabChoosenCell.SuspendLayout();
            this.addDetailGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdList)).BeginInit();
            this.tabPoddon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelezh)).BeginInit();
            this.TelezhkaGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelezhka)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCellinfo
            // 
            this.tabCellinfo.Controls.Add(this.tabChoosenCell);
            this.tabCellinfo.Controls.Add(this.tabPoddon);
            this.tabCellinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCellinfo.Location = new System.Drawing.Point(0, 0);
            this.tabCellinfo.Name = "tabCellinfo";
            this.tabCellinfo.SelectedIndex = 0;
            this.tabCellinfo.Size = new System.Drawing.Size(422, 335);
            this.tabCellinfo.TabIndex = 41;
            this.tabCellinfo.SelectedIndexChanged += new System.EventHandler(this.tabCellinfo_SelectedIndexChanged);
            // 
            // tabChoosenCell
            // 
            this.tabChoosenCell.Controls.Add(this.addDetailGroup);
            this.tabChoosenCell.Controls.Add(this.dgvProdList);
            this.tabChoosenCell.Location = new System.Drawing.Point(4, 22);
            this.tabChoosenCell.Name = "tabChoosenCell";
            this.tabChoosenCell.Padding = new System.Windows.Forms.Padding(3);
            this.tabChoosenCell.Size = new System.Drawing.Size(414, 309);
            this.tabChoosenCell.TabIndex = 0;
            this.tabChoosenCell.Text = "Выберите ячейку";
            this.tabChoosenCell.UseVisualStyleBackColor = true;
            // 
            // addDetailGroup
            // 
            this.addDetailGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addDetailGroup.Controls.Add(this.tbDetalFilter);
            this.addDetailGroup.Controls.Add(this.label12);
            this.addDetailGroup.Controls.Add(this.button_add);
            this.addDetailGroup.Controls.Add(this.tbProdCount);
            this.addDetailGroup.Controls.Add(this.cbProducts);
            this.addDetailGroup.Enabled = false;
            this.addDetailGroup.Location = new System.Drawing.Point(7, 6);
            this.addDetailGroup.Name = "addDetailGroup";
            this.addDetailGroup.Size = new System.Drawing.Size(393, 67);
            this.addDetailGroup.TabIndex = 13;
            this.addDetailGroup.TabStop = false;
            this.addDetailGroup.Text = "Добавить деталь";
            // 
            // tbDetalFilter
            // 
            this.tbDetalFilter.Location = new System.Drawing.Point(11, 12);
            this.tbDetalFilter.Name = "tbDetalFilter";
            this.tbDetalFilter.Size = new System.Drawing.Size(148, 20);
            this.tbDetalFilter.TabIndex = 4;
            this.tbDetalFilter.Text = "Фильтр деталей";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(187, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "единиц";
            // 
            // button_add
            // 
            this.button_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_add.Location = new System.Drawing.Point(291, 11);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(96, 46);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "Добавить";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // tbProdCount
            // 
            this.tbProdCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProdCount.Location = new System.Drawing.Point(236, 11);
            this.tbProdCount.Name = "tbProdCount";
            this.tbProdCount.Size = new System.Drawing.Size(49, 20);
            this.tbProdCount.TabIndex = 2;
            // 
            // cbProducts
            // 
            this.cbProducts.DisplayMember = "name";
            this.cbProducts.FormattingEnabled = true;
            this.cbProducts.Location = new System.Drawing.Point(11, 36);
            this.cbProducts.Name = "cbProducts";
            this.cbProducts.Size = new System.Drawing.Size(274, 21);
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
            this.dgvProdList.Location = new System.Drawing.Point(7, 92);
            this.dgvProdList.MultiSelect = false;
            this.dgvProdList.Name = "dgvProdList";
            this.dgvProdList.ReadOnly = true;
            this.dgvProdList.RowHeadersWidth = 21;
            this.dgvProdList.Size = new System.Drawing.Size(393, 187);
            this.dgvProdList.TabIndex = 12;
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
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Push.DefaultCellStyle = dataGridViewCellStyle19;
            this.Push.Frozen = true;
            this.Push.HeaderText = "";
            this.Push.Name = "Push";
            this.Push.ReadOnly = true;
            this.Push.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Push.Text = "Положить";
            this.Push.UseColumnTextForButtonValue = true;
            this.Push.Width = 80;
            // 
            // Take
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Take.DefaultCellStyle = dataGridViewCellStyle20;
            this.Take.Frozen = true;
            this.Take.HeaderText = "";
            this.Take.Name = "Take";
            this.Take.ReadOnly = true;
            this.Take.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Take.Text = "Взять";
            this.Take.UseColumnTextForButtonValue = true;
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
            this.tabPoddon.Controls.Add(this.dgvTelezh);
            this.tabPoddon.Controls.Add(this.TelezhkaGroup);
            this.tabPoddon.Controls.Add(this.dgvTelezhka);
            this.tabPoddon.Location = new System.Drawing.Point(4, 22);
            this.tabPoddon.Name = "tabPoddon";
            this.tabPoddon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPoddon.Size = new System.Drawing.Size(414, 309);
            this.tabPoddon.TabIndex = 1;
            this.tabPoddon.Text = "На тележке";
            this.tabPoddon.UseVisualStyleBackColor = true;
            // 
            // dgvTelezh
            // 
            this.dgvTelezh.AllowUserToAddRows = false;
            this.dgvTelezh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTelezh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelezh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbTelezhProducts,
            this.dataGridViewButtonColumn1,
            this.dataGridViewButtonColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvTelezh.Location = new System.Drawing.Point(7, 83);
            this.dgvTelezh.MultiSelect = false;
            this.dgvTelezh.Name = "dgvTelezh";
            this.dgvTelezh.ReadOnly = true;
            this.dgvTelezh.RowHeadersWidth = 21;
            this.dgvTelezh.Size = new System.Drawing.Size(394, 191);
            this.dgvTelezh.TabIndex = 15;
            // 
            // cbTelezhProducts
            // 
            this.cbTelezhProducts.DataPropertyName = "product_id";
            this.cbTelezhProducts.Frozen = true;
            this.cbTelezhProducts.HeaderText = "Деталь";
            this.cbTelezhProducts.Name = "cbTelezhProducts";
            this.cbTelezhProducts.ReadOnly = true;
            this.cbTelezhProducts.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cbTelezhProducts.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cbTelezhProducts.Width = 200;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewButtonColumn1.Frozen = true;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewButtonColumn1.Text = "Положить";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 80;
            // 
            // dataGridViewButtonColumn2
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewButtonColumn2.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewButtonColumn2.Frozen = true;
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.ReadOnly = true;
            this.dataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewButtonColumn2.Text = "Взять";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "count";
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Количество";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "changed";
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Изменено";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn3.HeaderText = "ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "stacker_id";
            this.dataGridViewTextBoxColumn4.HeaderText = "STACKER_ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "cell_id";
            this.dataGridViewTextBoxColumn5.HeaderText = "CELL_ID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // TelezhkaGroup
            // 
            this.TelezhkaGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TelezhkaGroup.Controls.Add(this.tbTelezhkaProducts);
            this.TelezhkaGroup.Controls.Add(this.label2);
            this.TelezhkaGroup.Controls.Add(this.tbProdCountTelezhka);
            this.TelezhkaGroup.Controls.Add(this.button5);
            this.TelezhkaGroup.Controls.Add(this.cbTelezhkaProducts);
            this.TelezhkaGroup.Enabled = false;
            this.TelezhkaGroup.Location = new System.Drawing.Point(6, 6);
            this.TelezhkaGroup.Name = "TelezhkaGroup";
            this.TelezhkaGroup.Size = new System.Drawing.Size(395, 71);
            this.TelezhkaGroup.TabIndex = 14;
            this.TelezhkaGroup.TabStop = false;
            this.TelezhkaGroup.Text = "Добавить деталь";
            // 
            // tbTelezhkaProducts
            // 
            this.tbTelezhkaProducts.Location = new System.Drawing.Point(11, 18);
            this.tbTelezhkaProducts.Name = "tbTelezhkaProducts";
            this.tbTelezhkaProducts.Size = new System.Drawing.Size(206, 20);
            this.tbTelezhkaProducts.TabIndex = 4;
            this.tbTelezhkaProducts.Text = "Фильтр деталей";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "единиц";
            // 
            // tbProdCountTelezhka
            // 
            this.tbProdCountTelezhka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProdCountTelezhka.Location = new System.Drawing.Point(222, 17);
            this.tbProdCountTelezhka.Name = "tbProdCountTelezhka";
            this.tbProdCountTelezhka.Size = new System.Drawing.Size(49, 20);
            this.tbProdCountTelezhka.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(277, 17);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 46);
            this.button5.TabIndex = 1;
            this.button5.Text = "Добавить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cbTelezhkaProducts
            // 
            this.cbTelezhkaProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTelezhkaProducts.DisplayMember = "name";
            this.cbTelezhkaProducts.FormattingEnabled = true;
            this.cbTelezhkaProducts.Location = new System.Drawing.Point(11, 44);
            this.cbTelezhkaProducts.Name = "cbTelezhkaProducts";
            this.cbTelezhkaProducts.Size = new System.Drawing.Size(208, 21);
            this.cbTelezhkaProducts.TabIndex = 0;
            this.cbTelezhkaProducts.ValueMember = "id";
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
            this.dgvTelezhka.Location = new System.Drawing.Point(17, 77);
            this.dgvTelezhka.Name = "dgvTelezhka";
            this.dgvTelezhka.ReadOnly = true;
            this.dgvTelezhka.Size = new System.Drawing.Size(181, 0);
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
            // TableBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabCellinfo);
            this.Name = "TableBox";
            this.Size = new System.Drawing.Size(422, 335);
            this.tabCellinfo.ResumeLayout(false);
            this.tabChoosenCell.ResumeLayout(false);
            this.addDetailGroup.ResumeLayout(false);
            this.addDetailGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdList)).EndInit();
            this.tabPoddon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelezh)).EndInit();
            this.TelezhkaGroup.ResumeLayout(false);
            this.TelezhkaGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelezhka)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCellinfo;
        private System.Windows.Forms.TabPage tabChoosenCell;
        private System.Windows.Forms.GroupBox addDetailGroup;
        private System.Windows.Forms.TextBox tbDetalFilter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.TextBox tbProdCount;
        private System.Windows.Forms.ComboBox cbProducts;
        private System.Windows.Forms.DataGridView dgvProdList;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColDetal;
        private System.Windows.Forms.DataGridViewButtonColumn Push;
        private System.Windows.Forms.DataGridViewButtonColumn Take;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChanged;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStackerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CellID;
        private System.Windows.Forms.TabPage tabPoddon;
        private System.Windows.Forms.DataGridView dgvTelezh;
        private System.Windows.Forms.DataGridViewComboBoxColumn cbTelezhProducts;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.GroupBox TelezhkaGroup;
        private System.Windows.Forms.TextBox tbTelezhkaProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbProdCountTelezhka;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox cbTelezhkaProducts;
        private System.Windows.Forms.DataGridView dgvTelezhka;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColDetalTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCountTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChangedTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStackerIDTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCellIDTel;
    }
}
