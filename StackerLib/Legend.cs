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
    public partial class Legend : UserControl
    {
        public Legend()
        {
            InitializeComponent();
        }

        private Stacker fSTK;
        public Stacker Stk {
            get {
                return fSTK;
            }
            set {
                fSTK = value;
                fSTK.legend = this;
                refresh();
                }
        }

        public void refresh()
        {
            int delta = 2;
            int _cellsize = fSTK.cellsize - 6;

            Priem.FillColor = fSTK.StylePoddon.BackColor;
            /*
            Priem.Width = fSTK.cellsize;
            Priem.Height = fSTK.cellsize;*/
            Priem.Size = new Size(_cellsize, _cellsize);
            panel1.Height = _cellsize + 2 * delta;
            label3.Left = Priem.Left + _cellsize + delta;
            panel1.Width = _cellsize + delta + label3.Width;


            Zagr.FillColor = fSTK.StyleInput.BackColor;
           /* Zagr.Width = fSTK.cellsize;
            Zagr.Height = fSTK.cellsize;*/
            Zagr.Size = new Size(_cellsize, _cellsize);
            panel2.Height = _cellsize + 2 * delta;
            label1.Left = Zagr.Left + _cellsize + delta;
            panel2.Width = _cellsize + delta + label1.Width;


          //  Zanyata.Width = fSTK.cellsize;
            Zanyata.FillColor = Color.White;
            //Zanyata.Height = fSTK.cellsize;

            Zanyata.Size = new Size(_cellsize, _cellsize);
            panel3.Height = _cellsize + 2 * delta;
            label2.Left = Zanyata.Left + _cellsize + delta;
            panel3.Width = _cellsize + delta + label2.Width;
            lblNumber5.ForeColor = fSTK.OccupiedColor;
            lblNumber5.Top = Zanyata.Top + (Zanyata.Height - lblNumber5.Height) / 2;
            lblNumber5.Left = Zanyata.Left + (Zanyata.Width - lblNumber5.Width) / 2;
            lblNumber5.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
