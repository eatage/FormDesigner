using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FormDesinger.UserControls
{
    public partial class MyTextBox : TextBox
    {
        public MyTextBox()
        {

        }
        /// <summary>
        /// 用于数据库绑定的值
        /// </summary>
        [Browsable(true), Category("A-自定义属性"), Description("用于数据库绑定的值")]
        public string DBName { set; get; }

        /// <summary>
        /// 用于数据库绑定的值
        /// </summary>
        [Browsable(true), Category("A-自定义属性"), Description("绑定的下拉列表dw名,非下拉列表改属性为空")]
        public string DwName { set; get; }
        /// <summary>
        /// 用于数据库绑定的值
        /// </summary>
        [Browsable(true), Category("A-自定义属性"), Description("下拉列表数据列,非下拉列表改属性为空")]
        public string DwDataColumn { set; get; }
        /// <summary>
        /// 用于显示的值
        /// </summary>
        [Browsable(true), Category("A-自定义属性"), Description("下拉列表显示列,非下拉列表改属性为空")]
        public string DwDisplayColumn { set; get; }

    }
}
