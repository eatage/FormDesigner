using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FormDesinger
{
    /// <summary>
    /// 显示属性
    /// <para>只显示需要的属性</para>
    /// </summary>
    class Collections
    {
        /// <summary>
        /// 显示指定的属性
        /// <para>自定义属性必须定义ValueType</para>
        /// </summary>
        /// <param name="control">控件对象</param>
        /// <param name="controlName">控件名</param>
        /// <returns>属性集合</returns>
        public static CustomPropertyCollection GetCollections(Control control)
        {
            CustomPropertyCollection collection = new CustomPropertyCollection();
            //公共属性
            collection.Add(new CustomProperty("文本", "Text", "数据", "Text 要显示的内容。", control, typeof(System.ComponentModel.Design.MultilineStringEditor)));
            collection.Add(new CustomProperty("背景色", "BackColor", "外观", "BackColor 背景色。", control));
            collection.Add(new CustomProperty("颜色", "ForeColor", "外观", "ForeColor 前景色。", control));
            collection.Add(new CustomProperty("字体", "Font", "外观", "Font 字体。", control));
            collection.Add(new CustomProperty("位置", "Location", "布局", "Location 控件左上角相对于其容器左上角的坐标。", control));
            collection.Add(new CustomProperty("大小", "Size", "布局", "Size 控件的大小，以像素为单位。", control));
            collection.Add(new CustomProperty("边距", "Margin", "布局", "Margin 指定此控件与另一控件之间边距的距离。", control));
            collection.Add(new CustomProperty("锚", "Anchor", "布局", "Anchor 定义要绑定到容器的边缘，当控件锚定位到某个控件时，与指定边缘最接近的控件边缘与指定边缘之间的距离将保持不变。", control));
            collection.Add(new CustomProperty("停靠", "Dock", "布局", "Dock 定义要绑定到容器的控件边框。", control));
            collection.Add(new CustomProperty("Tab索引", "TabIndex", "行为", "TabIndex 确定此控件将占用的 Tab 键顺序索引。", control));

            //私有属性
            if (control is HostFrame)//设计器主窗体
            {
                //自定义属性SQL,并指定自定义编辑器，指定ValueType
                collection.Add(new CustomProperty("SQL语句", "SQL", "数据", "当前文档的SQL语句。", control,
                    typeof(SQLStringEditor)) { ValueType = ((HostFrame)control).SQL.GetType() });
                collection.Find(x => { return x.Name == "背景色"; }).IsReadOnly = true;
                collection.Find(x => { return x.Name == "位置"; }).IsReadOnly = true;
                collection.Find(x => { return x.Name == "边距"; }).IsReadOnly = true;
                collection.Find(x => { return x.Name == "锚"; }).IsReadOnly = true;
                collection.Find(x => { return x.Name == "停靠"; }).IsReadOnly = true;
                collection.Find(x => { return x.Name == "Tab索引"; }).IsReadOnly = true;
            }
            if (control is UserControls.MyTextBox)
                collection.Add(new CustomProperty("多行显示", "Multiline", "行为", "Multiline 控件的文本是否能跨越多行。", control));

            if (control is DateTimePicker)
            {
                if (((DateTimePicker)control).Format != DateTimePickerFormat.Custom)
                {
                    //必须定义为Custom，CustomFormat才有效
                    ((DateTimePicker)control).Format = DateTimePickerFormat.Custom;
                    ((DateTimePicker)control).CustomFormat = "";
                }
                collection.Add(new CustomProperty("格式化", "CustomFormat", "行为", "CustomFormat 用于格式化在控件中显示的日期/或时间的自定义字符串。", control));
            }
            return collection;
        }
    }
}