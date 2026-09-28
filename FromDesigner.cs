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
            ApplyLanguage();
            designerControl1._overlayer.Init(800, 500, Lang.T("新建设计"));
        }

        #region 多语言
        /// <summary>
        /// 按当前语言刷新界面文字
        /// </summary>
        private void ApplyLanguage()
        {
            操作ToolStripMenuItem.Text = Lang.T("菜单");
            新建ToolStripMenuItem.Text = Lang.T("新建");
            打开ToolStripMenuItem.Text = Lang.T("打开");
            保存ToolStripMenuItem.Text = Lang.T("保存");
            退出ToolStripMenuItem.Text = Lang.T("退出");
            视图ToolStripMenuItem.Text = Lang.T("视图");
            设计器最大化ToolStripMenuItem.Text = Lang.T("设计器最大化");
            还原ToolStripMenuItem.Text = Lang.T("还原");
            语言ToolStripMenuItem.Text = Lang.T("语言");
            中文ToolStripMenuItem.Checked = Lang.Current == Language.Chinese;
            englishToolStripMenuItem.Checked = Lang.Current == Language.English;
            deutschToolStripMenuItem.Checked = Lang.Current == Language.German;

            tool_auto.Text = Lang.T("微调");
            toolStrip_align.Text = Lang.T("对齐");
            toolStrip_center_left.Text = Lang.T("左对齐");
            toolStrip_center_top.Text = Lang.T("上对齐");

            //工具箱(控件名用于创建控件,不翻译)
            SetTool(toolMenuItems_tools, "所有Windows窗体", "工具箱,将下列控件拖到设计器里可添加对应控件");
            SetTool(toolMenuItems_tools_cus, "自定义控件", "从.net程序集添加外部控件");
            SetTool(toolMenuItems_adds, "从程序集添加...", "单击从.net程序集添加外部控件");
            SetTool(toolMenuItems_panel, null, "允许对控件集合分组");
            SetTool(toolMenuItems_label, null, "为控件提供说明性文字");
            SetTool(toolMenuItems_checkbox, null, "允许用户选择或清除关联选项");
            SetTool(toolMenuItems_treeview, null, "树形结构,显示可选择包含图像的标签项的分层集合");
            SetTool(toolMenuItems_progressbar, null, "显示操作进度的填充条");
            SetTool(toolMenuItems_textbox, null, "允许用户输入文本,并提供多行编辑及密码字符掩码功能");
            SetTool(toolMenuItems_picturebox, null, "\n显示图片");
            SetTool(toolMenuItems_button, null, "按钮,用户单击时引发事件");
            SetTool(toolMenuItems_linklabel, null, "显示支持超链接的标签");
            SetTool(toolMenuItems_radiobutton, null, "当与其他单选按钮成对出现时,允许用户从一组选项中选择单个选项");
            SetTool(toolMenuItems_datetimepicker, null, "\n选择日期和时间,并指定格式");
            SetTool(toolMenuItems_combobox, null, "显示一个可编辑的文本框,其中包括一个一个允许值下拉列表");
            SetTool(toolMenuItems_listbox, null, "显示用户可以从中选择项的列表");

            if (designerControl1.ContextMenuStrip != null && designerControl1.ContextMenuStrip.Items.Count > 0)
                designerControl1.ContextMenuStrip.Items[0].Text = Lang.T("编辑SQL");

            //重新加载属性窗口,使属性名称与分组按新语言显示
            object selected = propertyGrid1.SelectedObject;
            propertyGrid1.SelectedObject = null;
            propertyGrid1.SelectedObject = selected;
        }

        private void SetTool(UserControls.ToolMenuItems tool, string name, string tip)
        {
            if (name != null)
                tool.ToolName = Lang.T(name);
            tool.ToolTip = Lang.T(tip);
            tool.RefreshToolTip();
        }

        private void SetLanguage(Language language)
        {
            Lang.Current = language;
            Lang.Save();
            ApplyLanguage();
        }

        private void 中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage(Language.Chinese);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage(Language.English);
        }

        private void deutschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage(Language.German);
        }
        #endregion

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
                of.Filter = Lang.T("net程序集(*.dll)|*.dll");
                if (of.ShowDialog() == DialogResult.OK)
                {
                    Assembly assem = null;
                    try
                    {
                        assem = Assembly.LoadFile(of.FileName);
                    }
                    catch
                    {
                        MessageBox.Show(Lang.T("不可识别程序集！"));
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
                                toolMenuItems.ToolTip = Lang.T("从外部加载的.net控件\n位置:") + of.FileName;
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
                MessageBox.Show(Lang.T("没有任何控件,不能保存."), Lang.T("提示"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = Lang.T("请选择保存路径与文件名");
            fileDialog.Filter = Lang.T("文本文件|*.txt|所有文件|*.*"); //设置要选择的文件的类型
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
                DialogResult dr = MessageBox.Show(Lang.T("当前设计将被覆盖,确定新建吗?\n建议先保存当前设计"),
                    Lang.T("提示"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel)
                    return;
            }
            designerControl1._overlayer.Init(800, 500, Lang.T("新建设计"));
            //designerControl1._hostFrame.Controls.Clear();
            //designerControl1._hostFrame.Text = "新建设计";
            //designerControl1._hostFrame.Width = 800;
            //designerControl1._hostFrame.Height = 500;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (designerControl1._overlayer.Controls.Count != 0)
            {
                DialogResult dr = MessageBox.Show(Lang.T("当前设计将被覆盖,确定新建吗?\n建议先保存当前设计"),
                    Lang.T("提示"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel)
                    return;
            }
            designerControl1._overlayer.Init(800, 500, Lang.T("新建设计"));
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = Lang.T("请选择文本文件");
            fileDialog.Filter = Lang.T("文本文件|*.txt|所有文件|*.*");
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = fileDialog.FileName;
                designerControl1._overlayer.DesingerFormText = Lang.T("自由型设计");
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add(Lang.T("编辑SQL"));
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
