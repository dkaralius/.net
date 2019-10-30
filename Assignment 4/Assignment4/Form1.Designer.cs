namespace Assignment4
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userLabel = new System.Windows.Forms.Label();
            this.logInButton = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Location = new System.Drawing.Point(2, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.AutoSize = true;
            this.mainPanel.Location = new System.Drawing.Point(11, 69);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(614, 421);
            this.mainPanel.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.userLabel);
            this.panel2.Controls.Add(this.logInButton);
            this.panel2.Location = new System.Drawing.Point(-6, -7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(903, 34);
            this.panel2.TabIndex = 4;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(5, 13);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(0, 13);
            this.userLabel.TabIndex = 1;
            // 
            // logInButton
            // 
            this.logInButton.Location = new System.Drawing.Point(825, 8);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(75, 23);
            this.logInButton.TabIndex = 0;
            this.logInButton.Text = "Log In";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(895, 501);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Reddit";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.Label userLabel;
    }
}

