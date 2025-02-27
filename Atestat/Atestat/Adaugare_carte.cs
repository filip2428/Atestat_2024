﻿using System;
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
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Carti.mdf;Integrated Security=True"); public Adaugare_carte()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string Titlu = txt_titlu.Text;
                string Autor = txt_autor.Text;
                string Categorie = txt_categorie.Text;
                string Editura = txt_editura.Text;
                string Pozitie = txt_pozitie.Text;
                string Nr_Copie = txt_NrCopie.Text;
                string NrInventar = txt_nr.Text;
            if (NrInventar != "" && Titlu != "" && Autor != "" && Categorie != "" && Editura != "" && Nr_Copie != "")
            {

                try
                {
                        if (Pozitie == "") Pozitie = "****";
                    con.Open();
                    string querry = "INSERT INTO Date_cartii(Titlu, Autor, Categorie, Editură, Poziție, Nr_Copie, Număr_de_inventar)values('" + Titlu + "','" + Autor + "','" + Categorie + "','" + Editura + "','" + Pozitie + "', '"+Nr_Copie+"', '" + NrInventar + "')";
                    SqlCommand cmd = new SqlCommand(querry, con);
                    cmd.ExecuteNonQuery();
                     
                    MessageBox.Show("Salvat cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_nr.Clear();
                    txt_titlu.Clear();
                    txt_autor.Clear();
                    txt_categorie.Clear();
                    txt_editura.Clear();
                    txt_NrCopie.Clear();
                    txt_pozitie.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
            txt_NrCopie.Clear();
            txt_pozitie.Clear();
        }

        private void txt_nr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void Adaugare_carte_Load(object sender, EventArgs e)
        {

        }
    }
}
