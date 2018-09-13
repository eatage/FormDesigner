using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FormDesinger.UserControls
{
    public partial class ToolMenuItems : UserControl
    {
        public ToolMenuItems()
        {
            InitializeComponent();


            label1.MouseDown += ((s, e) => { OnMouseDown(e); });
            label1.MouseEnter += ((s, e) => { OnMouseEnter(e); });
            label1.MouseLeave += ((s, e) => { OnMouseLeave(e); });
            label1.Click += ((s, e) => { OnClick(e); });

            pictureBox1.MouseDown += ((s, e) => { OnMouseDown(e); });
            pictureBox1.MouseEnter += ((s, e) => { OnMouseEnter(e); });
            pictureBox1.MouseLeave += ((s, e) => { OnMouseLeave(e); });
            pictureBox1.Click += ((s, e) => { OnClick(e); });
        }
        #region 组合控件中的子控件鼠标事件、点击事件由父控件代理
        protected override void OnMouseEnter(EventArgs e)
        {
            BackColor = toolFocusColor;
            label1.ForeColor = toolFocusForeColor;
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            BackColor = toolBackColor;
            label1.ForeColor = Color.Black;
            base.OnMouseLeave(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }
        protected override void OnClick(EventArgs e)
        {
            if (toolIsMenu != null)
            {
                if (toolIsMenu.Height != 24)
                {
                    toolIsMenuHeight = toolIsMenu.Height;
                    this.ToolImage = Properties.Resources.tools_open;
                    toolIsMenu.Height = 24;
                }
                else
                {
                    this.ToolImage = Properties.Resources.tools_close;
                    if (toolIsMenuHeight == 0) toolIsMenuHeight = 175;
                    toolIsMenu.Height = toolIsMenuHeight;
                }
            }
            base.OnClick(e);
        }
        #endregion
        /// <summary>
        /// 工具名称
        /// </summary>
        [Browsable(true), Category("A-Tool属性"), Description("工具名称")]
        public string ToolName
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
        private string toolTip;

        /// <summary>
        /// 工具标识名称(当鼠标悬浮时显示)
        /// </summary>
        [Browsable(true), Category("A-Tool属性"), Description("工具标识名称(当鼠标悬浮时显示)")]
        public string ToolTip
        {
            get
            {
                return toolTip;
            }
            set
            {
                toolTip = value;
            }
        }
        /// <summary>
        /// 工具Tag
        /// </summary>
        [Browsable(true), Category("A-Tool属性"), Description("工具Tag")]
        public object ToolTag
        {
            get
            {
                return Tag;
            }
            set
            {
                Tag = value;
            }
        }

        private Color toolBackColor = Color.White;
        /// <summary>
        /// 工具背景颜色
        /// </summary>
        [Browsable(true), Category("A-Tool属性"), Description("工具背景颜色")]
        public Color ToolBackColor
        {
            get
            {
                return toolBackColor;
            }
            set
            {
                toolBackColor = value;
                this.BackColor = toolBackColor;
            }
        }

        private Color toolFocusColor = Color.DodgerBlue;
        /// <summary>
        /// 工具鼠标移过时背景颜色
        /// </summary>
        [Browsable(true), Category("A-Tool属性"), Description("工具鼠标移过时背景颜色")]
        public Color ToolFocusColor
        {
            get
            {
                return toolFocusColor;
            }
            set
            {
                toolFocusColor = value;
            }
        }

        private Color toolFocusForeColor = Color.White;
        /// <summary>
        /// 工具鼠标移过时前景颜色
        /// </summary>
        [Browsable(true), Category("A-Tool属性"), Description("工具鼠标移过时背景颜色")]
        public Color ToolFocusForeColor
        {
            get
            {
                return toolFocusForeColor;
            }
            set
            {
                toolFocusForeColor = value;
            }
        }

        private Image toolImage = Properties.Resources.tools_24px;
        /// <summary>
        /// 工具图标 规格:20x20
        /// </summary>
        [Browsable(true), Category("A-Tool属性"), Description("工具图标 规格:20x20")]
        public Image ToolImage
        {
            get
            {
                return toolImage;
            }
            set
            {
                toolImage = value;
                pictureBox1.Image = toolImage;
            }
        }

        private Control toolIsMenu;
        [Browsable(true), Category("A-Tool属性"), Description("是否作为菜单控件\n指定作为菜单控件时需要伸缩的容器")]
        public Control ToolIsMenu
        {
            get
            {
                return toolIsMenu;
            }
            set
            {
                toolIsMenu = value;
                if (value != null) this.Cursor = Cursors.Hand;
            }
        }

        private int toolIsMenuHeight;
        [Browsable(true), Category("A-Tool属性"), Description("当作为作为菜单控件时展开的高度")]
        public int ToolIsMenuHeight
        {
            get
            {
                return toolIsMenuHeight;
            }
            set
            {
                toolIsMenuHeight = value;
            }
        }

        public override string Text
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }

        public new object Tag
        {
            set;
            get;
        }

        private void ToolMenuItems_Load(object sender, EventArgs e)
        {
            string tip = string.Empty;
            if (string.IsNullOrEmpty(toolTip))
                tip = label1.Text;
            else
                tip = label1.Text + "\n" + toolTip;
            this.toolTip1.SetToolTip(this, tip);
            this.toolTip1.SetToolTip(this.label1, tip);
            this.toolTip1.SetToolTip(this.pictureBox1, tip);
        }
    }
}
