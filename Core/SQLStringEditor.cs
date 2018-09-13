using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;

namespace FormDesinger
{
    /// <summary>
    /// 用于设计器编辑SQL
    /// </summary>
    class SQLStringEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            //指定为模式窗体属性编辑器类型 
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            //打开属性编辑器修改数据 
            Notepad notepad = new Notepad(value);
            System.Windows.Forms.DialogResult dr = notepad.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
                return notepad.SQL;
            else
                return value;
        }
    }
}
