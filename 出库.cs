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
    public partial class 出库 : Form
    {
        public 出库()
        {
            InitializeComponent();
        }
        MySqlHelper msh = new MySqlHelper(Properties.Resources.MySqlConnStr);
        List<string> In_Stock_Names = new List<string>();
        int amount = 0;
        DataTable mainDT = new DataTable();
        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            label1.Visible = false;
            label11.Text = "";
            label6.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            listBox2.Items.Clear();
            listBox2.Visible = false;
        }
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

        private void 出库_Load(object sender, EventArgs e)
        {
            mainDT = msh.GetDataTable("select * from `in_stock`  where Flag=0");
            DataTable tempDT = msh.GetDataTable("select * from `in_stock`  where Flag=0 group by Name");
            foreach (DataRow dr in tempDT.Rows)
            {
                In_Stock_Names.Add(dr["Name"].ToString());
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (listBox2.Visible == true && listBox2.Items.Count > 0 && listBox2.SelectedIndex < listBox2.Items.Count - 1)
                {
                    listBox2.SelectedIndex += 1;
                    listBox2.Focus();
                    textBox1.Focus();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (listBox2.Visible == true && listBox2.Items.Count > 0 && listBox2.SelectedIndex > 0)
                {
                    listBox2.SelectedIndex -= 1;
                    listBox2.Focus();
                    textBox1.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (listBox2.Visible == true)
                    textBox1.Text = listBox2.SelectedItem.ToString();
                listBox2.Items.Clear();
                listBox2.Visible = false;
                textBox2.Select();
            }
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Text = listBox2.SelectedItem.ToString();
                textBox1.Select();
                listBox2.Items.Clear();
                listBox2.Visible = false;
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!IsNumber(textBox2.Text))
            {
                label6.Visible = true;
            }
            else
                label6.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                MySqlParameter[] msp = new MySqlParameter[7];
                msp[0] = new MySqlParameter("?ID", MySqlDbType.Int16, 10);
                msp[1] = new MySqlParameter("?Name", MySqlDbType.VarChar, 80);
                msp[2] = new MySqlParameter("?amount", MySqlDbType.Int32, 10);
                msp[3] = new MySqlParameter("?Date", MySqlDbType.VarChar, 20);
                msp[4] = new MySqlParameter("?cost_price", MySqlDbType.Decimal, 10);
                msp[5] = new MySqlParameter("?price", MySqlDbType.Decimal, 10);
                msp[6] = new MySqlParameter("?Remark", MySqlDbType.VarChar, 80);

                msp[1].Value = textBox1.Text;
                msp[2].Value = textBox2.Text;
                msp[3].Value = DateTime.Now.ToString("D");
                msp[4].Value = comboBox1.Text;
                msp[5].Value = textBox3.Text;
                msp[6].Value = textBox4.Text;
                DataTable dt = msh.GetDataTable("select * from in_stock where Name=?Name and cost_price=cost_price and Flag=0");
                if (dt.Rows.Count == 0)
                    MessageBox.Show("发生错误\r\n当前出库错误\r\n可能无该商品");
                else
                {
                    msp[0].Value = dt.Rows[0]["ID"];
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //离开Name文本并Listbox2隐藏，则去数据库中搜索该数据，有则添加进货价和售价，无则提示
            if (listBox2.Visible == false)
            {
                //MySqlParameter[] msp = new MySqlParameter[1];
                //msp[0] = new MySqlParameter("?Name", MySqlDbType.VarChar, 80);
                //msp[0].Value = textBox1.Text;
                //DataTable dt = msh.GetDataTable("select * from in_stock where Name=?Name and Flag=0", msp);
                DataTable dt = mainDT.Clone();
                foreach (DataRow dr in mainDT.Rows)
                {
                    if (textBox1.Text == dr["Name"].ToString())
                    {
                        dt.Rows.Add(dr.ItemArray);
                    }
                }
                if (dt.Rows.Count == 0)
                {
                    textBox1.SelectAll();
                    textBox1.Focus();
                    label1.Visible = true;
                    comboBox1.Items.Clear();
                }
                else
                {
                    label1.Visible = false;
                    comboBox1.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        comboBox1.Items.Add(dr["cost_price"]);
                    }
                    comboBox1.SelectedIndex = 0;
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string s = textBox1.Text;
            foreach (string name in In_Stock_Names)
            {
                if (name.Contains(s))
                {
                    listBox2.Items.Add(name);
                }
            }
            if (listBox2.Items.Count > 0)
            {
                listBox2.Visible = true;
                listBox2.SelectedIndex = 0;
            }
            else
                listBox2.Visible = false;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in mainDT.Rows)
            {
                if (dr["Name"].ToString() == textBox1.Text && dr["cost_price"].ToString() == comboBox1.Text)
                {
                    label11.Text = dr["amount"].ToString();
                    textBox2.SelectAll();
                    textBox2.Focus();
                    textBox3.Text = dr["price"].ToString();
                }
            }
        }
    }
}
