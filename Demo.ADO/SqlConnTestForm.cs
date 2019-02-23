using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Demo.ADO
{
    public partial class SqlConnTestForm : Form
    {
        SqlConnection sqlConn;
        public SqlConnTestForm()
        {
            InitializeComponent();
            sqlConn = new SqlConnection();
            statusLabel2.Text = sqlConn.State.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sError = new StringBuilder();

            if(txt_Srv.Text.Trim()=="" || txt_DB.Text.Trim()=="" || txt_User.Text.Trim()=="")
            {
                MessageBox.Show("服务器IP、数据库名称、数据库用户名不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            //string connStr = "Server="+txt_Srv.Text.Trim()+";database="+txt_DB.Text.Trim()+";uid="+txt_User.Text.Trim()+";pwd="+txt_Pwd.Text.Trim()+";";
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            if (sqlConn.State != ConnectionState.Closed)
                sqlConn.Close();
            sqlConn.ConnectionString = connStr;
            try
            {
                sError.Clear();
                sqlConn.Open();
                if (sqlConn.State == ConnectionState.Open)
                {
                    sError.Append("数据库连接成功！");
                    MessageBox.Show(sError.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    sError.Append("数据库连接失败！");
                    MessageBox.Show(sError.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                 sError.Append(sqlConn.State.ToString());
            }
            catch (Exception ex)
            {
                sError.Append(ex.Message + sqlConn.State.ToString());
                MessageBox.Show("数据库连接失败！" + ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            statusLabel2.Text = sError.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sError = "";
            sqlConn.Close();
            if(sqlConn.State == ConnectionState.Closed)
            {
                sError = "数据库关闭成功！";
            }
            else
            {
                sError = "数据库关闭失败！";
            }
            statusLabel2.Text = sError + sqlConn.State.ToString();
        }

        private void SqlConnTestForm_Load(object sender, EventArgs e)
        {

        }

        private void txt_Srv_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = (sender as TextBox).Text.Trim() != "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlTableForm aForm = new SqlTableForm();
            aForm.Show();
        }
    }
}
