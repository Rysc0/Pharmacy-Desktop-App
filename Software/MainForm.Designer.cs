
namespace Ljekarna
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnDodavanjeLijekova = new System.Windows.Forms.Button();
            this.btnNaručivanje = new System.Windows.Forms.Button();
            this.btnProdaja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDodavanjeLijekova
            // 
            this.btnDodavanjeLijekova.BackColor = System.Drawing.Color.LightCoral;
            this.btnDodavanjeLijekova.Location = new System.Drawing.Point(207, 182);
            this.btnDodavanjeLijekova.Name = "btnDodavanjeLijekova";
            this.btnDodavanjeLijekova.Size = new System.Drawing.Size(125, 58);
            this.btnDodavanjeLijekova.TabIndex = 0;
            this.btnDodavanjeLijekova.Text = "Dodavanje lijekova u bazu podataka";
            this.btnDodavanjeLijekova.UseVisualStyleBackColor = false;
            this.btnDodavanjeLijekova.Click += new System.EventHandler(this.btnDodavanjeLijekova_Click);
            // 
            // btnNaručivanje
            // 
            this.btnNaručivanje.BackColor = System.Drawing.Color.Salmon;
            this.btnNaručivanje.Location = new System.Drawing.Point(338, 182);
            this.btnNaručivanje.Name = "btnNaručivanje";
            this.btnNaručivanje.Size = new System.Drawing.Size(125, 58);
            this.btnNaručivanje.TabIndex = 1;
            this.btnNaručivanje.Text = "Naručivanje novih zaliha";
            this.btnNaručivanje.UseVisualStyleBackColor = false;
            this.btnNaručivanje.Click += new System.EventHandler(this.btnNaručivanje_Click);
            // 
            // btnProdaja
            // 
            this.btnProdaja.BackColor = System.Drawing.Color.LightGreen;
            this.btnProdaja.Location = new System.Drawing.Point(469, 182);
            this.btnProdaja.Name = "btnProdaja";
            this.btnProdaja.Size = new System.Drawing.Size(125, 58);
            this.btnProdaja.TabIndex = 2;
            this.btnProdaja.Text = "Prodaja";
            this.btnProdaja.UseVisualStyleBackColor = false;
            this.btnProdaja.Click += new System.EventHandler(this.btnProdaja_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnProdaja);
            this.Controls.Add(this.btnNaručivanje);
            this.Controls.Add(this.btnDodavanjeLijekova);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDodavanjeLijekova;
        private System.Windows.Forms.Button btnNaručivanje;
        private System.Windows.Forms.Button btnProdaja;
    }
}