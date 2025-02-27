﻿using System;
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
    public partial class Retur : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Elevi.mdf;Integrated Security=True");
        SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Carti.mdf;Integrated Security=True");
        public Retur()
        {
            InitializeComponent();
        }

        private void Retur_Load(object sender, EventArgs e)
        {
            search_result.Height = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Vei pierde toate datele nesalvate", "Ești sigur?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
            else this.Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text != "")
                {
                    string querry = "Select Nr_crt,Număr_de_inventar,Titlu, Autor from Date_cartii ";
                    querry += "WHERE Număr_de_inventar LIKE '" + textBox6.Text + "%'";
                    SqlCommand cmd = new SqlCommand(querry, con);
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
                    SqlCommand cmd = new SqlCommand("select Nr_crt,Număr_de_inventar,Titlu, Autor from Date_cartii", con);
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

                    txt_nume.Text = ds.Tables[0].Rows[0][3].ToString();
                    txt_prenume.Text = ds.Tables[0].Rows[0][4].ToString();
                    txt_clasa.Text = ds.Tables[0].Rows[0][5].ToString();
                    txt_telefon.Text = ds.Tables[0].Rows[0][6].ToString();
                    txt_email.Text = ds.Tables[0].Rows[0][7].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Număr matricol invalid", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
            }
        }

        private void btn_retur_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from date_elevi WHERE Număr_matricol = " + search.Text + "", con2);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                SqlCommand cmd2 = new SqlCommand("select * from Date_cartii WHERE Nr_crt = " + x + "", con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);

                if (ds2.Tables[0].Rows[0][8].ToString() == "DA")
                {
                    MessageBox.Show("Cartea nu a fost împrumutată", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    con.Open();
                    con2.Open();
                    string querry = "UPDATE Date_cartii set DISPONIBIL = '" + "DA" + "'where Nr_crt = '" + x + "' ";
                    SqlCommand cmd3 = new SqlCommand(querry, con);
                    string querry2;
                    cmd3.ExecuteNonQuery();
                    try
                    {
                        if (ds.Tables[0].Rows[0][9].ToString() == nr_carte)
                        {
                            querry2 = "UPDATE date_elevi set Carte1 = '" + null + "', Retur1 = '" + null + "' where Număr_matricol = '" + search.Text + "' ";

                        }
                        else if (ds.Tables[0].Rows[0][11].ToString() == nr_carte)
                        {
                            querry2 = "UPDATE date_elevi set Carte2 = '" + null + "',Retur2 = '" + null + "' where Număr_matricol = '" + search.Text + "' ";
                        }
                        else
                        {
                            querry2 = "UPDATE date_elevi set Carte3 = '" + null + "', Retur3 = '" + null + "' where Număr_matricol = '" + search.Text + "' ";
                        }
                        SqlCommand cmd4 = new SqlCommand(querry2, con2);
                        cmd4.ExecuteNonQuery();
                        MessageBox.Show("Returnat cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message);
                    }
                }
                        con.Close();
                        con2.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            search.Clear();
            txt_clasa.Clear();
            txt_email.Clear();
            txt_nume.Clear();
            txt_prenume.Clear();
            txt_telefon.Clear();
            textBox6.Clear();
        }

        int x;
        string nr_carte;
        private void search_result_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (search_result.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    x = int.Parse(search_result.Rows[e.RowIndex].Cells[0].Value.ToString());
                    nr_carte = search_result.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
                SqlCommand cmd = new SqlCommand("select * from Date_cartii WHERE Nr_crt = " + x + "", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                textBox6.Text = ds.Tables[0].Rows[0][7].ToString();

                search_result.Height = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
