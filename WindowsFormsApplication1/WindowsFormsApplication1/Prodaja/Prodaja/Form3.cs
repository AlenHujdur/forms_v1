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

        private void lstMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)lstMovies.SelectedItem;
            if(drv != null)
            {
                int videoid = (int)drv["id"];
                cmd.Parameters.Clear();
                cmd.CommandText = "GetVideo";
                cmd.Parameters.AddWithValue("@id", videoid);
                cmd.Parameters.Add("@vurl", SqlDbType.VarChar, 100);
                cmd.Parameters["@vurl"].Direction = ParameterDirection.Output;
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                cmd.ExecuteNonQuery();
                string videourl = cmd.Parameters["@vurl"].Value.ToString();
                axWindowsMediaPlayer1.URL = videourl;
            }
        }
    }
}
