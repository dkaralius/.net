using System;

namespace Assignment2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.User_Output = new System.Windows.Forms.ListBox();
            this.Subreddit_Output = new System.Windows.Forms.ListBox();
            this.System_Output = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.LogIn = new System.Windows.Forms.Button();
            this.Post_Output = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Members_Output = new System.Windows.Forms.RichTextBox();
            this.Active_Output = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(363, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Subreddits";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(519, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Posts";
            // 
            // User_Output
            // 
            this.User_Output.Cursor = System.Windows.Forms.Cursors.Hand;
            this.User_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Output.FormattingEnabled = true;
            this.User_Output.ItemHeight = 20;
            this.User_Output.Location = new System.Drawing.Point(16, 40);
            this.User_Output.Name = "User_Output";
            this.User_Output.Size = new System.Drawing.Size(328, 224);
            this.User_Output.TabIndex = 7;
            this.User_Output.SelectedIndexChanged += new System.EventHandler(this.User_Output_SelectedIndexChanged);
            // 
            // Subreddit_Output
            // 
            this.Subreddit_Output.BackColor = System.Drawing.Color.Black;
            this.Subreddit_Output.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Subreddit_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subreddit_Output.ForeColor = System.Drawing.Color.White;
            this.Subreddit_Output.FormattingEnabled = true;
            this.Subreddit_Output.ItemHeight = 20;
            this.Subreddit_Output.Location = new System.Drawing.Point(367, 40);
            this.Subreddit_Output.Name = "Subreddit_Output";
            this.Subreddit_Output.Size = new System.Drawing.Size(134, 224);
            this.Subreddit_Output.TabIndex = 8;
            this.Subreddit_Output.SelectedIndexChanged += new System.EventHandler(this.Subreddit_Output_SelectedIndexChanged);
            // 
            // System_Output
            // 
            this.System_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.System_Output.Location = new System.Drawing.Point(12, 562);
            this.System_Output.Name = "System_Output";
            this.System_Output.ReadOnly = true;
            this.System_Output.Size = new System.Drawing.Size(1404, 96);
            this.System_Output.TabIndex = 9;
            this.System_Output.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(12, 535);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "System Output";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.OrangeRed;
            this.label5.Location = new System.Drawing.Point(12, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Password";
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(16, 294);
            this.Password.MaxLength = 40;
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(141, 26);
            this.Password.TabIndex = 12;
            // 
            // LogIn
            // 
            this.LogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogIn.Location = new System.Drawing.Point(172, 294);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(75, 26);
            this.LogIn.TabIndex = 13;
            this.LogIn.Text = "Log-In";
            this.LogIn.UseVisualStyleBackColor = true;
            this.LogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // Post_Output
            // 
            this.Post_Output.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Post_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Post_Output.FormattingEnabled = true;
            this.Post_Output.ItemHeight = 20;
            this.Post_Output.Location = new System.Drawing.Point(523, 40);
            this.Post_Output.Name = "Post_Output";
            this.Post_Output.Size = new System.Drawing.Size(893, 224);
            this.Post_Output.TabIndex = 14;
            this.Post_Output.SelectedIndexChanged += new System.EventHandler(this.Post_Output_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(311, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Members";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(467, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Active";
            // 
            // Members_Output
            // 
            this.Members_Output.BackColor = System.Drawing.Color.Black;
            this.Members_Output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Members_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Members_Output.ForeColor = System.Drawing.Color.White;
            this.Members_Output.Location = new System.Drawing.Point(389, 273);
            this.Members_Output.Name = "Members_Output";
            this.Members_Output.ReadOnly = true;
            this.Members_Output.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.Members_Output.Size = new System.Drawing.Size(72, 16);
            this.Members_Output.TabIndex = 17;
            this.Members_Output.Text = "";
            // 
            // Active_Output
            // 
            this.Active_Output.BackColor = System.Drawing.Color.Black;
            this.Active_Output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Active_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Active_Output.ForeColor = System.Drawing.Color.White;
            this.Active_Output.Location = new System.Drawing.Point(523, 273);
            this.Active_Output.Name = "Active_Output";
            this.Active_Output.ReadOnly = true;
            this.Active_Output.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.Active_Output.Size = new System.Drawing.Size(72, 16);
            this.Active_Output.TabIndex = 18;
            this.Active_Output.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1428, 670);
            this.Controls.Add(this.Active_Output);
            this.Controls.Add(this.Members_Output);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Post_Output);
            this.Controls.Add(this.LogIn);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.System_Output);
            this.Controls.Add(this.Subreddit_Output);
            this.Controls.Add(this.User_Output);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Welcome to Reddit!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox User_Output;
        private System.Windows.Forms.ListBox Subreddit_Output;
        private System.Windows.Forms.RichTextBox System_Output;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button LogIn;
        private System.Windows.Forms.ListBox Post_Output;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox Members_Output;
        private System.Windows.Forms.RichTextBox Active_Output;
    }
}

