using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BR.AN.PviServices;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace StackerLib
{
    public partial class TableBox : Component
    {
        public TableBox()
        {
            InitializeComponent();
        }

        public TableBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [DisplayName("BindingSource")]
        [Description("BindingSource таблицы")]
        public BindingSource BS { get; set; }

        [DisplayName("DataSet")]
        [Description("DataSet таблицы")]
        public global::System.ComponentModel.Component DS { get; set; }

        [DisplayName("DataAdapter")]
        [Description("DataAdapter таблицы")]
        public global::System.ComponentModel.Component DA { get; set; }

        [DisplayName("DataTable")]
        [Description("DataTable таблицы")]
        public global::System.ComponentModel.Component DT { get; set; }
    }
}
