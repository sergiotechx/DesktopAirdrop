namespace Airdrop
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxChainId = new System.Windows.Forms.TextBox();
            this.labelChainId = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxConnections = new System.Windows.Forms.TextBox();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxContract = new System.Windows.Forms.TextBox();
            this.textBoxPrivateKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxDisclaimer = new System.Windows.Forms.GroupBox();
            this.textBoxDisclaimer = new System.Windows.Forms.TextBox();
            this.pictureBoxDisclaimer = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBoxDisclaimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisclaimer)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Controls.Add(this.textBoxChainId);
            this.groupBox1.Controls.Add(this.labelChainId);
            this.groupBox1.Controls.Add(this.textBoxAddress);
            this.groupBox1.Controls.Add(this.labelAddress);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxConnections);
            this.groupBox1.Controls.Add(this.buttonTest);
            this.groupBox1.Controls.Add(this.buttonClose);
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.textBoxContract);
            this.groupBox1.Controls.Add(this.textBoxPrivateKey);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBoxChainId
            // 
            this.textBoxChainId.Location = new System.Drawing.Point(101, 107);
            this.textBoxChainId.Name = "textBoxChainId";
            this.textBoxChainId.Size = new System.Drawing.Size(399, 23);
            this.textBoxChainId.TabIndex = 17;
            this.textBoxChainId.TextChanged += new System.EventHandler(this.textBoxChainId_TextChanged);
            // 
            // labelChainId
            // 
            this.labelChainId.AutoSize = true;
            this.labelChainId.Location = new System.Drawing.Point(7, 115);
            this.labelChainId.Name = "labelChainId";
            this.labelChainId.Size = new System.Drawing.Size(51, 15);
            this.labelChainId.TabIndex = 16;
            this.labelChainId.Text = "Chain Id";
            this.labelChainId.Click += new System.EventHandler(this.labelChainId_Click);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(104, 22);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(399, 23);
            this.textBoxAddress.TabIndex = 15;
            this.textBoxAddress.TextChanged += new System.EventHandler(this.textBoxAddress_TextChanged);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(6, 30);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(49, 15);
            this.labelAddress.TabIndex = 14;
            this.labelAddress.Text = "Address";
            this.labelAddress.Click += new System.EventHandler(this.labelAddress_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Connection";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxConnections
            // 
            this.textBoxConnections.Location = new System.Drawing.Point(101, 135);
            this.textBoxConnections.Name = "textBoxConnections";
            this.textBoxConnections.PasswordChar = '֎';
            this.textBoxConnections.Size = new System.Drawing.Size(399, 23);
            this.textBoxConnections.TabIndex = 12;
            this.textBoxConnections.TextChanged += new System.EventHandler(this.textBoxConnections_TextChanged);
            // 
            // buttonTest
            // 
            this.buttonTest.BackColor = System.Drawing.Color.DimGray;
            this.buttonTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTest.Location = new System.Drawing.Point(103, 166);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 4;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = false;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.DimGray;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(265, 164);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.DimGray;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(184, 165);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxContract
            // 
            this.textBoxContract.Location = new System.Drawing.Point(103, 80);
            this.textBoxContract.Name = "textBoxContract";
            this.textBoxContract.Size = new System.Drawing.Size(399, 23);
            this.textBoxContract.TabIndex = 3;
            this.textBoxContract.TextChanged += new System.EventHandler(this.textBoxContract_TextChanged);
            // 
            // textBoxPrivateKey
            // 
            this.textBoxPrivateKey.Location = new System.Drawing.Point(103, 51);
            this.textBoxPrivateKey.Name = "textBoxPrivateKey";
            this.textBoxPrivateKey.PasswordChar = '֎';
            this.textBoxPrivateKey.Size = new System.Drawing.Size(399, 23);
            this.textBoxPrivateKey.TabIndex = 2;
            this.textBoxPrivateKey.TextChanged += new System.EventHandler(this.textBoxPrivateKey_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Token contract";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Private Key";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBoxDisclaimer
            // 
            this.groupBoxDisclaimer.Controls.Add(this.textBoxDisclaimer);
            this.groupBoxDisclaimer.Controls.Add(this.pictureBoxDisclaimer);
            this.groupBoxDisclaimer.ForeColor = System.Drawing.Color.White;
            this.groupBoxDisclaimer.Location = new System.Drawing.Point(13, 224);
            this.groupBoxDisclaimer.Name = "groupBoxDisclaimer";
            this.groupBoxDisclaimer.Size = new System.Drawing.Size(525, 62);
            this.groupBoxDisclaimer.TabIndex = 1;
            this.groupBoxDisclaimer.TabStop = false;
            this.groupBoxDisclaimer.Text = "Disclaimer";
            this.groupBoxDisclaimer.Enter += new System.EventHandler(this.groupBoxDisclaimer_Enter);
            // 
            // textBoxDisclaimer
            // 
            this.textBoxDisclaimer.BackColor = System.Drawing.Color.Black;
            this.textBoxDisclaimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDisclaimer.ForeColor = System.Drawing.Color.White;
            this.textBoxDisclaimer.Location = new System.Drawing.Point(79, 11);
            this.textBoxDisclaimer.Multiline = true;
            this.textBoxDisclaimer.Name = "textBoxDisclaimer";
            this.textBoxDisclaimer.Size = new System.Drawing.Size(423, 41);
            this.textBoxDisclaimer.TabIndex = 14;
            this.textBoxDisclaimer.Text = "Sensitive information is encripted, please use an unique wallet for the airdrop p" +
    "rocess and remove the remain funds after the airdrop process.";
            this.textBoxDisclaimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDisclaimer.TextChanged += new System.EventHandler(this.textBoxDisclaimer_TextChanged);
            // 
            // pictureBoxDisclaimer
            // 
            this.pictureBoxDisclaimer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxDisclaimer.BackgroundImage")));
            this.pictureBoxDisclaimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxDisclaimer.Location = new System.Drawing.Point(6, 22);
            this.pictureBoxDisclaimer.Name = "pictureBoxDisclaimer";
            this.pictureBoxDisclaimer.Size = new System.Drawing.Size(67, 30);
            this.pictureBoxDisclaimer.TabIndex = 0;
            this.pictureBoxDisclaimer.TabStop = false;
            this.pictureBoxDisclaimer.Click += new System.EventHandler(this.pictureBoxDisclaimer_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(550, 313);
            this.Controls.Add(this.groupBoxDisclaimer);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxDisclaimer.ResumeLayout(false);
            this.groupBoxDisclaimer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisclaimer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private TextBox textBoxContract;
        private TextBox textBoxPrivateKey;
        private Button buttonClose;
        private Button buttonSave;
        private Button buttonTest;
        private Label label1;
        private TextBox textBoxConnections;
        private GroupBox groupBoxDisclaimer;
        private PictureBox pictureBoxDisclaimer;
        private TextBox textBoxDisclaimer;
        private TextBox textBoxAddress;
        private Label labelAddress;
        private TextBox textBoxChainId;
        private Label labelChainId;
    }
}