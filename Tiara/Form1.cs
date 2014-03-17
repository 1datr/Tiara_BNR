using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BR.AN.PviServices;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;



namespace Tiara
{


    public partial class Form1 : Form
    {
        private static Service service;
        private static Cpu cpu;
        private static Variable variable;
        private static Utilities utils;
        private String ip=null; 
        private int port = 0;
        private Dictionary<string, Variable> Varlist;
        private Command CurrCmd;    // current command with operands
        private bool cmdExecuting = false;  // command executing now
        public static Logger logger; 

        private void ShowStatus(String status_str)
        {
            tsl_error.Text = status_str;
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

        private void Connect_CPU(object sender, PviEventArgs e)
        {
            ShowStatus("PVI service connected");
            ShowStatus("PVI CPU connecting ...");
            cpu = new Cpu(service, "Cpu");
            //cpu.Connection.DeviceType = DeviceType.Serial;
            cpu.Connection.DeviceType = DeviceType.TcpIp;
         /*   cpu.Connection.TcpIp.DestinationIpAddress = "127.0.0.1";
            cpu.Connection.TcpIp.DestinationPort = 11160;*/
            cpu.Connection.TcpIp.DestinationIpAddress = ConfigurationManager.AppSettings["PLC_IP"];
            cpu.Connection.TcpIp.DestinationPort = short.Parse(ConfigurationManager.AppSettings["PLC_PORT"]);
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
                            default: tsl_error.Text = "Ошибка " + status.ToString() + ". " + stacker_error_text(status); break;
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
                        gb_commands.Enabled = (mode != 0);
                        String[] mode_capts = { "ПА", "наладка/шаговый", "наладка/ручной" };
                        lblMode.Text = mode_capts[mode];
                        LogMes(mode_capts[mode]);             
                    break;
                case "gOPC.Output.power":
                    power =  Convert.ToBoolean(VarVal("gOPC.Output.power").ToString());
                    LogMes(String.Format("power = "+power.ToString()));      
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
                                this.load(Convert.ToInt32(Varlist["gOPC.Input.src_cell"].Value.ToString()));
                            }
                        }
                        else // выгрузили с поддона
                        {
                            //if (CurrCmd.operand2 > -1)
                            if (!vch_first)
                         //   if (Convert.ToInt32(Varlist["gOPC.Input.dst_cell"].Value.ToString()) != "0")
                            {
                                this.unload(Convert.ToInt32(Varlist["gOPC.Input.dst_cell"].Value.ToString()));
                                
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
                        driveerrorsBindingSource.Filter = "err_id=" + VarVal("gOPC.Output.drivestatus").ToString();
                        if (driveerrorsBindingSource.Count > 0)
                        {
                            DataRowView currentRow = (DataRowView)driveerrorsBindingSource.Current;
                            tbDriveErrText.Text = currentRow["err_text"].ToString();
                        }
                        else tbDriveErrText.Text = "Неизвестная ошибка";
                        LogMes(tbDriveErrText.Text);
                    }
                    break;
                case "gModule1":
                    DrawModule(Varlist["gModule1"],dgvMod1);
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
                    break;
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
            foreach (KeyValuePair<string,Variable> kvp in Varlist)  
            {
                bool varadded = false;
                foreach(DataGridViewRow dgvr in dgvVarlist.Rows)
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
                    if(dgvVarlist.Columns.Count>0)
                        dgvVarlist.Rows.Add(kvp.Key, kvp.Value.Value.ToString(), DateTime.Now);
                }
            }
            //Trigger_State();
        }

