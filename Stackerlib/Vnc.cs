using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StackerLib
{
    public partial class Vnc : Form
    {
        public Vnc()
        {
            InitializeComponent();
        }

        public String VNC_IP {get; set; }

        private void Vnc_Load(object sender, EventArgs e)
        {
            this.remoteDesktop1.Connect(VNC_IP);
        }
    }
}
