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
    public partial class Vizualizare_Elevi : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elev10\Desktop\Atestat\Atestat\Atestat\Elevi.mdf;Integrated Security=True");
        public Vizualizare_Elevi()
        {
            InitializeComponent();
        }

        private void Vizualizare_Elevi_Load(object sender, EventArgs e)
        {

            panel1.Visible = false;
            SqlCommand cmd = new SqlCommand("select * from date_elevi", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        int x;
        Int64 Row_id;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cauta_nume_TextChanged(object sender, EventArgs e)
        {
            if (cauta_nume.Text != "")
            {
                panel1.Visible = false;
                SqlCommand cmd = new SqlCommand("select * from date_elevi where Număr_matricol LIKE '" + cauta_nume.Text + "%'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                panel1.Visible = false;
                SqlCommand cmd = new SqlCommand("select * from date_elevi", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            cauta_nume.Clear();
            panel1.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                x = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
               // x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }

            panel1.Visible = true;
            SqlCommand cmd = new SqlCommand("select * from date_elevi where Număr_matricol = " + x + "", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Row_id = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txt_nrmatricol.Text = ds.Tables[0].Rows[0][0].ToString();
            txt_cnp.Text = ds.Tables[0].Rows[0][1].ToString();
            txt_nume.Text = ds.Tables[0].Rows[0][2].ToString();
            txt_prenume.Text = ds.Tables[0].Rows[0][3].ToString();
            txt_clasa.Text = ds.Tables[0].Rows[0][4].ToString();
            txt_telElev.Text = ds.Tables[0].Rows[0][5].ToString();
            txt_email.Text = ds.Tables[0].Rows[0][6].ToString();
            txt_telParinte.Text = ds.Tables[0].Rows[0][7].ToString();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Datele vor fi schimbate. Confirmi?", "Informare", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)

                try
                {
                    string Nr_Matricol = txt_nrmatricol.Text;
                    string CNP = txt_cnp.Text;
                    string Nume = txt_nume.Text;
                    string Prenume = txt_prenume.Text;
                    string Clasa = txt_clasa.Text;
                    string Telefon_Elev = txt_telElev.Text;
                    string Email_Elev = txt_email.Text;
                    string Telefon_Parinte = txt_telParinte.Text;


                    if (Nr_Matricol != "" && CNP != "" && Nume != "" && Prenume != "" && Clasa != "" && Telefon_Elev != "" && Email_Elev != "" && Telefon_Parinte!="")
                    {

                        try
                        {
                            con.Open();
                            string querry = "UPDATE date_elevi set Număr_matricol = '" + Nr_Matricol + "', CNP = '" + CNP + "', Nume = '" + Nume + "', Prenume = '" + Prenume + "', Clasa = '" + Clasa + "', Număr_de_telefon_elev = '" + Telefon_Elev + "', Email_elev = '" + Email_Elev + "', Număr_de_telefon_părinte = '" + Telefon_Parinte + "' where Număr_matricol = '" + Row_id + "' ";
                            SqlCommand cmd = new SqlCommand(querry, con);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Salvat cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_cnp.Clear();
                            txt_nrmatricol.Clear();
                            txt_nume.Clear();
                            txt_prenume.Clear();
                            txt_clasa.Clear();
                            txt_telElev.Clear();
                            txt_email.Clear();
                            txt_telParinte.Clear();
                            SqlCommand cmd2 = new SqlCommand("select * from date_elevi", con);
                            SqlDataAdapter da = new SqlDataAdapter(cmd2);
                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            dataGridView1.DataSource = ds.Tables[0];
                        }
                        catch (Exception ex)
                        {
                          //  MessageBox.Show(ex.Message);
                            MessageBox.Show("Una din datele introduse nu este corectă sau nu ai completat toate căsuțele obligatorii, te rog încearcă din nou", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        con.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Una din datele introduse nu este corectă sau nu ai completat toate căsuțele obligatorii, te rog încearcă din nou", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Datele vor fi șterse definitiv. Confirmi?", "Șterge", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                con.Open();
                string querry = "DELETE from date_elevi WHERE Număr_matricol = '" + Row_id + "'";
                SqlCommand cmd = new SqlCommand(querry, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sters cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand cmd2 = new SqlCommand("select * from date_elevi", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
                panel1.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void txt_nrmatricol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
