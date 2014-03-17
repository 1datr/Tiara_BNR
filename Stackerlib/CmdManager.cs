using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stackerlib
{
    public delegate String OnGetCmdCaption(int cmd, int op1, int op2);
    public delegate void CmdManagerEvent(String cmdstr, int op1, int op2);

    public partial class CmdManager : UserControl
    {
        public CmdManager()
        {
            InitializeComponent();
            CmdList = new List<StackerCmd>();
            //this.Width = this.dgvCmdlist.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed)+5;
        }

        private void ExeCmd()
        {
            if (this.OnExe_hndlr != null)
            {
                if (CmdList.Count - 1 >= currCmdPtr)
                {
                    if (this.OnGetReady_hndlr(CmdList[currCmdPtr].cmd, CmdList[currCmdPtr].op1, CmdList[currCmdPtr].op2))
                    {
                        this.OnExe_hndlr(CmdList[currCmdPtr].cmd, CmdList[currCmdPtr].op1, CmdList[currCmdPtr].op2);

                        String cmdcapt = "";
                        if (this.OnExeCommand_hndlr != null)
                            cmdcapt = OnGetCmdCaption_hndlr(CmdList[currCmdPtr].cmd, CmdList[currCmdPtr].op1, CmdList[currCmdPtr].op2);
                        else
                            cmdcapt = CmdList[currCmdPtr].cmd.ToString();
                        OnExeCommand_hndlr(cmdcapt, CmdList[currCmdPtr].op1, CmdList[currCmdPtr].op2);
                    }
                }
            }
        }

        private List<StackerCmd> CmdList; // список команд
        private int currCmdPtr = 0; // Индекс текущей выполняемой команды

        public void EndCommand()
        {
            if (CmdList.Count-1 >= currCmdPtr)
            {
                CmdList.RemoveAt(currCmdPtr);
                this.Refresh();
                this.ExeCmd();
            }
        }

        public void AddCommand(int cmd, int op1=-1, int op2=-1)
        {
            StackerCmd c = new StackerCmd(cmd, op1, op2);
            CmdList.Add(c);

            if (OnAddCommand_hndlr != null)
            {
                String cmdcapt = "";
                if (this.OnGetCmdCaption_hndlr != null)
                    cmdcapt = OnGetCmdCaption_hndlr(cmd, op1, op2);
                else
                    cmdcapt = c.cmd.ToString();
                OnAddCommand_hndlr(cmdcapt, op1, op2);
            }
            Refresh();
            ExeCmd();
        }

        // обновить список
        private void Refresh()
        {
            int idx = 0;
            
            foreach (StackerCmd c in CmdList)
            {
                String cmdcapt = "";
                if (this.OnGetCmdCaption_hndlr != null)
                    cmdcapt = OnGetCmdCaption_hndlr(c.cmd, c.op1, c.op2);
                else
                    cmdcapt = c.cmd.ToString();

                String op1str = "";
                if(c.op1!=-1) op1str=c.op1.ToString();

                String op2str = "";
                if(c.op2!=-1) op2str=c.op2.ToString();

                if (dgvCmdlist.Rows.Count - 1 < idx)
                    dgvCmdlist.Rows.Add(cmdcapt, op1str, op2str);
                else
                {
                    dgvCmdlist.Rows[idx].Cells[0].Value = cmdcapt;
                    dgvCmdlist.Rows[idx].Cells[1].Value = op1str;
                    dgvCmdlist.Rows[idx].Cells[2].Value = op2str;
                }
                
                    for (int i = 0; i < 5; i++)
                    {
                        DataGridViewCellStyle dgvc = dgvCmdlist.Rows[idx].Cells[i].Style;
                        if (idx == currCmdPtr)

                            dgvc.BackColor = Color.LightGreen;
                        else
                            dgvc.BackColor = Color.White;
                        dgvCmdlist.Rows[idx].Cells[i].Style = dgvc;
                    }
                
                idx++;
            }
            // Удаляем лишнее
            for (int i = idx; i < dgvCmdlist.Rows.Count; i++)
            {
                dgvCmdlist.Rows.RemoveAt(i);
            }
            //this.Width = this.dgvCmdlist.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed)+5;
        }

        // проверяет готов ли к выполнению команды
        private OnGetReady OnGetReady_hndlr;
        [DisplayName("Получение готовности к выполнению команды")]
        [Description("Функция получения готовности к выполнению команды")] 
        public event OnGetReady OnGetReady
        {
            add { lock (this) { OnGetReady_hndlr += value; } }
            remove { lock (this) { OnGetReady_hndlr -= value; } }
        }
        // выполнить команду
        private OnExe OnExe_hndlr;
        [DisplayName("При выполнении команды")]
        [Description("Функция выполнения команды")] 
        public event OnExe OnExe
        {
            add { lock (this) { OnExe_hndlr += value; } }
            remove { lock (this) { OnExe_hndlr -= value; } }
        }

        private OnGetCmdCaption OnGetCmdCaption_hndlr;
        [DisplayName("Названия команд")]
        [Description("Функция определения названия команды")] 
        public event OnGetCmdCaption OnGetCmdCaption
        { 
            add { lock (this) { OnGetCmdCaption_hndlr += value; } }
            remove { lock (this) { OnGetCmdCaption_hndlr -= value; } }
        }

        private CmdManagerEvent OnAddCommand_hndlr;
        [DisplayName("При добавлении команды")]
        [Description("При добавлении новой команды")]
        public event CmdManagerEvent OnAddCommand
        {
            add { lock (this) { OnAddCommand_hndlr += value; } }
            remove { lock (this) { OnAddCommand_hndlr -= value; } }
        }

        private CmdManagerEvent OnExeCommand_hndlr;
        [DisplayName("При выполнении команды")]
        [Description("Событие при выполнении команды")]
        public event CmdManagerEvent OnExeCommand
        {
            add { lock (this) { OnExeCommand_hndlr += value; } }
            remove { lock (this) { OnExeCommand_hndlr -= value; } }
        }

        private CmdManagerEvent OnDeleteCommand_hndlr;
        [DisplayName("При удалении команды")]
        [Description("Событие при удалении команды")]
        public event CmdManagerEvent OnDeleteCommand
        {
            add { lock (this) { OnDeleteCommand_hndlr += value; } }
            remove { lock (this) { OnDeleteCommand_hndlr -= value; } }
        }

        private void dgvCmdlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (e.RowIndex != this.currCmdPtr)
                {
                    this.CmdList.RemoveAt(e.RowIndex);
                    this.Refresh();
                }

            }
        }

        public StackerCmd Current 
        {
            get {
                if (currCmdPtr < this.CmdList.Count - 1)
                    return CmdList[currCmdPtr];
                return null;
            }
        }
            
    }
}
