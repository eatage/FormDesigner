using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace FormDesinger
{
    /// <summary>
    /// 文本编辑器
    /// </summary>
    public partial class Notepad : Form
    {
        public Notepad(object source)
        {
            InitializeComponent();

            undoAndRedo = new UndoAndRedo(6);
            this.txtContent.Seperators.Remove('-');//SQL的注释比较特殊,分析语句时去掉 - 分隔符
            this.txtContent.ConfigFile = "SQL.xml";
            this.txtContent.MouseWheel += new MouseEventHandler(txtContect_MouseWheel);
            if (source != null)
            {
                txtContent.Text = source.ToString();
                撤销ToolStripMenuItem.Enabled = false;
                恢复ToolStripMenuItem.Enabled = false;
                txtContent.SelectionStart = 0;
            }
        }
        public string SQL
        {
            get { return txtContent.Text; }
        }
        private UndoAndRedo undoAndRedo;
        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();

            撤销ToolStripMenuItem.Enabled = true;
            恢复ToolStripMenuItem.Enabled = true;
            undoAndRedo.execute(txtContent.Text);
        }

        //鼠标滚动
        void txtContect_MouseWheel(object sender, MouseEventArgs e)
        {
            panel1.Invalidate();
        }

        // 上、下键 全选
        private void txtContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                ((TextBox)sender).SelectAll();
            else
                panel1.Invalidate();
        }

        private void txtContent_KeyUp(object sender, KeyEventArgs e)
        {
            panel1.Invalidate();
        }


        //文本框大小改变
        private void txtContent_SizeChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        #region Method
        private void ShowCursorLine()
        {
            tssl_Lines.Text = string.Format("第{0}行", (this.txtContent.GetLineFromCharIndex(this.txtContent.SelectionStart) + 1));
            tssl_TotalStr.Text = string.Format("共{0}个字符", txtContent.Text.Length);
        }


        #endregion

        #region Menu

        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Checked)
            {
                txtContent.WordWrap = false;
                txtContent.ScrollBars = RichTextBoxScrollBars.Both;
                (sender as ToolStripMenuItem).Checked = false;
            }
            else
            {
                txtContent.WordWrap = true;
                txtContent.ScrollBars = RichTextBoxScrollBars.Vertical;
                (sender as ToolStripMenuItem).Checked = true;
            }
            panel1.Invalidate();
            ShowCursorLine();
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = txtContent.Font;
            fd.ShowEffects = false;
            DialogResult dr = fd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtContent.Font = fd.Font;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoAndRedo.undo();
            this.txtContent.Text = undoAndRedo.Record;
            this.txtContent.Select(this.txtContent.TextLength, 0);
        }

        private void 恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoAndRedo.redo();
            this.txtContent.Text = undoAndRedo.Record;
            this.txtContent.Select(this.txtContent.TextLength, 0);
        }

        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Checked)
            {
                (sender as ToolStripMenuItem).Checked = false;
                statusStrip1.Visible = false;
                txtContent.Height += 22;
                panel1.Height += 22;
            }
            else
            {
                (sender as ToolStripMenuItem).Checked = true;
                statusStrip1.Visible = true;
                txtContent.Height -= 22;
                panel1.Height -= 22;
            }
        }

        #endregion
        //以下是待实现部分 是否提示保存逻辑待优化
        private void 编辑EToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (txtContent.Text == "")
            {
                剪切TToolStripMenuItem.Enabled = false;
                复制CToolStripMenuItem.Enabled = false;
                删除LToolStripMenuItem.Enabled = false;
                全选AToolStripMenuItem.Enabled = false;
                return;
            }
            else if (txtContent.SelectedText != "")
            {
                剪切TToolStripMenuItem.Enabled = true;
                复制CToolStripMenuItem.Enabled = true;
                删除LToolStripMenuItem.Enabled = true;
            }
            全选AToolStripMenuItem.Enabled = true;
        }

        private void 剪切TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string value = this.txtContent.SelectedText;
            int index = this.txtContent.SelectionStart;
            if (!string.IsNullOrEmpty(value))
            {
                Clipboard.SetDataObject(value);
                this.txtContent.Text = this.txtContent.Text.Remove(index, value.Length);
                txtContent.SelectionStart = index;
            }
        }

        private void 复制CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string value = this.txtContent.SelectedText;
            if (!string.IsNullOrEmpty(value))
            {
                Clipboard.SetDataObject(value);
            }
        }

        private void 粘贴PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
            {
                string value = (String)iData.GetData(DataFormats.Text);
                int index = txtContent.SelectionStart;
                txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, value);
                txtContent.SelectionStart = index + value.Length;
            }
        }

        private void 删除LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string value = this.txtContent.SelectedText;
            int index = this.txtContent.SelectionStart;
            if (!string.IsNullOrEmpty(value))
            {
                this.txtContent.Text = this.txtContent.Text.Remove(index, value.Length);
                txtContent.SelectionStart = index;
            }
        }

        public RichTextBox TxtContext { get { return txtContent; } }


        private void 全选AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtContent.SelectAll();
        }

        private void Notepad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtContent.Text == "")
            {
                this.DialogResult = DialogResult.Cancel;
                return; 
            }
            if (this.DialogResult != DialogResult.OK)
            {
                DialogResult dr = MessageBox.Show("退出前是否保存编辑信息？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.Yes)
                    保存ToolStripMenuItem_Click(null, e);
                else
                    this.DialogResult = DialogResult.Cancel;
            }
            else
                保存ToolStripMenuItem_Click(null, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            showLineNo();
        }
        private void showLineNo()
        {
            //获得当前坐标信息
            //Point p = this.richTextBox1.Location;
            Point p = new Point(0, 0);
            int crntFirstIndex = this.txtContent.GetCharIndexFromPosition(p);
            int crntFirstLine = this.txtContent.GetLineFromCharIndex(crntFirstIndex);
            Point crntFirstPos = this.txtContent.GetPositionFromCharIndex(crntFirstIndex);

            p.Y += this.txtContent.Height;

            int crntLastIndex = this.txtContent.GetCharIndexFromPosition(p);
            int crntLastLine = this.txtContent.GetLineFromCharIndex(crntLastIndex);
            Point crntLastPos = this.txtContent.GetPositionFromCharIndex(crntLastIndex);

            Graphics g = this.panel1.CreateGraphics();
            Font font = new Font(this.txtContent.Font, this.txtContent.Font.Style);
            SolidBrush brush = new SolidBrush(Color.FromArgb(245, 245, 245));

            //画图开始
            //刷新画布
            Rectangle rect = this.panel1.ClientRectangle;
            brush.Color = this.panel1.BackColor;
            g.FillRectangle(brush, 0, 0, this.panel1.ClientRectangle.Width, this.panel1.ClientRectangle.Height);
            brush.Color = Color.FromArgb(245, 245, 245);//重置画笔颜色

            //绘制行号
            int lineSpace = 0;
            if (crntFirstLine != crntLastLine)
            {
                lineSpace = (crntLastPos.Y - crntFirstPos.Y) / (crntLastLine - crntFirstLine);
            }
            else
            {
                lineSpace = Convert.ToInt32(this.txtContent.Font.Size);
            }
            int brushX = this.panel1.ClientRectangle.Width - Convert.ToInt32(font.Size * 3.0);
            int brushY = crntLastPos.Y + Convert.ToInt32(font.Size * 0.21f);
            for (int i = crntLastLine; i >= crntFirstLine; i--)
            {
                g.DrawString((i + 1).ToString(), font, brush, brushX, brushY);
                brushY -= lineSpace;
            }
            g.Dispose();
            font.Dispose();
            brush.Dispose();
            ShowCursorLine();
        }

        private void txtContent_VScroll(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void txtContent_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Invalidate();
        }
    }
}