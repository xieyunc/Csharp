using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Demo.ADO
{
    public partial class SqlTableForm : Form
    {
        public SqlTableForm()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connStr;
            try 
	        {
                //conn.Close();
                //conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter("select id,s_name,S_role,S_rolename,s_Status,S_logins from [dbo].[FYM_Admin]",conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
	        }
	        finally
	        {
                conn.Close();
	        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void SqlTableForm_Load(object sender, EventArgs e)
        {
            button1_Click(this.button1,null);
        }
    }
}
