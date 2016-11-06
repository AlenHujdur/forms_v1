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
    public partial class Form3 : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string cs = "Data Source = DESKTOP-97OEARS\\SQLEXPRESS; Initial Catalog = PSDB; Integrated Security = True";
            cn = new SqlConnection(cs);
            cmd = new SqlCommand();
            cmd.Connection = cn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetVideo";
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dt = new DataTable();
            dt.Load(dr);
            lstMovies.DataSource = dt;
            lstMovies.DisplayMember = "vtitle";
            lstMovies.ValueMember = "id";
    
        }
    }
}
