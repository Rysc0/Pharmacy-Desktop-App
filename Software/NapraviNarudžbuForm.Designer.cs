
namespace Ljekarna
{
    partial class NapraviNarudžbuForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLijekovi = new System.Windows.Forms.DataGridView();
            this.dgvNarudzba = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Dobavljač = new System.Windows.Forms.Label();
            this.cbDobavljač = new System.Windows.Forms.ComboBox();
            this.btnNaruči = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.GenerirajAutomatskuNarudzbu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLijekovi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNarudzba)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lijekovi koje je potrebno naručiti:";
            // 
            // dgvLijekovi
            // 
            this.dgvLijekovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLijekovi.Location = new System.Drawing.Point(15, 25);
            this.dgvLijekovi.Name = "dgvLijekovi";
            this.dgvLijekovi.Size = new System.Drawing.Size(754, 195);
            this.dgvLijekovi.TabIndex = 1;
            this.dgvLijekovi.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLijekovi_RowHeaderMouseDoubleClick);
            // 
            // dgvNarudzba
            // 
            this.dgvNarudzba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNarudzba.Location = new System.Drawing.Point(15, 250);
            this.dgvNarudzba.Name = "dgvNarudzba";
            this.dgvNarudzba.Size = new System.Drawing.Size(754, 150);
            this.dgvNarudzba.TabIndex = 2;
            this.dgvNarudzba.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNarudzba_RowHeaderMouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Narudžba:";
            // 
            // Dobavljač
            // 
            this.Dobavljač.AutoSize = true;
            this.Dobavljač.Location = new System.Drawing.Point(15, 412);
            this.Dobavljač.Name = "Dobavljač";
            this.Dobavljač.Size = new System.Drawing.Size(58, 13);
            this.Dobavljač.TabIndex = 3;
            this.Dobavljač.Text = "Dobavljač:";
            // 
            // cbDobavljač
            // 
            this.cbDobavljač.FormattingEnabled = true;
            this.cbDobavljač.Location = new System.Drawing.Point(79, 409);
            this.cbDobavljač.Name = "cbDobavljač";
            this.cbDobavljač.Size = new System.Drawing.Size(121, 21);
            this.cbDobavljač.TabIndex = 4;
            // 
            // btnNaruči
            // 
            this.btnNaruči.Location = new System.Drawing.Point(632, 415);
            this.btnNaruči.Name = "btnNaruči";
            this.btnNaruči.Size = new System.Drawing.Size(75, 23);
            this.btnNaruči.TabIndex = 5;
            this.btnNaruči.Text = "Naruči";
            this.btnNaruči.UseVisualStyleBackColor = true;
            this.btnNaruči.Click += new System.EventHandler(this.btnNaruči_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(713, 415);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 5;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // GenerirajAutomatskuNarudzbu
            // 
            this.GenerirajAutomatskuNarudzbu.Location = new System.Drawing.Point(474, 415);
            this.GenerirajAutomatskuNarudzbu.Name = "GenerirajAutomatskuNarudzbu";
            this.GenerirajAutomatskuNarudzbu.Size = new System.Drawing.Size(152, 23);
            this.GenerirajAutomatskuNarudzbu.TabIndex = 5;
            this.GenerirajAutomatskuNarudzbu.Text = "Automatska narudžba";
            this.GenerirajAutomatskuNarudzbu.UseVisualStyleBackColor = true;
            this.GenerirajAutomatskuNarudzbu.Click += new System.EventHandler(this.GenerirajAutomatskuNarudzbu_Click);
            // 
            // NapraviNarudžbuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GenerirajAutomatskuNarudzbu);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnNaruči);
            this.Controls.Add(this.cbDobavljač);
            this.Controls.Add(this.Dobavljač);
            this.Controls.Add(this.dgvNarudzba);
            this.Controls.Add(this.dgvLijekovi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NapraviNarudžbuForm";
            this.Text = "Napravi narudžbu";
            this.Load += new System.EventHandler(this.NapraviNarudžbuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLijekovi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNarudzba)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLijekovi;
        private System.Windows.Forms.DataGridView dgvNarudzba;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Dobavljač;
        private System.Windows.Forms.ComboBox cbDobavljač;
        private System.Windows.Forms.Button btnNaruči;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button GenerirajAutomatskuNarudzbu;
    }
}