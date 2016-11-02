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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hello Alenichev!", this.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //paziti!!
            //string cs = "Data Source = NO356518BA\\SQLEXPRESS; Initial Catalog = ProdajaSQL_test; Integrated Security = True";
            string cs = "Data Source = DESKTOP-97OEARS\\SQLEXPRESS; Initial Catalog = ProdajaSQL; Integrated Security = True";

            SqlConnection cn = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("Select * from Employees", cn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();

            da.Fill(ds, "Employees");
            ds.Tables[0].Constraints.Add("Empno_PK", ds.Tables[0].Columns[0], true);
            DataRow row;
            row = ds.Tables[0].NewRow();
            row["Empno"] = txtEmpno.Text;
            row["Ename"] = txtEname.Text;
            row["Salary"] = txtSalary.Text;
            row["Hiredate"] = dtpHireDate.Value;
            ds.Tables[0].Rows.Add(row);
            da.Update(ds.Tables[0]);
            MessageBox.Show("Added", this.Text);

        }

        private void dtpHireDate_ValueChanged(object sender, EventArgs e)
        {
            //upisati
        }
    }
}
