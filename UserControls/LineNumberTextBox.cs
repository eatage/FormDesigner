using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FormDesinger.UserControls
{
    /// <summary>
    /// 带行号的TextBox
    /// </summary>
    public partial class LineNumberTextBox : TextBox
    {
        public LineNumberTextBox()
            : base()
        {
        }
        protected override bool IsInputKey(System.Windows.Forms.Keys KeyData)
        {
            if (KeyData == System.Windows.Forms.Keys.Up || KeyData == System.Windows.Forms.Keys.Down)
                return true;
            return base.IsInputKey(KeyData);
        }
    }
}
