using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace FormDesinger
{
    /// <summary>
    /// 消息过滤器
    /// </summary>
    class MessageFilter : IMessageFilter
    {
        HostFrame _thehost;
        DesignerControl _theDesignerBoard;
        public MessageFilter(HostFrame hostFrame, DesignerControl designer)
        {
            _thehost = hostFrame;
            _theDesignerBoard = designer;
        }
        #region IMessageFilter 成员
        public bool PreFilterMessage(ref Message m) //过滤所有控件的WM_PAINT消息
        {
            Control ctrl = (Control)Control.FromHandle(m.HWnd);
            if (_thehost != null && _theDesignerBoard != null && _thehost.Controls.Contains(ctrl) && m.Msg == 0x000F) // 0x000F == WM_PAINT
            {
                _theDesignerBoard.Refresh();
                return true;
            }
            return false;
        }
        #endregion
    }
}
