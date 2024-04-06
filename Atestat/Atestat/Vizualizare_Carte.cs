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
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hacfi\OneDrive\Desktop\Atestat\Atestat\Atestat\Carti.mdf;Integrated Security=True");
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
        int x;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                x = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            panel1.Visible = true;
            SqlCommand cmd = new SqlCommand("select * from date_carti where Număr_de_inventar = " + x + "",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            txt_nr.Text = ds.Tables[0].Rows[0][0].ToString();
            txt_titlu.Text = ds.Tables[0].Rows[0][1].ToString();
            txt_autor.Text = ds.Tables[0].Rows[0][2].ToString();
            txt_categorie.Text = ds.Tables[0].Rows[0][3].ToString();
            txt_editura.Text = ds.Tables[0].Rows[0][4].ToString();
            txt_detinute.Text = ds.Tables[0].Rows[0][5].ToString();
            txt_imprumutate.Text = ds.Tables[0].Rows[0][6].ToString();
            txt_pozitie.Text = ds.Tables[0].Rows[0][7].ToString();
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
    }
}
