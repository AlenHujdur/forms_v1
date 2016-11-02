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
    public partial class SearchEmployee : Form
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cmb;

        public SearchEmployee()
        {
            InitializeComponent();
        }

        private void SearchEmployee_Load(object sender, EventArgs e)
        {
            //string cs = "Data Source = NO356518BA\\SQLEXPRESS; Initial Catalog = ProdajaSQL_test; Integrated Security = True";
            string cs = "Data Source = DESKTOP-97OEARS\\SQLEXPRESS; Initial Catalog = ProdajaSQL; Integrated Security = True";
            cn = new SqlConnection(cs);
            da = new SqlDataAdapter("select * from Employees", cn);
            cmb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Employees");
            ds.Tables["Employees"].Constraints.Add("Empno_PK", ds.Tables["employees"].Columns["empno"], true);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int empno = int.Parse(txtEmpno.Text);
            if (ds.Tables["employees"].Rows.Contains(empno) == true)
            {
                DataRow row;
                row = ds.Tables["employees"].Rows.Find(empno);
                txtEname.Text = row["ename"].ToString();
                txtSalary.Text = row["salary"].ToString();
                txtHiredate.Text = row["hiredate"].ToString();
            }
            else
            {
                MessageBox.Show("Record not found!", "Error");
                txtEname.Clear();
                txtHiredate.Clear();
                txtSalary.Clear();
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int eno = int.Parse(txtEmpno.Text);
            DataRow row;
            row = ds.Tables["Employees"].Rows.Find(eno);
            row.BeginEdit();
            row["ename"] = txtEname.Text;
            row["salary"] = txtSalary.Text;
            row["hiredate"] = txtHiredate.Text;
            row.EndEdit();
            da.Update(ds.Tables["Employees"]);
            MessageBox.Show("Updated!", "Update");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure want to delete??", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int eno = int.Parse(txtEmpno.Text);
                ds.Tables["Employees"].Rows.Find(eno).Delete();
                da.Update(ds.Tables["Employees"]);
                MessageBox.Show("Removed...", "Delete");
                txtEname.Clear();
                txtHiredate.Clear();
                txtSalary.Clear();
            }
        }
    }
}
