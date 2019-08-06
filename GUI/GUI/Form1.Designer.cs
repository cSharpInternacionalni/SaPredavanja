namespace GUI
{
    partial class Form1
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
            this.btnUnos = new System.Windows.Forms.Button();
            this.lblNesto = new System.Windows.Forms.Label();
            this.tbUnos = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvOsobe = new System.Windows.Forms.DataGridView();
            this.tbUnos2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOsobe)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUnos
            // 
            this.btnUnos.Location = new System.Drawing.Point(426, 223);
            this.btnUnos.Name = "btnUnos";
            this.btnUnos.Size = new System.Drawing.Size(75, 23);
            this.btnUnos.TabIndex = 0;
            this.btnUnos.Text = "button1";
            this.btnUnos.UseVisualStyleBackColor = true;
            this.btnUnos.Click += new System.EventHandler(this.Button1_Click);
            this.btnUnos.MouseEnter += new System.EventHandler(this.Button1_MouseEnter);
            this.btnUnos.MouseLeave += new System.EventHandler(this.Button1_MouseLeave);
            // 
            // lblNesto
            // 
            this.lblNesto.AutoSize = true;
            this.lblNesto.Location = new System.Drawing.Point(336, 67);
            this.lblNesto.Name = "lblNesto";
            this.lblNesto.Size = new System.Drawing.Size(13, 13);
            this.lblNesto.TabIndex = 1;
            this.lblNesto.Text = ":)";
            this.lblNesto.Click += new System.EventHandler(this.LblNesto_Click);
            // 
            // tbUnos
            // 
            this.tbUnos.Location = new System.Drawing.Point(339, 179);
            this.tbUnos.Name = "tbUnos";
            this.tbUnos.Size = new System.Drawing.Size(100, 20);
            this.tbUnos.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(652, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // dgvOsobe
            // 
            this.dgvOsobe.AllowUserToAddRows = false;
            this.dgvOsobe.AllowUserToDeleteRows = false;
            this.dgvOsobe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOsobe.Location = new System.Drawing.Point(53, 179);
            this.dgvOsobe.MultiSelect = false;
            this.dgvOsobe.Name = "dgvOsobe";
            this.dgvOsobe.ReadOnly = true;
            this.dgvOsobe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOsobe.Size = new System.Drawing.Size(240, 150);
            this.dgvOsobe.TabIndex = 4;
            // 
            // tbUnos2
            // 
            this.tbUnos2.Location = new System.Drawing.Point(494, 179);
            this.tbUnos2.Name = "tbUnos2";
            this.tbUnos2.Size = new System.Drawing.Size(100, 20);
            this.tbUnos2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbUnos2);
            this.Controls.Add(this.dgvOsobe);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbUnos);
            this.Controls.Add(this.lblNesto);
            this.Controls.Add(this.btnUnos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOsobe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUnos;
        private System.Windows.Forms.Label lblNesto;
        private System.Windows.Forms.TextBox tbUnos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvOsobe;
        private System.Windows.Forms.TextBox tbUnos2;
    }
}

