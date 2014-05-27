using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Stackerlib
{
    // тип события при выборе ячейки
    public delegate void OnCellSelectDelegate(int cellno);
    // тип события определить сколько в ячейке продуктов
    public delegate int OnGetCellCountDelegate(int cellno);
    // тип события при команде взять из
    public delegate int OnCmdTake(Stacker s);
    // тип события при команде взять в
    public delegate int OnCmdPut(Stacker s);

    public delegate bool isReady();
    // клик по квадрату штабелера
    public delegate void OnClickStacker();

    public partial class Stacker : UserControl
    {
        public Stacker()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // CELL WIDTH AND HEIGHT
        private int f_cellsize = 20;
        [DisplayName("Размер ячейки")]
        [Description("Размер ячейки в пикселях")]           
        public int cellsize {
            get{
                return f_cellsize;
            } 
            set{
                f_cellsize = value;
                init_component();
            }
        }
        // STACKER rows
        private int fRows = 5;
        [DisplayName("Рядов")]
        [Description("Сколько рядов у штабелера")]   
        public int Rows {
            get {
                return fRows;
            }
            set {
                fRows = value;
                init_component();
            }
        }
        // 
        private int fFloors = 5;
        [DisplayName("Полок")]
        [Description("Сколько полок у штабелера")]  
        public int Floors {
            get {
                return fFloors;
            }
            set {
                fFloors = value;
                init_component();
            }
        }

        private int fGroup = 1;
        [DisplayName("Группировка")]
        [Description("Группировка ячеек по нескольку в одной")]
        public int Group
        {
            get
            {
                return fGroup;
            }
            set
            {
                fGroup = value;
                init_component();
            }
        }

        private List<CellPassInfo> fCellsNextPass;
        [DisplayName("Ячейки с пропуском")]
        [Description("Ячейки после которых пропустить нумерацию следующей")]
        public String CellsNextPass
        {
            get
            {
                String str = "";
                int i = 0;
                foreach (CellPassInfo ci in fCellsNextPass)
                {
                    if (i > 0)
                        str = str + "," + ci.cell.ToString();
                    else
                        str = str + ci.cell.ToString();

                    if (ci.passcount > 1)
                        str = str + ":" + ci.passcount.ToString();
                    i++;
                }
                return str;
            }
            set
            {
                try
                {
                    String[] arr1 = value.Split(new Char[] { ',' });
                    fCellsNextPass = new List<CellPassInfo>();
                    foreach (String cellstr in arr1)
                    {
                        String[] arr2 = cellstr.Split(new Char[] { ':' });
                        if (arr2.Length > 1)
                        {
                            fCellsNextPass.Add(new CellPassInfo(Convert.ToInt32(arr2[0]), Convert.ToInt32(arr2[1])));
                        }
                        else
                        {
                            fCellsNextPass.Add(new CellPassInfo(Convert.ToInt32(cellstr)));
                        }
                    }
                    fCellsNextPass.Sort();
                }
                catch (Exception e)
                {

                }
                init_component();
            }
        }

        private int[] fPoddonCells = { };
        [DisplayName("Поддоны")]
        [Description("Массив поддонов")]
        public int[] PoddonCells
        {
            get
            {
                return fPoddonCells;
            }
            set
            {
                fPoddonCells = value;
                Array.Sort(fPoddonCells);
                init_component();
            }
        }

        private int[] fCellsInput = { };
        [DisplayName("Поддоны входные")]
        [Description("Массив поддонов входных")]
        public int[] InputCells
        {
            get
            {
                return fCellsInput;
            }
            set
            {
                fCellsInput = value;
                Array.Sort(fCellsInput);
                init_component();
            }
        }

        private DataGridViewCellStyle PoddonStyle;
        public DataGridViewCellStyle StylePoddon { get { return PoddonStyle; } }
        private DataGridViewCellStyle InputStyle;
        public DataGridViewCellStyle StyleInput { get { return InputStyle; } }

        void init_component()
        {
            dgvRackLeft.Columns.Clear();
            dgvRackRight.Columns.Clear();

            this.PoddonStyle = new DataGridViewCellStyle();
            this.PoddonStyle.BackColor = Color.FromArgb(181, 206, 231);

            this.InputStyle = new DataGridViewCellStyle();
            this.InputStyle.BackColor = Color.FromArgb(200, 252, 200);

            // Set columns
            for (int row = 0; row < fRows; row++)
            {
                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.Width = f_cellsize;
                col.FlatStyle = FlatStyle.Popup;
                              
                DataGridViewButtonColumn col2 = new DataGridViewButtonColumn();
                col2.Width = f_cellsize;
                col2.FlatStyle = FlatStyle.Popup;

                if (fGroup > 1)
                {
                    if ((row+1) % fGroup == 0)
                    {
                        if ((0 < row) & (row < fRows - 1))
                        {
                            Padding pdng = col.DefaultCellStyle.Padding;
                            pdng.Right = 4;
                            col.DefaultCellStyle.Padding = pdng;
                            col.Width += 4;
                            col2.DefaultCellStyle.Padding = pdng;
                            col2.Width += 4;
                        }
                    }
                }

                this.dgvRackLeft.Columns.Add(col);
                this.dgvRackRight.Columns.Add(col2);
            }
            // Set rows
            dgvRackLeft.Rows.Add(fFloors-dgvRackLeft.Rows.Count);
            dgvRackRight.Rows.Add(fFloors-dgvRackRight.Rows.Count);
            for (int i = 0; i < dgvRackRight.Rows.Count; i++)
            {
                dgvRackLeft.Rows[i].Height = this.f_cellsize;
                dgvRackRight.Rows[i].Height = this.f_cellsize;
            }
            // установка размеров элементов
            dgvRackLeft.Height = dgvRackLeft.Rows.GetRowsHeight(DataGridViewElementStates.None);
            dgvRackLeft.Width = dgvRackLeft.Columns.GetColumnsWidth(DataGridViewElementStates.None);

            dgvRackRight.Height = dgvRackRight.Rows.GetRowsHeight(DataGridViewElementStates.None);
            dgvRackRight.Width = dgvRackRight.Columns.GetColumnsWidth(DataGridViewElementStates.None);

            this.Width = dgvRackRight.Columns.GetColumnsWidth(DataGridViewElementStates.None);

            this.Height = dgvRackLeft.Height + dgvRackRight.Height + 20;

            dgvRackRight.ClearSelection();
            // установить цифры
            // left
            numerate();

            pnl_zahvat.Height = 4;
            pnl_zahvat.Top = pnlStacker.Height / 2 - pnl_zahvat.Height / 2;
        }

        // нумеровать ячейки

        private void PassSomeCells(ref CellAddr ca, int ncell)
        {
            if (fCellsNextPass == null) fCellsNextPass = new List<CellPassInfo>();
            CellPassInfo thecell2 = this.fCellsNextPass.Find(delegate(CellPassInfo cpi)
            {
                return (cpi.cell == ncell);
            }
            );
            if (thecell2 != null)
                for (int i = 0; i < thecell2.passcount; i++)
                {
                    NextCell(ref ca);
                    maxcell--;
                    printcell(ca, ncell, "");
                }
        }

        // следующая по номеру ячейка
        private void NextCell(ref CellAddr ca)
        {
            if (ca.rack == 0)   // left rack
            {
                if (ca.y > 0)
                    ca.y--;
                else
                {
                    ca.y = fFloors - 1;
                    ca.x++;
                }
            }
            else            // right rack           
            {
                if (ca.y < fFloors - 1)
                    ca.y++;
                else
                {
                    ca.y = 0;
                    ca.x++;
                }
            }

            if (ca.x == fRows)
            {
                ca.x = 0;
                ca.y = 0;
                ca.rack = 1;
            }
        }

        private CellAddr getAddr(int ncell)
        {
            if (CellAddrs == null) CellAddrs = new Dictionary<int, CellAddr>();
            if (CellAddrs.ContainsKey(ncell))
                return CellAddrs[ncell];
            if (ncell == 0)
            {
                CellAddr ca = new CellAddr();
                ca.x = 0;
                ca.y = fFloors - 1;
                ca.rack = 0;
                PassSomeCells(ref ca, ncell);
                CellAddrs.Add(ncell, ca);
                return ca;
            }
            else
            {
                CellAddr ca = getAddr(ncell - 1);

                NextCell(ref ca);
                PassSomeCells(ref ca, ncell);
                CellAddrs.Add(ncell, ca);
                return ca;
            }
        }

        private void printcell(CellAddr ca, int ncell, String celltext)
        {
            if (ca.rack == 0)
            {
                if (ca.y > dgvRackLeft.Rows.Count - 1) return;
                if (ca.x > dgvRackLeft.Rows[0].Cells.Count - 1) return;

                this.dgvRackLeft.Rows[ca.y].Cells[ca.x].Value = celltext;

                DataGridViewCellStyle dgvc = dgvRackLeft.Rows[ca.y].Cells[ca.x].Style;
                if (this.fPoddonCells == null) this.fPoddonCells = new int[0];
                if (Array.BinarySearch<int>(this.fPoddonCells, ncell) > -1)
                {
                    // ячейка куда можно класть
                    if (Array.BinarySearch<int>(this.fCellsInput, ncell) > -1)
                        dgvc.BackColor = this.InputStyle.BackColor;
                    else
                        dgvc.BackColor = this.PoddonStyle.BackColor;

                }
                else
                    dgvc.BackColor = Color.FromArgb(255, 255, 255);
                this.dgvRackLeft.Rows[ca.y].Cells[ca.x].Style = dgvc;
            }
            else if (ca.rack == 1)
            {
                if (ca.y > dgvRackRight.Rows.Count - 1) return;
                if (ca.x > dgvRackRight.Rows[0].Cells.Count - 1) return;

                this.dgvRackRight.Rows[ca.y].Cells[ca.x].Value = celltext;

                DataGridViewCellStyle dgvc = dgvRackRight.Rows[ca.y].Cells[ca.x].Style;
                if (this.fPoddonCells == null) this.fPoddonCells = new int[0];
                if (Array.BinarySearch<int>(this.fPoddonCells, ncell) > -1)
                {
                    // ячейка куда можно класть
                    if (Array.BinarySearch<int>(this.fCellsInput, ncell) > -1)
                        dgvc.BackColor = this.InputStyle.BackColor;
                    else
                        dgvc.BackColor = this.PoddonStyle.BackColor;

                }
                else
                    dgvc.BackColor = Color.FromArgb(255, 255, 255);
                this.dgvRackRight.Rows[ca.y].Cells[ca.x].Style = dgvc;
            }
        }

        private Dictionary<int, CellAddr> CellAddrs;
        // нумеровать ячейки
        private void numerate()
        {
            CellAddrs = new Dictionary<int, CellAddr>();
            maxcell = 2 * fFloors * fRows;
            int ncell = 0;
            while (ncell < maxcell)
            {
                CellAddr ca = getAddr(ncell);
                printcell(ca, ncell, ncell.ToString());
                ncell++;
            }

        }
        
        private int maxcell;

        public int MaxCell { get { return maxcell; } }
        // изменить цвет квадратика
        public void TriggerStacker(Boolean mode)
        {
            if (mode)
                pnlStacker.BackColor = Color.PaleVioletRed;
            else
                pnlStacker.BackColor = Color.DarkGray;
        }

        private void Stacker_Load(object sender, EventArgs e)
        {
            init_component();
        }

        private void Stacker_Layout(object sender, LayoutEventArgs e)
        {
            if (this.DesignMode)
                init_component();
            walk_cell_styles();  
        }
        // Свойство текущая выделенная ячейка
        public int SelectedCellNumber {
            get { return selected_cell_num; }
        }

        public bool is_poddon(int cellnum)
        {            
            Array.Sort(fPoddonCells);
            int res = Array.BinarySearch(fPoddonCells,cellnum);
            return (res > -1);
        }

        public bool is_input(int cellnum)
        {
            Array.Sort(fCellsInput);
            int res = Array.BinarySearch(fCellsInput, cellnum);
            return (res > -1)&&(is_poddon(cellnum));
        }

        [DisplayName("Таблица координат")]
        [Description("Таблица координат ячеек")]
        public DataTable TableCoords
        {
            get;
            set;
        }

        private Rectangle getCellRect(int ncell)
        {
            CellAddr ca = this.getCellIdxes(ncell);
            if (ca.rack == 0)
            {
                //if(dgvRackLeft!=null)
                return dgvRackLeft.GetCellDisplayRectangle(ca.x, ca.y, true);
            }
            else
            {
               // if (dgvRackRight != null)
                return dgvRackRight.GetCellDisplayRectangle(ca.x, ca.y, true);
            }

        }

        private int point_y, point_z;
        public void SetX(int x) 
        {
            try
            {
                // ячейка 1
                DataRow[] Rows_less = this.TableCoords.Select("x <= " + x.ToString(), "x DESC");
                int x0 = Convert.ToInt32(Rows_less[0]["x"]);
                int ncell0 = Convert.ToInt32(Rows_less[0]["ncell"]);
                Rectangle r0 = getCellRect(ncell0);

                // ячейка 2
                DataRow[] Rows_more = this.TableCoords.Select("x > " + x.ToString(), "x ASC");
                if (Rows_more.Length > 0)
                {
                    int x1 = Convert.ToInt32(Rows_more[0]["x"]);
                    int ncell1 = Convert.ToInt32(Rows_more[0]["ncell"]);
                    Rectangle r1 = getCellRect(ncell1);

                    int dx;
                    if (x1 == x0)
                        dx = 0;
                    else
                        dx = (r1.X - r0.X) * (x - x0) / (x1 - x0);
                    pnlStacker.Left = r0.X + dx;

                }
                else
                {

                    pnlStacker.Left = r0.X;
                }

                pnlStacker.Left++;

                pnlStacker.Top = 1;
                pnlStacker.Height = pnlStacker.Parent.Height - 2;
                pnlStacker.Width = cellsize - 2;
            }
            catch (Exception e)
            { }
        }

        private int curr_y_pos;
        public void SetY(int y)
        {
            try
            {
                // 0 - 4670
                DataRow[] Rows = this.TableCoords.Select("TRUE", "y DESC");
                int ymax = Convert.ToInt32(Rows[0]["y"]);
                pnl_kran.Width = 2 + y * 7 / ymax;
            }
            catch (Exception e)
            { }

        }

        public void SetZ(int z)
        {
            // 1350
            /* ymax - this.cellwidth* fFloors
             * ycurr - y
             * 
             * y = curr_y_pos*this.cellsize*fFloors/ymax
             * 
             * zmax - y 
             * zcurr - z
             * 
             * 
             */

            /*
            int y_ = curr_y_pos * this.cellsize * fFloors / 4670;

            int panel_y = y_ * z / 1350;
            pnlStacker.Top = fFloors*cellsize + panel_y;
             * 
             1270 - pnlStacker.Height/2
             CurrZ - Z
             */
            try
            {
            pnl_zahvat.Width = pnlStacker.Width - 1;
            pnl_zahvat.Left = 0;
            int zmaxpix = ((pnlStacker.Height-pnl_zahvat.Height) / 2);
            DataRow[] Rows = this.TableCoords.Select("TRUE", "z DESC");
            int zmax = Convert.ToInt32(Rows[0]["z"]);
            pnl_zahvat.Top = pnlStacker.Height / 2 - pnl_zahvat.Height / 2 + z * zmaxpix / zmax;
            }
            catch (Exception e)
            { }
        }
        // освежить данные о ячейках
        public void refresh()
        {
            for (int c = 0; c <= maxcell; c++ )
            {
                if (c == 330)
                { 
                
                }
                if (OnGetCellCountDelegate_hndlr(c) > 0)
                {

                    this.SetCellOccupied(c);
                }
                else
                {
                    this.SetCellFree(c);
                }
            }
           
        }
        // выделить ячейку
        public void SelectCell(int ncell)
        {
            if (CellAddrs[ncell].rack == 0)
            {
                dgvRackLeft.Rows[CellAddrs[ncell].y].Cells[CellAddrs[ncell].x].Selected = true;
            }
            else
            {
                dgvRackRight.Rows[CellAddrs[ncell].y].Cells[CellAddrs[ncell].x].Selected = true;
            }
            this.Focus();
        }

        // Selection provider
        private int selected_cell_num = 0;
        DataGridView currdgv = null;
        private void dgvRackLeft_SelectionChanged(object sender, EventArgs e)
        {
            // Попытка выделить пустую ячейку
            if (dgvRackLeft.SelectedCells.Count > 0)
                if (dgvRackLeft.SelectedCells[0].Value == null)
                {
                    dgvRackLeft.ClearSelection();
                    return;
                }

            if (currdgv != null)
                if (currdgv != dgvRackLeft)
                    currdgv.ClearSelection();
            currdgv = dgvRackLeft;
            if (currdgv.SelectedCells.Count > 0)
            {
                try
                {
                    selected_cell_num = System.Convert.ToInt32(currdgv.SelectedCells[0].Value);
                    exe_OnCellSelect(selected_cell_num);
                }
                catch (System.Exception ex)
                { 
                
                }
            }
        }

        private void dgvRackRight_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRackRight.SelectedCells.Count > 0)
                if(dgvRackRight.SelectedCells[0].Value==null)
                {
                    dgvRackRight.ClearSelection();
                    return;
                }

            if (currdgv != null) 
                if(currdgv!=dgvRackRight)
                    currdgv.ClearSelection();
            currdgv = dgvRackRight;

            if (currdgv.SelectedCells.Count > 0)
            {
                selected_cell_num = System.Convert.ToInt32(currdgv.SelectedCells[0].Value);
                exe_OnCellSelect(selected_cell_num);
            }

        }

        private void exe_OnCellSelect(int cellno)
        {
            if (this.OnCellSelect_hndlr != null)
                this.OnCellSelect_hndlr(cellno);
        }

        private OnCellSelectDelegate OnCellSelect_hndlr;
        [DisplayName("При выделении ячейки")]
        [Description("Событие при выделении ячейки")]      
        public event OnCellSelectDelegate OnCellSelect
        {
            add { lock (this) { OnCellSelect_hndlr += value; } }
            remove { lock (this) { OnCellSelect_hndlr -= value; } }
        }

        private OnGetCellCountDelegate OnGetCellCountDelegate_hndlr;
        [DisplayName("Получение числа продуктов в ячейке")]
        [Description("Функция-событие, возвращающая сколько в ячейке продуктов")] 
        public event OnGetCellCountDelegate OnGetCellCount
        {
            add { lock (this) { OnGetCellCountDelegate_hndlr += value; } }
            remove { lock (this) { OnGetCellCountDelegate_hndlr -= value; } }
        }

        public struct CellAddr{
            public int rack;
            public int x;
            public int y;
        }
        // "Адрес" ячейки с номером ncell
        private CellAddr getCellIdxes(int ncell)
        {
            CellAddr addr = new CellAddr();            
            if(ncell < this.fRows*this.fFloors) 
            {
                addr.rack = 0;
               // ncell--;
                addr.x = Convert.ToInt32(Math.Floor(Convert.ToDouble(ncell/fFloors)));                
                addr.y = ncell-addr.x*fFloors;
                addr.y = fFloors-1 - addr.y;
            }
            else
            {
                addr.rack = 1;
                ncell -= this.fRows*this.fFloors; 
               // ncell--;
                addr.x = Convert.ToInt32(Math.Floor(Convert.ToDouble(ncell/fFloors)));
                addr.y = ncell-addr.x*fFloors;
            }
            return addr;
        }
        // Установить ячейку по стилю свободной
        public void SetCellFree(int ncell)
        {
            if (CellAddrs == null) CellAddrs = new Dictionary<int, CellAddr>();
            if (!CellAddrs.ContainsKey(ncell)) return;
            CellAddr caddr = CellAddrs[ncell];
            if(caddr.rack==0) 
            {
                DataGridViewCellStyle dgvc = dgvRackLeft.Rows[caddr.y].Cells[caddr.x].Style;
                if (dgvc.ForeColor == Color.FromArgb(0, 0, 0)) return;
                dgvc.ForeColor = Color.FromArgb(0, 0, 0);
                dgvRackLeft.Rows[caddr.y].Cells[caddr.x].Style = dgvc;                
            }
            else
            {
                DataGridViewCellStyle dgvc = dgvRackRight.Rows[caddr.y].Cells[caddr.x].Style;
                if (dgvc.ForeColor == Color.FromArgb(0, 0, 0)) return;
                dgvc.ForeColor = Color.FromArgb(0, 0, 0);
                dgvRackRight.Rows[caddr.y].Cells[caddr.x].Style = dgvc;  
            }
        }
        // Установить ячейку по стилю занятой
        public void SetCellOccupied(int ncell)
        {
            CellAddr caddr = CellAddrs[ncell];
            // цвет занятых ячеек
            Color OccupiedColor = Color.FromArgb(255, 0, 0);
            if(caddr.rack==0)
            {
                DataGridViewCellStyle dgvc = dgvRackLeft.Rows[caddr.y].Cells[caddr.x].Style;
                if (dgvc.ForeColor == OccupiedColor) return;
                dgvc.ForeColor = OccupiedColor;
                dgvRackLeft.Rows[caddr.y].Cells[caddr.x].Style = dgvc;                
            }
            else
            {
                DataGridViewCellStyle dgvc = dgvRackRight.Rows[caddr.y].Cells[caddr.x].Style;
                if (dgvc.ForeColor == OccupiedColor) return;
                dgvc.ForeColor = OccupiedColor;
                dgvRackRight.Rows[caddr.y].Cells[caddr.x].Style = dgvc;  
            }
        }
        // установить стили ячеек
        private void walk_cell_styles()
        {
            
                if (this.OnGetCellCountDelegate_hndlr == null) return;
                if (dgvRackLeft.Rows.Count < fFloors) return;
                if (dgvRackLeft.Columns.Count < fRows) return;
                if (dgvRackRight.Rows.Count < fFloors) return;
                if (dgvRackRight.Columns.Count < fRows) return;
                // цвет занятых ячеек
                Color OccupiedColor = Color.FromArgb(255, 00, 00);

                for (int y = 0; y < dgvRackLeft.Rows.Count; y++)
                {
                    for (int x = 0; x < dgvRackLeft.Columns.Count; x++)
                    {
                        // Left rack
                        if (dgvRackLeft.Rows[y].Cells[x].Value != null)
                        {
                            if (dgvRackLeft.Rows[y].Cells[x].Value.ToString() == "") continue;

                            int ncell_left = System.Convert.ToInt32(dgvRackLeft.Rows[y].Cells[x].Value);
                            if (OnGetCellCountDelegate_hndlr(ncell_left) > 0)
                            {
                                DataGridViewCellStyle dgvc = dgvRackLeft.Rows[y].Cells[x].Style;
                                dgvc.ForeColor = OccupiedColor;
                                dgvRackLeft.Rows[y].Cells[x].Style = dgvc;
                            }
                            else
                            {
                                DataGridViewCellStyle dgvc = dgvRackLeft.Rows[y].Cells[x].Style;
                                dgvc.ForeColor = Color.FromArgb(0, 0, 0);
                                dgvRackLeft.Rows[y].Cells[x].Style = dgvc;
                            }
                        }
                        // Right rack
                        if (dgvRackRight.Rows[y].Cells[x].Value != null)
                        {
                            if (dgvRackRight.Rows[y].Cells[x].Value.ToString() == "") continue;

                            int ncell_right = System.Convert.ToInt32(dgvRackRight.Rows[y].Cells[x].Value);
                            if (OnGetCellCountDelegate_hndlr(ncell_right) > 0)
                            {
                                DataGridViewCellStyle dgvc = dgvRackRight.Rows[y].Cells[x].Style;
                                dgvc.ForeColor = OccupiedColor;
                                dgvRackRight.Rows[y].Cells[x].Style = dgvc;
                            }
                            else
                            {
                                DataGridViewCellStyle dgvc = dgvRackRight.Rows[y].Cells[x].Style;
                                dgvc.ForeColor = Color.FromArgb(0, 0, 0);
                                dgvRackRight.Rows[y].Cells[x].Style = dgvc;
                            }
                        }
                    }
                }
            
        }

        private void положитьВToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.OnCmdPut_hndlr!=null)
                this.OnCmdPut_hndlr(this);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private OnCmdPut OnCmdPut_hndlr;
        [DisplayName("Контекстное меню Положить в")]
        [Description("При выборе в контекстном меню пункта Положить в")]
        public event OnCmdPut OnCmdPut
        {
            add { lock (this) { OnCmdPut_hndlr += value; } }
            remove { lock (this) { OnCmdPut_hndlr -= value; } }
        }

        private OnCmdTake OnCmdTake_hndlr;
        [DisplayName("Контекстное меню Взять из")]
        [Description("При выборе в контекстном меню пункта Взять из")]
        public event OnCmdTake OnCmdTake 
        {
            add { lock (this) { OnCmdTake_hndlr += value; } }
            remove { lock (this) { OnCmdTake_hndlr -= value; } }
        }

        private isReady OnIsReady_hndlr;
        [DisplayName("При получении готовности")]
        [Description("Функция получения готовности")]
        public event isReady OnIsReady
        {
            add { lock (this) { OnIsReady_hndlr += value; } }
            remove { lock (this) { OnIsReady_hndlr -= value; } }
        }

        private void взятьИзToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // вызов события При команде взять из
            if(this.OnCmdTake_hndlr!=null)
                this.OnCmdTake_hndlr(this);
        }
        // контекстное меню
        private void dgvRackLeft_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dgvRackLeft.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Rectangle cellRect = dgvRackLeft.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                if (OnIsReady_hndlr != null)
                {
                    if(OnIsReady_hndlr())
                        contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void dgvRackRight_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            this.dgvRackRight.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (OnIsReady_hndlr != null)
                {
                    if (OnIsReady_hndlr())
                        contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void pnlStacker_Paint(object sender, PaintEventArgs e)
        {

        }

        private OnClickStacker OnClickStacker_hndlr;
        [DisplayName("Клик по квадрату штабелера")]
        [Description("Щелчок по штабелеру")]
        public event OnClickStacker OnClickStacker
        {
            add { lock (this) { OnClickStacker_hndlr += value; } }
            remove { lock (this) { OnClickStacker_hndlr -= value; } }
        }

        private void pnlStacker_Click(object sender, EventArgs e)
        {
            if (OnClickStacker_hndlr != null)
            {
                OnClickStacker_hndlr();
            }
        }

        private void pnl_zahvat_Click(object sender, EventArgs e)
        {
            if (OnClickStacker_hndlr != null)
            {
                OnClickStacker_hndlr();
            }
        }

        private void pnl_kran_Click(object sender, EventArgs e)
        {
            if (OnClickStacker_hndlr != null)
            {
                OnClickStacker_hndlr();
            }
        }
    }

    // информация о пропускаемых ячейках
    public class CellPassInfo
    {
        public int cell { get; set; }
        public int passcount { get; set; }
        public CellPassInfo(int cell = 0, int count = 1)
        {
            this.cell = cell;
            this.passcount = count;
        }
    }
}
