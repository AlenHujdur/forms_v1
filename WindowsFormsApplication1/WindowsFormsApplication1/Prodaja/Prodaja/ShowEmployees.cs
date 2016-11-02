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
    public partial class ShowEmployees : Form
    {
        public ShowEmployees()
        {
            InitializeComponent();
        }

        private void ShowEmployees_Load(object sender, EventArgs e)
        {
            //string cs = "Data Source = NO356518BA\\SQLEXPRESS; Initial Catalog = ProdajaSQL_test; Integrated Security = True";
            string cs = "Data Source = DESKTOP-97OEARS\\SQLEXPRESS; Initial Catalog = ProdajaSQL; Integrated Security = True";

            SqlConnection cn = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("Select * from Employees", cn);
        
            DataSet ds = new DataSet();
            da.Fill(ds, "Employees");
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
