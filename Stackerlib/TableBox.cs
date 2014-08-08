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
    public partial class TableBox : UserControl
    {
        public TableBox()
        {
            InitializeComponent();
        }

        private void tabCellinfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private int f_StackerID = 1;
        [DisplayName("ID штабелера")]
        [Description("Номер штабелера")]
        public int StackerID
        {
            get { return f_StackerID; }
            set
            {
                f_StackerID = value;
             /*   if (!DesignMode)
                {
                    if (service == null)


                        Connect_Service(this.Servname + f_StackerID.ToString());
                    else if (!service.IsConnected)
                        Connect_Service(this.Servname + f_StackerID.ToString());
                }*/
            }
        }

        private Stacker f_stacker;
        public Stacker c_stacker
        {

            get { return f_stacker; }
            set {
                c_stacker = value;
                if (c_stacker != null) c_stacker.refresh();
            }
        }
    }
}
