using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FormDesinger
{
    /// <summary>
    /// 鼠标左键按下拖动时,出现的选中区域方框
    /// </summary>
    class Select
    {
        Rectangle _rect = new Rectangle();
        public Select()
        {
        }
        public Rectangle Rect
        {
            get
            {
                return _rect;
            }
            set
            {
                _rect = value;
            }
        }

        /// <summary>
        /// 绘制方框
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            Rectangle rect = _rect;
            using (Pen p = new Pen(Brushes.Black, 1))
            {
                p.DashStyle = DashStyle.Dot;
                //rect.Inflate(new Size(+1, +1));
                g.DrawRectangle(p, rect); //方框

                //p.DashStyle = DashStyle.Solid;

                g.FillRectangle(new SolidBrush(Color.FromArgb(100,151, 209, 255)), new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 1, rect.Height - 1));

                g.DrawRectangle(p, rect);
            }

        }
    }
}
