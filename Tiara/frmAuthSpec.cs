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
    public partial class frmAuthSpec : Form
    {
        public frmAuthSpec()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "admin") && (textBox2.Text == "12345"))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
                DialogResult = DialogResult.Abort;
        }
    }
}
