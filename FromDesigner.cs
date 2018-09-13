using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace FormDesinger
{
    public partial class FromDesigner : Form
    {
        public FromDesigner()
        {
            InitializeComponent();
            designerControl1._overlayer.Init(800, 500, "新建设计");
        }

        /// <summary>
        /// 拖拽控件
        /// </summary>
        private void toolMenuItems_MouseDown(object sender, MouseEventArgs e)
        {
            ToolStripItem ctrl = sender as ToolStripItem;
            if (ctrl != null)
            {
                string[] strs = { ctrl.Tag == null ? "" : ctrl.Tag.ToString(), ctrl.Text };
                DoDragDrop(strs, DragDropEffects.Copy);
            }
            else
            {
                UserControls.ToolMenuItems tool = sender as UserControls.ToolMenuItems;
                if (tool != null)
                {
                    string[] strs = { tool.Tag == null ? "" : tool.Tag.ToString(), tool.Text };
                    DoDragDrop(strs, DragDropEffects.Copy);
                }
            }
        }
        private Point LastAddToolsLocation = new Point(-1, -1);
        /// <summary>
        /// 添加控件
        /// <para>外部控件</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolMenuItems_adds_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "net程序集(*.dll)|*.dll";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    Assembly assem = null;
                    try
                    {
                        assem = Assembly.LoadFile(of.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("不可识别程序集！");
                    }
                    if (assem != null)
                    {
                        using (AddControlDialog add = new AddControlDialog())
                        {
                            add.Assembly = assem;
                            if (add.ShowDialog() == DialogResult.OK)
                            {
                                //ToolStripMenuItem i = new ToolStripMenuItem(add.CtrlName);
                                //i.Tag = add.FullName + "/" + of.FileName;
                                ////toolStrip1.Items.Insert(toolStrip1.Items.Count - 1, i);
                                //i.MouseDown += new MouseEventHandler(toolStripButton10_MouseDown);
                                //添加菜单
                                UserControls.ToolMenuItems toolMenuItems = new UserControls.ToolMenuItems();
                                toolMenuItems.ToolImage = Properties.Resources.tools_settings_24px;
                                toolMenuItems.ToolName = add.FullName;
                                toolMenuItems.ToolTag = add.FullName + "/" + of.FileName;
                                toolMenuItems.ToolTip = "从外部加载的.net控件\n位置:" + of.FileName;
                                toolMenuItems.Size = new Size(136, 22);
                                toolMenuItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                                toolMenuItems.MouseDown += new MouseEventHandler(toolMenuItems_MouseDown);
                                if (LastAddToolsLocation == new Point(-1, -1))
                                    LastAddToolsLocation = new Point(toolMenuItems_adds.Location.X, toolMenuItems_adds.Location.Y + 23);
                                else
                                    LastAddToolsLocation = new Point(LastAddToolsLocation.X, LastAddToolsLocation.Y + 23);
                                toolMenuItems.Location = LastAddToolsLocation;
                                this.panel_tools_cus.Controls.Add(toolMenuItems);//从Panel容器中添加
                                toolMenuItems.BringToFront();
                            }
                        }
                    }
                }
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (designerControl1._overlayer.Controls.Count == 0)
            {
                MessageBox.Show("没有任何控件,不能保存.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "请选择保存路径与文件名";
            fileDialog.Filter = "文本文件|*.txt|所有文件|*.*"; //设置要选择的文件的类型
            fileDialog.FileName = "*.txt";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string text = new Core.ControlSave(designerControl1._overlayer).Save();
                string fileName = fileDialog.FileName;
                System.IO.File.WriteAllText(fileName, text, Encoding.UTF8);
            }
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (designerControl1._overlayer.Controls.Count != 0)
            {
                DialogResult dr = MessageBox.Show("当前设计将被覆盖,确定新建吗?\n建议先保存当前设计",
                    "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel)
                    return;
            }
            designerControl1._overlayer.Init(800, 500, "新建设计");
            //designerControl1._hostFrame.Controls.Clear();
            //designerControl1._hostFrame.Text = "新建设计";
            //designerControl1._hostFrame.Width = 800;
            //designerControl1._hostFrame.Height = 500;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (designerControl1._overlayer.Controls.Count != 0)
            {
                DialogResult dr = MessageBox.Show("当前设计将被覆盖,确定新建吗?\n建议先保存当前设计",
                    "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel)
                    return;
            }
            designerControl1._overlayer.Init(800, 500, "新建设计");
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文本文件";
            fileDialog.Filter = "文本文件|*.txt|所有文件|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = fileDialog.FileName;
                designerControl1._overlayer.DesingerFormText = "自由型设计";
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("编辑SQL");
                designerControl1.ContextMenuStrip = menu;

                string source = System.IO.File.ReadAllText(fileName);
                //Core.OldAnalysis old = new Core.OldAnalysis(designerControl1._overlayer);
                //old.of_LoaddwText(source);
                Core.Analysis anl = new Core.Analysis(designerControl1._overlayer);
                anl.Load(source);
                return;
            }
        }

        //微调
        private void tool_auto_Click(object sender, EventArgs e)
        {
            designerControl1._overlayer.ControlAlginFineTune();
        }
        //左对齐
        private void toolStrip_center_left_Click(object sender, EventArgs e)
        {
            designerControl1._overlayer.ControlAlgin(AlginType.Left);
        }
        //上对齐
        private void toolStrip_center_top_Click(object sender, EventArgs e)
        {
            designerControl1._overlayer.ControlAlgin(AlginType.Top);
        }

        private void 设计器最大化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitter1.SplitPosition = 0;
            splitter2.SplitPosition = 0;
        }

        private void 还原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitter1.SplitPosition = 138;
            splitter2.SplitPosition = 239;
        }
    }
}
