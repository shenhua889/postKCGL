using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postKCGL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool DecideChildForm()
        {
            if (this.MdiChildren.Length == 0)
                return true;
            {
                MessageBox.Show("已有其他窗口打开");
                return false;
            }
        }
        private void 单位修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DecideChildForm())
            {
                单位修改 dwxg = new 单位修改();
                dwxg.MdiParent = this;
                //dwxg.WindowState = FormWindowState.Maximized;
                dwxg.Show();
            }
        }

        private void 入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DecideChildForm())
            {
                入库 rk = new 入库();
                rk.MdiParent = this;
                //rk.WindowState = FormWindowState.Maximized;
                rk.Show();
            }
        }

        private void 出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DecideChildForm())
            {
                出库 ck = new 出库();
                ck.MdiParent = this;
                //ck.WindowState = FormWindowState.Maximized;
                ck.Show();
            }
        }

        private void 库存查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DecideChildForm())
            {
                库存查询 cx = new 库存查询();
                cx.MdiParent = this;
                //cx.WindowState = FormWindowState.Maximized;
                cx.Show();
            }
        }

        private void 统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DecideChildForm())
            {
                统计 tj = new 统计();
                tj.MdiParent = this;
                //tj.WindowState = FormWindowState.Maximized;
                tj.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
