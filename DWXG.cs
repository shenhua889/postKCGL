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
    public partial class DWXG : Form
    {
        public DWXG()
        {
            InitializeComponent();
        }
        DataTable dt;
        MySqlHelper msh = new MySqlHelper(Properties.Resources.MySqlConnStr);
        private void DWXG_Load(object sender, EventArgs e)
        {
            FormLoad();
        }
        private void FormLoad()
        {
            listBox1.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            dt = msh.GetDataTable("select * from unit");
            foreach (DataRow dr in dt.Rows)
            {
                string ID = dr["ID"].ToString().PadLeft(15).PadRight(30);
                string Name = dr["Name"].ToString();
                listBox1.Items.Add(ID + Name);
            }

        }
        private void ListBoxSelect(int SelectIndex)
        {
            listBox1.SelectedIndex = SelectIndex;
        }
        private void UnitFind()
        {
            string name = textBox2.Text;
            int flag = 0;
            for(int i=listBox1.SelectedIndex;i<dt.Rows.Count;i++)
            {
                if(listBox1.Items[i].ToString().Contains(name))
                {
                    ListBoxSelect(i);
                    return;
                }
            }
            if(flag==0)
            {
                for(int i=0;i<listBox1.SelectedIndex;i++)
                {
                    if (listBox1.Items[i].ToString().Contains(name))
                    {
                        ListBoxSelect(i);
                        return;
                    }
                }
            }
            MessageBox.Show("没有找到该用户");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UnitFind();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string s = listBox1.SelectedItem.ToString();
                textBox1.Text = s.Substring(0, 15).Trim();
                textBox2.Text = s.Substring(15).Trim();
            }
        }
        private void UpdateUnit()
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                MySqlParameter[] msp = new MySqlParameter[2];
                msp[0] = new MySqlParameter("?name", MySqlDbType.VarChar, 80);
                msp[1] = new MySqlParameter("?ID", MySqlDbType.Int32, 10);
                msp[0].Value = textBox2.Text;
                msp[1].Value = textBox1.Text;
                msh.ExecuteNonQuery("update Unit set name=?name where ID=?ID", msp);
                FormLoad();
                MessageBox.Show("修改成功");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //MySqlParameter msp = new MySqlParameter("?name", MySqlDbType.VarChar, 80);
            //msp.Value = textBox2.Text;
            UpdateUnit();
        }
        private void DeleteUnit()
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                MySqlParameter[] msp = new MySqlParameter[2];
                msp[0] = new MySqlParameter("?name", MySqlDbType.VarChar, 80);
                msp[1] = new MySqlParameter("?ID", MySqlDbType.Int32, 10);
                msp[0].Value = textBox2.Text;
                msp[1].Value = textBox1.Text;
                msh.ExecuteNonQuery("delete from unit where name=?name and ID=?ID", msp);
                FormLoad();
                MessageBox.Show("删除成功");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DeleteUnit();
        }
    }
}
