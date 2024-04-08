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

namespace Atestat
{
    public partial class Adaugare_carte : Form
    {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elev10\Desktop\Atestat\Atestat\Atestat\Carti.mdf;Integrated Security=True");
        public Adaugare_carte()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string NrInventar = txt_nr.Text;
                string Titlu = txt_titlu.Text;
                string Autor = txt_autor.Text;
                string Categorie = txt_categorie.Text;
                string Editura = txt_editura.Text;
                int NrDetinute = Convert.ToInt32(txt_detinute.Text);
                int NrImprumutate = Convert.ToInt32(txt_imprumutate.Text);
                string Pozitie = txt_pozitie.Text;
            if (NrInventar != "" && Titlu != "" && Autor != "" && Categorie != "" && Editura != "" && NrDetinute != 0 && NrImprumutate != 0)
            {

                try
                {
                        if (Pozitie == "") Pozitie = "****";
                    con.Open();
                    string querry = "INSERT INTO date_carti(Număr_de_inventar, Titlu, Autor, Categorie, Editură, Exemplare_Deţinute, Exemplare_Împrumutate, Poziție)values('" + NrInventar + "','" + Titlu + "','" + Autor + "','" + Categorie + "','" + Editura + "','" + NrDetinute + "','" + NrImprumutate + "','" + Pozitie + "')";
                    SqlCommand cmd = new SqlCommand(querry, con);
                    cmd.ExecuteNonQuery();
                     
                    MessageBox.Show("Salvat cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_nr.Clear();
                    txt_titlu.Clear();
                    txt_autor.Clear();
                    txt_categorie.Clear();
                    txt_editura.Clear();
                    txt_imprumutate.Clear();
                    txt_detinute.Clear();
                    txt_pozitie.Clear();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    MessageBox.Show("Una din datele introduse nu este corectă sau nu ai completat toate căsuțele obligatorii, te rog încearcă din nou", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else MessageBox.Show("Una din datele introduse nu este corectă sau nu ai completat toate căsuțele obligatorii, te rog încearcă din nou", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("Una din datele introduse nu este corectă sau nu ai completat toate căsuțele obligatorii, te rog încearcă din nou", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error); }
          

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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_nr.Clear();
            txt_titlu.Clear();
            txt_autor.Clear();
            txt_categorie.Clear();
            txt_editura.Clear();
            txt_imprumutate.Clear();
            txt_detinute.Clear();
            txt_pozitie.Clear();
        }
    }
}
