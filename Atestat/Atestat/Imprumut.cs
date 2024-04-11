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
    public partial class Imprumut : Form
    {
        public Imprumut()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hacfi\OneDrive\Documente\GitHub\Atestat_2024\Atestat\Atestat\Carti.mdf;Integrated Security=True");
        SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hacfi\OneDrive\Documente\GitHub\Atestat_2024\Atestat\Atestat\Elevi.mdf;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text!="")
                {
                    string querry = "Select Număr_de_inventar,Titlu, Autor from date_carti ";
                    querry += "WHERE Titlu LIKE '"+textBox6.Text+ "%'";
                    SqlCommand cmd = new SqlCommand(querry,con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        search_result.DataSource = dt;
                        search_result.Height = 150;
                    }
                    else search_result.Height = 0;
                }
                else
                {
                    search_result.Height = 0;
                    SqlCommand cmd = new SqlCommand("select Număr_de_inventar,Titlu, Autor from date_carti", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    search_result.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        int x;
        private void search_result_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                /*DataGridViewRow row = this.search_result.Rows[e.RowIndex];
                textBox6.Text = row.Cells["result"].Value.ToString();
                search_result.Height = 0;*/
                if (search_result.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    x = int.Parse(search_result.Rows[e.RowIndex].Cells[0].Value.ToString());
                SqlCommand cmd = new SqlCommand("select * from date_carti WHERE Număr_de_inventar = " + x + "", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                textBox6.Text = ds.Tables[0].Rows[0][1].ToString();
                search_result.Height = 0;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Imprumut_Load(object sender, EventArgs e)
        {
           search_result.Height= 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            search.Clear();
            txt_clasa.Clear();
            txt_email.Clear();
            txt_nume.Clear();
            txt_prenume.Clear();
            txt_telefon.Clear();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.Text != "")
                {
                    string querry = "select * from date_elevi where Număr_matricol = '" + search.Text.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(querry, con2);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    txt_nume.Text = ds.Tables[0].Rows[0][2].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
