using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FormDesinger
{
    public partial class AddControlDialog : Form
    {
        public string FullName = "";
        public string CtrlName = "";
        public AddControlDialog()
        {
            InitializeComponent();
        }
        public Assembly Assembly
        {
            set
            {
                listBox1.Items.Clear();
                foreach (Module module in value.GetModules())
                {
                    foreach (Type type in module.GetTypes())
                    {
                        if (type.IsSubclassOf(typeof(Control)) && !type.IsSubclassOf(typeof(Form)))
                        {
                            listBox1.Items.Add(type.FullName + "/" + type.Name);
                        }
                    }
                }
            }
        }
        private void AddControlDialog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                FullName = listBox1.SelectedItem.ToString().Split('/')[0];
                CtrlName = listBox1.SelectedItem.ToString().Split('/')[1];
                DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
