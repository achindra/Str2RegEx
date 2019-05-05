namespace Str2RegEx
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
            this.components = new System.ComponentModel.Container();
            this.btnLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.rtbOpenFile = new System.Windows.Forms.RichTextBox();
            this.rtbRegEx = new System.Windows.Forms.RichTextBox();
            this.txtLinesToSample = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbFrequency = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblCluster = new System.Windows.Forms.Label();
            this.lblHash = new System.Windows.Forms.Label();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.btnTrain = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.samplerDataSet = new Str2RegEx.SamplerDataSet();
            this.sampleDBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sampleDBTableAdapter = new Str2RegEx.SamplerDataSetTableAdapters.SampleDBTableAdapter();
            this.clusterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hashDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtbPattern = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(544, 15);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load File";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // rtbOpenFile
            // 
            this.rtbOpenFile.Location = new System.Drawing.Point(12, 49);
            this.rtbOpenFile.Name = "rtbOpenFile";
            this.rtbOpenFile.Size = new System.Drawing.Size(882, 356);
            this.rtbOpenFile.TabIndex = 1;
            this.rtbOpenFile.Text = "";
            // 
            // rtbRegEx
            // 
            this.rtbRegEx.Location = new System.Drawing.Point(900, 49);
            this.rtbRegEx.Name = "rtbRegEx";
            this.rtbRegEx.Size = new System.Drawing.Size(481, 356);
            this.rtbRegEx.TabIndex = 2;
            this.rtbRegEx.Text = "";
            // 
            // txtLinesToSample
            // 
            this.txtLinesToSample.AutoCompleteCustomSource.AddRange(new string[] {
            "100",
            "250",
            "500",
            "750",
            "1000"});
            this.txtLinesToSample.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtLinesToSample.Location = new System.Drawing.Point(428, 14);
            this.txtLinesToSample.Name = "txtLinesToSample";
            this.txtLinesToSample.Size = new System.Drawing.Size(100, 20);
            this.txtLinesToSample.TabIndex = 4;
            this.txtLinesToSample.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lines to sample:";
            // 
            // rtbFrequency
            // 
            this.rtbFrequency.Location = new System.Drawing.Point(439, 411);
            this.rtbFrequency.Name = "rtbFrequency";
            this.rtbFrequency.Size = new System.Drawing.Size(420, 295);
            this.rtbFrequency.TabIndex = 6;
            this.rtbFrequency.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clusterDataGridViewTextBoxColumn,
            this.hashDataGridViewTextBoxColumn,
            this.frequencyDataGridViewTextBoxColumn,
            this.stackDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.sampleDBBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(876, 411);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(505, 290);
            this.dataGridView1.TabIndex = 8;
            // 
            // lblCluster
            // 
            this.lblCluster.AutoSize = true;
            this.lblCluster.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCluster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCluster.Location = new System.Drawing.Point(674, 13);
            this.lblCluster.Name = "lblCluster";
            this.lblCluster.Size = new System.Drawing.Size(12, 15);
            this.lblCluster.TabIndex = 9;
            this.lblCluster.Text = ":";
            // 
            // lblHash
            // 
            this.lblHash.AutoSize = true;
            this.lblHash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHash.Location = new System.Drawing.Point(900, 13);
            this.lblHash.Name = "lblHash";
            this.lblHash.Size = new System.Drawing.Size(12, 15);
            this.lblHash.TabIndex = 10;
            this.lblHash.Text = ":";
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFrequency.Location = new System.Drawing.Point(1167, 13);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(12, 15);
            this.lblFrequency.TabIndex = 11;
            this.lblFrequency.Text = ":";
            // 
            // btnTrain
            // 
            this.btnTrain.Enabled = false;
            this.btnTrain.Location = new System.Drawing.Point(142, 13);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(75, 23);
            this.btnTrain.TabIndex = 12;
            this.btnTrain.Text = "Train DB";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(114, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Train From Sample";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // samplerDataSet
            // 
            this.samplerDataSet.DataSetName = "SamplerDataSet";
            this.samplerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sampleDBBindingSource
            // 
            this.sampleDBBindingSource.DataMember = "SampleDB";
            this.sampleDBBindingSource.DataSource = this.samplerDataSet;
            // 
            // sampleDBTableAdapter
            // 
            this.sampleDBTableAdapter.ClearBeforeFill = true;
            // 
            // clusterDataGridViewTextBoxColumn
            // 
            this.clusterDataGridViewTextBoxColumn.DataPropertyName = "Cluster";
            this.clusterDataGridViewTextBoxColumn.HeaderText = "Cluster";
            this.clusterDataGridViewTextBoxColumn.Name = "clusterDataGridViewTextBoxColumn";
            // 
            // hashDataGridViewTextBoxColumn
            // 
            this.hashDataGridViewTextBoxColumn.DataPropertyName = "Hash";
            this.hashDataGridViewTextBoxColumn.HeaderText = "Hash";
            this.hashDataGridViewTextBoxColumn.Name = "hashDataGridViewTextBoxColumn";
            // 
            // frequencyDataGridViewTextBoxColumn
            // 
            this.frequencyDataGridViewTextBoxColumn.DataPropertyName = "Frequency";
            this.frequencyDataGridViewTextBoxColumn.HeaderText = "Frequency";
            this.frequencyDataGridViewTextBoxColumn.Name = "frequencyDataGridViewTextBoxColumn";
            // 
            // stackDataGridViewTextBoxColumn
            // 
            this.stackDataGridViewTextBoxColumn.DataPropertyName = "Stack";
            this.stackDataGridViewTextBoxColumn.HeaderText = "Stack";
            this.stackDataGridViewTextBoxColumn.Name = "stackDataGridViewTextBoxColumn";
            // 
            // rtbPattern
            // 
            this.rtbPattern.Location = new System.Drawing.Point(12, 411);
            this.rtbPattern.Name = "rtbPattern";
            this.rtbPattern.Size = new System.Drawing.Size(420, 294);
            this.rtbPattern.TabIndex = 14;
            this.rtbPattern.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 709);
            this.Controls.Add(this.rtbPattern);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.lblHash);
            this.Controls.Add(this.lblCluster);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rtbFrequency);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLinesToSample);
            this.Controls.Add(this.rtbRegEx);
            this.Controls.Add(this.rtbOpenFile);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox rtbOpenFile;
        private System.Windows.Forms.RichTextBox rtbRegEx;
        private System.Windows.Forms.TextBox txtLinesToSample;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbFrequency;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCluster;
        private System.Windows.Forms.Label lblHash;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.CheckBox checkBox1;
        private SamplerDataSet samplerDataSet;
        private System.Windows.Forms.BindingSource sampleDBBindingSource;
        private SamplerDataSetTableAdapters.SampleDBTableAdapter sampleDBTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn clusterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hashDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stackDataGridViewTextBoxColumn;
        private System.Windows.Forms.RichTextBox rtbPattern;
    }
}

