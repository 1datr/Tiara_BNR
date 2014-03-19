using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BR.AN.PviServices;

namespace Stackerlib
{

    public enum CoordType
    {
        CoordX, CoordY, CoordZ
    }
    // тип события установилось соединение
    public delegate void OnConnected();
    // тип события ошибка соединения с ПЛК
    public delegate void OnConnectError(PviEventArgs e);
    // тип события ошибка штабелера
    public delegate void OnStackerError(String errstr, int errcode);
    // При изменении координат штабелера
    public delegate void OnCoordChange(CoordType coordtype, int value);
    // Поддон загружен/разгружен
    public delegate void OnLoadedUnloaded(int cellno);

    public delegate void OnVarChanged(Variable var);

    public interface IStackerman
    {
        // OnConnected
        event OnConnected OnConnected;
        //
        event OnConnectError OnConnectError;
        //
        event OnStackerError OnStackerError;
        // При изменении координаты
        event OnCoordChange OnCoordChange;
        // Поддон загружен
        event OnLoadedUnloaded OnLoaded;
        // Поддон разгружен
        event OnLoadedUnloaded OnUnloaded;

        void connect_plc();
    }

    public partial class Satckerman : Component,IStackerman
    {
        public Satckerman()
        {
            InitializeComponent();
        }

