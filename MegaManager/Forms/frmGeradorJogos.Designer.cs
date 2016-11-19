namespace MegaManager
{
    partial class frmGeradorJogos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelarGeracao = new System.Windows.Forms.Button();
            this.txtDesvioMedia = new System.Windows.Forms.TextBox();
            this.txtMediaSoma = new System.Windows.Forms.TextBox();
            this.checkedListBoxGabaritos = new System.Windows.Forms.CheckedListBox();
            this.txtSomaMin = new System.Windows.Forms.TextBox();
            this.txtSomaMax = new System.Windows.Forms.TextBox();
            this.txtQtdJogos = new System.Windows.Forms.TextBox();
            this.btngerarNumeros = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.bgWorkerGerarNumeros = new System.ComponentModel.BackgroundWorker();
            this.trackBarDesvioMedia = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDesvioMedia)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackBarDesvioMedia);
            this.groupBox1.Controls.Add(this.btnCancelarGeracao);
            this.groupBox1.Controls.Add(this.txtDesvioMedia);
            this.groupBox1.Controls.Add(this.txtMediaSoma);
            this.groupBox1.Controls.Add(this.checkedListBoxGabaritos);
            this.groupBox1.Controls.Add(this.txtSomaMin);
            this.groupBox1.Controls.Add(this.txtSomaMax);
            this.groupBox1.Controls.Add(this.txtQtdJogos);
            this.groupBox1.Controls.Add(this.btngerarNumeros);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(931, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnCancelarGeracao
            // 
            this.btnCancelarGeracao.Location = new System.Drawing.Point(781, 65);
            this.btnCancelarGeracao.Name = "btnCancelarGeracao";
            this.btnCancelarGeracao.Size = new System.Drawing.Size(125, 23);
            this.btnCancelarGeracao.TabIndex = 15;
            this.btnCancelarGeracao.Text = "Cancelar";
            this.btnCancelarGeracao.UseVisualStyleBackColor = true;
            this.btnCancelarGeracao.Click += new System.EventHandler(this.btnCancelarGeracao_Click);
            // 
            // txtDesvioMedia
            // 
            this.txtDesvioMedia.Location = new System.Drawing.Point(524, 81);
            this.txtDesvioMedia.Name = "txtDesvioMedia";
            this.txtDesvioMedia.Size = new System.Drawing.Size(100, 20);
            this.txtDesvioMedia.TabIndex = 14;
            this.txtDesvioMedia.Text = "40";
            // 
            // txtMediaSoma
            // 
            this.txtMediaSoma.Location = new System.Drawing.Point(524, 38);
            this.txtMediaSoma.Name = "txtMediaSoma";
            this.txtMediaSoma.Size = new System.Drawing.Size(100, 20);
            this.txtMediaSoma.TabIndex = 13;
            this.txtMediaSoma.Text = "190";
            this.txtMediaSoma.TextChanged += new System.EventHandler(this.txtMediaSoma_TextChanged);
            // 
            // checkedListBoxGabaritos
            // 
            this.checkedListBoxGabaritos.FormattingEnabled = true;
            this.checkedListBoxGabaritos.Location = new System.Drawing.Point(278, 19);
            this.checkedListBoxGabaritos.Name = "checkedListBoxGabaritos";
            this.checkedListBoxGabaritos.Size = new System.Drawing.Size(120, 94);
            this.checkedListBoxGabaritos.TabIndex = 12;
            // 
            // txtSomaMin
            // 
            this.txtSomaMin.Location = new System.Drawing.Point(647, 55);
            this.txtSomaMin.Name = "txtSomaMin";
            this.txtSomaMin.Size = new System.Drawing.Size(100, 20);
            this.txtSomaMin.TabIndex = 10;
            // 
            // txtSomaMax
            // 
            this.txtSomaMax.Location = new System.Drawing.Point(647, 19);
            this.txtSomaMax.Name = "txtSomaMax";
            this.txtSomaMax.Size = new System.Drawing.Size(100, 20);
            this.txtSomaMax.TabIndex = 9;
            // 
            // txtQtdJogos
            // 
            this.txtQtdJogos.Location = new System.Drawing.Point(80, 35);
            this.txtQtdJogos.Name = "txtQtdJogos";
            this.txtQtdJogos.Size = new System.Drawing.Size(100, 20);
            this.txtQtdJogos.TabIndex = 7;
            this.txtQtdJogos.Text = "10";
            // 
            // btngerarNumeros
            // 
            this.btngerarNumeros.Location = new System.Drawing.Point(781, 35);
            this.btngerarNumeros.Name = "btngerarNumeros";
            this.btngerarNumeros.Size = new System.Drawing.Size(125, 23);
            this.btngerarNumeros.TabIndex = 6;
            this.btngerarNumeros.Text = "Gerar Números";
            this.btngerarNumeros.UseVisualStyleBackColor = true;
            this.btngerarNumeros.Click += new System.EventHandler(this.btngerarNumeros_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 166);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(931, 334);
            this.dataGridView1.TabIndex = 1;
            // 
            // lbLog
            // 
            this.lbLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(0, 405);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(931, 95);
            this.lbLog.TabIndex = 2;
            // 
            // bgWorkerGerarNumeros
            // 
            this.bgWorkerGerarNumeros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerGerarNumeros_DoWork);
            this.bgWorkerGerarNumeros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerGerarNumeros_RunWorkerCompleted);
            // 
            // trackBarDesvioMedia
            // 
            this.trackBarDesvioMedia.Location = new System.Drawing.Point(419, 112);
            this.trackBarDesvioMedia.Name = "trackBarDesvioMedia";
            this.trackBarDesvioMedia.Size = new System.Drawing.Size(487, 42);
            this.trackBarDesvioMedia.SmallChange = 5;
            this.trackBarDesvioMedia.TabIndex = 16;
            this.trackBarDesvioMedia.TickFrequency = 5;
            this.trackBarDesvioMedia.ValueChanged += new System.EventHandler(this.trackBarDesvioMedia_ValueChanged);
            // 
            // frmGeradorJogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 500);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGeradorJogos";
            this.Text = "frmGeradorJogos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDesvioMedia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btngerarNumeros;
        private System.Windows.Forms.TextBox txtQtdJogos;
        private System.Windows.Forms.TextBox txtSomaMin;
        private System.Windows.Forms.TextBox txtSomaMax;
        private System.Windows.Forms.CheckedListBox checkedListBoxGabaritos;
        private System.Windows.Forms.TextBox txtMediaSoma;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.TextBox txtDesvioMedia;
        private System.ComponentModel.BackgroundWorker bgWorkerGerarNumeros;
        private System.Windows.Forms.Button btnCancelarGeracao;
        private System.Windows.Forms.TrackBar trackBarDesvioMedia;
    }
}