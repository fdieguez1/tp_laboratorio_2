
namespace MiCalculadora
{
    partial class FormCalculadora
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbOperators = new System.Windows.Forms.ComboBox();
            this.txtOperando1 = new System.Windows.Forms.TextBox();
            this.txtOperando2 = new System.Windows.Forms.TextBox();
            this.btnOperar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnDecimalABinario = new System.Windows.Forms.Button();
            this.btnBinarioADecimal = new System.Windows.Forms.Button();
            this.lstHistorial = new System.Windows.Forms.ListBox();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbOperators
            // 
            this.cmbOperators.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbOperators.FormattingEnabled = true;
            this.cmbOperators.Location = new System.Drawing.Point(185, 115);
            this.cmbOperators.Name = "cmbOperators";
            this.cmbOperators.Size = new System.Drawing.Size(121, 31);
            this.cmbOperators.TabIndex = 2;
            this.cmbOperators.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtOperando1
            // 
            this.txtOperando1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtOperando1.Location = new System.Drawing.Point(19, 115);
            this.txtOperando1.Name = "txtOperando1";
            this.txtOperando1.Size = new System.Drawing.Size(121, 31);
            this.txtOperando1.TabIndex = 1;
            this.txtOperando1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtOperando2
            // 
            this.txtOperando2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtOperando2.Location = new System.Drawing.Point(350, 115);
            this.txtOperando2.Name = "txtOperando2";
            this.txtOperando2.Size = new System.Drawing.Size(121, 31);
            this.txtOperando2.TabIndex = 3;
            this.txtOperando2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btnOperar
            // 
            this.btnOperar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnOperar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOperar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOperar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOperar.Location = new System.Drawing.Point(19, 221);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Padding = new System.Windows.Forms.Padding(3);
            this.btnOperar.Size = new System.Drawing.Size(121, 45);
            this.btnOperar.TabIndex = 4;
            this.btnOperar.Text = "&Operar";
            this.btnOperar.UseVisualStyleBackColor = false;
            this.btnOperar.Click += new System.EventHandler(this.btnOperar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLimpiar.Location = new System.Drawing.Point(185, 221);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Padding = new System.Windows.Forms.Padding(3);
            this.btnLimpiar.Size = new System.Drawing.Size(121, 45);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(350, 221);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Padding = new System.Windows.Forms.Padding(3);
            this.btnCerrar.Size = new System.Drawing.Size(121, 45);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnDecimalABinario
            // 
            this.btnDecimalABinario.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDecimalABinario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecimalABinario.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDecimalABinario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDecimalABinario.Location = new System.Drawing.Point(89, 291);
            this.btnDecimalABinario.Name = "btnDecimalABinario";
            this.btnDecimalABinario.Padding = new System.Windows.Forms.Padding(3);
            this.btnDecimalABinario.Size = new System.Drawing.Size(139, 49);
            this.btnDecimalABinario.TabIndex = 7;
            this.btnDecimalABinario.Text = "Convertir a &Binario";
            this.btnDecimalABinario.UseVisualStyleBackColor = false;
            // 
            // btnBinarioADecimal
            // 
            this.btnBinarioADecimal.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnBinarioADecimal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBinarioADecimal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBinarioADecimal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBinarioADecimal.Location = new System.Drawing.Point(258, 291);
            this.btnBinarioADecimal.Name = "btnBinarioADecimal";
            this.btnBinarioADecimal.Padding = new System.Windows.Forms.Padding(3);
            this.btnBinarioADecimal.Size = new System.Drawing.Size(139, 49);
            this.btnBinarioADecimal.TabIndex = 8;
            this.btnBinarioADecimal.Text = "Convertir a &Decimal";
            this.btnBinarioADecimal.UseVisualStyleBackColor = false;
            // 
            // lstHistorial
            // 
            this.lstHistorial.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstHistorial.FormattingEnabled = true;
            this.lstHistorial.ItemHeight = 16;
            this.lstHistorial.Location = new System.Drawing.Point(491, 13);
            this.lstHistorial.Name = "lstHistorial";
            this.lstHistorial.Size = new System.Drawing.Size(281, 420);
            this.lstHistorial.TabIndex = 9;
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDisplay.Location = new System.Drawing.Point(19, 13);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(77, 23);
            this.lblDisplay.TabIndex = 10;
            this.lblDisplay.Text = "label1";
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDisplay);
            this.Controls.Add(this.lstHistorial);
            this.Controls.Add(this.btnBinarioADecimal);
            this.Controls.Add(this.btnDecimalABinario);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnOperar);
            this.Controls.Add(this.txtOperando2);
            this.Controls.Add(this.txtOperando1);
            this.Controls.Add(this.cmbOperators);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Fernando Dieguez del curso 2ºE";
            this.Load += new System.EventHandler(this.FormCalculadora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbOperators;
        private System.Windows.Forms.TextBox txtOperando1;
        private System.Windows.Forms.TextBox txtOperando2;
        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnDecimalABinario;
        private System.Windows.Forms.Button btnBinarioADecimal;
        private System.Windows.Forms.ListBox lstHistorial;
        private System.Windows.Forms.Label lblDisplay;
    }
}

