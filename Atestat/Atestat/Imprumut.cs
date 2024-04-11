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

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elev10\Desktop\Atestat\Atestat\Atestat\Carti.mdf;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.TextLength >= 3)
                {
                    con.Open();
                    string querry = "Select Titlu, Autor from date_carti ";
                    querry += "WHERE Titlu LIKE '"+textBox6.Text+ "%'";
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = querry;
                    cmd.Parameters.AddWithValue("Titlu", textBox6.Text + "%");
                    cmd.Parameters.AddWithValue("Autor", textBox6.Text + "%");
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        search_result.DataSource = dt;
                        search_result.Height = search_result.Rows.Count * 30;
                    }
                    else search_result.Height = 0;
                    cmd.Dispose();
                    da.Dispose();
                    con.Close();
                }
                else
                {
                    search_result.Height = 0;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void search_result_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.search_result.Rows[e.RowIndex];
            textBox6.Text = row.Cells["result"].Value.ToString();
            search_result.Height = 0;
        }

        private void Imprumut_Load(object sender, EventArgs e)
        {
           
        }
    }
}
