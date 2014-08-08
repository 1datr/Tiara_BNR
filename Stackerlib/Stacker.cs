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
    // определяется есть ли что-нибудь на штабелере
    public delegate int OnGetOnStackerDelegate();

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
            set
            {
                f_cellsize = value;
                if (this.legend != null) legend.refresh();
                GroupColumns();
                for (int i = 0; i < dgvRackLeft.Rows.Count; i++)
                {
                    dgvRackLeft.Rows[i].Height = f_cellsize;
                }

                for (int i = 0; i < dgvRackRight.Rows.Count; i++)
                {
                    dgvRackRight.Rows[i].Height = f_cellsize;
                }
                setsizes();
            }
        }

        private TableBox fTB;
        [DisplayName("Компонент таблиц")]
        [Description("Компонент, выбирающий из таблиц содержимое ячеек")]   
        public TableBox TB {
            get { return fTB; }
            set {
                fTB = value;
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
                
                // left rack
                if (fRows > dgvRackLeft.Columns.Count)
                {
                    DataGridViewTextBoxCell cellTemplate;
                    cellTemplate = new DataGridViewTextBoxCell();
                    cellTemplate.Style.BackColor = Color.White;
                    cellTemplate.Style.ForeColor = Color.Black;
                    
                    
                    while (dgvRackLeft.Columns.Count<fRows)
                    {

                        // 
                        DataGridViewButtonColumn dgvc = new DataGridViewButtonColumn();
                        dgvc.FlatStyle = FlatStyle.Popup;
                        this.dgvRackLeft.Columns.Add(dgvc);
                    }
                }
                else if (fRows < dgvRackLeft.Columns.Count)
                {                    
                    while(dgvRackLeft.Columns.Count>fRows)
                    {
                        dgvRackLeft.Columns.RemoveAt(dgvRackLeft.Columns.Count - 1);
                    }
                }
                // right rack 
                if (fRows > dgvRackRight.Columns.Count)
                {

                    while(dgvRackRight.Columns.Count<fRows)
                    {
                        DataGridViewButtonColumn dgvc = new DataGridViewButtonColumn();
                        dgvc.FlatStyle = FlatStyle.Popup;

                        this.dgvRackRight.Columns.Add(dgvc);
                    }
                }
                else if (fRows < dgvRackRight.Columns.Count)
                {
                    while (dgvRackRight.Columns.Count > fRows)
                    {
                        dgvRackRight.Columns.RemoveAt(dgvRackRight.Columns.Count - 1);
                    }
                }

                GroupColumns();
                setsizes();
                run_numerate();
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

                
                // left rack
                if (dgvRackLeft.Columns.Count == 0)
                {
                    DataGridViewButtonColumn dgvc = new DataGridViewButtonColumn();
                    dgvc.FlatStyle = FlatStyle.Popup;
                    dgvRackLeft.Columns.Add(dgvc);
                    fRows = 1;
                }

                if (fFloors > dgvRackLeft.Rows.Count)
                {
                    this.dgvRackLeft.Rows.Add(fFloors - dgvRackLeft.Rows.Count);
                   
                }
                else if (fFloors < dgvRackLeft.Rows.Count)
                {
                    
                    while(dgvRackLeft.Rows.Count > fFloors)
                    {
                        dgvRackLeft.Rows.RemoveAt(dgvRackLeft.Rows.Count - 1);
                    }
                }                

                
                // right rack 
                if (dgvRackRight.Rows.Count == 0)
                {
                    DataGridViewButtonColumn dgvc = new DataGridViewButtonColumn();
                    dgvc.FlatStyle = FlatStyle.Popup;                    
                    dgvRackRight.Columns.Add(dgvc);
                }

                if (fFloors > dgvRackRight.Rows.Count)
                {

                    this.dgvRackRight.Rows.Add(fFloors - dgvRackRight.Rows.Count);
                }
                else if (fFloors < dgvRackRight.Rows.Count)
                {
                    while(dgvRackRight.Rows.Count > fFloors)
                    {
                        dgvRackRight.Rows.RemoveAt(dgvRackRight.Rows.Count - 1);
                    }
                }

                for (int i = 0; i < dgvRackLeft.Rows.Count; i++)
                {
                    dgvRackLeft.Rows[i].Height = f_cellsize;
                }

                for (int i = 0; i < dgvRackRight.Rows.Count; i++)
                {
                    dgvRackRight.Rows[i].Height = f_cellsize;
                }

                setsizes();                               
                numerate();
            }
        }

        private void setsizes()
        {
            // установка размеров элементов
            //this.Width = dgvRackLeft.Columns.GetColumnsWidth(DataGridViewElementStates.None)+2;
            int totalwidth = dgvRackLeft.Columns.GetColumnsWidth(DataGridViewElementStates.None);
            panel1.Width = totalwidth;
            // Left          
            int height_left = dgvRackLeft.Rows.GetRowsHeight(DataGridViewElementStates.None);
            dgvRackLeft.Height = height_left;
            dgvRackLeft.Width = totalwidth;
            // Right
            //splitLow.Height = splitLow.Panel1.Height + dgvRackRight.Rows.GetRowsHeight(DataGridViewElementStates.None);
            int height_right = dgvRackRight.Rows.GetRowsHeight(DataGridViewElementStates.None);
            dgvRackRight.Height = height_right;
            dgvRackRight.Width = totalwidth;

            this.Width = totalwidth;
            this.MaximumSize = new Size(totalwidth + 4, height_left + height_right + panel1.Height + 12);
            this.MinimumSize = new Size(totalwidth + 4, height_left + height_right + panel1.Height + 12);
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
                // group fields
                GroupColumns();
                setsizes();
            }
        }

        private int fDelta = 2;
        [DisplayName("Группировочная дельта")]
        [Description("Разница в ширине между нормальной и граничной группирующей ячейкой")]
        public int Delta
        {
            get
            {
                return fDelta;
            }
            set
            {
                fDelta = value;
                // group fields
                GroupColumns();
                setsizes();
            }
        }

        private void GroupColumns()
        {
            if (fGroup > 1)
            {
                int i = 1;
                foreach (DataGridViewButtonColumn dgvc in dgvRackLeft.Columns)
                {
                    Padding pdng = dgvc.DefaultCellStyle.Padding;
                    pdng.All = 0;
                    if (((i % fGroup) == 0) && (i < dgvRackLeft.Columns.Count))
                    {
                        dgvc.Width = f_cellsize + fDelta;
                        pdng.Right = fDelta;
                    }
                    else
                    {
                        dgvc.Width = f_cellsize;
                    }
                    dgvc.DefaultCellStyle.Padding = pdng;
                    i++;
                }
                i = 1;
                foreach (DataGridViewButtonColumn dgvc in dgvRackRight.Columns)
                {
                    Padding pdng = dgvc.DefaultCellStyle.Padding;
                    pdng.All = 0;
                    if (((i % fGroup) == 0) && (i < dgvRackLeft.Columns.Count))
                    {
                        dgvc.Width = f_cellsize + fDelta;
                        pdng.Right = fDelta;
                    }
                    else
                    {
                        dgvc.Width = f_cellsize;
                    }
                    dgvc.DefaultCellStyle.Padding = pdng;
                    i++;
                }
            }
            else
            {
                foreach (DataGridViewColumn dgvc in dgvRackLeft.Columns)
                {
                    Padding pdng = dgvc.DefaultCellStyle.Padding;
                    pdng.All = 0;
                    dgvc.Width = f_cellsize;
                    dgvc.DefaultCellStyle.Padding = pdng;
                }

                foreach (DataGridViewColumn dgvc in dgvRackRight.Columns)
                {
                    Padding pdng = dgvc.DefaultCellStyle.Padding;
                    pdng.All = 0;
                    dgvc.Width = f_cellsize;
                    dgvc.DefaultCellStyle.Padding = pdng;
                }
            }
        }

        private List<CellPassInfo> fCellsNextPass;
        [DisplayName("Ячейки с пропуском")]
        [Description("Ячейки, перед которыми будет пропущенно указанное число ячеек")]
        public String CellsNextPass
        {
            get
            {
                String str = "";
                int i = 0;
                if (fCellsNextPass != null)
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
                    run_numerate();
                    setsizes();
                }
                catch (Exception e)
                {

                }
               
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
                numerate();
                
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
                /*
                foreach(int ci in fCellsInput)
                {
                    CellAddr ca = this.getCellIdxes(ci);
                    SetCellInput(ca);
                }*/
                run_numerate();
            }
        }

        private void SetCellEmpty(CellAddr caddr)
        {
            
            if(caddr.rack==0) 
            {
                DataGridViewCellStyle dgvc = dgvRackLeft.Rows[caddr.y].Cells[caddr.x].Style;
                dgvc.ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                dgvc.BackColor = Color.FromArgb(0xff, 0xff, 0xff);       
                dgvRackLeft.Rows[caddr.y].Cells[caddr.x].Value = "";
            }
            else
            {
                DataGridViewCellStyle dgvc = dgvRackRight.Rows[caddr.y].Cells[caddr.x].Style;
                dgvc.ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                dgvc.BackColor = Color.FromArgb(0xff, 0xff, 0xff);    
                dgvRackRight.Rows[caddr.y].Cells[caddr.x].Value = "";
            }
        }

        private void SetCellInput(CellAddr caddr)
        {

            if (caddr.rack == 0)
            {
                if (caddr.y > dgvRackLeft.Rows.Count - 1) return;
                if (caddr.x > dgvRackLeft.Columns.Count - 1) return;
                DataGridViewCellStyle dgvc = dgvRackLeft.Rows[caddr.y].Cells[caddr.x].Style;
                dgvc.ForeColor = InputStyle.ForeColor;
                dgvc.BackColor = InputStyle.BackColor;
            }
            else
            {
                if (caddr.y > dgvRackRight.Rows.Count - 1) return;
                if (caddr.x > dgvRackRight.Columns.Count - 1) return;
                DataGridViewCellStyle dgvc = dgvRackRight.Rows[caddr.y].Cells[caddr.x].Style;
                dgvc.ForeColor = InputStyle.ForeColor;
                dgvc.BackColor = InputStyle.BackColor;
            }
        }

        private DataGridViewCellStyle PoddonStyle;
        [DisplayName("Стиль поддонов")]
        [Description("Стиль поддонных ячеек")]
        public DataGridViewCellStyle StylePoddon { 
            get {
                if (PoddonStyle == null)
                {
                    PoddonStyle = new DataGridViewCellStyle();
                    this.PoddonStyle.BackColor = Color.FromArgb(181, 206, 231);
                    if (this.legend != null) legend.refresh();
                }                        
                return PoddonStyle; 
            }
            set { 
                PoddonStyle = value;
                if (this.legend != null) legend.refresh();
            }
        }

        public Legend legend;

        private DataGridViewCellStyle InputStyle;
        [DisplayName("Стиль загрузочных ячеек")]
        [Description("Стиль загрузочных ячеек")]
        public DataGridViewCellStyle StyleInput { 
            get {
                if (InputStyle == null)
                {
                    InputStyle = new DataGridViewCellStyle();
                    this.InputStyle.BackColor = Color.FromArgb(200, 252, 200);
                    if (this.legend != null) legend.refresh();
                }
            
                return InputStyle; 
            }
            set {
                InputStyle = value;
                if (this.legend != null) legend.refresh();
            }
        }

        private Color fOccupiedColor;
        [DisplayName("Цвет занятой ячейки")]
        [Description("Цвет номеров полных ячеек")]
        public Color OccupiedColor {
            get {
                if(fOccupiedColor == null)
                    fOccupiedColor = Color.Red;
                return fOccupiedColor; 
            }
            set { fOccupiedColor = value;
                if (this.legend != null) legend.refresh();
                run_numerate();
            }
        }

        public int getTotalWidth()
        {
            int borders;
            if (this.fGroup > 1)
                borders = ((this.fRows / this.fGroup)-1) * 3 + 6;
            else
                borders = 6;
            return dgvRackRight.Width+borders;
        }

        public int getTotalHeight()
        {
            return dgvRackRight.Height + dgvRackRight.Height + panel1.Height + 6;            
        }

        delegate void init_component_delegate();

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
                            if ((row + 1) % fGroup == 0)
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
                    dgvRackLeft.Rows.Add(fFloors - dgvRackLeft.Rows.Count);
                    dgvRackRight.Rows.Add(fFloors - dgvRackRight.Rows.Count);
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
                    run_numerate();

                    pnl_zahvat.Height = 4;
                    pnl_zahvat.Top = pnlStacker.Height / 2 - pnl_zahvat.Height / 2;

                    if (this.legend != null) legend.refresh();

                  //  setsizes();
                   /* Rows = 5;
                    Floors = 5;
                    cellsize = 24;
                    GroupColumns();
                    setsizes();*/
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
                if(!CellAddrs.ContainsKey(ncell))
                    CellAddrs.Add(ncell, ca);
                return ca;
            }
        }

        private void printcell(CellAddr ca, int ncell, String celltext)
        {
            if (PoddonStyle == null)
            {
                this.PoddonStyle = new DataGridViewCellStyle();
                this.PoddonStyle.BackColor = Color.FromArgb(181, 206, 231);
            }
            if (InputStyle == null)
            {
                this.InputStyle = new DataGridViewCellStyle();
                this.InputStyle.BackColor = Color.FromArgb(200, 252, 200);
            }
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
                    dgvc.BackColor = this.PoddonStyle.BackColor;
                }
                else
                {
                    if (Array.BinarySearch<int>(this.fCellsInput, ncell) > -1)
                        dgvc.BackColor = this.InputStyle.BackColor;
                    else
                        dgvc.BackColor = Color.FromArgb(255, 255, 255);
                }
                
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
                        dgvc.BackColor = this.PoddonStyle.BackColor;                   
                }
                else
                {
                    if (Array.BinarySearch<int>(this.fCellsInput, ncell) > -1)
                        dgvc.BackColor = this.InputStyle.BackColor;
                    else
                        dgvc.BackColor = Color.FromArgb(255, 255, 255);
                }
                this.dgvRackRight.Rows[ca.y].Cells[ca.x].Style = dgvc;
            }
        }

        private Dictionary<int, CellAddr> CellAddrs;
        // нумеровать ячейки
        private void numerate()
        {
            try
            {
                for (int y = 0; y < dgvRackLeft.Rows.Count; y++)
                {
                    for (int x = 0; x < dgvRackLeft.Columns.Count; x++)
                    {
                        dgvRackLeft.Rows[y].Cells[x].Value = "";
                        dgvRackLeft.Rows[y].Cells[x].Style.BackColor = Color.White;
                    }
                }

                for (int y = 0; y < dgvRackRight.Rows.Count; y++)
                {
                    for (int x = 0; x < dgvRackRight.Columns.Count; x++)
                    {
                        dgvRackRight.Rows[y].Cells[x].Value = "";
                        dgvRackRight.Rows[y].Cells[x].Style.BackColor = Color.White;
                    }
                }

                CellAddrs = new Dictionary<int, CellAddr>();
                maxcell = 2 * fFloors * fRows;
                int ncell = 0;
                while (ncell < maxcell)
                {

                    CellAddr ca = getAddr(ncell);
                    printcell(ca, ncell, ncell.ToString());
                    ncell++;
                }
                refresh();
            }
            catch (System.Exception exc)
            { }
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
         /*   if(!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();*/

        }

        private void Stacker_Layout(object sender, LayoutEventArgs e)
        {

            setsizes();
            
           
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
            return (res > -1);//&&(is_poddon(cellnum));
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
            if (OnGetOnStackerDelegate_hndlr == null) return;
            try
            {
                // detect cell content
                for (int c = 0; c <= maxcell; c++)
                {             
                    if (OnGetCellCountDelegate_hndlr(c) > 0)
                    {

                        this.SetCellOccupied(c);
                    }
                    else
                    {
                        this.SetCellFree(c);
                    }
                }
                // detect stacker content
                if (OnGetOnStackerDelegate_hndlr != null)
                    TriggerStacker((OnGetOnStackerDelegate_hndlr() > 0));
            }
            catch (Exception exc)
            { }
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
                    if (currdgv.SelectedCells[0].Value.ToString() != "")
                    {
                       // oldcellid = selected_cell_num;
                        selected_cell_num = System.Convert.ToInt32(currdgv.SelectedCells[0].Value);
                        exe_OnCellSelect(selected_cell_num);
                    }
                    else
                    {
                        currdgv.SelectedCells[0].Selected = false;
                        if (selected_cell_num != -1)
                        {
                            SelectCell(selected_cell_num);
                        }

                    }
                }
                catch (System.Exception ex)
                { 
                
                }
            }
        }

        private int oldcellid = -1;

        private void dgvRackRight_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                if (dgvRackRight.SelectedCells.Count > 0)
                    if (dgvRackRight.SelectedCells[0].Value == null)
                    {
                        dgvRackRight.ClearSelection();
                        return;
                    }

                if (currdgv != null)
                    if (currdgv != dgvRackRight)
                        currdgv.ClearSelection();
                currdgv = dgvRackRight;

                if (currdgv.SelectedCells.Count > 0)
                {
                    if(currdgv.SelectedCells[0].Value.ToString()!="")
                    {
                        //oldcellid = selected_cell_num;
                        selected_cell_num = System.Convert.ToInt32(currdgv.SelectedCells[0].Value);
                        exe_OnCellSelect(selected_cell_num);
                    }
                    else
                    {
                        currdgv.SelectedCells[0].Selected = false;
                        if(selected_cell_num!=-1)
                        {
                            SelectCell(selected_cell_num);
                        }
                        
                    }
                }
            }
            catch (System.Exception excp)
            { }

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
            add { lock (this) { 
                OnCellSelect_hndlr += value;
                refresh();
            } }
            remove { lock (this) { 
                OnCellSelect_hndlr -= value;
                refresh();
            } }
        }

        private OnGetCellCountDelegate OnGetCellCountDelegate_hndlr;
        [DisplayName("Получение числа продуктов в ячейке")]
        [Description("Функция-событие, возвращающая сколько в ячейке продуктов")] 
        public event OnGetCellCountDelegate OnGetCellCount
        {
            add { lock (this) { OnGetCellCountDelegate_hndlr += value; } }
            remove { lock (this) { OnGetCellCountDelegate_hndlr -= value; } }
        }

        private OnGetOnStackerDelegate OnGetOnStackerDelegate_hndlr;
        [DisplayName("Получение числа продуктов в тележке")]
        [Description("Функция-событие, возвращающая сколько продуктов на тележке")]
        public event OnGetOnStackerDelegate OnGetTelezhkaCount
        {
            add { lock (this) { 
                OnGetOnStackerDelegate_hndlr += value;
                if (!DesignMode)
                {
                    if (OnGetOnStackerDelegate_hndlr != null)
                        TriggerStacker((OnGetOnStackerDelegate_hndlr() > 0));
                }
            } }
            remove { lock (this) { OnGetOnStackerDelegate_hndlr -= value; } }
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
            try
            {
                CellAddr caddr = CellAddrs[ncell];
                // цвет занятых ячеек
                Color OccupiedColor = Color.FromArgb(255, 0, 0);
                if (caddr.rack == 0)
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
            catch (Exception exc)
            { }
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

        delegate void dlg_numerate();

        private void run_numerate()
        {
            if(!bwNumerate.IsBusy)
            bwNumerate.RunWorkerAsync();
        }

        private void bwNumerate_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new dlg_numerate(numerate), new object[] { });
            else
                numerate();
        }

        
    }

    // информация о пропускаемых ячейках
    public class CellPassInfo : IComparable<CellPassInfo>
    {
        public int cell { get; set; }
        public int passcount { get; set; }
        public CellPassInfo(int cell = 0, int count = 1)
        {
            this.cell = cell;
            this.passcount = count;
        }

        public int CompareTo(CellPassInfo obj) 
        {
            if (obj == null) return 1;
            return this.cell.CompareTo(obj.cell);
        }

        public int Compare(CellPassInfo x, CellPassInfo y)
        {
            // Compare y and x in reverse order.             

            return y.CompareTo(x);
        }
    }
}