        public Satckerman(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        
        // OnConnected
        private OnConnected OnConnected_hndlr;
        [DisplayName("При соединении")]
        [Description("При соединении с ПЛК")]
        public event OnConnected OnConnected
        {
            add { lock (this) { OnConnected_hndlr += value; } }
            remove { lock (this) { OnConnected_hndlr -= value; } }
        }
        //
        private OnConnectError OnConnectError_hndlr;
        [DisplayName("При ошибке")]
        [Description("При ошибке соединения с ПЛК")]
        public event OnConnectError OnConnectError
        {
            add { lock (this) { OnConnectError_hndlr += value; } }
            remove { lock (this) { OnConnectError_hndlr -= value; } }
        }
        //
        private OnStackerError OnStackerError_hndlr;
        [DisplayName("Ошибка штабелера")]
        [Description("При ошибке штабелера")]
        public event OnStackerError OnStackerError
        {
            add { lock (this) { OnStackerError_hndlr += value; } }
            remove { lock (this) { OnStackerError_hndlr -= value; } }
        }
        // При изменении координаты
        private OnCoordChange OnCoordChange_hndlr;
        [DisplayName("Изменение координат")]
        [Description("При изменении координат")]
        public event OnCoordChange OnCoordChange
        {
            add { lock (this) { OnCoordChange_hndlr += value; } }
            remove { lock (this) { OnCoordChange_hndlr -= value; } }
        }
        
        // При изменении значения переменной
        private OnVarChanged OnVarChanged_hndlr;
        [DisplayName("Изменение переменных")]
        [Description("При изменении переменной")]
        public event OnVarChanged OnVarChanged
        {
            add { lock (this) { OnVarChanged_hndlr += value; } }
            remove { lock (this) { OnVarChanged_hndlr -= value; } }
        }


        // При загрузке поддона
        private OnLoadedUnloaded OnLoaded_hndlr;
        [DisplayName("Загрузка поддона")]
        [Description("После загрузки поддона")]
        public event OnLoadedUnloaded OnLoaded
        {
            add { lock (this) { OnLoaded_hndlr += value; } }
            remove { lock (this) { OnLoaded_hndlr -= value; } }
        }

        // При выгрузке поддона
        private OnLoadedUnloaded OnUnloaded_hndlr;
        [DisplayName("Разгрузка поддона")]
        [Description("После выгрузки поддона")]
        public event OnLoadedUnloaded OnUnloaded
        {
            add { lock (this) { OnUnloaded_hndlr += value; } }
            remove { lock (this) { OnUnloaded_hndlr -= value; } }
        }

        private static Service service;
        private static Cpu cpu;
        private Dictionary<string, Variable> Varlist;

        private String fservname = "plc1";
        [DisplayName("Имя сервиса")]
        [Description("Имя сервиса PVI")]
        public String servname { get { return fservname; } set { fservname = value; } }

        private String f_ip = null;
        [DisplayName("IP")]
        [Description("IP PVI-сервиса")]
        public String ip { get { return f_ip; } set { f_ip = value; } }

        private int f_port = 11160;
        [DisplayName("Порт")]
        [Description("Порт PVI-сервиса")]
        public int port { get { return f_port; } set { f_port = value; } }

        [DisplayName("IP ПЛК")]
        [Description("IP-адрес ПЛК")]   
        public String plc_ip { get; set; }
        [DisplayName("Порт ПЛК")]
        [Description("Порт ПЛК")]   
        public int plc_port { get; set; }

        public void connect_plc()
        {
            Varlist = new Dictionary<string, Variable>();
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

        private void ConnectionError(object sender, PviEventArgs e)
        {
            /*this.tsl_error.Text = String.Format("Error:{0} ({1})", e.ErrorText, e.ErrorCode);

            out_cpu_state();*/
            if (this.OnConnectError_hndlr != null)
                OnConnectError_hndlr(e);
            if (!service.IsConnected) service.Connect();
            if (!cpu.IsConnected) cpu.Connect();
            //Application.Exit();
        }

        private void Connect_CPU(object sender, PviEventArgs e)
        {            
            if (cpu == null)
                cpu = new Cpu(service, fservname + ".Cpu");
            //cpu.Connection.DeviceType = DeviceType.Serial;
            cpu.Connection.DeviceType = DeviceType.TcpIp;
            /*   cpu.Connection.TcpIp.DestinationIpAddress = "127.0.0.1";
               cpu.Connection.TcpIp.DestinationPort = 11160;*/
            cpu.Connection.TcpIp.DestinationIpAddress = this.plc_ip;
            cpu.Connection.TcpIp.DestinationPort = short.Parse(plc_port.ToString());
            /*
            cpu.Connection.TcpIp.DestinationIpAddress = "192.168.1.200";
            cpu.Connection.TcpIp.DestinationPort = 11159;*/
            //cpu.Connection.Serial.Channel = 1;
            cpu.Error += new PviEventHandler(ConnectionError);
            cpu.Connected += new PviEventHandler(Connect_Vars);
            //Console.WriteLine("Connecting Cpu ...");
            cpu.Connect();
        }

        private void Connect_Vars(object sender, PviEventArgs e)
        {
            if (this.OnConnected_hndlr != null)
                OnConnected_hndlr();
           /* ShowStatus("PVI CPU connected");
            ShowStatus("PVI variables connecting ...");
            */
            
            AddVar("gOPC.Output.Xpos");
            AddVar("gOPC.Output.Ypos");
            AddVar("gOPC.Output.Zpos");
            AddVar("gOPC.Output.load");
            
            AddVar("gOPC.Output.status");
            AddVar("gOPC.Output.drivestatus");
            AddVar("gOPC.Output.power");
            AddVar("gOPC.Output.Mode");
            /*
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
            */
            AddVar("gOPC.Input.ack");
            AddVar("gOPC.Input.driveack");
            AddVar("gOPC.Input.start");
            AddVar("gOPC.Input.src_cell");
            AddVar("gOPC.Input.dst_cell");
            AddVar("gOPC.Input.command");
            AddVar("gOPC.Input.power");

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

        private void variables_Connected(object sender, PviEventArgs e)
        {
           // ShowStatus("PVI variables connected");
            // Console.WriteLine("Variable Connected Error=" + e.ErrorCode.ToString());
            if (Varlist.ContainsKey("gOPC.Input.power"))
                Varlist["gOPC.Input.power"].Value = true;
          //  gb_commands.Enabled = true;
        }

        // Отслеживание значений переменных
        private int status = 0;
        private bool power = false;
        private int mode = 0;
        private bool vch_first = true;
        private bool cmdExecuting = false;

        // Get variable value 
        private object VarVal(String Varname)
        {
            return Varlist[Varname].Value;
        }

        private void ValueChanged(object sender, VariableEventArgs e)
        {
            Variable var = (Variable)sender;
            if (this.OnVarChanged_hndlr != null)
                OnVarChanged_hndlr(var);

            //out_cpu_state();
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
                               /* tsl_error.Text = "Штабелер готов к выполнению команды";
                                this.cmdManager1.EndCommand();*/
                                break;
                            case 1: /*tsl_error.Text = "Штабелер находиться в состоянии выполнения команды";*/ break;
                            case 2: /*tsl_error.Text = "Штабелер не готов выполненять команду";*/ break;
                            default: /*tsl_error.Text = "Ошибка " + status.ToString() + ". " + stacker_error_text(status);*/ break;
                        
                        }
                       // LogMes(tsl_error.Text);
                       /* if (gb_commands.Enabled)
                        {
                            CurrCmd.cmdid = 0;
                            CurrCmd.operand1 = 0;
                            CurrCmd.operand2 = 0;
                        }*/
                    }
                    break;
                case "gOPC.Output.Mode":
                    mode = Convert.ToInt32(VarVal("gOPC.Output.Mode").ToString());
                   // gb_commands.Enabled = (mode != 0);
                    String[] mode_capts = { "ПА", "наладка/шаговый", "наладка/ручной" };
                  /*  lblMode.Text = mode_capts[mode];
                    LogMes(mode_capts[mode]);*/
                    break;
                case "gOPC.Output.power":
                    power = Convert.ToBoolean(VarVal("gOPC.Output.power").ToString());
                   // LogMes(String.Format("power = " + power.ToString()));
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
                                if (this.OnLoaded_hndlr != null)
                                    OnLoaded_hndlr(Convert.ToInt32(Varlist["gOPC.Input.src_cell"].Value.ToString()));
                              //  this.load(Convert.ToInt32(Varlist["gOPC.Input.src_cell"].Value.ToString()));
                            }
                        }
                        else // выгрузили с поддона
                        {
                            //if (CurrCmd.operand2 > -1)
                            if (!vch_first)
                            //   if (Convert.ToInt32(Varlist["gOPC.Input.dst_cell"].Value.ToString()) != "0")
                            {
                                if (this.OnUnloaded_hndlr != null)
                                    OnUnloaded_hndlr(Convert.ToInt32(Varlist["gOPC.Input.dst_cell"].Value.ToString()));
                               // this.unload(Convert.ToInt32(Varlist["gOPC.Input.dst_cell"].Value.ToString()));

                            }
                        }
                        vch_first = false;
                        //stacker1.TriggerStacker(load);
                    }
                    break;
                case "gOPC.Output.Xpos":
                    /*stacker1.SetX(Convert.ToInt32(VarVal("gOPC.Output.Xpos")));
                    lblPosition.Text = "X:" + VarVal("gOPC.Output.Xpos") + " Y:" + VarVal("gOPC.Output.Ypos") + " Z:" + VarVal("gOPC.Output.Zpos");
                    */break;
                case "gOPC.Output.Ypos":
                    /*stacker1.SetY(Convert.ToInt32(VarVal("gOPC.Output.Ypos")));
                    lblPosition.Text = "X:" + VarVal("gOPC.Output.Xpos") + " Y:" + VarVal("gOPC.Output.Ypos") + " Z:" + VarVal("gOPC.Output.Zpos");
                    */break;
                case "gOPC.Output.Zpos":
                    /*stacker1.SetZ(Convert.ToInt32(VarVal("gOPC.Output.Zpos")));
                    lblPosition.Text = "X:" + VarVal("gOPC.Output.Xpos") + " Y:" + VarVal("gOPC.Output.Ypos") + " Z:" + VarVal("gOPC.Output.Zpos");
                   */ break;
                case "gOPC.Output.drivestatus":
                    /*lblDrivestatus.Text = "Drive status is " + VarVal("gOPC.Output.drivestatus");
                    if (VarVal("gOPC.Output.drivestatus").ToString() == "0")
                    {
                        tbDriveErrText.Text = "";
                    }
                    else
                    {
                        driveerrorsBindingSource.Filter = "err_id=" + VarVal("gOPC.Output.drivestatus").ToString();
                        if (driveerrorsBindingSource.Count > 0)
                        {
                            DataRowView currentRow = (DataRowView)driveerrorsBindingSource.Current;
                            tbDriveErrText.Text = currentRow["err_text"].ToString();
                        }
                        else tbDriveErrText.Text = "Неизвестная ошибка";
                        LogMes(tbDriveErrText.Text);
                    }*/
                    break;
                /*case "gModule1":
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
            }*/
            //Trigger_State();
        }


    }
}
