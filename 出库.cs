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
        List<string> Units = new List<string>();
        int amount = 0;
        DataTable mainDT = new DataTable();
        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Items.Clear();
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            label1.Visible = false;
            label11.Text = "";
            label8.Visible = false;
            label9.Visible = false;
            listBox1.Items.Clear();
            listBox1.Visible = false;
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
        private void isFianl()
        {
            MessageBox.Show("            入库成功\r\n名称:" + textBox1.Text + "\r\n单位:" + textBox2.Text+"\r\n单价:"+comboBox1.Text+"\r\n数量:"+textBox3.Text+"\r\n结算单价:"+textBox4.Text+"\r\n备注:"+textBox5.Text);
            Clear();
        }

        private void 出库_Load(object sender, EventArgs e)
        {
            mainDT = msh.GetDataTable("select * from `in_stock`  where Flag=0");
            DataTable tempDT = msh.GetDataTable("select * from `in_stock`  where Flag=0 group by Name");
            foreach (DataRow dr in tempDT.Rows)
            {
                In_Stock_Names.Add(dr["Name"].ToString());
            }
            tempDT = msh.GetDataTable("select * from unit where Flag=0");
            foreach(DataRow dr in tempDT.Rows)
            {
                Units.Add(dr["Name"].ToString());
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (listBox1.Visible == true && listBox1.Items.Count > 0 && listBox1.SelectedIndex < listBox1.Items.Count - 1)
                {
                    listBox1.SelectedIndex += 1;
                    listBox1.Focus();
                    textBox2.Focus();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (listBox1.Visible == true && listBox1.Items.Count > 0 && listBox1.SelectedIndex > 0)
                {
                    listBox1.SelectedIndex -= 1;
                    listBox1.Focus();
                    textBox2.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (listBox1.Visible == true)
                    textBox2.Text = listBox1.SelectedItem.ToString();
                listBox1.Items.Clear();
                listBox1.Visible = false;
                textBox3.Focus();
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
                textBox2.Focus();
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!IsNumber(textBox3.Text))
            {
                label8.Visible = true;
                textBox3.Focus();
            }
            else
            {
                label8.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "")
            {
                MySqlParameter[] msp = new MySqlParameter[10];
                msp[0] = new MySqlParameter("?ID", MySqlDbType.Int16, 10);
                msp[1] = new MySqlParameter("?Name", MySqlDbType.VarChar, 80);
                msp[2] = new MySqlParameter("?amount", MySqlDbType.Int32, 10);
                msp[3] = new MySqlParameter("?Date", MySqlDbType.VarChar, 20);
                msp[4] = new MySqlParameter("?cost_price", MySqlDbType.Decimal, 10);
                msp[5] = new MySqlParameter("?price", MySqlDbType.Decimal, 10);
                msp[6] = new MySqlParameter("?Remark", MySqlDbType.VarChar, 80);
                msp[7] = new MySqlParameter("?unit_Name", MySqlDbType.VarChar, 80);
                msp[8] = new MySqlParameter("?unit_ID", MySqlDbType.Int32, 10);
                msp[9] = new MySqlParameter("?Unit_RC", MySqlDbType.Int32, 10);

                msp[1].Value = textBox1.Text;//商品名
                msp[2].Value = textBox3.Text;//数量
                msp[3].Value = DateTime.Now.ToString("D");//日期
                msp[4].Value = comboBox1.Text;//进价
                msp[5].Value = textBox4.Text;//出价
                msp[6].Value = textBox5.Text;//备注
                msp[7].Value = textBox2.Text;//单位名
                

                DataTable dt = msh.GetDataTable("select * from in_stock where Name=?Name and cost_price=cost_price and Flag=0",msp);
                if (dt.Rows.Count == 0)//判断名字和进价是否存在
                    MessageBox.Show("发生错误\r\n当前出库错误\r\n可能无该商品");
                else
                {
                    msp[0].Value = dt.Rows[0]["ID"];//ID
                    dt = msh.GetDataTable("select * from unit where Name=?unit_Name and flag=0",msp );
                    if (dt.Rows.Count == 0)//判断单位是否存在
                    {
                        MessageBox.Show("发生错误\r\n没有当前出库单位信息");
                    }
                    else
                    {
                        msp[8].Value = dt.Rows[0]["ID"];//单位ID
                        dt = msh.GetDataTable("select * from outload where Unit_Name=?Unit_Name and flag=0", msp);
                        int Unit_RC = 0;
                        foreach(DataRow dr in dt.Rows)
                        {
                            if(dr["date"].ToString().Substring(0,4)==msp[3].Value.ToString().Substring(0,4))
                            {
                                if (int.Parse(dr["Unit_RC"].ToString()) > Unit_RC)
                                    Unit_RC = int.Parse(dr["Unit_RC"].ToString());
                            }
                        }
                        Unit_RC += 1;
                        msp[9].Value = Unit_RC;
                        string SQlstring = "update in_stock set amount=amount-?amount where Name=?Name and cost_price=?cost_price and flag=0";
                        if(msh.ExecuteNonQuery(SQlstring,msp)==1)
                        {
                            SQlstring = "insert into outload(In_stock_ID,In_stock_Name,Unit_ID,Unit_Name,Unit_RC,cost_price,price,Amount,Date,Remark,Flag)" +
                                " values(?ID,?Name,?unit_ID,?unit_Name,?Unit_RC,?cost_price,?price,?amount,?date,?Remark,0)";
                            msh.ExecuteNonQuery(SQlstring, msp);
                            isFianl();
                        }
                    }
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
                    //textBox3.SelectAll();
                    //textBox3.Focus();
                    textBox4.Text = dr["price"].ToString();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string s = textBox2.Text;
            foreach (string name in Units)
            {
                if (name.Contains(s))
                {
                    listBox1.Items.Add(name);
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
                textBox2.Focus();
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    textBox2.Text = listBox2.SelectedItem.ToString();
            //    textBox2.Select();
            //    listBox2.Items.Clear();
            //    listBox2.Visible = false;
            //}
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (IsNumber(textBox4.Text))
                label9.Visible = false;
            else
            {
                label9.Visible = true;
                textBox4.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
