namespace MegaManager
{
    partial class frmAnaliseResultados
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMediaSomaMenosMediaDif = new System.Windows.Forms.Label();
            this.lblMediaSomaMaisMediaDif = new System.Windows.Forms.Label();
            this.lblMediaDiferSoma = new System.Windows.Forms.Label();
            this.btnRefreshMediaSoma = new System.Windows.Forms.Button();
            this.monthCalendarDataFinal = new System.Windows.Forms.MonthCalendar();
            this.monthCalendarDataInicial = new System.Windows.Forms.MonthCalendar();
            this.lblSomaMedia = new System.Windows.Forms.Label();
            this.lblSomaMin = new System.Windows.Forms.Label();
            this.lblSomaMax = new System.Windows.Forms.Label();
            this.btnRefreshGabaritos = new System.Windows.Forms.Button();
            this.btnRefreshResultados = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridViewNumeros = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridViewParesImpares = new System.Windows.Forms.DataGridView();
            this.btnParesImpares = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNumeros)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParesImpares)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnParesImpares);
            this.groupBox1.Controls.Add(this.lblMediaSomaMenosMediaDif);
            this.groupBox1.Controls.Add(this.lblMediaSomaMaisMediaDif);
            this.groupBox1.Controls.Add(this.lblMediaDiferSoma);
            this.groupBox1.Controls.Add(this.btnRefreshMediaSoma);
            this.groupBox1.Controls.Add(this.monthCalendarDataFinal);
            this.groupBox1.Controls.Add(this.monthCalendarDataInicial);
            this.groupBox1.Controls.Add(this.lblSomaMedia);
            this.groupBox1.Controls.Add(this.lblSomaMin);
            this.groupBox1.Controls.Add(this.lblSomaMax);
            this.groupBox1.Controls.Add(this.btnRefreshGabaritos);
            this.groupBox1.Controls.Add(this.btnRefreshResultados);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(914, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parâmetros";
            // 
            // lblMediaSomaMenosMediaDif
            // 
            this.lblMediaSomaMenosMediaDif.AutoSize = true;
            this.lblMediaSomaMenosMediaDif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMediaSomaMenosMediaDif.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMediaSomaMenosMediaDif.Location = new System.Drawing.Point(489, 120);
            this.lblMediaSomaMenosMediaDif.Name = "lblMediaSomaMenosMediaDif";
            this.lblMediaSomaMenosMediaDif.Size = new System.Drawing.Size(45, 16);
            this.lblMediaSomaMenosMediaDif.TabIndex = 10;
            this.lblMediaSomaMenosMediaDif.Text = "label6";
            // 
            // lblMediaSomaMaisMediaDif
            // 
            this.lblMediaSomaMaisMediaDif.AutoSize = true;
            this.lblMediaSomaMaisMediaDif.BackColor = System.Drawing.Color.Red;
            this.lblMediaSomaMaisMediaDif.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMediaSomaMaisMediaDif.Location = new System.Drawing.Point(489, 84);
            this.lblMediaSomaMaisMediaDif.Name = "lblMediaSomaMaisMediaDif";
            this.lblMediaSomaMaisMediaDif.Size = new System.Drawing.Size(45, 16);
            this.lblMediaSomaMaisMediaDif.TabIndex = 9;
            this.lblMediaSomaMaisMediaDif.Text = "label5";
            // 
            // lblMediaDiferSoma
            // 
            this.lblMediaDiferSoma.AutoSize = true;
            this.lblMediaDiferSoma.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMediaDiferSoma.Location = new System.Drawing.Point(412, 99);
            this.lblMediaDiferSoma.Name = "lblMediaDiferSoma";
            this.lblMediaDiferSoma.Size = new System.Drawing.Size(60, 24);
            this.lblMediaDiferSoma.TabIndex = 8;
            this.lblMediaDiferSoma.Text = "label4";
            // 
            // btnRefreshMediaSoma
            // 
            this.btnRefreshMediaSoma.Location = new System.Drawing.Point(776, 114);
            this.btnRefreshMediaSoma.Name = "btnRefreshMediaSoma";
            this.btnRefreshMediaSoma.Size = new System.Drawing.Size(97, 23);
            this.btnRefreshMediaSoma.TabIndex = 7;
            this.btnRefreshMediaSoma.Text = "Média Soma";
            this.btnRefreshMediaSoma.UseVisualStyleBackColor = true;
            this.btnRefreshMediaSoma.Click += new System.EventHandler(this.button3_Click);
            // 
            // monthCalendarDataFinal
            // 
            this.monthCalendarDataFinal.Location = new System.Drawing.Point(203, 17);
            this.monthCalendarDataFinal.Name = "monthCalendarDataFinal";
            this.monthCalendarDataFinal.TabIndex = 6;
            this.monthCalendarDataFinal.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateChanged);
            // 
            // monthCalendarDataInicial
            // 
            this.monthCalendarDataInicial.Location = new System.Drawing.Point(18, 17);
            this.monthCalendarDataInicial.Name = "monthCalendarDataInicial";
            this.monthCalendarDataInicial.TabIndex = 5;
            this.monthCalendarDataInicial.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // lblSomaMedia
            // 
            this.lblSomaMedia.AutoSize = true;
            this.lblSomaMedia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSomaMedia.Location = new System.Drawing.Point(529, 17);
            this.lblSomaMedia.Name = "lblSomaMedia";
            this.lblSomaMedia.Size = new System.Drawing.Size(60, 24);
            this.lblSomaMedia.TabIndex = 4;
            this.lblSomaMedia.Text = "label3";
            // 
            // lblSomaMin
            // 
            this.lblSomaMin.AutoSize = true;
            this.lblSomaMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSomaMin.Location = new System.Drawing.Point(463, 17);
            this.lblSomaMin.Name = "lblSomaMin";
            this.lblSomaMin.Size = new System.Drawing.Size(60, 24);
            this.lblSomaMin.TabIndex = 3;
            this.lblSomaMin.Text = "label2";
            // 
            // lblSomaMax
            // 
            this.lblSomaMax.AutoSize = true;
            this.lblSomaMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSomaMax.Location = new System.Drawing.Point(397, 17);
            this.lblSomaMax.Name = "lblSomaMax";
            this.lblSomaMax.Size = new System.Drawing.Size(60, 24);
            this.lblSomaMax.TabIndex = 2;
            this.lblSomaMax.Text = "label1";
            // 
            // btnRefreshGabaritos
            // 
            this.btnRefreshGabaritos.Location = new System.Drawing.Point(776, 76);
            this.btnRefreshGabaritos.Name = "btnRefreshGabaritos";
            this.btnRefreshGabaritos.Size = new System.Drawing.Size(97, 23);
            this.btnRefreshGabaritos.TabIndex = 1;
            this.btnRefreshGabaritos.Text = "Gabaritos";
            this.btnRefreshGabaritos.UseVisualStyleBackColor = true;
            this.btnRefreshGabaritos.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRefreshResultados
            // 
            this.btnRefreshResultados.Location = new System.Drawing.Point(776, 47);
            this.btnRefreshResultados.Name = "btnRefreshResultados";
            this.btnRefreshResultados.Size = new System.Drawing.Size(97, 23);
            this.btnRefreshResultados.TabIndex = 0;
            this.btnRefreshResultados.Text = "Atualizar";
            this.btnRefreshResultados.UseVisualStyleBackColor = true;
            this.btnRefreshResultados.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(900, 341);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 192);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(914, 373);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(906, 347);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Resultados";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(906, 347);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gabaritos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(900, 341);
            this.dataGridView2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chart1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(906, 347);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Gráfico Média das Somas";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(900, 341);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridViewNumeros);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(906, 347);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Números";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridViewNumeros
            // 
            this.dataGridViewNumeros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNumeros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewNumeros.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewNumeros.Name = "dataGridViewNumeros";
            this.dataGridViewNumeros.Size = new System.Drawing.Size(900, 341);
            this.dataGridViewNumeros.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dataGridViewParesImpares);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(906, 347);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Pares & Ímpares";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridViewParesImpares
            // 
            this.dataGridViewParesImpares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParesImpares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewParesImpares.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewParesImpares.Name = "dataGridViewParesImpares";
            this.dataGridViewParesImpares.Size = new System.Drawing.Size(900, 341);
            this.dataGridViewParesImpares.TabIndex = 0;
            // 
            // btnParesImpares
            // 
            this.btnParesImpares.Location = new System.Drawing.Point(776, 143);
            this.btnParesImpares.Name = "btnParesImpares";
            this.btnParesImpares.Size = new System.Drawing.Size(97, 23);
            this.btnParesImpares.TabIndex = 11;
            this.btnParesImpares.Text = "Pares Ímpares";
            this.btnParesImpares.UseVisualStyleBackColor = true;
            this.btnParesImpares.Click += new System.EventHandler(this.btnParesImpares_Click);
            // 
            // frmAnaliseResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 565);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAnaliseResultados";
            this.Text = "frmAnaliseResultados";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNumeros)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParesImpares)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRefreshResultados;
        private System.Windows.Forms.Button btnRefreshGabaritos;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblSomaMedia;
        private System.Windows.Forms.Label lblSomaMin;
        private System.Windows.Forms.Label lblSomaMax;
        private System.Windows.Forms.MonthCalendar monthCalendarDataFinal;
        private System.Windows.Forms.MonthCalendar monthCalendarDataInicial;
        private System.Windows.Forms.Button btnRefreshMediaSoma;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblMediaDiferSoma;
        private System.Windows.Forms.Label lblMediaSomaMenosMediaDif;
        private System.Windows.Forms.Label lblMediaSomaMaisMediaDif;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridViewNumeros;
        private System.Windows.Forms.Button btnParesImpares;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dataGridViewParesImpares;
    }
}