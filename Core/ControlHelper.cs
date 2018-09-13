using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Reflection;

namespace FormDesinger
{
    /// <summary>
    /// 控件类型
    /// </summary>
    class ControlHelper
    {
        public static Control CreateControl(string ctrlName, string path)
        {
            try
            {
                Control ctrl = null;
                switch (ctrlName)
                {
                    case "Label":
                        ctrl = new Label();
                        ctrl.Width = 40;
                        ctrl.Height = 20;
                        break;
                    case "TextBox":
                        //ctrl = new TextBox();
                        ctrl = new UserControls.MyTextBox();//使用自定义
                        break;
                    case "PictureBox":
                        ctrl = new PictureBox();
                        ((PictureBox)ctrl).Image = Properties.Resources.tools_picture_24px;
                        break;
                    case "ListView":
                        ctrl = new ListView();
                        break;
                    case "ComboBox":
                        ctrl = new ComboBox();
                        ctrl.Width = 90;
                        break;
                    case "Button":
                        ctrl = new Button();
                        ctrl.Width = 90;
                        break;
                    case "CheckBox":
                        ctrl = new CheckBox();
                        ctrl.Width = 90;
                        break;
                    case "MonthCalender":
                        ctrl = new MonthCalendar();
                        break;
                    case "DateTimePicker":
                        ctrl = new DateTimePicker();
                        //((DateTimePicker)ctrl).Format = DateTimePickerFormat.Custom;
                        //((DateTimePicker)ctrl).CustomFormat = "yyyy年MM月dd日";
                        ctrl.Width = 110;
                        break;
                    case "RadioButton":
                        ctrl = new RadioButton();
                        ctrl.Width = 90;
                        break;
                    case "ProgressBar":
                        ctrl = new ProgressBar();
                        break;
                    case "TreeView":
                        ctrl = new TreeView();
                        break;
                    case "LinkLabel":
                        ctrl = new LinkLabel();
                        ctrl.Width = 90;
                        break;
                    case "ListBox":
                        ctrl = new ListBox();
                        break;
                    case "Panel":
                        ctrl = new Panel();
                        break;
                    default: //其他
                        string[] strs = path.Split('/');
                        if (strs.Length == 2)
                        {
                            Assembly controlAsm = Assembly.LoadFile(strs[1]);
                            Type controlType = controlAsm.GetType(strs[0]);
                            ctrl = (Control)Activator.CreateInstance(controlType);
                            ctrl.Width = 100;
                            ctrl.Height = 50;
                        }
                        break;

                }
                return ctrl;

            }
            catch (Exception ex) //创建失败
            {
                return new Control();
            }	
        }
    }
}
