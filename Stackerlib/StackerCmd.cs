using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stackerlib
{
    public delegate bool OnGetReady(int cmd, int op1, int op2);
    public delegate bool OnExe(int cmd, int op1, int op2);

    public class StackerCmd
    {
        public int cmd { get; set; }

        public int op1 { get; set; }

        public int op2 { get; set; }
        // команда активна. можно выполнять/пропустить выполнение
        private bool fActive = true;
        public bool active { get { return fActive; } set { fActive = value; } }
        // команда выполняется
        private bool fExecuting;
        public bool Executing { get { return fExecuting; } }

        public StackerCmd(int cmd, int op1 = -1, int op2 = -1)
        {
            this.cmd = cmd;
            this.op1 = op1;
            this.op2 = op2;
        }
        // проверяет готов ли к выполнению команды
        private OnGetReady OnGetReady_hndlr;
        public event OnGetReady OnGetReady
        {
            add { lock (this) { OnGetReady_hndlr += value; } }
            remove { lock (this) { OnGetReady_hndlr -= value; } }
        }
        // выполнить команду
        private OnExe OnExe_hndlr;
        public event OnExe OnExe
        {
            add { lock (this) { OnExe_hndlr += value; } }
            remove { lock (this) { OnExe_hndlr -= value; } }
        }

        
    }
}
