﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atestat
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res =MessageBox.Show("Vrei să ieși din program?", "Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(res == DialogResult.Yes) 
            Application.Exit();
        }

        private void adaugăCărțiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}