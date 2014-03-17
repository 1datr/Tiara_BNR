using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tiara
{
    public partial class Vnc : Form
    {
        public Vnc()
        {
            InitializeComponent();
        }

        private void Vnc_Load(object sender, EventArgs e)
        {
            this.remoteDesktop1.Connect("192.168.1.200");
        }
    }
}
