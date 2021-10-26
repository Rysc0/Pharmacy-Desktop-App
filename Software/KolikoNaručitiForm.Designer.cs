
namespace Ljekarna
{
    partial class KolikoNaručitiForm
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
            this.dgvNaNarudzbi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.dgvSKolicinama = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNaNarudzbi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSKolicinama)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNaNarudzbi
            // 
            this.dgvNaNarudzbi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNaNarudzbi.Location = new System.Drawing.Point(12, 34);
            this.dgvNaNarudzbi.Name = "dgvNaNarudzbi";
            this.dgvNaNarudzbi.Size = new System.Drawing.Size(834, 162);
            this.dgvNaNarudzbi.TabIndex = 0;
            this.dgvNaNarudzbi.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNaNarudzbi_RowHeaderMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lijekovi na narudžbi:";
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(767, 418);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 2;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // dgvSKolicinama
            // 
            this.dgvSKolicinama.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSKolicinama.Location = new System.Drawing.Point(12, 247);
            this.dgvSKolicinama.Name = "dgvSKolicinama";
            this.dgvSKolicinama.Size = new System.Drawing.Size(834, 162);
            this.dgvSKolicinama.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lijekovi i količina koja se naručuje:";
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(671, 418);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(75, 23);
            this.btnPotvrdi.TabIndex = 6;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // KolikoNaručitiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(854, 447);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSKolicinama);
            this.Controls.Add(this.dgvNaNarudzbi);
            this.Name = "KolikoNaručitiForm";
            this.Text = "KolikoNaručitiForm";
            this.Load += new System.EventHandler(this.KolikoNaručitiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNaNarudzbi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSKolicinama)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNaNarudzbi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.DataGridView dgvSKolicinama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPotvrdi;
    }
}