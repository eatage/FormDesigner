using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FormDesinger.Core
{
    class OldAnalysis
    {
        public string is_source;
        public string is_dataobject;
        private Overlayer overlayer;
        #region 私有变量
        List<string> RootNode = new List<string>();
        List<string> TableNode = new List<string>();

        /// <summary>
        /// (解析)数据列集合
        /// </summary>
        Dictionary<Point, Hashtable> columnData = new Dictionary<Point, Hashtable>();
        /// <summary>
        /// (解析)table数据列集合
        /// </summary>
        Dictionary<string, Hashtable> columnTable = new Dictionary<string, Hashtable>();
        /// <summary>
        /// (解析)列名集合
        /// </summary>
        Dictionary<Point, Hashtable> columnText = new Dictionary<Point, Hashtable>();
        /// <summary>
        /// 所有可录入控件的对象
        /// </summary>
        Dictionary<string, Control> dgv_control = new Dictionary<string, Control>();
        /// <summary>
        /// 所涉及的DddwName列表
        /// <para>Key:dwname,Value:dwdata</para>
        /// </summary>
        Dictionary<string, string> DddwName = new Dictionary<string, string>();
        #endregion
        #region  内部方法
        /// <summary>
        /// 选中下一个控件
        /// </summary>
        private void of_FocusItemIndex(Control c)
        {
            if (dgv_control == null || dgv_control.Count == 0)
            {
                return;
            }
            int i = 0;
            string key = string.Empty;
            string first = string.Empty;
            foreach (string tempkey in dgv_control.Keys)
            {
                if (dgv_control[tempkey] == c)
                {
                    key = tempkey;
                    break;
                }
                if (i == 0)
                {
                    first = tempkey;
                }
                i++;
            }
            if (!string.IsNullOrEmpty(key))
            {
                i++;
                int j = 0;
                foreach (string tempkey in dgv_control.Keys)
                {
                    if (j == i)
                    {
                        key = tempkey;
                        break;
                    }
                    j++;
                }
                if (j == dgv_control.Keys.Count)//已经是最后一个 回到第一个索引
                {
                    key = first;
                }
                dgv_control[key].Focus();
            }
            else
                dgv_control[first].Focus();
        }
        #endregion
        #region 外部方法
        public OldAnalysis(Overlayer overlayer)
        {
            this.overlayer = overlayer;
        }
        public string ErrStr = string.Empty;
        /// <summary>
        /// 载入DW文本
        /// </summary>
        /// <param name="as_dwSource"></param>
        /// <returns></returns>
        public string of_LoaddwText(string as_dwSource)
        {
            is_source = as_dwSource;
            is_dataobject = "";

            #region 初始化值
            RootNode = new List<string>();
            TableNode = new List<string>();
            columnData = new Dictionary<Point, Hashtable>();
            columnTable = new Dictionary<string, Hashtable>();
            columnText = new Dictionary<Point, Hashtable>();
            dgv_control = new Dictionary<string, Control>();
            DddwName = new Dictionary<string, string>();
            ErrStr = "";
            #endregion

            of_Init();
            return "OK";
        }
        private void of_Init()
        {
            //解析根节点
            Regex reg = new Regex(@"\(((?<Open>\()|(?<-Open>\))|[^()])*(?(Open)(?!))\)");
            Tools.MatchString(is_source, reg, RootNode);
            Tools.MatchStringTable(is_source, reg, TableNode);


            #region table内部的数据列
            foreach (string node in TableNode)
            {
                if (!node.StartsWith("column=("))
                {
                    continue;
                }
                string source = string.Empty;
                source = node.Substring(8);
                source = source.Substring(0, source.Length - 1);
                string[] args = source.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                Hashtable htable = new Hashtable();
                htable.Add("nodename", node.Substring(0, node.IndexOf("(") - 1));
                foreach (string arg in args)
                {
                    string[] nodes = arg.Split('=');
                    if (nodes.Length == 2)
                    {
                        if (htable.Contains(nodes[0]))
                            continue;
                        htable.Add(nodes[0], nodes[1].Replace("\"", ""));
                    }
                }
                if (htable.Contains("name"))
                {
                    if (!columnTable.ContainsKey(htable["name"].ToString()))
                        columnTable.Add(htable["name"].ToString(), htable);
                }
            }
            #endregion

            #region 分析控件
            foreach (string node in RootNode)
            {
                if (node.StartsWith("compute(") || node.StartsWith("column(") || node.StartsWith("text("))
                {
                    string source = string.Empty;
                    if (node.StartsWith("compute(")) source = node.Substring(8);
                    if (node.StartsWith("column(")) source = node.Substring(7);
                    if (node.StartsWith("text(")) source = node.Substring(5);
                    source = source.Substring(0, source.Length - 1);
                    string[] args = source.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    //防止值内部有空格
                    Hashtable htable = new Hashtable();
                    htable.Add("nodename", node.Substring(0, node.IndexOf("(")));
                    for (int i = 0; i < args.Length; i++)
                    {
                        string arg = args[i];
                        string[] nodes = arg.Split('=');
                        if (nodes.Length == 2)
                        {
                            if (htable.Contains(nodes[0]))
                                continue;
                            if (nodes[1] == "\"")//内容带括号
                            {
                                if (i < args.Length)
                                {
                                    nodes[1] = args[i + 1];
                                }
                            }
                            htable.Add(nodes[0], nodes[1].Replace("\"", ""));
                        }
                    }
                    if (htable.Contains("x") && node.StartsWith("text("))
                    {
                        Point p = new Point(int.Parse(htable["x"].ToString()), int.Parse(htable["y"].ToString()));
                        columnText.Add(p, htable);
                    }
                    else if (htable.Contains("x"))
                    {
                        if (htable["nodename"].ToString() == "column")//数据列 加上table内的列数据
                        {
                            string columnName = htable["name"].ToString();
                            Hashtable table = columnTable[columnName];
                            columnTable.Remove(columnName);
                            foreach (string key in table.Keys)
                            {
                                if (!htable.Contains(key))
                                {
                                    htable.Add(key, table[key]);
                                }
                            }
                        }
                        Point p = new Point(int.Parse(htable["x"].ToString()), int.Parse(htable["y"].ToString()));
                        columnData.Add(p, htable);
                    }
                }
            }
            #endregion

            #region 按X、Y轴排序
            List<KeyValuePair<Point, Hashtable>> lst = new List<KeyValuePair<Point, Hashtable>>(columnText);
            //进行排序 目前是顺序 当Y轴相同时 进行X轴排序
            lst.Sort(delegate(KeyValuePair<Point, Hashtable> s1, KeyValuePair<Point, Hashtable> s2)
            {
                if (s1.Key.Y != s2.Key.Y)
                    return s1.Key.Y.CompareTo(s2.Key.Y);
                else
                    return s1.Key.X.CompareTo(s2.Key.X);
            });
            columnText.Clear();
            foreach (KeyValuePair<Point, Hashtable> s in lst)
            {
                columnText.Add(s.Key, s.Value);
            }
            List<KeyValuePair<Point, Hashtable>> lst1 = new List<KeyValuePair<Point, Hashtable>>(columnData);
            //进行排序 目前是顺序 当Y轴相同时 进行X轴排序
            lst1.Sort(delegate(KeyValuePair<Point, Hashtable> s1, KeyValuePair<Point, Hashtable> s2)
            {
                if (s1.Key.Y != s2.Key.Y)
                    return s1.Key.Y.CompareTo(s2.Key.Y);
                else
                    return s1.Key.X.CompareTo(s2.Key.X);
            });
            columnData.Clear();
            foreach (KeyValuePair<Point, Hashtable> s in lst1)
            {
                columnData.Add(s.Key, s.Value);
            }

            #endregion

            #region 开始绘制
            int totalWidth = 0;
            int totalHeight = 0;

            #region Label
            foreach (Point p in columnText.Keys)
            {
                Hashtable hashTable = columnText[p];
                decimal x = int.Parse(hashTable["x"] as string) / (decimal)4.2;
                decimal y = int.Parse(hashTable["y"] as string) / (decimal)4;
                decimal width = int.Parse(hashTable["width"] as string) / (decimal)4;
                decimal height = int.Parse(hashTable["height"] as string) / (decimal)3.3;
                string text = hashTable["text"] as string;
                string fontface = hashTable["font.face"] as string;
                Label label = new Label();
                label.Text = text;
                label.Location = new Point((int)x + 5, (int)y + 18);
                label.Width = (int)width;
                label.Height = 25;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Margin = new Padding(0);
                if (text.Length == 2 && label.Width < 39)
                {
                    label.Width = 39;
                    label.Location = new Point(label.Location.X - 2, label.Location.Y);
                }
                if (text.Length > 5 && label.Width < 60)
                {
                    label.Location = new Point(label.Location.X, label.Location.Y + 5);
                }
                //ParentControl.Controls.Add(label);
                overlayer.DrawControl(label);
                label.BringToFront();
            }
            #endregion

            #region TextBox
            DddwName = new Dictionary<string, string>();
            foreach (Point p in columnData.Keys)
            {
                Hashtable hashTable = columnData[p];
                decimal x = int.Parse(hashTable["x"] as string) / (decimal)4.2;
                decimal y = int.Parse(hashTable["y"] as string) / (decimal)4;
                decimal width = int.Parse(hashTable["width"] as string) / (decimal)4.2;
                decimal height = int.Parse(hashTable["height"] as string) / (decimal)3.3;
                string name = hashTable["name"] as string;
                string dbname = hashTable["dbname"] as string;
                string format = hashTable["format"] as string;
                string dddwallowedit = hashTable["dddw.allowedit"] as string;
                string dddwdatacolumn = hashTable["dddw.datacolumn"] as string;
                string dddwdisplaycolumn = hashTable["dddw.displaycolumn"] as string;
                string dddwname = hashTable["dddw.name"] as string;
                #region 日期控件DateTimePicker
                if (format == "yyyy-mm-dd")
                {
                    DateTimePicker dateTimePicker = new DateTimePicker();
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = "yyyy-MM-dd";
                    dateTimePicker.Name = name;
                    dateTimePicker.Tag = dbname;
                    dateTimePicker.Location = new Point((int)x + 5, (int)y + 20);
                    dateTimePicker.Width = (int)width;
                    dateTimePicker.Height = 25;
                    dateTimePicker.Value = DateTime.Now;
                    //ParentControl.Controls.Add(dateTimePicker);
                    overlayer.DrawControl(dateTimePicker);
                    dateTimePicker.BringToFront();
                    dgv_control.Add(name, dateTimePicker);
                }
                #endregion
                else
                {
                    //contextMenuStrip.Show(MousePosition.X, MousePosition.Y);
                    FormDesinger.UserControls.MyTextBox textBox = new FormDesinger.UserControls.MyTextBox();
                    textBox.Name = name;
                    textBox.Tag = dbname;
                    textBox.Location = new Point((int)x + 5, (int)y + 20);
                    textBox.Width = (int)width;
                    textBox.Height = 25;
                    textBox.Margin = new Padding(3, 0, 0, 0);
                    textBox.BackColor = Color.FromArgb(252, 252, 252);
                    textBox.DBName = dbname;
                    textBox.DwName = dddwname;
                    textBox.DwDataColumn = dddwdatacolumn;
                    textBox.DwDisplayColumn = dddwdisplaycolumn;
                    //ParentControl.Controls.Add(textBox);
                    overlayer.DrawControl(textBox);
                    textBox.BringToFront();
                    dgv_control.Add(name, textBox);
                }
                if (totalWidth < x + width + 20)
                    totalWidth = (int)(x + width + 20);
                if (totalHeight < y + 25 + 10)
                    totalHeight = (int)(y + 25 + 30);
            }
            #endregion
            #endregion

            overlayer.DesingerForm.SQL = Tools.GetSQLbyDwText(is_source);
            overlayer.DesingerFormSize = new Point(totalWidth + 24, totalHeight + 50);
        }
        #endregion

    }

    /// <summary>
    /// 工具类
    /// </summary>
    internal class Tools
    {
        /// <summary>
        /// 正则匹配符合规则的内容
        /// </summary>
        public static void MatchString(string OutString, Regex r, List<string> list)
        {
            MatchCollection ms = r.Matches(OutString);// 获取所有的匹配
            foreach (Match m in ms)
            {
                if (m.Success)
                {
                    if (list == null)
                    {
                        list = new List<string>();
                    }
                    int index = m.Index;
                    //找到括号前面的字符串 按优先级 = \r\n (
                    string OutStringPrefix = OutString.Substring(0, index);
                    //int index1 = OutStringPrefix.LastIndexOf("=");
                    int index2 = OutStringPrefix.LastIndexOf("\r\n");
                    int index3 = OutStringPrefix.LastIndexOf("(");
                    //index1 = index1 == -1 ? 99999 : index1;
                    index2 = index2 == -1 ? 99999 : index2;
                    index3 = index3 == -1 ? 99999 : index3;
                    //int minValue = new int[] { /*index1,*/ index2, index3 }.ToArray().Min();
                    int minValue = index2;
                    if (index2 > index3)
                    {
                        minValue = index3;
                    }
                    if (minValue == 99999) minValue = 0;
                    string prefix = OutString.Substring(minValue, index - minValue);
                    if (prefix.IndexOf("\r\n") != -1)
                        prefix = prefix.Substring(prefix.LastIndexOf("\r\n") + 2);
                    if (prefix.IndexOf("(") != -1)
                        prefix = prefix.Substring(prefix.LastIndexOf("(") + 1);
                    list.Add(prefix.Trim() + m.Groups[0].Value);
                    //递归
                    //MatchString(m.Groups[0].Value.Substring(1, m.Groups[0].Value.Length - 1), r, list);// 去掉匹配到的头和尾的 "[" 和 "]"，避免陷入死循环递归中，导致溢出
                }
            }
            return;
        }
        /// <summary>
        /// 正则匹配符合规则的内容(table内部节点)
        /// </summary>
        public static void MatchStringTable(string OutString, Regex r, List<string> list)
        {
            MatchCollection ms = r.Matches(OutString);// 获取所有的匹配
            foreach (Match m in ms)
            {
                if (m.Success)
                {
                    if (list == null)
                    {
                        list = new List<string>();
                    }
                    int index = m.Index;
                    //找到括号前面的字符串 按优先级 = \r\n (
                    string OutStringPrefix = OutString.Substring(0, index);
                    //int index1 = OutStringPrefix.LastIndexOf("=");
                    int index2 = OutStringPrefix.LastIndexOf("\r\n");
                    int index3 = OutStringPrefix.LastIndexOf("(");
                    //index1 = index1 == -1 ? 99999 : index1;
                    index2 = index2 == -1 ? 99999 : index2;
                    index3 = index3 == -1 ? 99999 : index3;
                    //int minValue = new int[] { /*index1,*/ index2, index3 }.ToArray().Min();
                    int minValue = index2;
                    if (index2 > index3)
                    {
                        minValue = index3;
                    }
                    if (minValue == 99999) minValue = 0;
                    string prefix = OutString.Substring(minValue, index - minValue);
                    if (prefix.IndexOf("\r\n") != -1)
                        prefix = prefix.Substring(prefix.LastIndexOf("\r\n") + 2);
                    if (prefix.IndexOf("(") != -1)
                        prefix = prefix.Substring(prefix.LastIndexOf("(") + 1);
                    //list.Add(prefix.Trim() + m.Groups[0].Value);
                    if (prefix == "table")//解析table结构
                    {
                        string table = m.Groups[0].Value;
                        MatchString(table.Substring(1, table.Length - 1), r, list);
                        //SQL
                        string ls_sql = table.Substring(table.IndexOf("retrieve=\"") + 10);
                        ls_sql = ls_sql.Substring(0, ls_sql.Length - 1);
                        string sql = ls_sql.Substring(0, ls_sql.IndexOf("\""));
                        list.Add("retrieve=" + sql);
                        string ls_last = ls_sql.Substring(ls_sql.IndexOf("\"") + 1);
                        string[] last = ls_last.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string str in last)
                        {
                            list.Add(str.Trim());
                        }
                    }
                    //递归
                    //MatchString(m.Groups[0].Value.Substring(1, m.Groups[0].Value.Length - 1), r, list);// 去掉匹配到的头和尾的 "[" 和 "]"，避免陷入死循环递归中，导致溢出
                }
            }
            return;
        }
        /// <summary>
        /// 根据Dw文本获取SQL
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetSQLbyDwText(string as_dwText)
        {
            int li_RetrieveBegin;
            li_RetrieveBegin = as_dwText.IndexOf("retrieve=");
            if (li_RetrieveBegin < 0) { return ""; }

            //查找第一个引号
            int li_Begin = as_dwText.IndexOf("\"", li_RetrieveBegin + "retrieve=".Length);
            if (li_Begin < 0) { return ""; }

            int li_End = as_dwText.IndexOf("\"", li_Begin + 1);
            if (li_End < 0) { return ""; }

            string ls_SQL;
            ls_SQL = as_dwText.Substring(li_Begin + 1, li_End - li_Begin - 1); //减去2个引号

            //todo 先简单的把 : 处理成@
            ls_SQL = ls_SQL.Replace(":", "@");

            return ls_SQL;

            //if (sort != "" && sql != "" && sql.ToUpper().IndexOf("ORDER BY") == -1)
            //{
            //    sort = sort.Replace(" A", " ASC").Replace(" D", " DESC");
            //    sql += "\r\norder by " + sort;
            //}

            //if (arguments != "")  //todo参数不止一个，暂时先处理一个
            //{
            //    arguments = arguments.Substring(arguments.IndexOf("\"") + 1);
            //    arguments = arguments.Substring(0, arguments.IndexOf("\"")); 
            //}


            //sql = sql.Replace(":" + arguments, "@" + arguments);
            //return sql;
        }
    }
}
