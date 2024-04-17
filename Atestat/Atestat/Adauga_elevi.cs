using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atestat
{
    public partial class Adauga_elevi : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Elevi.mdf;Integrated Security=True");
        public Adauga_elevi()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string CNP = txt_cnp.Text;
                string Nr_Matricol = txt_nrmatricol.Text;
                string Nume = txt_nume.Text;
                string Prenume = txt_prenume.Text;
                string Clasa = txt_clasa.Text;
                string Telefon_Elev = txt_telelev.Text;
                string Email_Elev = txt_emailelev.Text;
                string Telefon_Parinte = txt_telparinte.Text;
                if (CNP != "" && Nr_Matricol != "" && Nume != "" && Prenume != "" && Clasa != "" && Telefon_Elev != "" && Email_Elev != "" && Telefon_Parinte!="")
                {

                    try
                    {
                        con.Open();
                        string querry = "INSERT INTO date_elevi(CNP, Număr_matricol, Nume, Prenume, Clasa, Număr_de_telefon_elev, Email_elev, Număr_de_telefon_părinte)values('" + CNP + "','" + Nr_Matricol + "','" + Nume + "','" + Prenume + "','" + Clasa + "','" + Telefon_Elev + "','" + Email_Elev + "','" + Telefon_Parinte + "')";
                        SqlCommand cmd = new SqlCommand(querry, con);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Salvat cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_cnp.Clear();
                        txt_nrmatricol.Clear();
                        txt_nume.Clear();
                        txt_prenume.Clear();
                        txt_clasa.Clear();
                        txt_telelev.Clear();
                        txt_emailelev.Clear();
                        txt_telparinte.Clear();
                    }
                    catch (Exception ex)
                    {
                       // MessageBox.Show(ex.Message);
                        MessageBox.Show("Una din datele introduse nu este corectă sau nu ai completat toate căsuțele obligatorii, te rog încearcă din nou", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                else MessageBox.Show("Una din datele introduse nu este corectă sau nu ai completat toate căsuțele obligatorii, te rog încearcă din nou", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("Una din datele introduse nu este corectă sau nu ai completat toate căsuțele obligatorii, te rog încearcă din nou", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_cnp.Clear();
            txt_nrmatricol.Clear();
            txt_nume.Clear();
            txt_prenume.Clear();
            txt_clasa.Clear();
            txt_telelev.Clear();
            txt_emailelev.Clear();
            txt_telparinte.Clear();
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Vei pierde toate datele nesalvate", "Ești sigur?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
            else this.Show();
        }

        private void txt_nrmatricol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_cnp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void Adauga_elevi_Load(object sender, EventArgs e)
        {

        }
    }
}
