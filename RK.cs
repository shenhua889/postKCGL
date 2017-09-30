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
    public partial class RK : Form
    {
        public RK()
        {
            InitializeComponent();
        }
        MySqlHelper msh = new MySqlHelper(Properties.Resources.MySqlConnStr);
        List<string> From_Names = new List<string>();
        List<string> In_Stock_Names = new List<string>();
        private void RK_Load(object sender, EventArgs e)
        {
            DataTable dt = msh.GetDataTable("select * from load where Flag=0");
            foreach(DataRow  dr in dt.Rows)
            {
                From_Names.Add(dr["From"].ToString());
            }
            DataTable dt1 = msh.GetDataTable("select * from From where Flag=0");
            foreach(DataRow dr in dt1.Rows)
            {
                In_Stock_Names.Add(dr["In_stock_Name"].ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string selectSrting = textBox1.Text;
            foreach(string s in From_Names)
            {
                if(s.Contains(selectSrting))
                {
                    listBox1.Items.Add(s);
                }
            }
            listBox1.Visible = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Right || e.KeyCode==Keys.Left|| e.KeyCode==Keys.Up)
            {
                listBox1.SelectedIndex = 0;
                listBox1.Select();
            }
            if(e.KeyCode==Keys.Enter)
            {
                listBox1.Items.Clear();
                listBox1.Visible = false;
                textBox2.Select();
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

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
            {
                listBox2.SelectedIndex = 0;
                listBox2.Select();
            }
            if (e.KeyCode == Keys.Enter)
            {
                listBox2.Items.Clear();
                listBox2.Visible = false;
                textBox3.Select();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string s = textBox2.Text;
            foreach(string name in In_Stock_Names)
            {
                if(name.Contains(s))
                {
                    listBox2.Items.Add(name);
                }
            }
            listBox2.Visible = true;
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Select();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Select();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlParameter[] msp = new MySqlParameter[11];
            msp[0] = new MySqlParameter("?ID", MySqlDbType.Int32, 10);
            msp[1] = new MySqlParameter("?Name", MySqlDbType.VarChar, 80);
            msp[1].Value = textBox2.Text;
            msp[2] = new MySqlParameter("?Date", MySqlDbType.DateTime, 20);
            msp[2].Value = DateTime.Now.ToString("D");
            msp[3] = new MySqlParameter("?amount", MySqlDbType.Int32, 10);
            msp[3].Value = textBox3.Text;
            msp[4] = new MySqlParameter("?cost_price", MySqlDbType.Decimal, 10);
            msp[4].Value = textBox4.Text;
            msp[5] = new MySqlParameter("?price", MySqlDbType.Decimal, 10);
            msp[5].Value = textBox5.Text;
            msp[6] = new MySqlParameter("?Address", MySqlDbType.VarChar, 80);
            msp[6].Value = textBox6.Text;
            msp[7] = new MySqlParameter("?Remark", MySqlDbType.VarChar, 80);
            msp[7].Value = textBox7.Text;
            msp[8] = new MySqlParameter("?Flag", MySqlDbType.Int16, 1);
            msp[8].Value = 1;
            msp[9] = new MySqlParameter("?From", MySqlDbType.Int32, 10);
            msp[9].Value = textBox1.Text;
            msp[10] = new MySqlParameter("?From_ID", MySqlDbType.Int32, 10);
            string sqlStr = "insert into in_stock(Name,amount,price,cost_price,From,Address,Flag) values(?Name,?amount,?price,?cost_price,?From,?Address,0)";
            if(msh.ExecuteNonQuery(sqlStr, msp)==1)
            {
                sqlStr = "select * from in_stock where Name=?Name and amount=?amount and price=?price and cost_price=?cost_price";
                DataTable temp = msh.GetDataTable(sqlStr, msp);
                msp[0].Value = temp.Rows[0]["ID"];
                sqlStr = "select * from load where From=?From";
                temp = msh.GetDataTable(sqlStr, msp);
                int from_id = 0;
                foreach(DataRow dr in temp.Rows)
                {
                    if (dr["Date"].ToString().Substring(0, 4) == DateTime.Now.ToString("D").Substring(4))
                    {
                        if(int.Parse(dr["From_ID"].ToString())>from_id)
                        {
                            from_id = int.Parse(dr["From_ID"].ToString());
                        }
                    }
                }
                msp[10].Value = from_id;
                sqlStr = "insert into load(In_stock_ID,In_stock_Name,Date,Amount,price,cost_price,From,From_ID,Remark,Flag) values(?ID,?Name,?Date,?amount,?price,?cost_price,?From,?From_ID,?Remark,0)";
                msh.ExecuteNonQuery(sqlStr, msp);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Visible = false;
            listBox2.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        private bool IsNumber(string s)
        {
            foreach(char c in s)
            {
                if (!char.IsNumber(c))
                    return false;
            }
            return true;
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            decimal d = new decimal();
            if(!decimal.TryParse(textBox3.Text,out d))
            {
                MessageBox.Show("这不是一个数字");
                textBox3.Select();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            decimal d = new decimal();
            if (!decimal.TryParse(textBox4.Text, out d))
            {
                MessageBox.Show("这不是一个数字");
                textBox4.Select();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            decimal d = new decimal();
            if (!decimal.TryParse(textBox5.Text, out d))
            {
                MessageBox.Show("这不是一个数字");
                textBox5.Select();
            }
        }
    }
}
