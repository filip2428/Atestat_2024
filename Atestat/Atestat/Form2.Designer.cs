namespace Atestat
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cărToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugăCărțiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vizualizareCărțiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eleviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugăEleviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informațiiDespreEleviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.împrumutăToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returneazaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Wheat;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cărToolStripMenuItem,
            this.eleviToolStripMenuItem,
            this.împrumutăToolStripMenuItem,
            this.returneazaToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1292, 58);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cărToolStripMenuItem
            // 
            this.cărToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugăCărțiToolStripMenuItem,
            this.vizualizareCărțiToolStripMenuItem});
            this.cărToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cărToolStripMenuItem.Image")));
            this.cărToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cărToolStripMenuItem.Name = "cărToolStripMenuItem";
            this.cărToolStripMenuItem.Size = new System.Drawing.Size(104, 54);
            this.cărToolStripMenuItem.Text = "Cărți";
            // 
            // adaugăCărțiToolStripMenuItem
            // 
            this.adaugăCărțiToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.adaugăCărțiToolStripMenuItem.Image = global::Atestat.Properties.Resources.icons8_add_book_48;
            this.adaugăCărțiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.adaugăCărțiToolStripMenuItem.Name = "adaugăCărțiToolStripMenuItem";
            this.adaugăCărțiToolStripMenuItem.Size = new System.Drawing.Size(227, 56);
            this.adaugăCărțiToolStripMenuItem.Text = "Adaugă cărți";
            this.adaugăCărțiToolStripMenuItem.Click += new System.EventHandler(this.adaugăCărțiToolStripMenuItem_Click);
            // 
            // vizualizareCărțiToolStripMenuItem
            // 
            this.vizualizareCărțiToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.vizualizareCărțiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("vizualizareCărțiToolStripMenuItem.Image")));
            this.vizualizareCărțiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.vizualizareCărțiToolStripMenuItem.Name = "vizualizareCărțiToolStripMenuItem";
            this.vizualizareCărțiToolStripMenuItem.Size = new System.Drawing.Size(227, 56);
            this.vizualizareCărțiToolStripMenuItem.Text = "Vizualizare cărți";
            this.vizualizareCărțiToolStripMenuItem.Click += new System.EventHandler(this.vizualizareCărțiToolStripMenuItem_Click);
            // 
            // eleviToolStripMenuItem
            // 
            this.eleviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugăEleviToolStripMenuItem,
            this.informațiiDespreEleviToolStripMenuItem});
            this.eleviToolStripMenuItem.Image = global::Atestat.Properties.Resources.icons8_student_male_50;
            this.eleviToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.eleviToolStripMenuItem.Name = "eleviToolStripMenuItem";
            this.eleviToolStripMenuItem.Size = new System.Drawing.Size(104, 54);
            this.eleviToolStripMenuItem.Text = "Elevi";
            // 
            // adaugăEleviToolStripMenuItem
            // 
            this.adaugăEleviToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("adaugăEleviToolStripMenuItem.Image")));
            this.adaugăEleviToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.adaugăEleviToolStripMenuItem.Name = "adaugăEleviToolStripMenuItem";
            this.adaugăEleviToolStripMenuItem.Size = new System.Drawing.Size(271, 56);
            this.adaugăEleviToolStripMenuItem.Text = "Adaugă elevi";
            this.adaugăEleviToolStripMenuItem.Click += new System.EventHandler(this.adaugăEleviToolStripMenuItem_Click);
            // 
            // informațiiDespreEleviToolStripMenuItem
            // 
            this.informațiiDespreEleviToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("informațiiDespreEleviToolStripMenuItem.Image")));
            this.informațiiDespreEleviToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.informațiiDespreEleviToolStripMenuItem.Name = "informațiiDespreEleviToolStripMenuItem";
            this.informațiiDespreEleviToolStripMenuItem.Size = new System.Drawing.Size(271, 56);
            this.informațiiDespreEleviToolStripMenuItem.Text = "Informații despre elevi";
            // 
            // împrumutăToolStripMenuItem
            // 
            this.împrumutăToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("împrumutăToolStripMenuItem.Image")));
            this.împrumutăToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.împrumutăToolStripMenuItem.Name = "împrumutăToolStripMenuItem";
            this.împrumutăToolStripMenuItem.Size = new System.Drawing.Size(146, 54);
            this.împrumutăToolStripMenuItem.Text = "Împrumută";
            // 
            // returneazaToolStripMenuItem
            // 
            this.returneazaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("returneazaToolStripMenuItem.Image")));
            this.returneazaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.returneazaToolStripMenuItem.Name = "returneazaToolStripMenuItem";
            this.returneazaToolStripMenuItem.Size = new System.Drawing.Size(147, 54);
            this.returneazaToolStripMenuItem.Text = "Returnează";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(97, 54);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1292, 679);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cărToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugăCărțiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vizualizareCărțiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eleviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugăEleviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informațiiDespreEleviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem împrumutăToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returneazaToolStripMenuItem;
    }
}