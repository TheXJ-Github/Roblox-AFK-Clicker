
namespace AFK_Clicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.upDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonClick = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.upDown)).BeginInit();
            this.SuspendLayout();
            // 
            // upDown
            // 
            this.upDown.Location = new System.Drawing.Point(12, 101);
            this.upDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDown.Name = "upDown";
            this.upDown.Size = new System.Drawing.Size(120, 20);
            this.upDown.TabIndex = 0;
            this.upDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Distance to deactivate auto-clicker (min 1, max 100)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "How does this Auto-Clicker work?                     to learn the inner-workings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(341, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "How do you use this Auto-Clicker?                    to learn how to use this!";
            // 
            // buttonClick
            // 
            this.buttonClick.Location = new System.Drawing.Point(12, 173);
            this.buttonClick.Name = "buttonClick";
            this.buttonClick.Size = new System.Drawing.Size(169, 23);
            this.buttonClick.TabIndex = 4;
            this.buttonClick.Text = "Begin Clicking!";
            this.buttonClick.UseVisualStyleBackColor = true;
            this.buttonClick.Click += new System.EventHandler(this.buttonClick_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Note that this button will move your";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "cursor rightward and downward 150 pixels";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(344, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Press F6 to enable/disable the autoclicker. This won\'t move your cursor";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(177, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(56, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Click Here";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TryVisitLink);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(177, 31);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(56, 13);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Click Here";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ShowHelp);
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(404, 243);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonClick);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.upDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roblox AFK Clicker - Prevent Disconnecting";
            ((System.ComponentModel.ISupportInitialize)(this.upDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown upDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonClick;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}

