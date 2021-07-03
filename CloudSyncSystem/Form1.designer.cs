
namespace CloudSyncSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnUpdateParty = new System.Windows.Forms.Button();
            this.btn_ManualSync = new System.Windows.Forms.Button();
            this.lblStat = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStartTimer = new System.Windows.Forms.Button();
            this.btnStopTimer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnUpdateReceipt = new System.Windows.Forms.Button();
            this.btnDelReceipt = new System.Windows.Forms.Button();
            this.btnUpdatePayment = new System.Windows.Forms.Button();
            this.btnDelPayment = new System.Windows.Forms.Button();
            this.btnUpdatePartyFromStart = new System.Windows.Forms.Button();
            this.btnUpdateLedgerFromStart = new System.Windows.Forms.Button();
            this.btnDeleteLedgerFromStart = new System.Windows.Forms.Button();
            this.btnDeletePartyFromStart = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdateParty
            // 
            this.btnUpdateParty.Location = new System.Drawing.Point(61, 103);
            this.btnUpdateParty.Name = "btnUpdateParty";
            this.btnUpdateParty.Size = new System.Drawing.Size(151, 23);
            this.btnUpdateParty.TabIndex = 0;
            this.btnUpdateParty.Text = "Update Party";
            this.btnUpdateParty.UseVisualStyleBackColor = true;
            this.btnUpdateParty.Click += new System.EventHandler(this.btnUpdateParty_Click);
            // 
            // btn_ManualSync
            // 
            this.btn_ManualSync.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_ManualSync.Location = new System.Drawing.Point(61, 64);
            this.btn_ManualSync.Name = "btn_ManualSync";
            this.btn_ManualSync.Size = new System.Drawing.Size(151, 23);
            this.btn_ManualSync.TabIndex = 1;
            this.btn_ManualSync.Text = "Manual Sync To Cloud";
            this.btn_ManualSync.UseVisualStyleBackColor = false;
            this.btn_ManualSync.Click += new System.EventHandler(this.btnManualSync_Click);
            // 
            // lblStat
            // 
            this.lblStat.AutoSize = true;
            this.lblStat.Location = new System.Drawing.Point(41, 5);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(0, 13);
            this.lblStat.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStartTimer
            // 
            this.btnStartTimer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnStartTimer.Enabled = false;
            this.btnStartTimer.Location = new System.Drawing.Point(218, 64);
            this.btnStartTimer.Name = "btnStartTimer";
            this.btnStartTimer.Size = new System.Drawing.Size(166, 23);
            this.btnStartTimer.TabIndex = 3;
            this.btnStartTimer.Text = "Start Auto Sync";
            this.btnStartTimer.UseVisualStyleBackColor = false;
            this.btnStartTimer.Click += new System.EventHandler(this.btnStartTimer_Click);
            // 
            // btnStopTimer
            // 
            this.btnStopTimer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnStopTimer.Location = new System.Drawing.Point(390, 64);
            this.btnStopTimer.Name = "btnStopTimer";
            this.btnStopTimer.Size = new System.Drawing.Size(166, 23);
            this.btnStopTimer.TabIndex = 3;
            this.btnStopTimer.Text = "Stop Auto Sync";
            this.btnStopTimer.UseVisualStyleBackColor = false;
            this.btnStopTimer.Click += new System.EventHandler(this.btnStopTimer_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 58);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(596, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cloud Sync Management System";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.lblStat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 337);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(614, 25);
            this.panel2.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(61, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Delete Party";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(61, 161);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(151, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Update Ledger";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(61, 190);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(151, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "Delete Ledger";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnUpdateReceipt
            // 
            this.btnUpdateReceipt.Location = new System.Drawing.Point(61, 220);
            this.btnUpdateReceipt.Name = "btnUpdateReceipt";
            this.btnUpdateReceipt.Size = new System.Drawing.Size(151, 23);
            this.btnUpdateReceipt.TabIndex = 0;
            this.btnUpdateReceipt.Text = "Update Receipt";
            this.btnUpdateReceipt.UseVisualStyleBackColor = true;
            this.btnUpdateReceipt.Visible = false;
            this.btnUpdateReceipt.Click += new System.EventHandler(this.btnUpdateReceipt_Click);
            // 
            // btnDelReceipt
            // 
            this.btnDelReceipt.Location = new System.Drawing.Point(61, 249);
            this.btnDelReceipt.Name = "btnDelReceipt";
            this.btnDelReceipt.Size = new System.Drawing.Size(151, 23);
            this.btnDelReceipt.TabIndex = 0;
            this.btnDelReceipt.Text = "Delete Receipt";
            this.btnDelReceipt.UseVisualStyleBackColor = true;
            this.btnDelReceipt.Visible = false;
            this.btnDelReceipt.Click += new System.EventHandler(this.btnDelReceipt_Click);
            // 
            // btnUpdatePayment
            // 
            this.btnUpdatePayment.Location = new System.Drawing.Point(61, 279);
            this.btnUpdatePayment.Name = "btnUpdatePayment";
            this.btnUpdatePayment.Size = new System.Drawing.Size(151, 23);
            this.btnUpdatePayment.TabIndex = 0;
            this.btnUpdatePayment.Text = "Update Payment";
            this.btnUpdatePayment.UseVisualStyleBackColor = true;
            this.btnUpdatePayment.Visible = false;
            this.btnUpdatePayment.Click += new System.EventHandler(this.btnUpdatePayment_Click);
            // 
            // btnDelPayment
            // 
            this.btnDelPayment.Location = new System.Drawing.Point(61, 308);
            this.btnDelPayment.Name = "btnDelPayment";
            this.btnDelPayment.Size = new System.Drawing.Size(151, 23);
            this.btnDelPayment.TabIndex = 0;
            this.btnDelPayment.Text = "Delete Payment";
            this.btnDelPayment.UseVisualStyleBackColor = true;
            this.btnDelPayment.Visible = false;
            this.btnDelPayment.Click += new System.EventHandler(this.btnDelPayment_Click);
            // 
            // btnUpdatePartyFromStart
            // 
            this.btnUpdatePartyFromStart.Location = new System.Drawing.Point(218, 103);
            this.btnUpdatePartyFromStart.Name = "btnUpdatePartyFromStart";
            this.btnUpdatePartyFromStart.Size = new System.Drawing.Size(166, 23);
            this.btnUpdatePartyFromStart.TabIndex = 13;
            this.btnUpdatePartyFromStart.Text = "Update Party From Start";
            this.btnUpdatePartyFromStart.UseVisualStyleBackColor = true;
            this.btnUpdatePartyFromStart.Click += new System.EventHandler(this.btnUpdatePartyFromStart_Click);
            // 
            // btnUpdateLedgerFromStart
            // 
            this.btnUpdateLedgerFromStart.Location = new System.Drawing.Point(218, 161);
            this.btnUpdateLedgerFromStart.Name = "btnUpdateLedgerFromStart";
            this.btnUpdateLedgerFromStart.Size = new System.Drawing.Size(166, 23);
            this.btnUpdateLedgerFromStart.TabIndex = 0;
            this.btnUpdateLedgerFromStart.Text = "Update Ledger From Start";
            this.btnUpdateLedgerFromStart.UseVisualStyleBackColor = true;
            this.btnUpdateLedgerFromStart.Click += new System.EventHandler(this.btnUpdateLedgerFromStart_Click);
            // 
            // btnDeleteLedgerFromStart
            // 
            this.btnDeleteLedgerFromStart.Location = new System.Drawing.Point(218, 190);
            this.btnDeleteLedgerFromStart.Name = "btnDeleteLedgerFromStart";
            this.btnDeleteLedgerFromStart.Size = new System.Drawing.Size(166, 23);
            this.btnDeleteLedgerFromStart.TabIndex = 0;
            this.btnDeleteLedgerFromStart.Text = "Delete Ledger From Start";
            this.btnDeleteLedgerFromStart.UseVisualStyleBackColor = true;
            this.btnDeleteLedgerFromStart.Click += new System.EventHandler(this.btnDeleteLedgerFromStart_Click);
            // 
            // btnDeletePartyFromStart
            // 
            this.btnDeletePartyFromStart.Location = new System.Drawing.Point(218, 132);
            this.btnDeletePartyFromStart.Name = "btnDeletePartyFromStart";
            this.btnDeletePartyFromStart.Size = new System.Drawing.Size(166, 23);
            this.btnDeletePartyFromStart.TabIndex = 13;
            this.btnDeletePartyFromStart.Text = "Delete Party From Start";
            this.btnDeletePartyFromStart.UseVisualStyleBackColor = true;
            this.btnDeletePartyFromStart.Click += new System.EventHandler(this.btnDeletePartyFromStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CloudSyncSystem.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(614, 362);
            this.Controls.Add(this.btnDeletePartyFromStart);
            this.Controls.Add(this.btnUpdatePartyFromStart);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStopTimer);
            this.Controls.Add(this.btnStartTimer);
            this.Controls.Add(this.btn_ManualSync);
            this.Controls.Add(this.btnDelPayment);
            this.Controls.Add(this.btnUpdatePayment);
            this.Controls.Add(this.btnDelReceipt);
            this.Controls.Add(this.btnUpdateReceipt);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnDeleteLedgerFromStart);
            this.Controls.Add(this.btnUpdateLedgerFromStart);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnUpdateParty);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Sync Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateParty;
        private System.Windows.Forms.Button btn_ManualSync;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStartTimer;
        private System.Windows.Forms.Button btnStopTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnUpdateReceipt;
        private System.Windows.Forms.Button btnDelReceipt;
        private System.Windows.Forms.Button btnUpdatePayment;
        private System.Windows.Forms.Button btnDelPayment;
        private System.Windows.Forms.Button btnUpdatePartyFromStart;
        private System.Windows.Forms.Button btnUpdateLedgerFromStart;
        private System.Windows.Forms.Button btnDeleteLedgerFromStart;
        private System.Windows.Forms.Button btnDeletePartyFromStart;
    }
}

