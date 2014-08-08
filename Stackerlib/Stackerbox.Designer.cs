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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer_refresh = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsl_error = new System.Windows.Forms.ToolStripStatusLabel();
            this.bwStackerRefresh = new System.ComponentModel.BackgroundWorker();
            this.splitConBase = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.labelStat = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.btnPower = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.legend1 = new Stackerlib.Legend();
            this.stacker1 = new Stackerlib.Stacker();
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
            this.btnTE = new System.Windows.Forms.Button();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.lblDrivestatus = new System.Windows.Forms.Label();
            this.tbDriveErrText = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvVarlist = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.console = new System.Windows.Forms.TextBox();
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
            this.dgvTelezhka = new System.Windows.Forms.DataGridView();
            this.ColDetalTel = new System.Windows.Forms.DataGridViewComboBoxColumn();
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
            this.cbTelezhProducts = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitConBase)).BeginInit();
            this.splitConBase.Panel1.SuspendLayout();
            this.splitConBase.Panel2.SuspendLayout();
            this.splitConBase.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gb_commands.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarlist)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabCellinfo.SuspendLayout();
            this.tabChoosenCell.SuspendLayout();
            this.addDetailGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdList)).BeginInit();
            this.tabPoddon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelezhka)).BeginInit();
            this.TelezhkaGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer_refresh
            // 
            this.timer_refresh.Interval = 50;
            this.timer_refresh.Tick += new System.EventHandler(this.timer_refresh_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsl_error});
            this.statusStrip1.Location = new System.Drawing.Point(0, 716);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1223, 22);
            this.statusStrip1.TabIndex = 40;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsl_error
            // 
            this.tsl_error.Name = "tsl_error";
            this.tsl_error.Size = new System.Drawing.Size(0, 17);
            // 
            // bwStackerRefresh
            // 
            this.bwStackerRefresh.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // splitConBase
            // 
            this.splitConBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitConBase.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitConBase.IsSplitterFixed = true;
            this.splitConBase.Location = new System.Drawing.Point(0, 0);
            this.splitConBase.Name = "splitConBase";
            // 
            // splitConBase.Panel1
            // 
            this.splitConBase.Panel1.Controls.Add(this.groupBox3);
            this.splitConBase.Panel1.Layout += new System.Windows.Forms.LayoutEventHandler(this.splitConBase_Panel1_Layout);
            // 
            // splitConBase.Panel2
            // 
            this.splitConBase.Panel2.Controls.Add(this.btnTE);
            this.splitConBase.Panel2.Controls.Add(this.tabControl3);
            this.splitConBase.Panel2.Controls.Add(this.tabCellinfo);
            this.splitConBase.Size = new System.Drawing.Size(1223, 716);
            this.splitConBase.SplitterDistance = 857;
            this.splitConBase.TabIndex = 47;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.legend1);
            this.groupBox3.Controls.Add(this.stacker1);
            this.groupBox3.Controls.Add(this.gb_commands);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox3.Size = new System.Drawing.Size(840, 697);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Штабелер";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblMode);
            this.groupBox1.Controls.Add(this.labelStat);
            this.groupBox1.Controls.Add(this.lblPosition);
            this.groupBox1.Controls.Add(this.btnPower);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Location = new System.Drawing.Point(282, 553);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 126);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "РЕЖИМ:";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(80, 20);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(44, 13);
            this.lblMode.TabIndex = 38;
            this.lblMode.Text = "lblMode";
            this.lblMode.Click += new System.EventHandler(this.lblMode_Click);
            // 
            // labelStat
            // 
            this.labelStat.AutoSize = true;
            this.labelStat.Location = new System.Drawing.Point(201, 53);
            this.labelStat.Name = "labelStat";
            this.labelStat.Size = new System.Drawing.Size(35, 13);
            this.labelStat.TabIndex = 42;
            this.labelStat.Text = "label2";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(22, 53);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(35, 13);
            this.lblPosition.TabIndex = 34;
            this.lblPosition.Text = "label1";
            // 
            // btnPower
            // 
            this.btnPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPower.BackColor = System.Drawing.Color.Maroon;
            this.btnPower.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPower.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPower.Location = new System.Drawing.Point(455, 14);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(94, 23);
            this.btnPower.TabIndex = 35;
            this.btnPower.Text = "POWER";
            this.btnPower.UseVisualStyleBackColor = false;
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(394, 48);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(155, 23);
            this.button7.TabIndex = 36;
            this.button7.Text = "Специальное управление";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // legend1
            // 
            this.legend1.Location = new System.Drawing.Point(3, 13);
            this.legend1.Margin = new System.Windows.Forms.Padding(0);
            this.legend1.Name = "legend1";
            this.legend1.Size = new System.Drawing.Size(103, 96);
            this.legend1.Stk = this.stacker1;
            this.legend1.TabIndex = 22;
            // 
            // stacker1
            // 
            this.stacker1.AutoSize = true;
            this.stacker1.cellsize = 25;
            this.stacker1.CellsNextPass = "1:11,254:11";
            this.stacker1.Delta = 4;
            this.stacker1.Floors = 12;
            this.stacker1.Group = 1;
            this.stacker1.InputCells = new int[0];
            this.stacker1.Location = new System.Drawing.Point(282, 13);
            this.stacker1.MaximumSize = new System.Drawing.Size(554, 541);
            this.stacker1.MinimumSize = new System.Drawing.Size(554, 541);
            this.stacker1.Name = "stacker1";
            this.stacker1.OccupiedColor = System.Drawing.Color.Empty;
            this.stacker1.PoddonCells = new int[0];
            this.stacker1.Rows = 22;
            this.stacker1.Size = new System.Drawing.Size(554, 541);
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(252)))), ((int)(((byte)(200)))));
            this.stacker1.StyleInput = dataGridViewCellStyle1;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(206)))), ((int)(((byte)(231)))));
            this.stacker1.StylePoddon = dataGridViewCellStyle2;
            this.stacker1.TabIndex = 21;
            this.stacker1.TableCoords = null;
            this.stacker1.TB = null;
            this.stacker1.OnCellSelect += new Stackerlib.OnCellSelectDelegate(this.stacker1_OnCellSelect);
            this.stacker1.OnGetCellCount += new Stackerlib.OnGetCellCountDelegate(this.stacker1_OnGetCellCount);
            this.stacker1.OnGetTelezhkaCount += new Stackerlib.OnGetOnStackerDelegate(this.stacker1_OnGetTelezhkaCount);
            this.stacker1.OnCmdPut += new Stackerlib.OnCmdPut(this.stacker1_OnCmdPut);
            this.stacker1.OnCmdTake += new Stackerlib.OnCmdTake(this.stacker1_OnCmdTake);
            this.stacker1.OnIsReady += new Stackerlib.isReady(this.stacker1_OnIsReady);
            this.stacker1.OnClickStacker += new Stackerlib.OnClickStacker(this.stacker1_OnClickStacker);
            this.stacker1.Load += new System.EventHandler(this.stacker1_Load);
            this.stacker1.Layout += new System.Windows.Forms.LayoutEventHandler(this.stacker1_Layout);
            this.stacker1.Resize += new System.EventHandler(this.stacker1_Resize);
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
            this.gb_commands.Location = new System.Drawing.Point(4, 112);
            this.gb_commands.Name = "gb_commands";
            this.gb_commands.Size = new System.Drawing.Size(263, 567);
            this.gb_commands.TabIndex = 46;
            this.gb_commands.TabStop = false;
            this.gb_commands.Text = "Команды";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(77, 197);
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
            this.cmdManager1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdManager1.AutoScroll = true;
            this.cmdManager1.AutoSize = true;
            this.cmdManager1.Location = new System.Drawing.Point(6, 213);
            this.cmdManager1.Name = "cmdManager1";
            this.cmdManager1.Size = new System.Drawing.Size(251, 361);
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
            this.lblCPUStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCPUStatus.AutoSize = true;
            this.lblCPUStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCPUStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCPUStatus.Location = new System.Drawing.Point(180, 16);
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
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Положить в";
            this.button3.UseVisualStyleBackColor = true;
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
            // 
            // btnTE
            // 
            this.btnTE.Location = new System.Drawing.Point(3, 3);
            this.btnTE.Name = "btnTE";
            this.btnTE.Size = new System.Drawing.Size(160, 23);
            this.btnTE.TabIndex = 45;
            this.btnTE.Text = "Тотальное редактирование";
            this.btnTE.UseVisualStyleBackColor = true;
            this.btnTE.Click += new System.EventHandler(this.btnTE_Click);
            // 
            // tabControl3
            // 
            this.tabControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl3.Controls.Add(this.tabPage3);
            this.tabControl3.Controls.Add(this.tabPage5);
            this.tabControl3.Controls.Add(this.tabPage1);
            this.tabControl3.Location = new System.Drawing.Point(3, 389);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.Padding = new System.Drawing.Point(3, 3);
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(356, 324);
            this.tabControl3.TabIndex = 38;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.lblDrivestatus);
            this.tabPage3.Controls.Add(this.tbDriveErrText);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(348, 298);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Ошибки";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.Location = new System.Drawing.Point(182, 35);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(152, 23);
            this.button8.TabIndex = 17;
            this.button8.Text = "Квитировать приводы";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // lblDrivestatus
            // 
            this.lblDrivestatus.AutoSize = true;
            this.lblDrivestatus.Location = new System.Drawing.Point(6, 16);
            this.lblDrivestatus.Name = "lblDrivestatus";
            this.lblDrivestatus.Size = new System.Drawing.Size(35, 13);
            this.lblDrivestatus.TabIndex = 16;
            this.lblDrivestatus.Text = "label3";
            // 
            // tbDriveErrText
            // 
            this.tbDriveErrText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDriveErrText.Location = new System.Drawing.Point(6, 64);
            this.tbDriveErrText.Multiline = true;
            this.tbDriveErrText.Name = "tbDriveErrText";
            this.tbDriveErrText.ReadOnly = true;
            this.tbDriveErrText.Size = new System.Drawing.Size(328, 228);
            this.tbDriveErrText.TabIndex = 15;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(242, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(92, 23);
            this.button6.TabIndex = 13;
            this.button6.Text = "Квитировать";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvVarlist);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(348, 298);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Переменные";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvVarlist
            // 
            this.dgvVarlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVarlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVarlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9,
            this.changed});
            this.dgvVarlist.Location = new System.Drawing.Point(7, 7);
            this.dgvVarlist.Name = "dgvVarlist";
            this.dgvVarlist.Size = new System.Drawing.Size(335, 282);
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.console);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(348, 298);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Консоль";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // console
            // 
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console.Location = new System.Drawing.Point(6, 6);
            this.console.Multiline = true;
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.console.Size = new System.Drawing.Size(336, 286);
            this.console.TabIndex = 0;
            // 
            // tabCellinfo
            // 
            this.tabCellinfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCellinfo.Controls.Add(this.tabChoosenCell);
            this.tabCellinfo.Controls.Add(this.tabPoddon);
            this.tabCellinfo.Location = new System.Drawing.Point(3, 29);
            this.tabCellinfo.Name = "tabCellinfo";
            this.tabCellinfo.SelectedIndex = 0;
            this.tabCellinfo.Size = new System.Drawing.Size(356, 357);
            this.tabCellinfo.TabIndex = 40;
            this.tabCellinfo.SelectedIndexChanged += new System.EventHandler(this.tabCellinfo_TabIndexChanged);
            // 
            // tabChoosenCell
            // 
            this.tabChoosenCell.Controls.Add(this.addDetailGroup);
            this.tabChoosenCell.Controls.Add(this.dgvProdList);
            this.tabChoosenCell.Location = new System.Drawing.Point(4, 22);
            this.tabChoosenCell.Name = "tabChoosenCell";
            this.tabChoosenCell.Padding = new System.Windows.Forms.Padding(3);
            this.tabChoosenCell.Size = new System.Drawing.Size(348, 331);
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
            this.addDetailGroup.Controls.Add(this.button_add);
            this.addDetailGroup.Controls.Add(this.tbProdCount);
            this.addDetailGroup.Controls.Add(this.cbProducts);
            this.addDetailGroup.Enabled = false;
            this.addDetailGroup.Location = new System.Drawing.Point(6, 7);
            this.addDetailGroup.Name = "addDetailGroup";
            this.addDetailGroup.Size = new System.Drawing.Size(336, 73);
            this.addDetailGroup.TabIndex = 13;
            this.addDetailGroup.TabStop = false;
            this.addDetailGroup.Text = "Добавить деталь";
            // 
            // tbDetalFilter
            // 
            this.tbDetalFilter.Location = new System.Drawing.Point(6, 19);
            this.tbDetalFilter.Name = "tbDetalFilter";
            this.tbDetalFilter.Size = new System.Drawing.Size(115, 20);
            this.tbDetalFilter.TabIndex = 4;
            this.tbDetalFilter.Text = "Фильтр деталей";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(127, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "единиц";
            // 
            // button_add
            // 
            this.button_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_add.Location = new System.Drawing.Point(231, 17);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(99, 50);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "Добавить";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.Click_add_detail);
            // 
            // tbProdCount
            // 
            this.tbProdCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProdCount.Location = new System.Drawing.Point(176, 17);
            this.tbProdCount.Name = "tbProdCount";
            this.tbProdCount.Size = new System.Drawing.Size(49, 20);
            this.tbProdCount.TabIndex = 2;
            this.tbProdCount.TextChanged += new System.EventHandler(this.tbProdCount_TextChanged);
            // 
            // cbProducts
            // 
            this.cbProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProducts.DisplayMember = "name";
            this.cbProducts.FormattingEnabled = true;
            this.cbProducts.Location = new System.Drawing.Point(6, 43);
            this.cbProducts.Name = "cbProducts";
            this.cbProducts.Size = new System.Drawing.Size(219, 21);
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
            this.dgvProdList.Location = new System.Drawing.Point(7, 86);
            this.dgvProdList.MultiSelect = false;
            this.dgvProdList.Name = "dgvProdList";
            this.dgvProdList.ReadOnly = true;
            this.dgvProdList.RowHeadersWidth = 21;
            this.dgvProdList.Size = new System.Drawing.Size(335, 239);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Push.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Take.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.tabPoddon.Controls.Add(this.dgvTelezhka);
            this.tabPoddon.Controls.Add(this.TelezhkaGroup);
            this.tabPoddon.Location = new System.Drawing.Point(4, 22);
            this.tabPoddon.Name = "tabPoddon";
            this.tabPoddon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPoddon.Size = new System.Drawing.Size(348, 331);
            this.tabPoddon.TabIndex = 1;
            this.tabPoddon.Text = "На тележке";
            this.tabPoddon.UseVisualStyleBackColor = true;
            // 
            // dgvTelezhka
            // 
            this.dgvTelezhka.AllowUserToAddRows = false;
            this.dgvTelezhka.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTelezhka.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelezhka.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDetalTel,
            this.dataGridViewButtonColumn1,
            this.dataGridViewButtonColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvTelezhka.Location = new System.Drawing.Point(6, 86);
            this.dgvTelezhka.MultiSelect = false;
            this.dgvTelezhka.Name = "dgvTelezhka";
            this.dgvTelezhka.ReadOnly = true;
            this.dgvTelezhka.RowHeadersWidth = 21;
            this.dgvTelezhka.Size = new System.Drawing.Size(336, 239);
            this.dgvTelezhka.TabIndex = 15;
            // 
            // ColDetalTel
            // 
            this.ColDetalTel.DataPropertyName = "product_id";
            this.ColDetalTel.Frozen = true;
            this.ColDetalTel.HeaderText = "Деталь";
            this.ColDetalTel.Name = "ColDetalTel";
            this.ColDetalTel.ReadOnly = true;
            this.ColDetalTel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColDetalTel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColDetalTel.Width = 200;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewButtonColumn2.DefaultCellStyle = dataGridViewCellStyle6;
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
            this.TelezhkaGroup.Controls.Add(this.cbTelezhProducts);
            this.TelezhkaGroup.Enabled = false;
            this.TelezhkaGroup.Location = new System.Drawing.Point(6, 6);
            this.TelezhkaGroup.Name = "TelezhkaGroup";
            this.TelezhkaGroup.Size = new System.Drawing.Size(336, 74);
            this.TelezhkaGroup.TabIndex = 14;
            this.TelezhkaGroup.TabStop = false;
            this.TelezhkaGroup.Text = "Добавить деталь";
            // 
            // tbTelezhkaProducts
            // 
            this.tbTelezhkaProducts.Location = new System.Drawing.Point(11, 18);
            this.tbTelezhkaProducts.Name = "tbTelezhkaProducts";
            this.tbTelezhkaProducts.Size = new System.Drawing.Size(102, 20);
            this.tbTelezhkaProducts.TabIndex = 4;
            this.tbTelezhkaProducts.Text = "Фильтр деталей";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "единиц";
            // 
            // tbProdCountTelezhka
            // 
            this.tbProdCountTelezhka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProdCountTelezhka.Location = new System.Drawing.Point(175, 18);
            this.tbProdCountTelezhka.Name = "tbProdCountTelezhka";
            this.tbProdCountTelezhka.Size = new System.Drawing.Size(49, 20);
            this.tbProdCountTelezhka.TabIndex = 2;
            this.tbProdCountTelezhka.TextChanged += new System.EventHandler(this.tbProdCountTelezhka_TextChanged);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(230, 18);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 47);
            this.button5.TabIndex = 1;
            this.button5.Text = "Добавить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cbTelezhProducts
            // 
            this.cbTelezhProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTelezhProducts.DisplayMember = "name";
            this.cbTelezhProducts.FormattingEnabled = true;
            this.cbTelezhProducts.Location = new System.Drawing.Point(11, 44);
            this.cbTelezhProducts.Name = "cbTelezhProducts";
            this.cbTelezhProducts.Size = new System.Drawing.Size(213, 21);
            this.cbTelezhProducts.TabIndex = 0;
            this.cbTelezhProducts.ValueMember = "id";
            // 
            // StackerBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitConBase);
            this.Controls.Add(this.statusStrip1);
            this.Name = "StackerBox";
            this.Size = new System.Drawing.Size(1223, 738);
            this.Load += new System.EventHandler(this.StackerBox_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.StackerBox_Layout);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitConBase.Panel1.ResumeLayout(false);
            this.splitConBase.Panel1.PerformLayout();
            this.splitConBase.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitConBase)).EndInit();
            this.splitConBase.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_commands.ResumeLayout(false);
            this.gb_commands.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarlist)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabCellinfo.ResumeLayout(false);
            this.tabChoosenCell.ResumeLayout(false);
            this.addDetailGroup.ResumeLayout(false);
            this.addDetailGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdList)).EndInit();
            this.tabPoddon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelezhka)).EndInit();
            this.TelezhkaGroup.ResumeLayout(false);
            this.TelezhkaGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer_refresh;
        private System.Windows.Forms.GroupBox groupBox3;
        private Stackerlib.Stacker stacker1;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnPower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsl_error;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgvVarlist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn changed;
        private System.Windows.Forms.TabControl tabCellinfo;
        private System.Windows.Forms.TabPage tabChoosenCell;
        private System.Windows.Forms.GroupBox addDetailGroup;
        private System.Windows.Forms.TextBox tbDetalFilter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbProdCount;
        private System.Windows.Forms.Button button_add;
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
        private System.Windows.Forms.GroupBox TelezhkaGroup;
        private System.Windows.Forms.TextBox tbTelezhkaProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbProdCountTelezhka;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox cbTelezhProducts;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox console;
        private System.Windows.Forms.DataGridView dgvTelezhka;
        private System.ComponentModel.BackgroundWorker bwStackerRefresh;
        private Stackerlib.Legend legend1;
        private System.Windows.Forms.Button btnTE;
        private System.Windows.Forms.Label labelStat;
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
        private System.Windows.Forms.DataGridViewComboBoxColumn ColDetalTel;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.SplitContainer splitConBase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbDriveErrText;
        private System.Windows.Forms.Label lblDrivestatus;
        private System.Windows.Forms.Button button8;
 
    }
}
