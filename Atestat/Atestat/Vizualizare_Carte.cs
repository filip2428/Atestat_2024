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
    public partial class Vizualizare_Carte : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elev10\Desktop\Atestat\Atestat\Atestat\Carti.mdf;Integrated Security=True");
        public Vizualizare_Carte()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Vizualizare_Carte_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            SqlCommand cmd = new SqlCommand("select * from date_carti",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int x;
        Int64 Row_id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                x = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            panel1.Visible = true;
            SqlCommand cmdd = new SqlCommand("select * from date_carti where Număr_de_inventar = " + x + "",con);
            SqlDataAdapter daa = new SqlDataAdapter(cmdd);
            DataSet dss = new DataSet();
            daa.Fill(dss);

            Row_id = Int64.Parse(dss.Tables[0].Rows[0][0].ToString());

            txt_nr.Text = dss.Tables[0].Rows[0][0].ToString();
            txt_titlu.Text = dss.Tables[0].Rows[0][1].ToString();
            txt_autor.Text = dss.Tables[0].Rows[0][2].ToString();
            txt_categorie.Text = dss.Tables[0].Rows[0][3].ToString();
            txt_editura.Text = dss.Tables[0].Rows[0][4].ToString();
            txt_detinute.Text = dss.Tables[0].Rows[0][5].ToString();
            txt_imprumutate.Text = dss.Tables[0].Rows[0][6].ToString();
            txt_pozitie.Text = dss.Tables[0].Rows[0][7].ToString();
        }

        private void cauta_nume_TextChanged(object sender, EventArgs e)
        {
            if(cauta_nume.Text !="")
            {
                panel1.Visible = false;
                SqlCommand cmd = new SqlCommand("select * from date_carti where Titlu LIKE '"+cauta_nume.Text+ "%'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                panel1.Visible = false;
                SqlCommand cmd = new SqlCommand("select * from date_carti", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            cauta_nume.Clear();
            panel1.Visible=false;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Datele vor fi schimbate. Confirmi?","Informare",MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK)

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
                        string querry = "UPDATE date_carti set Număr_de_inventar = '"+NrInventar+"', Titlu = '"+Titlu+"', Autor = '"+Autor+"', Categorie = '"+Categorie+"', Editură = '"+Editura+"', Exemplare_Deţinute = '"+NrDetinute+"', Exemplare_Împrumutate = '"+NrImprumutate+"', Poziție = '"+Pozitie+ "' where Număr_de_inventar = '"+Row_id+"' ";
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
                            SqlCommand cmd2 = new SqlCommand("select * from date_carti", con);
                            SqlDataAdapter da = new SqlDataAdapter(cmd2);
                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            dataGridView1.DataSource = ds.Tables[0];
                        }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Una din datele introduse nu este corectă sau nu ai completat toate căsuțele obligatorii, te rog încearcă din nou", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                }
            catch {
                MessageBox.Show("Una din datele introduse nu este corectă sau nu ai completat toate căsuțele obligatorii, te rog încearcă din nou", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Datele vor fi șterse definitiv. Confirmi?", "Șterge", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                con.Open();
                string querry = "DELETE from date_carti WHERE Număr_de_inventar = '" + Row_id + "'";
                SqlCommand cmd = new SqlCommand(querry, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sters cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand cmd2 = new SqlCommand("select * from date_carti", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
                panel1.Hide();
                con.Close( );
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void txt_nr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_detinute_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_imprumutate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
