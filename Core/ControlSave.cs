using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FormDesinger.Core
{
    class ControlSave
    {
        Overlayer overlayer;
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="controls"></param>
        public ControlSave(Overlayer overlayer)
        {
            this.overlayer = overlayer;
        }
        /// <summary>
        /// 保存格式
        /// <para>请自行添加需要保存的属性</para>
        /// <para>必须以;结尾</para>
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            //保存From
            StringBuilder sb = new StringBuilder();
            sb.Append("[Form]\r\n");
            sb.Append(string.Format("Width={0};Height={1};Text={2}\r\n", overlayer.DesingerFormSize.X, overlayer.DesingerFormSize.Y, overlayer.DesingerFormText));
            sb.Append("[SQL]\r\n");
            sb.Append(overlayer.DesingerForm.SQL + "\r\n");
            sb.Append("[ENDSQL]\r\n");
            foreach (Control c in overlayer.Controls)
            {
                int cc = c.TabIndex;
                if (cc != -1)
                {

                }
                string controlType = c.GetType().ToString();
                if (c is UserControls.MyTextBox)//自定义控件转换
                    controlType = "TextBox";
                //.....
                else
                    controlType = controlType.Substring(controlType.LastIndexOf(".") + 1);
                sb.Append(string.Format("[{0}]\r\n", controlType));
                //添加保存的属性 解析也需要添加
                sb.Append(string.Format("Width={0};Height={1};Text={2};Location={3};TabIndex={4};ForeColor={5};\r\n",
                    c.Width, c.Height, c.Text, c.Location.X + "," + c.Location.Y,
                    c.TabIndex, c.ForeColor.A + "," + c.ForeColor.R + "," + c.ForeColor.G + "," + c.ForeColor.B));
            }

            return sb.ToString();
        }
    }
}
