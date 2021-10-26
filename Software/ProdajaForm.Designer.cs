
namespace Ljekarna
{
    partial class ProdajaForm
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
            this.dgvLijekovi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.dgvRačun = new System.Windows.Forms.DataGridView();
            this.cbKupac = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIzdajRacun = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbZaposlenik = new System.Windows.Forms.ComboBox();
            this.gbRacun = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLijekovi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRačun)).BeginInit();
            this.gbRacun.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLijekovi
            // 
            this.dgvLijekovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLijekovi.Location = new System.Drawing.Point(15, 53);
            this.dgvLijekovi.Name = "dgvLijekovi";
            this.dgvLijekovi.Size = new System.Drawing.Size(901, 255);
            this.dgvLijekovi.TabIndex = 1;
            this.dgvLijekovi.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLijekovi_CellFormatting);
            this.dgvLijekovi.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLijekovi_RowHeaderMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filter:";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(50, 27);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 20);
            this.txtFilter.TabIndex = 3;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // dgvRačun
            // 
            this.dgvRačun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRačun.Location = new System.Drawing.Point(23, 28);
            this.dgvRačun.Name = "dgvRačun";
            this.dgvRačun.Size = new System.Drawing.Size(240, 150);
            this.dgvRačun.TabIndex = 4;
            // 
            // cbKupac
            // 
            this.cbKupac.FormattingEnabled = true;
            this.cbKupac.Location = new System.Drawing.Point(91, 199);
            this.cbKupac.Name = "cbKupac";
            this.cbKupac.Size = new System.Drawing.Size(121, 21);
            this.cbKupac.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kupac:";
            // 
            // btnIzdajRacun
            // 
            this.btnIzdajRacun.Location = new System.Drawing.Point(285, 28);
            this.btnIzdajRacun.Name = "btnIzdajRacun";
            this.btnIzdajRacun.Size = new System.Drawing.Size(75, 23);
            this.btnIzdajRacun.TabIndex = 7;
            this.btnIzdajRacun.Text = "Izdaj račun";
            this.btnIzdajRacun.UseVisualStyleBackColor = true;
            this.btnIzdajRacun.Click += new System.EventHandler(this.btnIzdajRacun_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(285, 57);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 7;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Zaposlenik:";
            // 
            // cbZaposlenik
            // 
            this.cbZaposlenik.FormattingEnabled = true;
            this.cbZaposlenik.Location = new System.Drawing.Point(91, 230);
            this.cbZaposlenik.Name = "cbZaposlenik";
            this.cbZaposlenik.Size = new System.Drawing.Size(121, 21);
            this.cbZaposlenik.TabIndex = 6;
            // 
            // gbRacun
            // 
            this.gbRacun.Controls.Add(this.cbZaposlenik);
            this.gbRacun.Controls.Add(this.btnOdustani);
            this.gbRacun.Controls.Add(this.dgvRačun);
            this.gbRacun.Controls.Add(this.btnIzdajRacun);
            this.gbRacun.Controls.Add(this.label3);
            this.gbRacun.Controls.Add(this.label4);
            this.gbRacun.Controls.Add(this.cbKupac);
            this.gbRacun.Location = new System.Drawing.Point(15, 352);
            this.gbRacun.Name = "gbRacun";
            this.gbRacun.Size = new System.Drawing.Size(382, 266);
            this.gbRacun.TabIndex = 8;
            this.gbRacun.TabStop = false;
            this.gbRacun.Text = "Račun:";
            // 
            // ProdajaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(928, 666);
            this.Controls.Add(this.gbRacun);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLijekovi);
            this.Name = "ProdajaForm";
            this.Text = "ProdajaForm";
            this.Load += new System.EventHandler(this.ProdajaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLijekovi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRačun)).EndInit();
            this.gbRacun.ResumeLayout(false);
            this.gbRacun.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvLijekovi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.DataGridView dgvRačun;
        private System.Windows.Forms.ComboBox cbKupac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIzdajRacun;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbZaposlenik;
        private System.Windows.Forms.GroupBox gbRacun;
    }
}