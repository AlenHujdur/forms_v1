using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PretplatniciDA.DATA;
using PretplatniciDA;

namespace Pretplatnici_UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NapuniSS();
        }

        private void NapuniSS()
        {
            List<StrucnaSprema> lista = PretplatniciDA.Pretplatnici.StrucneSpremeSelectAll();
            StrucnaSprema prazno = new StrucnaSprema();

            prazno.StrucnaSpremaID = 0;
            prazno.Skracenica = "-";
            prazno.Naziv = "-";

            lista.Insert(0, prazno);
            ddlStrucneSpreme.DataSource = lista;
            ddlStrucneSpreme.DataValueField = "StrucnaSpremaID";
            ddlStrucneSpreme.DataTextField = "Skracenica";
            ddlStrucneSpreme.DataBind();
        }

        protected void Sacuvaj_Click(object sender, EventArgs e)
        {
            PretplatniciDA.DATA.Pretplatnici p = new PretplatniciDA.DATA.Pretplatnici();
            p.Ime = txtIme.Text;
            p.Prezime = txtPrezime.Text;
            p.KorisnickoIme = txtKorisnickoIme.Text;
            p.Lozinka = txtLozinka.Text;
            p.Email = txtEmail.Text;
            p.StrucnaSpremaID = Convert.ToInt16(ddlStrucneSpreme.SelectedValue);
        }
    }
}