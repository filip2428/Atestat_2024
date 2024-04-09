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
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                x = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
