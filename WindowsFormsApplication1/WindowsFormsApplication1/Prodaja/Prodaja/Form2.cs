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

namespace Prodaja
{
    public partial class Form2 : Form
    {
        SqlConnection cn;
        SqlCommand cmd;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //paziti!!
            //string cs = "Data Source = NO356518BA\\SQLEXPRESS; Initial Catalog = ProdajaSQL_test; Integrated Security = True";
            string cs = "Data Source = DESKTOP-97OEARS\\SQLEXPRESS; Initial Catalog = ProdajaSQL; Integrated Security = True";
            cn = new SqlConnection(cs);
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string cname = txtCompany.Text;
            decimal revenue = decimal.Parse(txtRevenue.Text);

            cmd.Parameters.Clear();
            cmd.CommandText = "insert into CompanyRevenues values (@cname,@revenue)";
            cmd.Parameters.AddWithValue("@cname", cname);
            cmd.Parameters.AddWithValue("@revenue", revenue);
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close(); MessageBox.Show("Company added successfully...", "Success");
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "select * from CompanyRevenues";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            chart1.DataSource = dt;
            chart1.Series[0].XValueMember = "CompanyName";
            chart1.Series[0].YValueMembers = "Revenue";
            chart1.DataBind();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "select Revenue from CompanyRevenues where CompanyName = @cname";
            cmd.Parameters.AddWithValue("@cname", txtCompany.Text);
            if (cn.State == ConnectionState.Closed)
                cn.Open();

            decimal revenue = (decimal)cmd.ExecuteScalar();
            txtRevenue.Text = revenue.ToString();
            cn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string cname = txtCompany.Text;
            decimal revenue = decimal.Parse(txtRevenue.Text);

            cmd.Parameters.Clear();
            cmd.CommandText = "update CompanyRevenues where Revenue=@revenue where CompanyName=@cname";
            cmd.Parameters.AddWithValue("@revenue", revenue);
            cmd.Parameters.AddWithValue("@cname", cname);

            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Company Data updated...", "Success");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string cname = txtCompany.Text;
            cmd.Parameters.Clear();
            cmd.CommandText = "Delete from CompanyRevenues where CompanyName = @cname";
            cmd.Parameters.AddWithValue("@cname", cname);
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Company removed.", "Removed");
            txtRevenue.Clear();
            txtCompany.Clear();
        }
    }
}
