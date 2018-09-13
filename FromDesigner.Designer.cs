namespace FormDesinger
{
    partial class FromDesigner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FromDesigner));
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel_tools_cus = new System.Windows.Forms.Panel();
            this.panel_tools = new System.Windows.Forms.Panel();
            this.panel_top = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设计器最大化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.还原ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tool_auto = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_align = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStrip_center_left = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_center_top = new System.Windows.Forms.ToolStripMenuItem();
            this.designerControl1 = new FormDesinger.DesignerControl();
            this.toolMenuItems_adds = new FormDesinger.UserControls.ToolMenuItems();
            this.toolMenuItems_tools_cus = new FormDesinger.UserControls.ToolMenuItems();
            this.toolMenuItems1 = new FormDesinger.UserControls.ToolMenuItems();
            this.toolMenuItems_tools = new FormDesinger.UserControls.ToolMenuItems();
            this.toolMenuItems_checkbox = new FormDesinger.UserControls.ToolMenuItems();
            this.toolMenuItems_treeview = new FormDesinger.UserControls.ToolMenuItems();
            this.toolMenuItems_progressbar = new FormDesinger.UserControls.ToolMenuItems();
            this.toolMenuItems_textbox = new FormDesinger.UserControls.ToolMenuItems();
            this.toolMenuItems_picturebox = new FormDesinger.UserControls.ToolMenuItems();
            this.toolMenuItems_button = new FormDesinger.UserControls.ToolMenuItems();
            this.toolMenuItems_linklabel = new FormDesinger.UserControls.ToolMenuItems();
            this.toolMenuItems_radiobutton = new FormDesinger.UserControls.ToolMenuItems();
            this.toolMenuItems_datetimepicker = new FormDesinger.UserControls.ToolMenuItems();
            this.toolMenuItems_combobox = new FormDesinger.UserControls.ToolMenuItems();
            this.toolMenuItems_listbox = new FormDesinger.UserControls.ToolMenuItems();
            this.panel_left.SuspendLayout();
            this.panel_tools_cus.SuspendLayout();
            this.panel_tools.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_left
            // 
            this.panel_left.AutoScroll = true;
            this.panel_left.BackColor = System.Drawing.Color.White;
            this.panel_left.Controls.Add(this.panel_tools_cus);
            this.panel_left.Controls.Add(this.panel_tools);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 52);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(138, 593);
            this.panel_left.TabIndex = 0;
            // 
            // panel_tools_cus
            // 
            this.panel_tools_cus.BackColor = System.Drawing.Color.Transparent;
            this.panel_tools_cus.Controls.Add(this.toolMenuItems_adds);
            this.panel_tools_cus.Controls.Add(this.toolMenuItems_tools_cus);
            this.panel_tools_cus.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_tools_cus.Location = new System.Drawing.Point(0, 298);
            this.panel_tools_cus.Name = "panel_tools_cus";
            this.panel_tools_cus.Size = new System.Drawing.Size(138, 24);
            this.panel_tools_cus.TabIndex = 15;
            // 
            // panel_tools
            // 
            this.panel_tools.BackColor = System.Drawing.Color.Transparent;
            this.panel_tools.Controls.Add(this.toolMenuItems1);
            this.panel_tools.Controls.Add(this.toolMenuItems_tools);
            this.panel_tools.Controls.Add(this.toolMenuItems_checkbox);
            this.panel_tools.Controls.Add(this.toolMenuItems_treeview);
            this.panel_tools.Controls.Add(this.toolMenuItems_progressbar);
            this.panel_tools.Controls.Add(this.toolMenuItems_textbox);
            this.panel_tools.Controls.Add(this.toolMenuItems_picturebox);
            this.panel_tools.Controls.Add(this.toolMenuItems_button);
            this.panel_tools.Controls.Add(this.toolMenuItems_linklabel);
            this.panel_tools.Controls.Add(this.toolMenuItems_radiobutton);
            this.panel_tools.Controls.Add(this.toolMenuItems_datetimepicker);
            this.panel_tools.Controls.Add(this.toolMenuItems_combobox);
            this.panel_tools.Controls.Add(this.toolMenuItems_listbox);
            this.panel_tools.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_tools.Location = new System.Drawing.Point(0, 0);
            this.panel_tools.Name = "panel_tools";
            this.panel_tools.Size = new System.Drawing.Size(138, 298);
            this.panel_tools.TabIndex = 13;
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.toolStrip1);
            this.panel_top.Controls.Add(this.menuStrip1);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(1224, 52);
            this.panel_top.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_auto,
            this.toolStrip_align});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1224, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作ToolStripMenuItem,
            this.视图ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1224, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.操作ToolStripMenuItem.Text = "菜单";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设计器最大化ToolStripMenuItem,
            this.还原ToolStripMenuItem});
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // 设计器最大化ToolStripMenuItem
            // 
            this.设计器最大化ToolStripMenuItem.Name = "设计器最大化ToolStripMenuItem";
            this.设计器最大化ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.设计器最大化ToolStripMenuItem.Text = "设计器最大化";
            this.设计器最大化ToolStripMenuItem.Click += new System.EventHandler(this.设计器最大化ToolStripMenuItem_Click);
            // 
            // 还原ToolStripMenuItem
            // 
            this.还原ToolStripMenuItem.Name = "还原ToolStripMenuItem";
            this.还原ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.还原ToolStripMenuItem.Text = "还原";
            this.还原ToolStripMenuItem.Click += new System.EventHandler(this.还原ToolStripMenuItem_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGrid1.Location = new System.Drawing.Point(985, 52);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(239, 593);
            this.propertyGrid1.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.LightGray;
            this.splitter1.Location = new System.Drawing.Point(138, 52);
            this.splitter1.MinSize = 0;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 593);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.LightGray;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(983, 52);
            this.splitter2.MinSize = 0;
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(2, 593);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            // 
            // tool_auto
            // 
            this.tool_auto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_auto.Image = global::FormDesinger.Properties.Resources.reset_tune_72px;
            this.tool_auto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_auto.Name = "tool_auto";
            this.tool_auto.Size = new System.Drawing.Size(23, 22);
            this.tool_auto.Text = "微调";
            this.tool_auto.Click += new System.EventHandler(this.tool_auto_Click);
            // 
            // toolStrip_align
            // 
            this.toolStrip_align.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStrip_align.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_center_left,
            this.toolStrip_center_top});
            this.toolStrip_align.Image = global::FormDesinger.Properties.Resources.align_left_72px;
            this.toolStrip_align.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_align.Name = "toolStrip_align";
            this.toolStrip_align.Size = new System.Drawing.Size(29, 22);
            this.toolStrip_align.Text = "对齐";
            // 
            // toolStrip_center_left
            // 
            this.toolStrip_center_left.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_center_left.Image")));
            this.toolStrip_center_left.Name = "toolStrip_center_left";
            this.toolStrip_center_left.Size = new System.Drawing.Size(112, 22);
            this.toolStrip_center_left.Text = "左对齐";
            this.toolStrip_center_left.Click += new System.EventHandler(this.toolStrip_center_left_Click);
            // 
            // toolStrip_center_top
            // 
            this.toolStrip_center_top.Image = global::FormDesinger.Properties.Resources.align_top_72px;
            this.toolStrip_center_top.Name = "toolStrip_center_top";
            this.toolStrip_center_top.Size = new System.Drawing.Size(112, 22);
            this.toolStrip_center_top.Text = "上对齐";
            this.toolStrip_center_top.Click += new System.EventHandler(this.toolStrip_center_top_Click);
            // 
            // designerControl1
            // 
            this.designerControl1.AutoScroll = true;
            this.designerControl1.BackColor = System.Drawing.Color.White;
            this.designerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designerControl1.Location = new System.Drawing.Point(138, 52);
            this.designerControl1.Name = "designerControl1";
            this.designerControl1.Size = new System.Drawing.Size(847, 593);
            this.designerControl1.TabIndex = 4;
            // 
            // toolMenuItems_adds
            // 
            this.toolMenuItems_adds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolMenuItems_adds.BackColor = System.Drawing.Color.White;
            this.toolMenuItems_adds.Location = new System.Drawing.Point(0, 24);
            this.toolMenuItems_adds.Name = "toolMenuItems_adds";
            this.toolMenuItems_adds.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems_adds.TabIndex = 12;
            this.toolMenuItems_adds.ToolBackColor = System.Drawing.Color.White;
            this.toolMenuItems_adds.ToolFocusColor = System.Drawing.Color.DodgerBlue;
            this.toolMenuItems_adds.ToolFocusForeColor = System.Drawing.Color.White;
            this.toolMenuItems_adds.ToolImage = global::FormDesinger.Properties.Resources.tools_add_24px;
            this.toolMenuItems_adds.ToolIsMenu = null;
            this.toolMenuItems_adds.ToolIsMenuHeight = 0;
            this.toolMenuItems_adds.ToolName = "从程序集添加...";
            this.toolMenuItems_adds.ToolTag = null;
            this.toolMenuItems_adds.ToolTip = "单击从.net程序集添加外部控件";
            this.toolMenuItems_adds.Click += new System.EventHandler(this.toolMenuItems_adds_Click);
            // 
            // toolMenuItems_tools_cus
            // 
            this.toolMenuItems_tools_cus.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.toolMenuItems_tools_cus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toolMenuItems_tools_cus.Location = new System.Drawing.Point(0, 1);
            this.toolMenuItems_tools_cus.Name = "toolMenuItems_tools_cus";
            this.toolMenuItems_tools_cus.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems_tools_cus.TabIndex = 16;
            this.toolMenuItems_tools_cus.ToolBackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.toolMenuItems_tools_cus.ToolFocusColor = System.Drawing.Color.Khaki;
            this.toolMenuItems_tools_cus.ToolFocusForeColor = System.Drawing.Color.DimGray;
            this.toolMenuItems_tools_cus.ToolImage = global::FormDesinger.Properties.Resources.tools_open;
            this.toolMenuItems_tools_cus.ToolIsMenu = this.panel_tools_cus;
            this.toolMenuItems_tools_cus.ToolIsMenuHeight = 100;
            this.toolMenuItems_tools_cus.ToolName = "自定义控件";
            this.toolMenuItems_tools_cus.ToolTag = null;
            this.toolMenuItems_tools_cus.ToolTip = "从.net程序集添加外部控件";
            // 
            // toolMenuItems1
            // 
            this.toolMenuItems1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolMenuItems1.BackColor = System.Drawing.Color.White;
            this.toolMenuItems1.Location = new System.Drawing.Point(0, 277);
            this.toolMenuItems1.Name = "toolMenuItems1";
            this.toolMenuItems1.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems1.TabIndex = 14;
            this.toolMenuItems1.ToolBackColor = System.Drawing.Color.White;
            this.toolMenuItems1.ToolFocusColor = System.Drawing.Color.DodgerBlue;
            this.toolMenuItems1.ToolFocusForeColor = System.Drawing.Color.White;
            this.toolMenuItems1.ToolImage = global::FormDesinger.Properties.Resources.tools_panel_24px;
            this.toolMenuItems1.ToolIsMenu = null;
            this.toolMenuItems1.ToolIsMenuHeight = 0;
            this.toolMenuItems1.ToolName = "Panel";
            this.toolMenuItems1.ToolTag = null;
            this.toolMenuItems1.ToolTip = "允许对控件集合分组";
            this.toolMenuItems1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolMenuItems_MouseDown);
            // 
            // toolMenuItems_tools
            // 
            this.toolMenuItems_tools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolMenuItems_tools.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.toolMenuItems_tools.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toolMenuItems_tools.Location = new System.Drawing.Point(0, 1);
            this.toolMenuItems_tools.Name = "toolMenuItems_tools";
            this.toolMenuItems_tools.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems_tools.TabIndex = 13;
            this.toolMenuItems_tools.ToolBackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.toolMenuItems_tools.ToolFocusColor = System.Drawing.Color.Khaki;
            this.toolMenuItems_tools.ToolFocusForeColor = System.Drawing.Color.DimGray;
            this.toolMenuItems_tools.ToolImage = global::FormDesinger.Properties.Resources.tools_close;
            this.toolMenuItems_tools.ToolIsMenu = this.panel_tools;
            this.toolMenuItems_tools.ToolIsMenuHeight = 0;
            this.toolMenuItems_tools.ToolName = "所有Windows窗体";
            this.toolMenuItems_tools.ToolTag = null;
            this.toolMenuItems_tools.ToolTip = "工具箱,将下列控件拖到设计器里可添加对应控件";
            // 
            // toolMenuItems_checkbox
            // 
            this.toolMenuItems_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolMenuItems_checkbox.BackColor = System.Drawing.Color.White;
            this.toolMenuItems_checkbox.Location = new System.Drawing.Point(0, 70);
            this.toolMenuItems_checkbox.Name = "toolMenuItems_checkbox";
            this.toolMenuItems_checkbox.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems_checkbox.TabIndex = 3;
            this.toolMenuItems_checkbox.ToolBackColor = System.Drawing.Color.White;
            this.toolMenuItems_checkbox.ToolFocusColor = System.Drawing.Color.DodgerBlue;
            this.toolMenuItems_checkbox.ToolFocusForeColor = System.Drawing.Color.White;
            this.toolMenuItems_checkbox.ToolImage = global::FormDesinger.Properties.Resources.tools_checkbox_32px;
            this.toolMenuItems_checkbox.ToolIsMenu = null;
            this.toolMenuItems_checkbox.ToolIsMenuHeight = 0;
            this.toolMenuItems_checkbox.ToolName = "CheckBox";
            this.toolMenuItems_checkbox.ToolTag = null;
            this.toolMenuItems_checkbox.ToolTip = "允许用户选择或清除关联选项";
            this.toolMenuItems_checkbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolMenuItems_MouseDown);
            // 
            // toolMenuItems_treeview
            // 
            this.toolMenuItems_treeview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolMenuItems_treeview.BackColor = System.Drawing.Color.White;
            this.toolMenuItems_treeview.Location = new System.Drawing.Point(0, 254);
            this.toolMenuItems_treeview.Name = "toolMenuItems_treeview";
            this.toolMenuItems_treeview.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems_treeview.TabIndex = 11;
            this.toolMenuItems_treeview.ToolBackColor = System.Drawing.Color.White;
            this.toolMenuItems_treeview.ToolFocusColor = System.Drawing.Color.DodgerBlue;
            this.toolMenuItems_treeview.ToolFocusForeColor = System.Drawing.Color.White;
            this.toolMenuItems_treeview.ToolImage = global::FormDesinger.Properties.Resources.tools_treeview_32px;
            this.toolMenuItems_treeview.ToolIsMenu = null;
            this.toolMenuItems_treeview.ToolIsMenuHeight = 0;
            this.toolMenuItems_treeview.ToolName = "TreeView";
            this.toolMenuItems_treeview.ToolTag = null;
            this.toolMenuItems_treeview.ToolTip = "树形结构,显示可选择包含图像的标签项的分层集合";
            this.toolMenuItems_treeview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolMenuItems_MouseDown);
            // 
            // toolMenuItems_progressbar
            // 
            this.toolMenuItems_progressbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolMenuItems_progressbar.BackColor = System.Drawing.Color.White;
            this.toolMenuItems_progressbar.Location = new System.Drawing.Point(0, 231);
            this.toolMenuItems_progressbar.Name = "toolMenuItems_progressbar";
            this.toolMenuItems_progressbar.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems_progressbar.TabIndex = 10;
            this.toolMenuItems_progressbar.ToolBackColor = System.Drawing.Color.White;
            this.toolMenuItems_progressbar.ToolFocusColor = System.Drawing.Color.DodgerBlue;
            this.toolMenuItems_progressbar.ToolFocusForeColor = System.Drawing.Color.White;
            this.toolMenuItems_progressbar.ToolImage = global::FormDesinger.Properties.Resources.tools_progressbar_24px;
            this.toolMenuItems_progressbar.ToolIsMenu = null;
            this.toolMenuItems_progressbar.ToolIsMenuHeight = 0;
            this.toolMenuItems_progressbar.ToolName = "ProgressBar";
            this.toolMenuItems_progressbar.ToolTag = null;
            this.toolMenuItems_progressbar.ToolTip = "显示操作进度的填充条";
            this.toolMenuItems_progressbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolMenuItems_MouseDown);
            // 
            // toolMenuItems_textbox
            // 
            this.toolMenuItems_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolMenuItems_textbox.BackColor = System.Drawing.Color.White;
            this.toolMenuItems_textbox.Location = new System.Drawing.Point(0, 24);
            this.toolMenuItems_textbox.Name = "toolMenuItems_textbox";
            this.toolMenuItems_textbox.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems_textbox.TabIndex = 1;
            this.toolMenuItems_textbox.ToolBackColor = System.Drawing.Color.White;
            this.toolMenuItems_textbox.ToolFocusColor = System.Drawing.Color.DodgerBlue;
            this.toolMenuItems_textbox.ToolFocusForeColor = System.Drawing.Color.White;
            this.toolMenuItems_textbox.ToolImage = global::FormDesinger.Properties.Resources.tools_textbox_50px;
            this.toolMenuItems_textbox.ToolIsMenu = null;
            this.toolMenuItems_textbox.ToolIsMenuHeight = 0;
            this.toolMenuItems_textbox.ToolName = "TextBox";
            this.toolMenuItems_textbox.ToolTag = null;
            this.toolMenuItems_textbox.ToolTip = "允许用户输入文本,并提供多行编辑及密码字符掩码功能";
            this.toolMenuItems_textbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolMenuItems_MouseDown);
            // 
            // toolMenuItems_picturebox
            // 
            this.toolMenuItems_picturebox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolMenuItems_picturebox.BackColor = System.Drawing.Color.White;
            this.toolMenuItems_picturebox.Location = new System.Drawing.Point(0, 208);
            this.toolMenuItems_picturebox.Name = "toolMenuItems_picturebox";
            this.toolMenuItems_picturebox.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems_picturebox.TabIndex = 9;
            this.toolMenuItems_picturebox.ToolBackColor = System.Drawing.Color.White;
            this.toolMenuItems_picturebox.ToolFocusColor = System.Drawing.Color.DodgerBlue;
            this.toolMenuItems_picturebox.ToolFocusForeColor = System.Drawing.Color.White;
            this.toolMenuItems_picturebox.ToolImage = global::FormDesinger.Properties.Resources.tools_picture_24px;
            this.toolMenuItems_picturebox.ToolIsMenu = null;
            this.toolMenuItems_picturebox.ToolIsMenuHeight = 0;
            this.toolMenuItems_picturebox.ToolName = "PictureBox";
            this.toolMenuItems_picturebox.ToolTag = null;
            this.toolMenuItems_picturebox.ToolTip = "\n显示图片";
            this.toolMenuItems_picturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolMenuItems_MouseDown);
            // 
            // toolMenuItems_button
            // 
            this.toolMenuItems_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolMenuItems_button.BackColor = System.Drawing.Color.White;
            this.toolMenuItems_button.Location = new System.Drawing.Point(0, 47);
            this.toolMenuItems_button.Name = "toolMenuItems_button";
            this.toolMenuItems_button.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems_button.TabIndex = 2;
            this.toolMenuItems_button.ToolBackColor = System.Drawing.Color.White;
            this.toolMenuItems_button.ToolFocusColor = System.Drawing.Color.DodgerBlue;
            this.toolMenuItems_button.ToolFocusForeColor = System.Drawing.Color.White;
            this.toolMenuItems_button.ToolImage = global::FormDesinger.Properties.Resources.tools_button_50pxt;
            this.toolMenuItems_button.ToolIsMenu = null;
            this.toolMenuItems_button.ToolIsMenuHeight = 0;
            this.toolMenuItems_button.ToolName = "Button";
            this.toolMenuItems_button.ToolTag = null;
            this.toolMenuItems_button.ToolTip = "按钮,用户单击时引发事件";
            this.toolMenuItems_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolMenuItems_MouseDown);
            // 
            // toolMenuItems_linklabel
            // 
            this.toolMenuItems_linklabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolMenuItems_linklabel.BackColor = System.Drawing.Color.White;
            this.toolMenuItems_linklabel.Location = new System.Drawing.Point(0, 185);
            this.toolMenuItems_linklabel.Name = "toolMenuItems_linklabel";
            this.toolMenuItems_linklabel.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems_linklabel.TabIndex = 8;
            this.toolMenuItems_linklabel.ToolBackColor = System.Drawing.Color.White;
            this.toolMenuItems_linklabel.ToolFocusColor = System.Drawing.Color.DodgerBlue;
            this.toolMenuItems_linklabel.ToolFocusForeColor = System.Drawing.Color.White;
            this.toolMenuItems_linklabel.ToolImage = global::FormDesinger.Properties.Resources.tools_linklabel_40px;
            this.toolMenuItems_linklabel.ToolIsMenu = null;
            this.toolMenuItems_linklabel.ToolIsMenuHeight = 0;
            this.toolMenuItems_linklabel.ToolName = "LinkLabel";
            this.toolMenuItems_linklabel.ToolTag = null;
            this.toolMenuItems_linklabel.ToolTip = "显示支持超链接的标签";
            this.toolMenuItems_linklabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolMenuItems_MouseDown);
            // 
            // toolMenuItems_radiobutton
            // 
            this.toolMenuItems_radiobutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolMenuItems_radiobutton.BackColor = System.Drawing.Color.White;
            this.toolMenuItems_radiobutton.Location = new System.Drawing.Point(0, 93);
            this.toolMenuItems_radiobutton.Name = "toolMenuItems_radiobutton";
            this.toolMenuItems_radiobutton.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems_radiobutton.TabIndex = 4;
            this.toolMenuItems_radiobutton.ToolBackColor = System.Drawing.Color.White;
            this.toolMenuItems_radiobutton.ToolFocusColor = System.Drawing.Color.DodgerBlue;
            this.toolMenuItems_radiobutton.ToolFocusForeColor = System.Drawing.Color.White;
            this.toolMenuItems_radiobutton.ToolImage = global::FormDesinger.Properties.Resources.tools_radiobutton_32px;
            this.toolMenuItems_radiobutton.ToolIsMenu = null;
            this.toolMenuItems_radiobutton.ToolIsMenuHeight = 0;
            this.toolMenuItems_radiobutton.ToolName = "RadioButton";
            this.toolMenuItems_radiobutton.ToolTag = null;
            this.toolMenuItems_radiobutton.ToolTip = "当与其他单选按钮成对出现时,允许用户从一组选项中选择单个选项";
            this.toolMenuItems_radiobutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolMenuItems_MouseDown);
            // 
            // toolMenuItems_datetimepicker
            // 
            this.toolMenuItems_datetimepicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolMenuItems_datetimepicker.BackColor = System.Drawing.Color.White;
            this.toolMenuItems_datetimepicker.Location = new System.Drawing.Point(0, 162);
            this.toolMenuItems_datetimepicker.Name = "toolMenuItems_datetimepicker";
            this.toolMenuItems_datetimepicker.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems_datetimepicker.TabIndex = 7;
            this.toolMenuItems_datetimepicker.ToolBackColor = System.Drawing.Color.White;
            this.toolMenuItems_datetimepicker.ToolFocusColor = System.Drawing.Color.DodgerBlue;
            this.toolMenuItems_datetimepicker.ToolFocusForeColor = System.Drawing.Color.White;
            this.toolMenuItems_datetimepicker.ToolImage = global::FormDesinger.Properties.Resources.tools_time_145px;
            this.toolMenuItems_datetimepicker.ToolIsMenu = null;
            this.toolMenuItems_datetimepicker.ToolIsMenuHeight = 0;
            this.toolMenuItems_datetimepicker.ToolName = "DateTimePicker";
            this.toolMenuItems_datetimepicker.ToolTag = null;
            this.toolMenuItems_datetimepicker.ToolTip = "\n选择日期和时间,并指定格式";
            this.toolMenuItems_datetimepicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolMenuItems_MouseDown);
            // 
            // toolMenuItems_combobox
            // 
            this.toolMenuItems_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolMenuItems_combobox.BackColor = System.Drawing.Color.White;
            this.toolMenuItems_combobox.Location = new System.Drawing.Point(0, 116);
            this.toolMenuItems_combobox.Name = "toolMenuItems_combobox";
            this.toolMenuItems_combobox.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems_combobox.TabIndex = 5;
            this.toolMenuItems_combobox.ToolBackColor = System.Drawing.Color.White;
            this.toolMenuItems_combobox.ToolFocusColor = System.Drawing.Color.DodgerBlue;
            this.toolMenuItems_combobox.ToolFocusForeColor = System.Drawing.Color.White;
            this.toolMenuItems_combobox.ToolImage = global::FormDesinger.Properties.Resources.tools_dropdown_50px;
            this.toolMenuItems_combobox.ToolIsMenu = null;
            this.toolMenuItems_combobox.ToolIsMenuHeight = 0;
            this.toolMenuItems_combobox.ToolName = "ComboBox";
            this.toolMenuItems_combobox.ToolTag = null;
            this.toolMenuItems_combobox.ToolTip = "显示一个可编辑的文本框,其中包括一个一个允许值下拉列表";
            this.toolMenuItems_combobox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolMenuItems_MouseDown);
            // 
            // toolMenuItems_listbox
            // 
            this.toolMenuItems_listbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolMenuItems_listbox.BackColor = System.Drawing.Color.White;
            this.toolMenuItems_listbox.Location = new System.Drawing.Point(0, 139);
            this.toolMenuItems_listbox.Name = "toolMenuItems_listbox";
            this.toolMenuItems_listbox.Size = new System.Drawing.Size(138, 22);
            this.toolMenuItems_listbox.TabIndex = 6;
            this.toolMenuItems_listbox.ToolBackColor = System.Drawing.Color.White;
            this.toolMenuItems_listbox.ToolFocusColor = System.Drawing.Color.DodgerBlue;
            this.toolMenuItems_listbox.ToolFocusForeColor = System.Drawing.Color.White;
            this.toolMenuItems_listbox.ToolImage = global::FormDesinger.Properties.Resources.tools_listbox_32px;
            this.toolMenuItems_listbox.ToolIsMenu = null;
            this.toolMenuItems_listbox.ToolIsMenuHeight = 0;
            this.toolMenuItems_listbox.ToolName = "ListBox";
            this.toolMenuItems_listbox.ToolTag = null;
            this.toolMenuItems_listbox.ToolTip = "显示用户可以从中选择项的列表";
            this.toolMenuItems_listbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolMenuItems_MouseDown);
            // 
            // FromDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 645);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.designerControl1);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.panel_top);
            this.Name = "FromDesigner";
            this.Text = "FromDesigner";
            this.panel_left.ResumeLayout(false);
            this.panel_tools_cus.ResumeLayout(false);
            this.panel_tools.ResumeLayout(false);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_top;
        public System.Windows.Forms.PropertyGrid propertyGrid1;
        private DesignerControl designerControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private UserControls.ToolMenuItems toolMenuItems_textbox;
        private UserControls.ToolMenuItems toolMenuItems_button;
        private UserControls.ToolMenuItems toolMenuItems_checkbox;
        private UserControls.ToolMenuItems toolMenuItems_radiobutton;
        private UserControls.ToolMenuItems toolMenuItems_combobox;
        private UserControls.ToolMenuItems toolMenuItems_listbox;
        private UserControls.ToolMenuItems toolMenuItems_datetimepicker;
        private UserControls.ToolMenuItems toolMenuItems_linklabel;
        private UserControls.ToolMenuItems toolMenuItems_picturebox;
        private UserControls.ToolMenuItems toolMenuItems_progressbar;
        private UserControls.ToolMenuItems toolMenuItems_treeview;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool_auto;
        private System.Windows.Forms.ToolStripDropDownButton toolStrip_align;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_center_left;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_center_top;
        private UserControls.ToolMenuItems toolMenuItems_adds;
        private UserControls.ToolMenuItems toolMenuItems_tools;
        private System.Windows.Forms.Panel panel_tools;
        private System.Windows.Forms.Panel panel_tools_cus;
        private UserControls.ToolMenuItems toolMenuItems_tools_cus;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设计器最大化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 还原ToolStripMenuItem;
        private UserControls.ToolMenuItems toolMenuItems1;



    }
}