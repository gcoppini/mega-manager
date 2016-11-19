namespace MegaManager
{
    partial class frmImportacaoResultados
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
            this.linkLabelExtractedFolder = new System.Windows.Forms.LinkLabel();
            this.linkLabelDownloadFolder = new System.Windows.Forms.LinkLabel();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnExtrairResultados = new System.Windows.Forms.Button();
            this.btnExibirResultados = new System.Windows.Forms.Button();
            this.btnDownloadResultados = new System.Windows.Forms.Button();
            this.btnImportarResultados = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabelExtractedFolder);
            this.groupBox1.Controls.Add(this.linkLabelDownloadFolder);
            this.groupBox1.Controls.Add(this.btnMerge);
            this.groupBox1.Controls.Add(this.btnExtrairResultados);
            this.groupBox1.Controls.Add(this.btnExibirResultados);
            this.groupBox1.Controls.Add(this.btnDownloadResultados);
            this.groupBox1.Controls.Add(this.btnImportarResultados);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1146, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // linkLabelExtractedFolder
            // 
            this.linkLabelExtractedFolder.AutoSize = true;
            this.linkLabelExtractedFolder.Location = new System.Drawing.Point(596, 39);
            this.linkLabelExtractedFolder.Name = "linkLabelExtractedFolder";
            this.linkLabelExtractedFolder.Size = new System.Drawing.Size(75, 13);
            this.linkLabelExtractedFolder.TabIndex = 7;
            this.linkLabelExtractedFolder.TabStop = true;
            this.linkLabelExtractedFolder.Text = "Pasta Extraido";
            this.linkLabelExtractedFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelExtractedFolder_LinkClicked);
            // 
            // linkLabelDownloadFolder
            // 
            this.linkLabelDownloadFolder.AutoSize = true;
            this.linkLabelDownloadFolder.Location = new System.Drawing.Point(596, 16);
            this.linkLabelDownloadFolder.Name = "linkLabelDownloadFolder";
            this.linkLabelDownloadFolder.Size = new System.Drawing.Size(85, 13);
            this.linkLabelDownloadFolder.TabIndex = 6;
            this.linkLabelDownloadFolder.TabStop = true;
            this.linkLabelDownloadFolder.Text = "Pasta Download";
            this.linkLabelDownloadFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDownloadFolder_LinkClicked);
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(425, 28);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 4;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnExtrairResultados
            // 
            this.btnExtrairResultados.Location = new System.Drawing.Point(232, 29);
            this.btnExtrairResultados.Name = "btnExtrairResultados";
            this.btnExtrairResultados.Size = new System.Drawing.Size(75, 23);
            this.btnExtrairResultados.TabIndex = 3;
            this.btnExtrairResultados.Text = "Extrair";
            this.btnExtrairResultados.UseVisualStyleBackColor = true;
            this.btnExtrairResultados.Click += new System.EventHandler(this.btnExtrairResultados_Click);
            // 
            // btnExibirResultados
            // 
            this.btnExibirResultados.Location = new System.Drawing.Point(776, 28);
            this.btnExibirResultados.Name = "btnExibirResultados";
            this.btnExibirResultados.Size = new System.Drawing.Size(75, 23);
            this.btnExibirResultados.TabIndex = 2;
            this.btnExibirResultados.Text = "Carregar DB";
            this.btnExibirResultados.UseVisualStyleBackColor = true;
            this.btnExibirResultados.Click += new System.EventHandler(this.btnExibirResultados_Click);
            // 
            // btnDownloadResultados
            // 
            this.btnDownloadResultados.Location = new System.Drawing.Point(41, 28);
            this.btnDownloadResultados.Name = "btnDownloadResultados";
            this.btnDownloadResultados.Size = new System.Drawing.Size(75, 23);
            this.btnDownloadResultados.TabIndex = 1;
            this.btnDownloadResultados.Text = "Download";
            this.btnDownloadResultados.UseVisualStyleBackColor = true;
            this.btnDownloadResultados.Click += new System.EventHandler(this.btnDownloadResultados_Click);
            // 
            // btnImportarResultados
            // 
            this.btnImportarResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportarResultados.Location = new System.Drawing.Point(1015, 20);
            this.btnImportarResultados.Name = "btnImportarResultados";
            this.btnImportarResultados.Size = new System.Drawing.Size(89, 41);
            this.btnImportarResultados.TabIndex = 0;
            this.btnImportarResultados.Text = "Importar";
            this.btnImportarResultados.UseVisualStyleBackColor = true;
            this.btnImportarResultados.Click += new System.EventHandler(this.btnImportarResultados_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 75);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1146, 648);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.webBrowser1);
            this.tabPage3.Controls.Add(this.splitContainer1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1138, 622);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Arquivos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 310);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1132, 309);
            this.dataGridView1.TabIndex = 4;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Top;
            this.webBrowser1.Location = new System.Drawing.Point(3, 147);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1132, 163);
            this.webBrowser1.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView2);
            this.splitContainer1.Size = new System.Drawing.Size(1132, 144);
            this.splitContainer1.SplitterDistance = 540;
            this.splitContainer1.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(540, 144);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // listView2
            // 
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(588, 144);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView2_ItemSelectionChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmImportacaoResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 723);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmImportacaoResultados";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnImportarResultados;
        private System.Windows.Forms.Button btnDownloadResultados;
        private System.Windows.Forms.Button btnExibirResultados;
        private System.Windows.Forms.Button btnExtrairResultados;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.LinkLabel linkLabelExtractedFolder;
        private System.Windows.Forms.LinkLabel linkLabelDownloadFolder;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

