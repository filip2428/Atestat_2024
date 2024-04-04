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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hacfi\OneDrive\Desktop\Atestat\Atestat\Atestat\Autentificare.mdf;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user, parola;
            user = username_text.Text;
            parola = password_text.Text;
            try
            {
                String querry = "SELECT * FROM date_autentificare WHERE username = '" + username_text.Text + "' AND password ='" + password_text.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry,conn);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                if(dataTable.Rows.Count > 0)
                {
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                    
                }

                else
                {
                    MessageBox.Show("Date Invalide","Eroare",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    username_text.Clear();
                    password_text.Clear();
                    username_text.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Eroare");
            }
            finally { conn.Close(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Vrei să ieși din program?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else this.Show();
        }

        private void See_Password_CheckedChanged(object sender, EventArgs e)
        {
            if(See_Password.Checked)
            {
                password_text.UseSystemPasswordChar = false;
            }
            else password_text.UseSystemPasswordChar = true;
        }
    }
}
