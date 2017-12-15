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
    public partial class 入库 : Form
    {
        public 入库()
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
        private bool TextIsNotNull()
        {
            bool Flag = false;
            if (textBox1.Text =="")
            {
                Flag = true;
                textBox1.Select();
            }
            else if (textBox2.Text == "")
            {
                Flag = true;
                textBox2.Select();
            }
            else if (textBox3.Text == "")
            {
                Flag = true;
                textBox3.Select();
            }
            else if (textBox4.Text == "")
            {
                Flag = true;
                textBox4.Select();
            }
            else if (textBox5.Text == "")
            {
                Flag = true;
                textBox5.Select();
            }
            if (Flag == true)
                MessageBox.Show("请填写参数");
            return Flag;
        }
        private void IsFinal()
        {
            MessageBox.Show("已经添加成功\r\n进货单位:"+textBox1.Text+"\r\n名称:"+textBox2.Text+"\r\n数量:"+textBox3.Text
                +"\r\n单价:"+textBox4.Text+"\r\n结算单价:"+textBox5.Text+"\r\n备注"+textBox7.Text);
            this.Close();
        }
        private void RK_Load(object sender, EventArgs e)
        {
            DataTable dt = msh.GetDataTable("select * from `inload` where Flag=0 group by source");
            foreach(DataRow  dr in dt.Rows)
            {
                From_Names.Add(dr["source"].ToString());
            }
            DataTable dt1 = msh.GetDataTable("select * from `in_stock`  where Flag=0");
            foreach(DataRow dr in dt1.Rows)
            {
                In_Stock_Names.Add(dr["Name"].ToString());
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
            if (listBox1.Items.Count > 0)
            {
                listBox1.Visible = true;
                listBox1.SelectedIndex = 0;
            }
            else
                listBox1.Visible = false;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (listBox1.Visible == true && listBox1.Items.Count > 0 && listBox1.SelectedIndex<listBox1.Items.Count-1)
                {
                    listBox1.SelectedIndex +=1;
                    listBox1.Focus();
                    textBox1.Focus();
                }
            }
            else if(e.KeyCode == Keys.Up)
            {
                if (listBox1.Visible == true && listBox1.Items.Count > 0 &&listBox1.SelectedIndex>0)
                {
                    listBox1.SelectedIndex -=1;
                    listBox1.Focus();
                    textBox1.Focus();
                }
            }
            if(e.KeyCode==Keys.Enter)
            {
                if (listBox1.Visible == true)
                    textBox1.Text = listBox1.SelectedItem.ToString();
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
            if (e.KeyCode == Keys.Down)
            {
                if (listBox2.Visible == true && listBox2.Items.Count > 0 &&listBox2.SelectedIndex<listBox2.Items.Count-1)
                {
                    listBox2.SelectedIndex +=1;
                    listBox2.Focus();
                    textBox2.Focus();
                }
            }
            else if(e.KeyCode == Keys.Up)
            {
                if(listBox2.Visible == true && listBox2.Items.Count > 0 && listBox2.SelectedIndex>0)
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
            if (listBox2.Items.Count > 0)
            {
                listBox2.Visible = true;
                listBox2.SelectedIndex = 0;
            }
            else
                listBox2.Visible = false;
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
                textBox7.Select();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!TextIsNotNull())
            {
                MySqlParameter[] msp = new MySqlParameter[10];
                string sqlStr = "";
                bool Flag = false;
                msp[0] = new MySqlParameter("?ID", MySqlDbType.Int32, 10);
                msp[1] = new MySqlParameter("?Name", MySqlDbType.VarChar, 80);
                msp[1].Value = textBox2.Text;
                msp[2] = new MySqlParameter("?Date", MySqlDbType.VarChar, 20);
                msp[2].Value = DateTime.Now.ToString("D");
                msp[3] = new MySqlParameter("?amount", MySqlDbType.Int32, 10);
                msp[3].Value = textBox3.Text;
                msp[4] = new MySqlParameter("?cost_price", MySqlDbType.Decimal, 10);
                msp[4].Value = textBox4.Text;
                msp[5] = new MySqlParameter("?price", MySqlDbType.Decimal, 10);
                msp[5].Value = textBox5.Text;
                //msp[6] = new MySqlParameter("?Address", MySqlDbType.VarChar, 80);
                //msp[6].Value = textBox6.Text;
                msp[6] = new MySqlParameter("?Remark", MySqlDbType.VarChar, 80);
                msp[6].Value = textBox7.Text;
                msp[7] = new MySqlParameter("?Flag", MySqlDbType.Int16, 1);
                msp[7].Value = 1;
                msp[8] = new MySqlParameter("?source", MySqlDbType.VarChar, 80);
                msp[8].Value = textBox1.Text;
                msp[9] = new MySqlParameter("?source_RC", MySqlDbType.Int32, 10);
                //先去库存表内找是否有该商品
                sqlStr = "select * from in_stock where Name=?Name  and price=?price and cost_price=?cost_price and Flag=0";
                if (msh.ExecuteDataTable(sqlStr, msp).Rows.Count == 1)
                {
                    sqlStr = "update in_stock set amount=amount+?amount where Name=?Name  and price=?price and cost_price=?cost_price and Flag=0";
                    if(msh.ExecuteNonQuery(sqlStr,msp)==1)
                    {
                        Flag = true;
                    }
                }
                else
                {
                    sqlStr = "insert into in_stock(Name,amount,price,cost_price,Flag)"
                             + " values (?Name,?amount,?price,?cost_price,0)";
                    if (msh.ExecuteNonQuery(sqlStr, msp) == 1)//是否添加库存表成功
                    {
                        Flag = true;
                    }
                }
                if(Flag==true)//in_stock表修改成功，追加inload表
                {
                    //查询库存表中的商品ID
                    sqlStr = "select * from in_stock where Name=?Name and Flag=0";
                    DataTable temp = msh.GetDataTable(sqlStr, msp);
                    msp[0].Value = temp.Rows[0]["ID"];
                    //获取入库的序列号
                    sqlStr = "select * from inload where source=?source";
                    temp = msh.GetDataTable(sqlStr, msp);
                    int source_RC = 0;
                    foreach (DataRow dr in temp.Rows)
                    {
                        if (dr["Date"].ToString().Substring(0, 4) == DateTime.Now.ToString("D").Substring(4))
                        {
                            if (int.Parse(dr["source_RC"].ToString()) > source_RC)
                            {
                                source_RC = int.Parse(dr["source_RC"].ToString());
                            }
                        }
                    }
                    msp[9].Value = source_RC + 1;
                    sqlStr = "insert into inload(In_stock_ID,In_stock_Name,Date,Amount,price,cost_price,source,source_RC,Remark,Flag) "
                              + "values (?ID,?Name,?Date,?amount,?price,?cost_price,?source,?source_RC,?Remark,0)";
                    if (msh.ExecuteNonQuery(sqlStr, msp) == 1)
                        IsFinal();
                }
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!listBox1.Focused)
            {
                listBox1.Items.Clear();
                listBox1.Visible = false;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (!listBox2.Focused)
            {
                listBox2.Items.Clear();
                listBox2.Visible = false;
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
