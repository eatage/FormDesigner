using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormDesinger
{
    /// <summary>
    /// 用于放置控件的容器
    /// </summary>
    public partial class HostFrame : Form
    {
        public HostFrame()
        {
            InitializeComponent();
        }
        private string _sql = string.Empty;
        /// <summary>
        /// SQL语句
        /// </summary>
        [Browsable(true), Category("A-全局属性"), Description("SQL语句")]
        public string SQL
        {
            get
            {
                return _sql;
            }
            set
            {
                _sql = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!this.TopLevel)
                ControlPaint.DrawGrid(e.Graphics, this.ClientRectangle, new Size(10, 10), Color.White); //绘制底层网格White
            base.OnPaint(e);
        }
    }
}
