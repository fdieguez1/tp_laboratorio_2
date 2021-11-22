
namespace FormsProyect
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvIncidences = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvErrors = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUsuariosDb = new System.Windows.Forms.Button();
            this.btnCleanDb = new System.Windows.Forms.Button();
            this.btnCloseApp = new System.Windows.Forms.Button();
            this.btnSeeStatistics = new System.Windows.Forms.Button();
            this.btnCloseIncidence = new System.Windows.Forms.Button();
            this.btnAddIncidence = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(571, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sistema de carga y analisis de bugs";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.dgvIncidences);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dgvErrors);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dgvUsers);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 553);
            this.panel1.TabIndex = 1;
            // 
            // dgvIncidences
            // 
            this.dgvIncidences.AllowUserToAddRows = false;
            this.dgvIncidences.AllowUserToDeleteRows = false;
            this.dgvIncidences.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIncidences.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIncidences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIncidences.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIncidences.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvIncidences.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvIncidences.GridColor = System.Drawing.Color.Black;
            this.dgvIncidences.Location = new System.Drawing.Point(0, 378);
            this.dgvIncidences.Name = "dgvIncidences";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIncidences.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIncidences.RowTemplate.Height = 25;
            this.dgvIncidences.Size = new System.Drawing.Size(547, 150);
            this.dgvIncidences.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(547, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "Incidencias";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dgvErrors
            // 
            this.dgvErrors.AllowUserToAddRows = false;
            this.dgvErrors.AllowUserToDeleteRows = false;
            this.dgvErrors.BackgroundColor = System.Drawing.Color.White;
            this.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrors.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvErrors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvErrors.GridColor = System.Drawing.Color.Black;
            this.dgvErrors.Location = new System.Drawing.Point(0, 202);
            this.dgvErrors.Name = "dgvErrors";
            this.dgvErrors.RowTemplate.Height = 25;
            this.dgvErrors.Size = new System.Drawing.Size(547, 150);
            this.dgvErrors.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(547, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Errores";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUsers.GridColor = System.Drawing.Color.Black;
            this.dgvUsers.Location = new System.Drawing.Point(0, 26);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvUsers.RowTemplate.Height = 25;
            this.dgvUsers.Size = new System.Drawing.Size(547, 150);
            this.dgvUsers.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(547, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuarios";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnUsuariosDb);
            this.panel2.Controls.Add(this.btnCleanDb);
            this.panel2.Controls.Add(this.btnCloseApp);
            this.panel2.Controls.Add(this.btnSeeStatistics);
            this.panel2.Controls.Add(this.btnCloseIncidence);
            this.panel2.Controls.Add(this.btnAddIncidence);
            this.panel2.Location = new System.Drawing.Point(13, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(546, 40);
            this.panel2.TabIndex = 2;
            // 
            // btnUsuariosDb
            // 
            this.btnUsuariosDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnUsuariosDb.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUsuariosDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuariosDb.ForeColor = System.Drawing.Color.White;
            this.btnUsuariosDb.Location = new System.Drawing.Point(328, 0);
            this.btnUsuariosDb.Name = "btnUsuariosDb";
            this.btnUsuariosDb.Size = new System.Drawing.Size(93, 40);
            this.btnUsuariosDb.TabIndex = 5;
            this.btnUsuariosDb.Text = "Enviar usuarios a Db";
            this.btnUsuariosDb.UseVisualStyleBackColor = false;
            this.btnUsuariosDb.Click += new System.EventHandler(this.btnUsuariosDb_Click);
            // 
            // btnCleanDb
            // 
            this.btnCleanDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCleanDb.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCleanDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCleanDb.ForeColor = System.Drawing.Color.White;
            this.btnCleanDb.Location = new System.Drawing.Point(235, 0);
            this.btnCleanDb.Name = "btnCleanDb";
            this.btnCleanDb.Size = new System.Drawing.Size(93, 40);
            this.btnCleanDb.TabIndex = 4;
            this.btnCleanDb.Text = "Limpiar BD";
            this.btnCleanDb.UseVisualStyleBackColor = false;
            this.btnCleanDb.Click += new System.EventHandler(this.btnCleanDb_Click);
            // 
            // btnCloseApp
            // 
            this.btnCloseApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCloseApp.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCloseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseApp.ForeColor = System.Drawing.Color.White;
            this.btnCloseApp.Location = new System.Drawing.Point(471, 0);
            this.btnCloseApp.Name = "btnCloseApp";
            this.btnCloseApp.Size = new System.Drawing.Size(75, 40);
            this.btnCloseApp.TabIndex = 3;
            this.btnCloseApp.Text = "Cerrar app";
            this.btnCloseApp.UseVisualStyleBackColor = false;
            this.btnCloseApp.Click += new System.EventHandler(this.btnCloseApp_Click);
            // 
            // btnSeeStatistics
            // 
            this.btnSeeStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSeeStatistics.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSeeStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeeStatistics.ForeColor = System.Drawing.Color.White;
            this.btnSeeStatistics.Location = new System.Drawing.Point(150, 0);
            this.btnSeeStatistics.Name = "btnSeeStatistics";
            this.btnSeeStatistics.Size = new System.Drawing.Size(85, 40);
            this.btnSeeStatistics.TabIndex = 2;
            this.btnSeeStatistics.Text = "Ver estadisticas";
            this.btnSeeStatistics.UseVisualStyleBackColor = false;
            this.btnSeeStatistics.Click += new System.EventHandler(this.btnSeeStatistics_Click);
            // 
            // btnCloseIncidence
            // 
            this.btnCloseIncidence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCloseIncidence.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseIncidence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseIncidence.ForeColor = System.Drawing.Color.White;
            this.btnCloseIncidence.Location = new System.Drawing.Point(75, 0);
            this.btnCloseIncidence.Name = "btnCloseIncidence";
            this.btnCloseIncidence.Size = new System.Drawing.Size(75, 40);
            this.btnCloseIncidence.TabIndex = 1;
            this.btnCloseIncidence.Text = "Cerrar incidencia";
            this.btnCloseIncidence.UseVisualStyleBackColor = false;
            this.btnCloseIncidence.Click += new System.EventHandler(this.btnCloseIncidence_Click);
            // 
            // btnAddIncidence
            // 
            this.btnAddIncidence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAddIncidence.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddIncidence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddIncidence.ForeColor = System.Drawing.Color.White;
            this.btnAddIncidence.Location = new System.Drawing.Point(0, 0);
            this.btnAddIncidence.Name = "btnAddIncidence";
            this.btnAddIncidence.Size = new System.Drawing.Size(75, 40);
            this.btnAddIncidence.TabIndex = 0;
            this.btnAddIncidence.Text = "Cargar incidencia";
            this.btnAddIncidence.UseVisualStyleBackColor = false;
            this.btnAddIncidence.Click += new System.EventHandler(this.bntAddIncidence_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(571, 650);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fernando Dieguez 2E";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvErrors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvIncidences;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSeeStatistics;
        private System.Windows.Forms.Button btnCloseIncidence;
        private System.Windows.Forms.Button btnAddIncidence;
        private System.Windows.Forms.Button btnCloseApp;
        private System.Windows.Forms.Button btnCleanDb;
        private System.Windows.Forms.Button btnUsuariosDb;
    }
}