    private void DrawModule(Variable v,DataGridView dgv)
    {
        dgv.ReadOnly = true;
        if (dgv.Columns.Count == 0)
        {
            DataGridViewTextBoxColumn col_name = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col_flag = new DataGridViewTextBoxColumn();
            DataGridViewCheckBoxColumn col_checkbox = new DataGridViewCheckBoxColumn();
            col_checkbox.Width = 20;
            dgv.Columns.Add(col_name);
            //dgv.Columns.Add(col_flag);
            dgv.Columns.Add(col_checkbox);
        }
        foreach (Variable member in v.Members)
        {
            
            bool found = false;
            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                if (dgvr.Cells[0].Value == member.Name)
                {
                    if (member.Name == "DI_3")
                    {
                    //    MessageBox.Show("DI_3 = "+member.Value);
                    }
                    dgvr.Cells[1].Value = member.Value;
                    found = true;
                }
             
            }
            if (!found)
            {
                dgv.Rows.Add(member.Name, member.Value);
            }
        }
        dgv.Refresh();
        dgv.Height = dgv.Rows.GetRowsHeight(DataGridViewElementStates.None);
        dgv.Width = dgv.Columns.GetColumnsWidth(DataGridViewElementStates.None);
        dgv.ColumnHeadersVisible = false;
        dgv.RowHeadersVisible = false;
        dgv.ScrollBars = ScrollBars.None;
        

    }

        private void load(int cell) // загрузка из ячейки
        {
            lock (this)
            {
                DataRow[] Rows = this.dbTiaraDataSet.Tables["products"].Select("(cell_id=" + cell.ToString() + ") AND (stacker_id=1)");
                //DataRow[] Rows = ProductsDataSet.Tables["products"].Select("(cell_id=" + cell.ToString() + ") AND (stacker_id=1)");

                for (int i = 0; i < Rows.Length; i++)
                {
                    Rows[i].BeginEdit();
                    Rows[i]["cell_id"] = -1;
                    Rows[i]["changed"] = DateTime.Now;
                    Rows[i].EndEdit();
                    //Rows[i].AcceptChanges();                   
                }

                LogMes("Взято из ячейки " + cell.ToString());
                /*
                ProductsDataSet.Tables["products"].AcceptChanges();                
                ProductsDataSet.AcceptChanges();
                productsTableAdapter1.Update(ProductsDataSet);
                */
                
              /*  this.dbTiaraDataSet.products.AcceptChanges();
                dbTiaraDataSet.AcceptChanges();*/
                productsTableAdapter.Update(dbTiaraDataSet);
                dbTiaraDataSet.AcceptChanges();

                bsPoddon.Filter = bsPoddon.Filter;
                this.bsProductlist.Filter = bsProductlist.Filter;
                //productlistTableAdapter.Update(this.dbTiaraDataSet4);
                stacker1.refresh();
            }
        }
        
        private void unload(int cell)   // выгрузка в ячейку
        {
            lock (this)
            {

                DataRow[] Rows = dbTiaraDataSet.Tables["products"].Select("(cell_id=-1) AND (stacker_id=1)");
                //DataRow[] Rows = ProductsDataSet.Tables["products"].Select("(cell_id=-1) AND (stacker_id=1)");

                for (int i = 0; i < Rows.Length; i++)
                {
                    Rows[i].BeginEdit();
                    Rows[i]["cell_id"] = cell;
                    Rows[i]["changed"] = DateTime.Now;
                    Rows[i].EndEdit();
                  //  Rows[i].AcceptChanges();                    
                }
                LogMes("Помещено в ячейку " + cell.ToString());
                /*
                ProductsDataSet.Tables["products"].AcceptChanges();
                ProductsDataSet.AcceptChanges();
                productsTableAdapter1.Update(ProductsDataSet);
                */
                /*
                this.dbTiaraDataSet.products.AcceptChanges();
                dbTiaraDataSet.AcceptChanges();*/
                productsTableAdapter.Update(dbTiaraDataSet);
                dbTiaraDataSet.AcceptChanges();
                
                bsPoddon.Filter = bsPoddon.Filter;
                this.bsProductlist.Filter = bsProductlist.Filter;
                //productlistTableAdapter.Update(this.dbTiaraDataSet4);
                stacker1.refresh();
                
            }
        }

        private void Trigger_State()
        { 

        // обработка состояния системы
            if (Convert.ToBoolean(VarVal(Varlist["gOPC.Input.load"].Value)) == true) // поддон занят
            {
                if (Convert.ToInt32(VarVal(Varlist["gOPC.Output.status"].Value)) == 1)  // в статусе выполнения команды
                { 
                      
                }
            }
            else
            { 
            
            }
        }
        // Парковать
        private void Park()
        {
            cmdExecuting = true;
            Varlist["gOPC.Input.command"].Value = 0;
            Varlist["gOPC.Input.start"].Value = true;
            CurrCmd.cmdid = 0;
            CurrCmd.operand1 = -1;
            CurrCmd.operand2 = -1;
        }
        // Парковать
        private void Trans(int cellfrom, int cellto)
        {
            cmdExecuting = true;
            Varlist["gOPC.Input.command"].Value = 3;
            Varlist["gOPC.Input.src_cell"].Value = cellfrom;
            Varlist["gOPC.Input.dst_cell"].Value = cellto;
            Varlist["gOPC.Input.start"].Value = true;
            CurrCmd.cmdid = 3;
            CurrCmd.operand1 = cellfrom;
            CurrCmd.operand2 = cellto;
        }
        // Взять из ячейки
        private void TakeFrom(int cell)
        {
            cmdExecuting = true;
            Varlist["gOPC.Input.command"].Value = 1;
            Varlist["gOPC.Input.src_cell"].Value = cell;
            Varlist["gOPC.Input.start"].Value = true;
            CurrCmd.cmdid = 1;
            CurrCmd.operand1 = cell;
            CurrCmd.operand2 = -1;
        }
        // Положить в ячейку
        private void PutTo(int cell)
        {
            cmdExecuting = true;
            Varlist["gOPC.Input.command"].Value = 2;
            Varlist["gOPC.Input.dst_cell"].Value = cell;
            Varlist["gOPC.Input.start"].Value = true;
            CurrCmd.cmdid = 2;
            CurrCmd.operand1 = -1;
            CurrCmd.operand2 = cell;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbTiaraDataSet2.products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter2.Fill(this.dbTiaraDataSet2.products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbTiaraDataSet3.coords". При необходимости она может быть перемещена или удалена.
            this.coordsTableAdapter.Fill(this.dbTiaraDataSet3.coords);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbTiaraDataSet1.products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter1.Fill(this.ProductsDataSet.products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbTiaraDataSet.stacker_errors". При необходимости она может быть перемещена или удалена.
            this.stacker_errorsTableAdapter.Fill(this.dbTiaraDataSet.stacker_errors);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbTiaraDataSet.drive_errors". При необходимости она может быть перемещена или удалена.
            this.drive_errorsTableAdapter.Fill(this.dbTiaraDataSet.drive_errors);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbTiaraDataSet.productlist". При необходимости она может быть перемещена или удалена.
            this.productlistTableAdapter.Fill(this.dbTiaraDataSet.productlist);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbTiaraDataSet.products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.dbTiaraDataSet.products);
            /*
            try
            {
                log = LogManager.GetCurrentClassLogger();

                log.Trace("Version: {0}", Environment.Version.ToString());
                log.Trace("OS: {0}", Environment.OSVersion.ToString());
                log.Trace("Command: {0}", Environment.CommandLine.ToString());

                NLog.Targets.FileTarget tar = (NLog.Targets.FileTarget)LogManager.Configuration.FindTargetByName("run_log");
                tar.DeleteOldFileOnStartup = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ошибка работы с логом!\n" + ex.Message);
            }
           */
           // logger = LogManager.GetCurrentClassLogger();
            
            CurrCmd = new Command();
            Connect_Service("serv1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Park();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.TakeFrom(System.Convert.ToInt32(this.Src_TakeFrom.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.PutTo(System.Convert.ToInt32(this.PutTo_Dest.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Trans(System.Convert.ToInt32(this.Trans_Src.Text), System.Convert.ToInt32(this.Trans_Dst.Text));
        }

        private void stacker1_OnCellSelect(int cellno)
        {
            this.tabChoosenCell.Text = "Ячейка " + cellno.ToString();
            bsProductlist.Filter = "stacker_id=1 AND cell_id="+cellno;
            addDetailGroup.Enabled = (stacker1.is_input(cellno));
            //sqdt_productlist.Update();
            //productsBindingSource.ResumeBinding();
          //  productsBindingSource1.Filter = "cell_id = " + cellno;
          
            //dgvProdList.ReadOnly = !(stacker1.is_poddon(cellno));
            dgvProdList.Columns[1].Visible = (stacker1.is_input(cellno));
            dgvProdList.Columns[2].Visible = (stacker1.is_poddon(cellno));

            tabCellinfo.SelectedIndex = 0;
            //productsBindingSource1.
        }

        private int stacker1_OnGetCellCount(int cellno)
        {

           // DataRow[] Rows = ProductsDataSet.Tables["products"].Select("stacker_id=1 AND cell_id = " + cellno);
            DataRow[] Rows = dbTiaraDataSet.Tables["products"].Select("stacker_id=1 AND cell_id = " + cellno);
            return Rows.Length;
        }

        private void button5_Click(object sender, EventArgs e)
        {
         //   bsSearch.Filter = "Convert ([prodname],'System.String') Like '%" + tbSearchStr.Text + "%'";
            DataTable products = dbTiaraDataSet.Tables["products"];
            DataTable productlist = dbTiaraDataSet.Tables["productlist"];
            /*var result_rows = from r in products.AsEnumerable() 
                              where r.cell_id = 1
                              select r;*/
           /* var result_rows =
               from r in dbTiaraDataSet.Tables["products"].AsEnumerable()
               join p in dbTiaraDataSet.Tables["productlist"].AsEnumerable()
               on r.Field<int>("product_id") equals p.Field<int>("id")
               where r.Field<int>("stacker_id") == 1
               select r;*/
            var result_rows = 
                from r in dbTiaraDataSet.products    
                join p in dbTiaraDataSet.productlist  
                on r.product_id equals p.id
                where r.stacker_id == 1
                && p.name.ToLower().Contains(tbSearchStr.Text)
                select new { r.cell_id, p.name, r.count, r.changed };
            dgvSearch.Rows.Clear();
            foreach (var row in result_rows)
            {
                dgvSearch.Rows.Add(row.cell_id.ToString(), row.name.ToString(), row.count.ToString(), row.changed.ToString());
                //Console.WriteLine("{0} bought {1}", group.Name, group.Product);
            }
        }
        //
        private void button1_Click_1(object sender, EventArgs e)
        {
            cmdManager1.AddCommand(0);
        }
        //
        private void button2_Click_1(object sender, EventArgs e)
        {
            try {
                cmdManager1.AddCommand(1, Convert.ToInt32(this.Src_TakeFrom.Text));
            }
            catch (System.Exception ex) { }
            
            /*
            if (System.Convert.ToInt32(this.VarVal("gOPC.Output.status")) == 0)
                this.TakeFrom(Convert.ToInt32(this.Src_TakeFrom.Text));*/
        }
        //
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmdManager1.AddCommand(2,-1,Convert.ToInt32(this.PutTo_Dest.Text));
            }
            catch (System.Exception ex) { }
            /*
            if (System.Convert.ToInt32(this.VarVal("gOPC.Output.status")) == 0)
            
                this.PutTo(Convert.ToInt32(this.PutTo_Dest.Text));*/
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
        //
        private void button4_Click_1(object sender, EventArgs e)
        {
            Trans();
        }
               
        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            /*dgvProdList.Rows[e.RowIndex].Cells["stacker_id"].Value = this.stacker1.SelectedCellNumber;
            dgvProdList.Rows[e.RowIndex].Cells["cell_id"].Value = 1;*/
        }


        public class Command
        {
            public int cmdid=-1;
            public int operand1=-1;
            public int operand2=-1;
        }

        public class ProductRec
        {
            public int stacker_id;
            public int cell_id;
            public string prodname;
            public int count;
            public DateTime changed;
        }

        private void productsBindingSource1_AddingNew(object sender, AddingNewEventArgs e)
        {
            /*ProductRec prodrec = new ProductRec();
            prodrec.cell_id = stacker1.SelectedCellNumber;
            prodrec.stacker_id = 1;
            e.NewObject = prodrec;*/
           // e.NewObject = productsBindingSource1.
        }

        private void productsBindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (bsProductlist.Current == null) return;
            /*
            object theitem = bsProductlist.Current;
            if (!bsProductlist.AllowEdit) return;
            if (theitem.GetType() == typeof(DataRowView))
            {
                DataRowView dr = ((DataRowView)bsProductlist.Current);
                //DataRowView dr = ((DataRowView)theitem);
                if (dr != null)
                {
                    dr["stacker_id"] = 1;
                    dr["cell_id"] = this.stacker1.SelectedCellNumber;
                    dr["changed"] = DateTime.Now;
                }
            }
            else
            {
                CurrencyManager cmgr = bsProductlist.CurrencyManager;
                DataRow dr = ((DataRowView)cmgr.Current).Row;
                //DataRowView dr = ((DataRowView)theitem);             

                dr["stacker_id"] = 1;
                dr["cell_id"] = this.stacker1.SelectedCellNumber;
                dr["changed"] = DateTime.Now;

            }
            */
          //  productsTableAdapter.Update(this.dbTiaraDataSet);
        }

        private void productsBindingSource1_CurrentItemChanged(object sender, EventArgs e)
        {
            //this.sqdt_productlist.Update();
           /* DataRow dr = (DataRow)this.productsBindingSource1.Current;
            if (dr != null)
            {
                dr["stacker_id"] = 1;
                dr["cell_id"] = this.stacker1.SelectedCellNumber;
            }*/
            
        }

        private void sqdt_productlist_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            
            /*if(e.Row!=null)
                sqLiteDataAdapter1.Update(this.sqdt_productlist);*/
           // this.dataSet1.AcceptChanges();
            productlistTableAdapter.Update(this.dbTiaraDataSet);
            stacker1.refresh();
        }

        private void productsBindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            //this.dataSet1.AcceptChanges();
            productsTableAdapter.Update(this.dbTiaraDataSet);
            stacker1.refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            productlistTableAdapter.Update(this.dbTiaraDataSet);
        }

        private void tbSearchStr_TextChanged(object sender, EventArgs e)
        {
          //  bsSearch.Filter = "Convert ([prodname],'System.String') Like '%" + tbSearchStr.Text + "%'";
        }

        private void dgvProdList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            productlistTableAdapter.Update(this.dbTiaraDataSet);
        }

        private void bsProductlist_AddingNew(object sender, AddingNewEventArgs e)
        {
            
        }

        private void bsProductlist_CurrentItemChanged(object sender, EventArgs e)
        {
            DataRowView currentRow = (DataRowView)bsProductlist.Current;
            if (currentRow != null)
            {
                currentRow["stacker_id"] = 1;
                currentRow["cell_id"] = stacker1.SelectedCellNumber;
            }
            productlistTableAdapter.Update(this.dbTiaraDataSet);
        }

        private void bsPoddon_ListChanged(object sender, ListChangedEventArgs e)
        {
            //productsTableAdapter.Update(this.dbTiaraDataSet);
        }

        private void bsPoddon_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            LogMes(e.Exception.Message);
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

        private void button6_Click_1(object sender, EventArgs e)
        {
            
        }

        private void OpenVnc(object sender, EventArgs e)
        {
            Vnc vncform = new Vnc();
           
            vncform.Show();
        }

        

        private void button6_Click_2(object sender, EventArgs e)
        {
            Varlist["gOPC.Input.ack"].Value = true;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            int maxcnt = 12;
            int i = 0;
            while((VarVal("gOPC.Output.drivestatus").ToString()!="0") && (i<maxcnt))
            {
                Varlist["gOPC.Input.driveack"].Value = true;
                i++;
                System.Threading.Thread.Sleep(100);
            }
        }

        private void makeerrortable()
        {
            XmlTextReader reader = new XmlTextReader("LoaderAlarms.xml");
            int n = 50000 - 1;
            while (reader.Read())
            {

                if (reader.Name != "Text") continue;
                else n++;
              
                string elem_id = reader.GetAttribute(0);
                string elem_value = reader.GetAttribute(1);
                int idx = elem_value.IndexOf(' ');
                if (idx < 0) continue;
                elem_value = elem_value.Substring(idx + 1);

                stackererrorsBindingSource.AddNew();
                DataRowView currentRow = (DataRowView)stackererrorsBindingSource.Current;
                currentRow["err_id"] = n;
                currentRow["err_text"] = elem_value;
                stackererrorsBindingSource.EndEdit();

            }
        }

        private void make_coord_table()
        {
            XmlTextReader reader = new XmlTextReader("config.xml");
            int n = 50000 - 1;
            while (reader.Read())
            {

                if (reader.Name != "cell") continue;
                else n++;

                if (reader.AttributeCount == 0) continue;

                string elem_id = reader.GetAttribute("ID");
                string elem_x = reader.GetAttribute("X");
                string elem_y = reader.GetAttribute("Y");
                string elem_z = reader.GetAttribute("Z");

                this.coordsBindingSource.AddNew();
                DataRowView currentRow = (DataRowView)coordsBindingSource.Current;
                currentRow["ncell"] = Convert.ToInt32(elem_id);
                currentRow["x"] = Convert.ToInt32(elem_x);
                currentRow["y"] = Convert.ToInt32(elem_y);
                currentRow["z"] = Convert.ToInt32(elem_z);
                coordsBindingSource.EndEdit();
               /*

                stackererrorsBindingSource.AddNew();
                DataRowView currentRow = (DataRowView)stackererrorsBindingSource.Current;
                currentRow["err_id"] = n;
                currentRow["err_text"] = elem_value;
                stackererrorsBindingSource.EndEdit();*/

            }
        }


        private string stacker_error_text(int errcode)
        {
            stackererrorsBindingSource.Filter = "err_id=" + errcode.ToString();
            if (stackererrorsBindingSource.Current == null) return null;
            DataRowView currentRow = (DataRowView)stackererrorsBindingSource.Current;
            return currentRow["err_text"].ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //case 1: tsl_error.Text = "Штабелер находиться в состоянии выполнения команды"; break;(0);
        }

        private void errorsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void stackererrorsBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            
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
                    lblCPUStatus.Text = "Unknown";
                    break;
            }
        }

        private void dgvMod9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tabPoddon_Layout(object sender, LayoutEventArgs e)
        {
            bsPoddon.Filter = bsPoddon.Filter;
            //dgvTelezhka.DataSource = dgvTelezhka.DataSource;
        }

        private void bsProductlist_CurrentChanged(object sender, EventArgs e)
        {
            DataRowView currentRow = (DataRowView)bsPoddon.Current;   
            if(currentRow!=null)
                currentRow["changed"] = DateTime.Now;
        }

        private void bsProducts_ListChanged(object sender, ListChangedEventArgs e)
        {
            productsTableAdapter.Update(this.dbTiaraDataSet);
            //this.productsTableAdapter2.Fill(this.dbTiaraDataSet4.products);
           
            this.stacker1.refresh();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            stacker1.refresh();
        }

        private void productlistBindingSource2_ListChanged(object sender, ListChangedEventArgs e)
        {
            productlistTableAdapter.Update(dbTiaraDataSet);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            productsTableAdapter.Update(this.dbTiaraDataSet);
        }

        private void dgvSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvSearch.CurrentRow == null) return;
            int currrowidx = dgvSearch.CurrentRow.Index;
            int cellno = Convert.ToInt32(dgvSearch.Rows[currrowidx].Cells[0].Value.ToString());
            stacker1.SelectCell(cellno);
            this.tabControl1.SelectedIndex = 0;            
        }

        private void Trans_Dst_Enter(object sender, EventArgs e)
        {
            Trans();
        }

        private void LogMes(String mes)
        {
        using (System.IO.StreamWriter w = System.IO.File.AppendText(
    System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) +
    "\\tiara.log"))
  {
    w.WriteLine("--------------------");
    w.WriteLine(DateTime.Now);
    w.WriteLine(mes);
    w.Close();
  }
}

        private void dgvProdList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //  int currentRow = int.Parse(e.RowIndex.ToString());
            if (!stacker1.is_poddon(stacker1.SelectedCellNumber)) return;
            if (e.ColumnIndex == 1)
            {
                frmAddTake frm = new frmAddTake();
                
                frm.SetMode(true);
                DialogResult res =  frm.ShowDialog();
                
                if (res == DialogResult.OK)
                { 
                    // добавить
                    DataRowView currentRow = (DataRowView)this.bsProductlist.Current;
                    currentRow["count"] = Convert.ToInt32(currentRow["count"].ToString()) + frm.count;
                    this.bsProductlist.EndEdit();
                    dgvProdList.Refresh();
                    LogMes(String.Format("Добавлено {0} деталей {1} в ячейку {2}.", frm.count, dgvProdList.Rows[e.RowIndex].Cells[0].FormattedValue.ToString(),stacker1.SelectedCellNumber));
                }
            }
            else if (e.ColumnIndex == 2)
            {
                frmAddTake frm = new frmAddTake();
                
                frm.SetMode(false);
                DialogResult res = frm.ShowDialog();

                if (res == DialogResult.OK)
                {
                    DataRowView currentRow = (DataRowView)this.bsProductlist.Current;
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
                            this.bsProductlist.RemoveCurrent();
                        this.bsProductlist.EndEdit();
                        dgvProdList.Refresh();
                    }
                }
            }

        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            try
            {
                DataRow[] Rows = dbTiaraDataSet.products.Select("stacker_id=1 AND cell_id=" + stacker1.SelectedCellNumber.ToString() + " AND product_id=" + cbProducts.SelectedValue.ToString());
                if (Rows.Length > 0)
                {
                    Rows[0].BeginEdit();
                    int adding = 0;
                    if (tbProdCount.Text == "")                    
                        adding = 1;
                    else
                        adding = Convert.ToInt32(tbProdCount.Text);
                    Rows[0]["count"] = Convert.ToInt32(Rows[0]["count"]) + adding;
                    Rows[0].EndEdit();
                    LogMes(String.Format("Добавлено {0} деталей {1} в ячейку {2}.", adding, cbProducts.Text, stacker1.SelectedCellNumber));
                }
                else
                {
                    DataRowView currentRow = (DataRowView)this.bsProductlist.AddNew();
                    currentRow["cell_id"] = stacker1.SelectedCellNumber;
                    currentRow["stacker_id"] = 1;
                    currentRow["changed"] = DateTime.Now;
                    currentRow["product_id"] = Convert.ToInt32(cbProducts.SelectedValue.ToString());
                    if (tbProdCount.Text != "")
                     /*   currentRow["count"] = 0;
                    else*/
                        currentRow["count"] = Convert.ToInt32(tbProdCount.Text);
                    if (Convert.ToInt32(currentRow["count"].ToString()) <= 0)
                        this.bsProductlist.RemoveCurrent();
                    this.bsProductlist.EndEdit();
                    LogMes(String.Format("Добавлено {0} деталей {1} в ячейку {2}.", Convert.ToInt32(tbProdCount.Text), cbProducts.Text, stacker1.SelectedCellNumber));                    
                }
                
                dgvProdList.Refresh();
            }
            catch (System.Exception ex)
            { }
        }

        private int stacker1_OnCmdTake(Stackerlib.Stacker s)
        {
            try
            {
                cmdManager1.AddCommand(1, this.stacker1.SelectedCellNumber);
            }
            catch (System.Exception ex) {
                MessageBox.Show(ex.Message);
            }
            /*
            if (System.Convert.ToInt32(this.VarVal("gOPC.Output.status")) == 0)
                this.TakeFrom(this.stacker1.SelectedCellNumber);*/
            return default(int);
        }

        private int stacker1_OnCmdPut(Stackerlib.Stacker s)
        {
            try
            {
                cmdManager1.AddCommand(2, -1, this.stacker1.SelectedCellNumber);
            }
            catch (System.Exception ex) { }
            /*
            if (System.Convert.ToInt32(this.VarVal("gOPC.Output.status")) == 0)
                this.PutTo(this.stacker1.SelectedCellNumber);
            return default(int);
             * */
            return 0;
        }

        private void rectangleShape1_Paint(object sender, PaintEventArgs e)
        {
            rectangleShape1.BackColor = stacker1.StyleInput.BackColor;
            rectangleShape1.Size = new System.Drawing.Size(rectangleShape3.Size.Width, rectangleShape3.Size.Height);
            rectangleShape2.Size = new System.Drawing.Size(rectangleShape3.Size.Width, rectangleShape3.Size.Height);
            rectangleShape1.Top = rectangleShape3.Top;
            rectangleShape2.Top = rectangleShape3.Top;

            label13.Left = rectangleShape1.Left + rectangleShape1.Width + 6;
            //label13.Top = label13.Top + 3;
            label14.Left = rectangleShape2.Left + rectangleShape1.Width + 6;
            label14.Top = label13.Top;
            label15.Left = rectangleShape3.Left + rectangleShape1.Width + 6;
            label15.Top = label13.Top;
        }

        private void rectangleShape2_Paint(object sender, PaintEventArgs e)
        {
            rectangleShape2.BackColor = stacker1.StylePoddon.BackColor;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            make_coord_table();
        }

        private void coordsBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            coordsTableAdapter.Update(dbTiaraDataSet3);
        }

        private bool stacker1_OnIsReady()
        {
            //return (System.Convert.ToInt32(this.VarVal("gOPC.Output.status")) == 0);
            return true;
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int ncell = Convert.ToInt32(dgvSearch.Rows[e.RowIndex].Cells[0].Value.ToString());

                try
                {
                    cmdManager1.AddCommand(1, ncell);
                }
                catch (System.Exception ex) { }

            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        

        private string cmdManager1_OnGetCmdCaption(int cmd, int op1, int op2)
        {
            switch (cmd)
            {
                case 0: return "Парковать";
                case 1: return "Взять";
                case 2: return "Положить";
                case 3: return "Переложить";
            }
            return default(string);
        }

        private bool cmdManager1_OnExe(int cmd, int op1, int op2)
        {
            

            Varlist["gOPC.Input.command"].Value = cmd;
            if(op1!=-1)
                Varlist["gOPC.Input.src_cell"].Value = op1;
            if(op2!=-1)
                Varlist["gOPC.Input.dst_cell"].Value = op2;
            Varlist["gOPC.Input.start"].Value = true;

            LogMes(String.Format("Запущена команда {0}({1}{2})",cmd,op1,op2));
            return default(bool);
        }

        private bool cmdManager1_OnGetReady(int cmd, int op1, int op2)
        {            
            return (System.Convert.ToInt32(this.VarVal("gOPC.Output.status")) == 0);
        }

        private void stacker1_OnClickStacker()
        {
            tabCellinfo.SelectedIndex = 1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvMod10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage7_Enter(object sender, EventArgs e)
        {
            frmAuthSpec auth = new frmAuthSpec();
            if (auth.ShowDialog() != DialogResult.OK)
            {
                tabControl2.SelectedIndex = 0;
            }
        }

        private void button10_Click_2(object sender, EventArgs e)
        {
            productsTableAdapter2.Update(this.dbTiaraDataSet2);
            /*
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbTiaraDataSet2.products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter2.Fill(this.dbTiaraDataSet2.products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbTiaraDataSet3.coords". При необходимости она может быть перемещена или удалена.
            this.coordsTableAdapter.Fill(this.dbTiaraDataSet3.coords);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbTiaraDataSet1.products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter1.Fill(this.ProductsDataSet.products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbTiaraDataSet.stacker_errors". При необходимости она может быть перемещена или удалена.
            this.stacker_errorsTableAdapter.Fill(this.dbTiaraDataSet.stacker_errors);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbTiaraDataSet.drive_errors". При необходимости она может быть перемещена или удалена.
            this.drive_errorsTableAdapter.Fill(this.dbTiaraDataSet.drive_errors);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbTiaraDataSet.productlist". При необходимости она может быть перемещена или удалена.
            this.productlistTableAdapter.Fill(this.dbTiaraDataSet.productlist);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbTiaraDataSet.products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.dbTiaraDataSet.products);*/
        }

        private void productsBindingSource1_ListChanged_1(object sender, ListChangedEventArgs e)
        {
            //productsTableAdapter.Update(this.dbTiaraDataSet);
        }

        private void cmdManager1_OnAddCommand(String cmdstr, int op1, int op2)
        {
            LogMes(String.Format("Added command {0}({1}, {2})", cmdstr, op1, op2));
            
        }

        private void cmdManager1_OnExeCommand(string cmdstr, int op1, int op2)
        {
           LogMes(String.Format("Start execute command {0}({1}, {2})", cmdstr, op1, op2));
        }

        private void cmdManager1_OnDeleteCommand(string cmdstr, int op1, int op2)
        {
            LogMes(String.Format("Deleted command {0}({1}, {2})", cmdstr, op1, op2));
        }

        private void productsBindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {

        }
    }
}
