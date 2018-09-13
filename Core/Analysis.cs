using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FormDesinger.Core
{
    /// <summary>
    /// 解析
    /// </summary>
    class Analysis
    {
        Overlayer overlayer;
        public string ErrStr = string.Empty;

        public Analysis(Overlayer overlayer)
        {
            this.overlayer = overlayer;
        }

        public void Load(string source)
        {
            source = source.Replace("\r", "");
            List<string> nodes = new List<string>(source.Split('\n'));
            List<Control> controls = new List<Control>();
            for (int i = 0; i < nodes.Count; i++)
            {
                string node = nodes[i];
                string ControlName = string.Empty;
                if (node.StartsWith("#"))//#开头为注释
                {
                    continue;
                }
                if (node.StartsWith("["))
                {
                    ControlName = node.Substring(1, node.IndexOf("]") - 1);
                    switch (ControlName)
                    {
                        case "Form":
                            node = nodes[i + 1];
                            overlayer.DesingerFormText = GetText(node);
                            overlayer.DesingerFormSize = new Point(GetWidth(node), GetHeight(node));
                            i++;
                            break;
                        case "SQL":
                            StringBuilder sql = new StringBuilder();
                            i++;
                            node = nodes[i];
                            while (!node.StartsWith("[ENDSQL]"))
                            {
                                sql.Append(node + "\r\n");
                                i++;
                                node = nodes[i];
                            }
                            overlayer.DesingerForm.SQL = sql.ToString();
                            break;
                        case "TextBox":
                            node = nodes[i + 1];
                            UserControls.MyTextBox textBox = new UserControls.MyTextBox();
                            textBox.Location = GetLocation(node);
                            textBox.Text = GetText(node);
                            textBox.Width = GetWidth(node);
                            textBox.Height = GetHeight(node);
                            textBox.TabIndex = GetTabIndex(node);
                            textBox.ForeColor = GetForeColor(node);
                            controls.Add(textBox);
                            i++;
                            break;
                        case "Label":
                            node = nodes[i + 1];
                            Label label = new Label();
                            label.Location = GetLocation(node);
                            label.Text = GetText(node);
                            label.Width = GetWidth(node);
                            label.Height = GetHeight(node);
                            label.TabIndex = GetTabIndex(node);
                            label.ForeColor = GetForeColor(node);
                            controls.Add(label);
                            i++;
                            break;
                        case "Button":
                            node = nodes[i + 1];
                            Button button = new Button();
                            button.Location = GetLocation(node);
                            button.Text = GetText(node);
                            button.Width = GetWidth(node);
                            button.Height = GetHeight(node);
                            button.TabIndex = GetTabIndex(node);
                            button.ForeColor = GetForeColor(node);
                            controls.Add(button);
                            i++;
                            break;
                        case "DateTimePicker":
                            node = nodes[i + 1];
                            DateTimePicker dateTimePicker = new DateTimePicker();
                            dateTimePicker.Location = GetLocation(node);
                            dateTimePicker.Text = GetText(node);
                            dateTimePicker.Width = GetWidth(node);
                            dateTimePicker.Height = GetHeight(node);
                            dateTimePicker.TabIndex = GetTabIndex(node);
                            controls.Add(dateTimePicker);
                            i++;
                            break;
                    }
                }
            }
            overlayer.DrawControls(controls);

        }


        private string GetText(string node)
        {
            if (string.IsNullOrEmpty(node))
                return null;
            int star = node.IndexOf("Text=");
            if (star == -1)
                return null;
            star += 5;
            node = node.Substring(star);
            int end = node.IndexOf(";");
            if (end == -1)
                return null;
            node = node.Substring(0, end);
            return node;
        }
        private int GetWidth(string node)
        {
            if (string.IsNullOrEmpty(node))
                return 0;
            int star = node.IndexOf("Width=");
            if (star == -1)
                return 0;
            star += 6;
            node = node.Substring(star);
            int end = node.IndexOf(";");
            if (end == -1)
                return 0;
            node = node.Substring(0, end);
            int width = 0;
            int.TryParse(node, out width);
            return width;
        }
        private int GetHeight(string node)
        {
            if (string.IsNullOrEmpty(node))
                return 0;
            int star = node.IndexOf("Height=");
            if (star == -1)
                return 0;
            star += 7;
            node = node.Substring(star);
            int end = node.IndexOf(";");
            if (end == -1)
                return 0;
            node = node.Substring(0, end);
            int height = 0;
            int.TryParse(node, out height);
            return height;
        }
        private Point GetLocation(string node)
        {
            if (string.IsNullOrEmpty(node))
                return new Point(0, 0);
            int star = node.IndexOf("Location=");
            if (star == -1)
                return new Point(0, 0);
            star += 9;
            node = node.Substring(star);
            int end = node.IndexOf(";");
            if (end == -1)
                return new Point(0, 0);
            node = node.Substring(0, end);
            if (node.IndexOf(",") == -1)
                return new Point(0, 0);
            try
            {
                return new Point(int.Parse(node.Split(',')[0]), int.Parse(node.Split(',')[1]));
            }
            catch
            {
                return new Point(0, 0);
            }
        }
        private int GetTabIndex(string node)
        {
            if (string.IsNullOrEmpty(node))
                return 0;
            int star = node.IndexOf("TabIndex=");
            if (star == -1)
                return 0;
            star += 9;
            node = node.Substring(star);
            int end = node.IndexOf(";");
            if (end == -1)
                return 0;
            node = node.Substring(0, end);
            int index = 0;
            int.TryParse(node, out index);
            return index;
        }
        private Color GetForeColor(string node)
        {
            if (string.IsNullOrEmpty(node))
                return Color.White;
            int star = node.IndexOf("ForeColor=");
            if (star == -1)
                return Color.White;
            star += 10;
            node = node.Substring(star);
            int end = node.IndexOf(";");
            if (end == -1)
                return Color.White;
            node = node.Substring(0, end);
            if (node.IndexOf(",") == -1)
                return Color.White;
            try
            {
                return Color.FromArgb(int.Parse(node.Split(',')[0]),
                    int.Parse(node.Split(',')[1]), int.Parse(node.Split(',')[2]), int.Parse(node.Split(',')[3]));
            }
            catch
            {
                return Color.White;
            }
        }
    }
}
