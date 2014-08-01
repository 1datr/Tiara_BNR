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
    public partial class frmAuthSpec : Form
    {
        public frmAuthSpec()
        {
            InitializeComponent();
        }

        public String _PASSWORD;

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "admin") && (textBox2.Text == this._PASSWORD))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
                DialogResult = DialogResult.Abort;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
