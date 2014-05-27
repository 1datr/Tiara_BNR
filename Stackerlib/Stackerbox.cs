﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BR.AN.PviServices;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace StackerLib
{
    // тип события при выборе ячейки
    public delegate void OnEditProductsEvent(int cellno);

    public partial class StackerBox : UserControl
    {
        public StackerBox()
        {
            InitializeComponent();
        }

        private /*static*/ Service service;
        private /*static*/ Cpu cpu;
        private /*static*/ Variable variable;
        private static Utilities utils;
        private String ip = null;
        private int port = 0;
        private Dictionary<string, Variable> Varlist;
        private Command CurrCmd;    // current command with operands
        private bool cmdExecuting = false;  // command executing now
        public static Logger logger;

        public new bool DesignMode
        {
            get
            {
                return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
            }
        }

        public class Command
        {
            public int cmdid = -1;
            public int operand1 = -1;
            public int operand2 = -1;
        }

        public class ProductRec
        {
            public int stacker_id;
            public int cell_id;
            public string prodname;
            public int count;
            public DateTime changed;
        }



        private static int component_count = 0;

        private void Connect_Service(String servname)
        {
            try
            {
                if (this.DesignMode) return;
                Varlist = new Dictionary<string, Variable>();
                utils = new Utilities();
                ShowStatus("PVI service connecting ...");

                if (service == null)
                {
                    service = new Service(servname + this.f_StackerID.ToString());

                }

                service.Error += new PviEventHandler(ConnectionError);
                service.Connected += new PviEventHandler(Connect_CPU);
                if ((ip == null) && (port == 0))
                {
                    if (!service.IsConnected)
                        service.Connect();
                }
                else
                {
                    if (!service.IsConnected)
                        service.Connect(ip, port);
                }
            }
            catch (System.Exception ex)
            { }
        }

        private void ShowStatus(String status_str)
        {
            tsl_error.Text = status_str;
        }

        private int f_StackerID = 1;
        [DisplayName("ID штабелера")]
        [Description("Номер штабелера")]
        public int StackerID
        {
            get { return f_StackerID; }
            set { f_StackerID = value; }
        }

        private void Connect_CPU(object sender, PviEventArgs e)
        {
            ShowStatus("PVI service connected");
            ShowStatus("PVI CPU connecting ...");
            cpu = new Cpu(service, "Cpu"+component_count.ToString());
            component_count++;
            //cpu.Connection.DeviceType = DeviceType.Serial;
            cpu.Connection.DeviceType = DeviceType.TcpIp;
            /*   cpu.Connection.TcpIp.DestinationIpAddress = "127.0.0.1";
               cpu.Connection.TcpIp.DestinationPort = 11160;*/
            cpu.Connection.TcpIp.DestinationIpAddress = ConfigurationManager.AppSettings["PLC_IP_" + f_StackerID.ToString()];
            cpu.Connection.TcpIp.DestinationPort = short.Parse(ConfigurationManager.AppSettings["PLC_PORT_" + f_StackerID.ToString()]);
            /*
            cpu.Connection.TcpIp.DestinationIpAddress = "192.168.1.200";
            cpu.Connection.TcpIp.DestinationPort = 11159;*/
            //cpu.Connection.Serial.Channel = 1;
            cpu.Error += new PviEventHandler(ConnectionError);
            cpu.Connected += new PviEventHandler(Connect_Vars);
            Console.WriteLine("Connecting Cpu ...");
            cpu.Connect();
        }
        // Add variable to tree
        private void AddVar(String Varname)
        {
            if (Varlist.ContainsKey(Varname)) return;
            Varlist.Add(Varname, new Variable(cpu, Varname));
            Varlist[Varname].Active = true;
            Varlist[Varname].ValueChanged += new VariableEventHandler(ValueChanged);
            Varlist[Varname].Connected += new PviEventHandler(variables_Connected);
            Varlist[Varname].Connect();
        }
        // Get variable value 
        private object VarVal(String Varname)
        {
            return Varlist[Varname].Value;
        }
        //
        private void Connect_Vars(object sender, PviEventArgs e)
        {
            ShowStatus("PVI CPU connected");
            ShowStatus("PVI variables connecting ...");

            AddVar("gOPC.Output.Xpos");
            AddVar("gOPC.Output.Ypos");
            AddVar("gOPC.Output.Zpos");
            AddVar("gOPC.Output.load");

            AddVar("gOPC.Output.status");
            AddVar("gOPC.Output.drivestatus");
            AddVar("gOPC.Output.power");
            AddVar("gOPC.Output.Mode");

            AddVar("gModule1"); // 12 входов с датчиков
            AddVar("gModule2");  //
            AddVar("gModule3"); // 12 выходов на исполнительных устройств
            AddVar("gModule4"); // Шинный передатчик // только Module_OK
            AddVar("gModule8"); // Шинный приемник // только Module_OK
            AddVar("gModule9"); // Энкодер оси Y // ModuleOk, DI1, DI2, Encoder
            AddVar("gModule10"); // Энкодер оси X // ModuleOk, DI1, DI2, Encoder
            AddVar("gModule11"); // Энкодер оси Z // ModuleOk, DI1, DI2, Encoder

            AddVar("gModule12"); // 12 входов с датчиков
            AddVar("gModule13"); // 12 входов с датчиков

            AddVar("gOPC.Input.ack");
            AddVar("gOPC.Input.driveack");
            AddVar("gOPC.Input.start");
            AddVar("gOPC.Input.src_cell");
            AddVar("gOPC.Input.dst_cell");
            AddVar("gOPC.Input.command");
            AddVar("gOPC.Input.power");

        }

        private void variables_Connected(object sender, PviEventArgs e)
        {
            ShowStatus("PVI variables connected");
            // Console.WriteLine("Variable Connected Error=" + e.ErrorCode.ToString());
            if (Varlist.ContainsKey("gOPC.Input.power"))
                Varlist["gOPC.Input.power"].Value = true;
            gb_commands.Enabled = true;
        }

        private void out_cpu_state()
        {

            //CpuState.Offline
            if (cpu == null) return;
            switch (cpu.State)
            {
                /*  case CpuState.Boot:
                      lblCPUStatus.Text = "Boot";
                      break;*/
                case CpuState.Service:
                    lblCPUStatus.Text = "Service";
                    break;
                case CpuState.Run:
                    lblCPUStatus.Text = "Run";
                    break;
                default:
                    try
                    {
                        lblCPUStatus.Text = "Unknown";
                    }
                    catch (System.StackOverflowException ex)
                    {
                    }
                    break;
            }

        }

        private string stacker_error_text(int errcode)
        {
            this.BS_Errors.Filter = "err_id=" + errcode.ToString();
            if (this.BS_Errors.Current == null) return null;
            DataRowView currentRow = (DataRowView)this.BS_Errors.Current;
            return currentRow["err_text"].ToString();


        }

        private void ConnectionError(object sender, PviEventArgs e)
        {
            try
            {
                this.tsl_error.Text = String.Format("Error:{0}", e.ErrorText);

                out_cpu_state();
           /*     if (!service.IsConnected) service.Connect();
                if(cpu!=null)
                    if (!cpu.IsConnected) cpu.Connect();*/
            }
            catch (System.Exception ex)
            {
                this.tsl_error.Text = ex.Message;
            }
            //Application.Exit();
        }
        // Отслеживание значений переменных
        private int status = 0;
        private bool power = false;
        private int mode = 0;
        private bool vch_first = true;
        private bool cell_test_mode = false;
        private bool autokvit = false;

        private void ValueChanged(object sender, VariableEventArgs e)
        {
            Variable var = (Variable)sender;
            out_cpu_state();
            //MessageBox.Show(var.Name +":"+var.Value.ToString());

            switch (var.Name)
            {
                case "gOPC.Output.status":
                    {
                        cmdExecuting = false;
                        status = Convert.ToInt32(VarVal("gOPC.Output.status").ToString());
                        switch (status)
                        {
                            case 0:
                                tsl_error.Text = "Штабелер готов к выполнению команды";
                                this.cmdManager1.EndCommand();
                                break;
                            case 1: tsl_error.Text = "Штабелер находиться в состоянии выполнения команды"; break;
                            case 2: tsl_error.Text = "Штабелер не готов выполненять команду"; break;
                            default:
                                {
                                    tsl_error.Text = "Ошибка " + status.ToString() + ". " + stacker_error_text(status); break;

                                }
                        }
                        LogMes(tsl_error.Text);
                        if (gb_commands.Enabled)
                        {
                            CurrCmd.cmdid = 0;
                            CurrCmd.operand1 = 0;
                            CurrCmd.operand2 = 0;
                        }
                    }
                    break;
                case "gOPC.Output.Mode":
                    mode = Convert.ToInt32(VarVal("gOPC.Output.Mode").ToString());
                    gb_commands.Enabled = (mode == 0);
                    String[] mode_capts = { "ПА", "наладка/шаговый", "наладка/ручной" };
                    lblMode.Text = mode_capts[mode];
                    LogMes(mode_capts[mode]);
                    break;
                case "gOPC.Output.power":
                    power = Convert.ToBoolean(VarVal("gOPC.Output.power").ToString());
                    LogMes(String.Format("power = " + power.ToString()));
                    break;
                case "gOPC.Output.load":
                    {
                        bool load = Convert.ToBoolean(VarVal("gOPC.Output.load").ToString());
                        if (load)   // погрузили на поддон
                        {
                            //  if (CurrCmd.operand1 > -1)
                            if (!vch_first)
                            //  if(Convert.ToInt32(Varlist["gOPC.Input.src_cell"].Value.ToString())!=0)
                            {
                                //    this.load(Convert.ToInt32(Varlist["gOPC.Input.src_cell"].Value.ToString()));
                            }
                        }
                        else // выгрузили с поддона
                        {
                            //if (CurrCmd.operand2 > -1)
                            if (!vch_first)
                            //   if (Convert.ToInt32(Varlist["gOPC.Input.dst_cell"].Value.ToString()) != "0")
                            {
                                //    this.unload(Convert.ToInt32(Varlist["gOPC.Input.dst_cell"].Value.ToString()));

                            }
                        }
                        vch_first = false;
                        stacker1.TriggerStacker(load);
                    }
                    break;
                case "gOPC.Output.Xpos":
                    stacker1.SetX(Convert.ToInt32(VarVal("gOPC.Output.Xpos")));
                    lblPosition.Text = "X:" + VarVal("gOPC.Output.Xpos") + " Y:" + VarVal("gOPC.Output.Ypos") + " Z:" + VarVal("gOPC.Output.Zpos");
                    break;
                case "gOPC.Output.Ypos":
                    stacker1.SetY(Convert.ToInt32(VarVal("gOPC.Output.Ypos")));
                    lblPosition.Text = "X:" + VarVal("gOPC.Output.Xpos") + " Y:" + VarVal("gOPC.Output.Ypos") + " Z:" + VarVal("gOPC.Output.Zpos");
                    break;
                case "gOPC.Output.Zpos":
                    stacker1.SetZ(Convert.ToInt32(VarVal("gOPC.Output.Zpos")));
                    lblPosition.Text = "X:" + VarVal("gOPC.Output.Xpos") + " Y:" + VarVal("gOPC.Output.Ypos") + " Z:" + VarVal("gOPC.Output.Zpos");
                    break;
                case "gOPC.Output.drivestatus":
                    lblDrivestatus.Text = "Drive status is " + VarVal("gOPC.Output.drivestatus");
                    if (VarVal("gOPC.Output.drivestatus").ToString() == "0")
                    {
                        tbDriveErrText.Text = "";
                    }
                    else
                    {
                        BS_DriveErrors.Filter = "err_id=" + VarVal("gOPC.Output.drivestatus").ToString();
                        if (BS_DriveErrors.Count > 0)
                        {
                            DataRowView currentRow = (DataRowView)BS_DriveErrors.Current;
                            tbDriveErrText.Text = currentRow["err_text"].ToString();
                        }
                        else tbDriveErrText.Text = "Неизвестная ошибка";
                        // LogMes(tbDriveErrText.Text);
                    }
                    break;
                /*
            case "gModule1":
                DrawModule(Varlist["gModule1"], dgvMod1);
                break;
            case "gModule2":
                DrawModule(Varlist["gModule2"], dgvMod2);
                break;
            case "gModule3":
                DrawModule(Varlist["gModule3"], dgvMod3);
                break;
            case "gModule4":
                DrawModule(Varlist["gModule4"], dgvMod4);
                break;

            case "gModule8":
                DrawModule(Varlist["gModule8"], dgvMod8);
                break;
            case "gModule9":
                DrawModule(Varlist["gModule9"], dgvMod9);
                break;
            case "gModule10":
                DrawModule(Varlist["gModule10"], dgvMod10);
                break;
            case "gModule11":
                DrawModule(Varlist["gModule11"], dgvMod11);
                break;
            case "gModule12":
                DrawModule(Varlist["gModule12"], dgvMod12);
                break;
            case "gModule13":
                DrawModule(Varlist["gModule13"], dgvMod13);
                break;*/
            }
            /*
            if ((mode == 0) && (status == 0) && (power) && (cpu.State == CpuState.Run))
                gb_commands.Enabled = true;
            else
                gb_commands.Enabled = false;
            */

            if (power)
            {
                btnPower.ForeColor = Color.LightGreen;
                btnPower.Text = "ON";
            }
            else
            {
                btnPower.ForeColor = Color.DarkGray;
                btnPower.Text = "OFF";
            }

            // All vars output
            foreach (KeyValuePair<string, Variable> kvp in Varlist)
            {
                bool varadded = false;
                foreach (DataGridViewRow dgvr in dgvVarlist.Rows)
                {
                    if (dgvr.Cells[0].Value == kvp.Key)
                    {
                        varadded = true;
                        dgvr.Cells[1].Value = kvp.Value.Value.ToString();
                        dgvr.Cells[2].Value = DateTime.Now;
                    }
                }
                if (!varadded)
                {
                    if (dgvVarlist.Columns.Count > 0)
                        dgvVarlist.Rows.Add(kvp.Key, kvp.Value.Value.ToString(), DateTime.Now);
                }
            }
            //Trigger_State();
        }

        private String f_logpath = "events.log";
        [DisplayName("Размер ячейки")]
        [Description("Размер ячейки в пикселях")]
        public String Logpath 
        {
            get { return f_logpath; }
            set { f_logpath = value; }
        }

        private void LogMes(String mes)
        {
            String logpath = f_logpath ;
               using (System.IO.StreamWriter w = System.IO.File.AppendText(
           System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\" + logpath))
               {
                   w.WriteLine("--------------------");
                   w.WriteLine(DateTime.Now);
                   w.WriteLine(mes);
                   w.Close();
               }
        }


        [DisplayName("Размер ячейки")]
        [Description("Размер ячейки в пикселях")]
        public int cellsize
        {
            get
            {
                return this.stacker1.cellsize;
            }
            set
            {
                this.stacker1.cellsize = value;
            }
        }

        // STACKER rows
        [DisplayName("Рядов")]
        [Description("Сколько рядов у штабелера")]
        public int Rows
        {
            get
            {
                return stacker1.Rows;
            }
            set
            {
                stacker1.Rows = value;
            }
        }
        // 
        [DisplayName("Полок")]
        [Description("Сколько полок у штабелера")]
        public int Floors
        {
            get
            {
                return stacker1.Floors;
            }
            set
            {
                stacker1.Floors = value;
            }
        }

        [DisplayName("Группировка")]
        [Description("Группировка ячеек по нескольку в одной")]
        public int Group
        {
            get
            {
                return stacker1.Group;
            }
            set
            {
                stacker1.Group = value;
            }
        }

        [DisplayName("Ячейки с пропуском")]
        [Description("Ячейки после которых пропустить нумерацию следующей")]
        public String CellsNextPass
        {
            get
            {
                return stacker1.CellsNextPass;
            }
            set
            {
                stacker1.CellsNextPass = value;
            }
        }

        [DisplayName("Поддоны")]
        [Description("Массив поддонов")]
        public int[] PoddonCells
        {
            get
            {
                return stacker1.PoddonCells;
            }
            set
            {
                stacker1.PoddonCells = value;
            }
        }

        [DisplayName("Поддоны входные")]
        [Description("Массив поддонов входных")]
        public int[] InputCells
        {
            get
            {
                return stacker1.InputCells;
            }
            set
            {
                stacker1.InputCells = value;
            }
        }

        public DataGridViewCellStyle StylePoddon { get { return stacker1.StylePoddon; } }
        public DataGridViewCellStyle StyleInput { get { return stacker1.StyleInput; } }


        private DataTable fTableCoords;
        [DisplayName("Таблица координат")]
        [Description("Таблица координат ячеек")]

        public DataTable TableCoords
        {
            get
            {
                
                return fTableCoords;
            }
            set
            {
                fTableCoords = value;
                if (fTableCoords != null)
                    stacker1.TableCoords = fTableCoords;

            }
        }

        [DisplayName("Пароль")]
        [Description("Пароль для режима тотального редактирования и квитирования")]
        public String PASSWORD { get; set; }

        private BindingSource fTableProductlist;
        private BindingSource fTableProductlist_for_combo;
        [DisplayName("Список продуктов")]
        [Description("Таблица со списком продуктов")]
        public BindingSource TableProductlist
        {
            get {
                return fTableProductlist;
            }
            set {
                fTableProductlist = value;
                
                this.ColDetal.DataSource = this.fTableProductlist;
                this.ColDetal.DisplayMember = "name";
                this.ColDetal.ValueMember = "id";

                this.ColDetalTel.DataSource = this.fTableProductlist;
                this.ColDetalTel.DisplayMember = "name";
                this.ColDetalTel.ValueMember = "id";

                fTableProductlist_for_combo = new BindingSource();
                fTableProductlist_for_combo.DataSource = this.fTableProductlist.DataSource;

                cbProducts.DataSource = value;
                cbProducts.DisplayMember = "name";
                cbProducts.ValueMember = "id";
            }
        }

        private BindingSource bs_Errors;
        [DisplayName("Ошибки")]
        [Description("Таблица ошибок")]
        public BindingSource BS_Errors
        {
            get {
                return bs_Errors;
            }
            set {
                bs_Errors = value;
                
            }
        }

        [DisplayName("Ошибки привода")]
        [Description("Таблица ошибок привода")]
        public BindingSource BS_DriveErrors
        {
            get;
            set;
        }
        
        private BindingSource DT_Products_CurrCell;
        private BindingSource DT_Products_Telezhka;
        
        [DisplayName("Таблица продуктов")]
        [Description("Таблица продуктов по ячейкам")]
        public BindingSource TableProducts
        {
            get
            {
                return DT_Products_CurrCell;
            }
            set
            {
                // dgvProdList
                DT_Products_CurrCell = value;
                DT_Products_Telezhka = new BindingSource();
                DT_Products_Telezhka = DT_Products_CurrCell;

                dgvProdList.DataSource = DT_Products_CurrCell;
                 
                dgvTelezhka.DataSource = DT_Products_Telezhka;

                

                if (value != null)
                {
                    DT_Products_Telezhka.Filter = "stacker_id=" + this.f_StackerID.ToString() + " AND cell_id = -1";               
                }
            }
        }

        private int stacker1_OnGetCellCount(int cellno)
        {
            if (this.DesignMode) return 0;
            // DataRow[] Rows = ProductsDataSet.Tables["products"].Select("stacker_id=1 AND cell_id = " + cellno);
            this.TableProducts.Filter = "stacker_id=" + this.f_StackerID.ToString() + " AND cell_id = " + cellno.ToString();
            return this.TableProducts.Count; 
          
            
        }

        private bool TEmode = false;
        private void stacker1_OnCellSelect(int cellno)
        {
            //dgvProdList.DataSource = this.TableProducts;

            this.tabChoosenCell.Text = "Ячейка " + cellno.ToString();
            this.TableProducts.Filter = "stacker_id=" + this.f_StackerID.ToString() + " AND cell_id=" + cellno.ToString();
            addDetailGroup.Enabled = (stacker1.is_input(cellno)) || TEmode;
            //sqdt_productlist.Update();
            //productsBindingSource.ResumeBinding();
            //  productsBindingSource1.Filter = "cell_id = " + cellno;

            //dgvProdList.ReadOnly = !(stacker1.is_poddon(cellno));
            Take.Visible = (stacker1.is_input(cellno) || TEmode);
            Push.Visible = (stacker1.is_poddon(cellno) || TEmode);

            tabCellinfo.SelectedIndex = 0;

            
        }

        private void stacker1_OnClickStacker()
        {
            tabCellinfo.SelectedIndex = 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Vnc VNCform = new Vnc();
            VNCform.VNC_IP = ConfigurationManager.AppSettings["PLC_IP_" + f_StackerID.ToString()];
            VNCform.Show();
        }

        private bool auth()
        {
            frmAuthSpec auth = new frmAuthSpec();
            auth._PASSWORD = this.PASSWORD;
            return (auth.ShowDialog() == DialogResult.OK);
        }

        private void btnTE_Click(object sender, EventArgs e)
        {
            if (!TEmode)
            {
                
                if (auth())
                {
                    TEmode = true;
                    btnTE.Text = "Обычное редактирование";
                    stacker1_OnCellSelect(stacker1.SelectedCellNumber);
                }
            }
            else
            {
                TEmode = false;
                btnTE.Text = "Тотальное редактирование";
                stacker1_OnCellSelect(stacker1.SelectedCellNumber);
            }
        }

        private void tabCellinfo_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabCellinfo_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (tabCellinfo.SelectedIndex)
            {
                case 0:
                    DT_Products_Telezhka.Filter = "stacker_id=" + this.f_StackerID.ToString() + " AND cell_id=" + stacker1.SelectedCellNumber.ToString();
                    break;
                case 1:
                    DT_Products_Telezhka.Filter = "stacker_id=" + this.f_StackerID.ToString() + " AND cell_id = -1";
                    break;
            }
        }

        private void Kvit()
        {
            Varlist["gOPC.Input.ack"].Value = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (auth())
            {
                Kvit();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (auth())
            {
                int maxcnt = 12;
                int i = 0;
                while ((VarVal("gOPC.Output.drivestatus").ToString() != "0") && (i < maxcnt))
                {
                    Varlist["gOPC.Input.driveack"].Value = true;
                    i++;
                    System.Threading.Thread.Sleep(100);
                }
            }
        }

        private String fServname = "serv1";
        [DisplayName("Имя сервиса")]
        [Description("Имя сервиса PVI")]
        public String Servname {
            get { return fServname; }
            set { fServname = value; }
        }

        private bool layout_first = true;
        private bool loaded = false;
        private void StackerBox_Layout(object sender, LayoutEventArgs e)
        {
            
            if ((layout_first) && (!this.DesignMode) && (loaded))
            {
                
                CurrCmd = new Command();
                layout_first = false;

                Connect_Service(fServname);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmdManager1.AddCommand(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmdManager1.AddCommand(1, Convert.ToInt32(this.Src_TakeFrom.Text));
            }
            catch (System.Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmdManager1.AddCommand(2, -1, Convert.ToInt32(this.PutTo_Dest.Text));
            }
            catch (System.Exception ex) { }
        }

        private void Trans()
        {
            try
            {
                cmdManager1.AddCommand(3, Convert.ToInt32(this.Trans_Src.Text), Convert.ToInt32(this.Trans_Dst.Text));
            }
            catch (System.Exception ex) { }
            /*
            if (System.Convert.ToInt32(this.VarVal("gOPC.Output.status")) == 0)
            {
                try {
                    this.Trans(Convert.ToInt32(this.Trans_Src.Text), Convert.ToInt32(this.Trans_Dst.Text));
                }
                catch (System.Exception e)
                { 
                
                }
                
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Trans();
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            if (power)
            {
                if (Varlist["gOPC.Input.power"].Value == false)
                {
                    Varlist["gOPC.Input.power"].Value = true;
                    System.Threading.Thread.Sleep(1000);
                    Varlist["gOPC.Input.power"].Value = false;
                }
                else
                    Varlist["gOPC.Input.power"].Value = false;

            }
            else
            {
                if (Varlist["gOPC.Input.power"].Value == true)
                {
                    Varlist["gOPC.Input.power"].Value = false;
                    System.Threading.Thread.Sleep(1000);
                    Varlist["gOPC.Input.power"].Value = true;
                }
                else
                    Varlist["gOPC.Input.power"].Value = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // добавить деталь

            try
            {
                String oldfilter = this.TableProducts.Filter;
                this.TableProducts.Filter = "stacker_id=" + this.f_StackerID.ToString() + " AND cell_id=" + stacker1.SelectedCellNumber.ToString() + " AND product_id=" + cbProducts.SelectedValue.ToString();
                int thecount = this.TableProducts.Count;
                this.TableProducts.Filter = oldfilter;
               // DataRow[] Rows = dbTiaraDataSet.products.Select("stacker_id=1 AND cell_id=" + stacker1.SelectedCellNumber.ToString() + " AND product_id=" + cbProducts.SelectedValue.ToString());
                if (thecount > 0)
                {
                    DataRowView currentRow = (DataRowView)this.TableProducts.Current;
                    int adding = 0;
                    if (tbProdCount.Text == "")
                        adding = 1;
                    else
                        adding = Convert.ToInt32(tbProdCount.Text);
                    currentRow["count"] = Convert.ToInt32(currentRow["count"]) + adding;
                    
                    LogMes(String.Format("Добавлено {0} деталей {1} в ячейку {2}.", adding, cbProducts.Text, stacker1.SelectedCellNumber));
                }
                else
                {
                    DataRowView currentRow = (DataRowView)this.TableProducts.AddNew();
                    currentRow["cell_id"] = stacker1.SelectedCellNumber;
                    currentRow["stacker_id"] = this.f_StackerID;
                    currentRow["changed"] = DateTime.Now;
                    currentRow["product_id"] = Convert.ToInt32(cbProducts.SelectedValue.ToString());
                    if (tbProdCount.Text != "")
                        /*   currentRow["count"] = 0;
                       else*/
                        currentRow["count"] = Convert.ToInt32(tbProdCount.Text);
                    if (Convert.ToInt32(currentRow["count"].ToString()) <= 0)
                        this.TableProducts.RemoveCurrent();
                    this.TableProducts.EndEdit();
                    LogMes(String.Format("Добавлено {0} деталей {1} в ячейку {2}.", Convert.ToInt32(tbProdCount.Text), cbProducts.Text, stacker1.SelectedCellNumber));
                }

                dgvProdList.Refresh();
            }
            catch (System.Exception ex)
            { }
        }

        private void dgvProdList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //  int currentRow = int.Parse(e.RowIndex.ToString());
            if (!stacker1.is_poddon(stacker1.SelectedCellNumber) && !this.TEmode) return;
            if (e.ColumnIndex == 0)
            {
                frmAddTake frm = new frmAddTake();

                frm.SetMode(true);
                DialogResult res = frm.ShowDialog();

                if (res == DialogResult.OK)
                {
                    // добавить
                    DataRowView currentRow = (DataRowView)this.TableProducts.Current;
                    currentRow["count"] = Convert.ToInt32(currentRow["count"].ToString()) + frm.count;
                    this.TableProducts.EndEdit();
                    dgvProdList.Refresh();
                    LogMes(String.Format("Добавлено {0} деталей {1} в ячейку {2}.", frm.count, dgvProdList.Rows[e.RowIndex].Cells[0].FormattedValue.ToString(), stacker1.SelectedCellNumber));
                }
            }
            else if (e.ColumnIndex == 1)
            {
                frmAddTake frm = new frmAddTake();

                frm.SetMode(false);
                DialogResult res = frm.ShowDialog();

                if (res == DialogResult.OK)
                {
                    DataRowView currentRow = (DataRowView)this.TableProducts.Current;
                    // взять         
                    if (frm.count > Convert.ToInt32(currentRow["count"].ToString()))
                    {
                        MessageBox.Show("Нет такого количества данных деталей в данной ячейке");
                        dgvProdList_CellContentClick(sender, e);
                    }
                    else
                    {
                        currentRow["count"] = Convert.ToInt32(currentRow["count"].ToString()) - frm.count;
                        LogMes(String.Format("Взято {0} деталей {1} из ячейки {2}.", frm.count, dgvProdList.Rows[e.RowIndex].Cells[0].FormattedValue.ToString(), stacker1.SelectedCellNumber));

                        if (Convert.ToInt32(currentRow["count"].ToString()) == 0)
                            this.TableProducts.RemoveCurrent();
                        this.TableProducts.EndEdit();
                        dgvProdList.Refresh();
                    }
                }
            }
        }

        private void tbDetalFilter_TextChanged(object sender, EventArgs e)
        {
            if (tbDetalFilter.Text == "Фильтр деталей")
                tbDetalFilter.Text = "";
            TableProductlist.Filter = "name Like '%" + tbDetalFilter.Text + "%'";
            cbProducts.Refresh();
        }

        private void StackerBox_Load(object sender, EventArgs e)
        {
            if(!DesignMode)
                loaded = true;
        }
    }
}
