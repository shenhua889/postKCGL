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
                DWXG dwxg = new DWXG();
                dwxg.MdiParent = this;
                //dwxg.WindowState = FormWindowState.Maximized;
                dwxg.Show();
            }
        }

        private void 入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DecideChildForm())
            {
                RK rk = new RK();
                rk.MdiParent = this;
                //rk.WindowState = FormWindowState.Maximized;
                rk.Show();
            }
        }

        private void 出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DecideChildForm())
            {
                CK ck = new CK();
                ck.MdiParent = this;
                //ck.WindowState = FormWindowState.Maximized;
                ck.Show();
            }
        }

        private void 库存查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DecideChildForm())
            {
                CX cx = new CX();
                cx.MdiParent = this;
                //cx.WindowState = FormWindowState.Maximized;
                cx.Show();
            }
        }

        private void 统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DecideChildForm())
            {
                TJ tj = new TJ();
                tj.MdiParent = this;
                //tj.WindowState = FormWindowState.Maximized;
                tj.Show();
            }
        }
    }
}
