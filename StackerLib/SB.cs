using System;
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

namespace StackerLib
{
    public partial class SB : UserControl
    {
        public SB()
        {
            InitializeComponent();
        }


        private static Service service;
        private static Cpu cpu;
        private static Variable variable;
        private static Utilities utils;
        private String ip = null;
        private int port = 0;
        private Dictionary<string, Variable> Varlist;
        private Command CurrCmd;    // current command with operands
        private bool cmdExecuting = false;  // command executing now
        public static Logger logger;

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


        private void Stackerbox_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                CurrCmd = new Command();
                Connect_Service("serv1");
            }
        }

        private void Connect_Service(String servname)
        {
            Varlist = new Dictionary<string, Variable>();
            utils = new Utilities();
            ShowStatus("PVI service connecting ...");
            service = new Service(servname);
            service.Error += new PviEventHandler(ConnectionError);
            service.Connected += new PviEventHandler(Connect_CPU);
            if ((ip == null) && (port == 0))
            {
                service.Connect();
            }
            else
            {
                service.Connect(ip, port);
            }
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
            cpu = new Cpu(service, "Cpu");
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
                if (!service.IsConnected) service.Connect();
                if (!cpu.IsConnected) cpu.Connect();
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

        private void LogMes(String mes)
        {
         /*   using (System.IO.StreamWriter w = System.IO.File.AppendText(
        System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\" + f_logpath))
            {
                w.WriteLine("--------------------");
                w.WriteLine(DateTime.Now);
                w.WriteLine(mes);
                w.Close();
            }*/
        }

        [DisplayName("Таблица координат")]
        [Description("Таблица координат ячеек")]
        public DataTable TableCoords
        {
            get
            {

                return stacker1.TableCoords;
            }
            set
            {
                
                stacker1.TableCoords = value;

            }
        }

        [DisplayName("Таблица продуктов")]
        [Description("Таблица продуктов по ячейкам")]
        public BindingSource TableProducts
        {
            get;
            set;
        }

        [DisplayName("Ошибки")]
        [Description("Таблица ошибок")]
        public BindingSource BS_Errors
        {
            get;
            set;
        }

        [DisplayName("Ошибки привода")]
        [Description("Таблица ошибок привода")]
        public BindingSource BS_DriveErrors
        {
            get;
            set;
        }


        private BindingSource DT_Productlist;
        [DisplayName("Список продуктов")]
        [Description("Таблица со списком продуктов")]
        public BindingSource TableProductlist
        {
            get {
                return DT_Productlist;
            }
            set {
                DT_Productlist = value;
                if (value != null)
                {
                    cbProducts.DataSource = value;
                    cbProducts.DisplayMember = "name";
                    cbProducts.ValueMember = "id";
                }
            }
        }
        /*
        private void stacker1_OnClickStacker()
        {

        }

        private int stacker1_OnCmdTake(Stackerlib.Stacker s)
        {
            return default(int);
        }

        private int stacker1_OnCmdPut(Stackerlib.Stacker s)
        {
            return default(int);
        }

        private int stacker1_OnGetCellCount(int cellno)
        {
            return default(int);
        }
        */
    }
}
