namespace WlepPress
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
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStickerAmout = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numMargin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numCopies = new System.Windows.Forms.NumericUpDown();
            this.btnColorInternal = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numBorderInternal = new System.Windows.Forms.NumericUpDown();
            this.btnColorExternal = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numBorderExternal = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numSpacing = new System.Windows.Forms.NumericUpDown();
            this.btnResetDefaults = new System.Windows.Forms.Button();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.panelDropZone = new System.Windows.Forms.Panel();
            this.btnPinterestDownload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderInternal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderExternal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Location = new System.Drawing.Point(246, 26);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(150, 28);
            this.btnSelectFiles.TabIndex = 0;
            this.btnSelectFiles.Text = "Pick files";
            this.btnSelectFiles.UseVisualStyleBackColor = true;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(891, 494);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(175, 51);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate sheets";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selected files:";
            // 
            // txtStickerAmout
            // 
            this.txtStickerAmout.Location = new System.Drawing.Point(120, 30);
            this.txtStickerAmout.Name = "txtStickerAmout";
            this.txtStickerAmout.ReadOnly = true;
            this.txtStickerAmout.Size = new System.Drawing.Size(120, 20);
            this.txtStickerAmout.TabIndex = 3;
            this.txtStickerAmout.Text = "none";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Sticker height (mm):";
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(120, 57);
            this.numHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(120, 20);
            this.numHeight.TabIndex = 20;
            this.numHeight.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.numHeight.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Page margin (mm):";
            // 
            // numMargin
            // 
            this.numMargin.Location = new System.Drawing.Point(120, 83);
            this.numMargin.Name = "numMargin";
            this.numMargin.Size = new System.Drawing.Size(120, 20);
            this.numMargin.TabIndex = 23;
            this.numMargin.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMargin.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Copies per image:";
            // 
            // numCopies
            // 
            this.numCopies.Location = new System.Drawing.Point(120, 109);
            this.numCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCopies.Name = "numCopies";
            this.numCopies.Size = new System.Drawing.Size(120, 20);
            this.numCopies.TabIndex = 26;
            this.numCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCopies.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // btnColorInternal
            // 
            this.btnColorInternal.BackColor = System.Drawing.Color.White;
            this.btnColorInternal.Location = new System.Drawing.Point(246, 135);
            this.btnColorInternal.Name = "btnColorInternal";
            this.btnColorInternal.Size = new System.Drawing.Size(100, 20);
            this.btnColorInternal.TabIndex = 31;
            this.btnColorInternal.UseVisualStyleBackColor = false;
            this.btnColorInternal.Click += new System.EventHandler(this.colorPickerBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Internal border (mm):";
            // 
            // numBorderInternal
            // 
            this.numBorderInternal.Location = new System.Drawing.Point(120, 135);
            this.numBorderInternal.Name = "numBorderInternal";
            this.numBorderInternal.Size = new System.Drawing.Size(120, 20);
            this.numBorderInternal.TabIndex = 29;
            this.numBorderInternal.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numBorderInternal.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // btnColorExternal
            // 
            this.btnColorExternal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btnColorExternal.Location = new System.Drawing.Point(246, 161);
            this.btnColorExternal.Name = "btnColorExternal";
            this.btnColorExternal.Size = new System.Drawing.Size(100, 20);
            this.btnColorExternal.TabIndex = 34;
            this.btnColorExternal.UseVisualStyleBackColor = false;
            this.btnColorExternal.Click += new System.EventHandler(this.colorPickerBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Exernal border (px):";
            // 
            // numBorderExternal
            // 
            this.numBorderExternal.Location = new System.Drawing.Point(120, 161);
            this.numBorderExternal.Name = "numBorderExternal";
            this.numBorderExternal.Size = new System.Drawing.Size(120, 20);
            this.numBorderExternal.TabIndex = 32;
            this.numBorderExternal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBorderExternal.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Spacing (mm):";
            // 
            // numSpacing
            // 
            this.numSpacing.Location = new System.Drawing.Point(120, 187);
            this.numSpacing.Name = "numSpacing";
            this.numSpacing.Size = new System.Drawing.Size(120, 20);
            this.numSpacing.TabIndex = 35;
            this.numSpacing.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // btnResetDefaults
            // 
            this.btnResetDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetDefaults.Location = new System.Drawing.Point(710, 494);
            this.btnResetDefaults.Name = "btnResetDefaults";
            this.btnResetDefaults.Size = new System.Drawing.Size(175, 51);
            this.btnResetDefaults.TabIndex = 37;
            this.btnResetDefaults.Text = "Reset";
            this.btnResetDefaults.UseVisualStyleBackColor = true;
            this.btnResetDefaults.Click += new System.EventHandler(this.btnResetDefaults_Click);
            // 
            // picPreview
            // 
            this.picPreview.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picPreview.BackColor = System.Drawing.SystemColors.ControlLight;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(412, 19);
            this.picPreview.Margin = new System.Windows.Forms.Padding(10);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(654, 462);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 38;
            this.picPreview.TabStop = false;
            // 
            // panelDropZone
            // 
            this.panelDropZone.AllowDrop = true;
            this.panelDropZone.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelDropZone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDropZone.Location = new System.Drawing.Point(55, 227);
            this.panelDropZone.Name = "panelDropZone";
            this.panelDropZone.Size = new System.Drawing.Size(278, 155);
            this.panelDropZone.TabIndex = 39;
            this.panelDropZone.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelDropZone_DragDrop);
            this.panelDropZone.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelDropZone_DragEnter);
            // 
            // btnPinterestDownload
            // 
            this.btnPinterestDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPinterestDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPinterestDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPinterestDownload.ForeColor = System.Drawing.Color.White;
            this.btnPinterestDownload.Location = new System.Drawing.Point(529, 494);
            this.btnPinterestDownload.Name = "btnPinterestDownload";
            this.btnPinterestDownload.Size = new System.Drawing.Size(175, 51);
            this.btnPinterestDownload.TabIndex = 40;
            this.btnPinterestDownload.Text = "Download WLEPY from Pinterest";
            this.btnPinterestDownload.UseVisualStyleBackColor = false;
            this.btnPinterestDownload.Click += new System.EventHandler(this.btnPinterestDownload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 557);
            this.Controls.Add(this.btnPinterestDownload);
            this.Controls.Add(this.panelDropZone);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.btnResetDefaults);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numSpacing);
            this.Controls.Add(this.btnColorExternal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numBorderExternal);
            this.Controls.Add(this.btnColorInternal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numBorderInternal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numCopies);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numMargin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.txtStickerAmout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnSelectFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WlepPress";
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderInternal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderExternal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStickerAmout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numMargin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numCopies;
        private System.Windows.Forms.Button btnColorInternal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numBorderInternal;
        private System.Windows.Forms.Button btnColorExternal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numBorderExternal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numSpacing;
        private System.Windows.Forms.Button btnResetDefaults;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Panel panelDropZone;
        private System.Windows.Forms.Button btnPinterestDownload;
    }
}

