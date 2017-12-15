using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace postKCGL
{
    public partial class 追加 : Form
    {
        public 追加()
        {
            InitializeComponent();
        }
        MySqlHelper msh = new MySqlHelper(Properties.Resources.MySqlConnStr);
        List<string> From_Names = new List<string>();
        List<string> In_Stock_Names = new List<string>();
        private bool IsNumber(string s)
        {
            if (s == "")
                return true;
            foreach (char c in s)
            {
                if (!char.IsNumber(c))
                    return false;
            }
            return true;
        }
        private void 追加_Load(object sender, EventArgs e)
        {
            DataTable dt = msh.GetDataTable("select * from `inload` where Flag=0");
            foreach (DataRow dr in dt.Rows)
            {
                From_Names.Add(dr["source"].ToString());
            }
            DataTable dt1 = msh.GetDataTable("select * from `in_stock`  where Flag=0");
            foreach (DataRow dr in dt1.Rows)
            {
                In_Stock_Names.Add(dr["Name"].ToString());
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string selectSrting = textBox1.Text;
            foreach (string s in From_Names)
            {
                if (s.Contains(selectSrting))
                {
                    listBox1.Items.Add(s);
                }
            }
            if (listBox1.Items.Count > 0)
                listBox1.Visible = true;
            else
                listBox1.Visible = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (listBox1.Visible == true && listBox1.Items.Count > 0 && listBox1.SelectedIndex < listBox1.Items.Count - 1)
                {
                    listBox1.SelectedIndex += 1;
                    listBox1.Focus();
                    textBox1.Focus();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (listBox1.Visible == true && listBox1.Items.Count > 0 && listBox1.SelectedIndex > 0)
                {
                    listBox1.SelectedIndex -= 1;
                    listBox1.Focus();
                    textBox1.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (listBox1.Visible == true)
                    textBox1.Text = listBox1.SelectedItem.ToString();
                listBox1.Items.Clear();
                listBox1.Visible = false;
                textBox2.Select();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string s = textBox2.Text;
            foreach (string name in In_Stock_Names)
            {
                if (name.Contains(s))
                {
                    listBox2.Items.Add(name);
                }
            }
            if (listBox2.Items.Count > 0)
                listBox2.Visible = true;
            else
                listBox2.Visible = false;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (listBox2.Visible == true && listBox2.Items.Count > 0 && listBox2.SelectedIndex < listBox2.Items.Count - 1)
                {
                    listBox2.SelectedIndex += 1;
                    listBox2.Focus();
                    textBox2.Focus();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (listBox2.Visible == true && listBox2.Items.Count > 0 && listBox2.SelectedIndex > 0)
                {
                    listBox2.SelectedIndex -= 1;
                    listBox2.Focus();
                    textBox2.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (listBox2.Visible == true)
                    textBox2.Text = listBox2.SelectedItem.ToString();
                listBox2.Items.Clear();
                listBox2.Visible = false;
                textBox3.Select();
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
                textBox1.Select();
                listBox1.Items.Clear();
                listBox1.Visible = false;
            }
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Text = listBox2.SelectedItem.ToString();
                textBox2.Select();
                listBox2.Items.Clear();
                listBox2.Visible = false;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (listBox2.Focused == false)
            {
                MySqlParameter[] msp = new MySqlParameter[1];
                msp[0] = new MySqlParameter("?Name", MySqlDbType.VarChar, 80);
                msp[0].Value = textBox2.Text;
                string SQLstring = "select * from in_stock where Name=?Name and Flag=0";
                DataTable temp = msh.GetDataTable(SQLstring, msp);
                if (temp.Rows.Count == 1)
                {
                    textBox4.Text = temp.Rows[0]["cost_price"].ToString();
                    textBox5.Text = temp.Rows[0]["price"].ToString();
                    textBox6.Text = temp.Rows[0]["Address"].ToString();
                }
                else
                {
                    MessageBox.Show("获取商品名失败\r\n 请检查是否有该商品");
                    textBox2.Select();
                }
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            decimal d = new decimal();
            if (!decimal.TryParse(textBox3.Text, out d))
            {
                errorProvider1.SetError(textBox3, "这不是一个数字");
                //MessageBox.Show("这不是一个数字");
                textBox3.Select();
            }
            else
                errorProvider1.SetError(textBox3, "");
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Select();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
