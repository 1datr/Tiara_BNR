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
    public partial class frmAddTake : Form
    {
        public frmAddTake()
        {
            InitializeComponent();
        }

        private int f_count = 0;
        public int count { get { return f_count; } }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                f_count = Convert.ToInt32(tbCount.Text);
                if (f_count < 0)
                {
                    MessageBox.Show("Ошибка: Не может быть меньше нуля");
                }
                else
                    DialogResult = DialogResult.OK;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        private bool add_mode = false;
        public void SetMode(bool modeadd = true)
        {            
            add_mode = modeadd;
            if (modeadd)
            {
                this.Text = "Положить";
            }
            else
            {
                this.Text = "Взять";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmAddTake_Layout(object sender, LayoutEventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2;
            this.Height = 70;
        }
    }
}
