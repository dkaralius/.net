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
            this.label8 = new System.Windows.Forms.Label();
            this.Comments_Output = new System.Windows.Forms.ListBox();
            this.Delete_Post_Button = new System.Windows.Forms.Button();
            this.Delete_Comment_Button = new System.Windows.Forms.Button();
            this.Reply_Input = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Reply_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(484, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Subreddits";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(692, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Posts";
            // 
            // User_Output
            // 
            this.User_Output.Cursor = System.Windows.Forms.Cursors.Hand;
            this.User_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Output.FormattingEnabled = true;
            this.User_Output.ItemHeight = 25;
            this.User_Output.Location = new System.Drawing.Point(21, 49);
            this.User_Output.Margin = new System.Windows.Forms.Padding(4);
            this.User_Output.Name = "User_Output";
            this.User_Output.Size = new System.Drawing.Size(436, 254);
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
            this.Subreddit_Output.ItemHeight = 25;
            this.Subreddit_Output.Location = new System.Drawing.Point(489, 49);
            this.Subreddit_Output.Margin = new System.Windows.Forms.Padding(4);
            this.Subreddit_Output.Name = "Subreddit_Output";
            this.Subreddit_Output.Size = new System.Drawing.Size(177, 254);
            this.Subreddit_Output.TabIndex = 8;
            this.Subreddit_Output.SelectedIndexChanged += new System.EventHandler(this.Subreddit_Output_SelectedIndexChanged);
            // 
            // System_Output
            // 
            this.System_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.System_Output.Location = new System.Drawing.Point(16, 692);
            this.System_Output.Margin = new System.Windows.Forms.Padding(4);
            this.System_Output.Name = "System_Output";
            this.System_Output.ReadOnly = true;
            this.System_Output.Size = new System.Drawing.Size(1871, 117);
            this.System_Output.TabIndex = 9;
            this.System_Output.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(16, 658);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "System Output";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.OrangeRed;
            this.label5.Location = new System.Drawing.Point(16, 329);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "Password";
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(21, 362);
            this.Password.Margin = new System.Windows.Forms.Padding(4);
            this.Password.MaxLength = 40;
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(187, 30);
            this.Password.TabIndex = 12;
            // 
            // LogIn
            // 
            this.LogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogIn.Location = new System.Drawing.Point(229, 362);
            this.LogIn.Margin = new System.Windows.Forms.Padding(4);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(100, 32);
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
            this.Post_Output.ItemHeight = 25;
            this.Post_Output.Location = new System.Drawing.Point(697, 49);
            this.Post_Output.Margin = new System.Windows.Forms.Padding(4);
            this.Post_Output.Name = "Post_Output";
            this.Post_Output.Size = new System.Drawing.Size(1189, 254);
            this.Post_Output.TabIndex = 14;
            this.Post_Output.SelectedIndexChanged += new System.EventHandler(this.Post_Output_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(415, 336);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Members";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(623, 336);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Active";
            // 
            // Members_Output
            // 
            this.Members_Output.BackColor = System.Drawing.Color.Black;
            this.Members_Output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Members_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Members_Output.ForeColor = System.Drawing.Color.White;
            this.Members_Output.Location = new System.Drawing.Point(519, 336);
            this.Members_Output.Margin = new System.Windows.Forms.Padding(4);
            this.Members_Output.Name = "Members_Output";
            this.Members_Output.ReadOnly = true;
            this.Members_Output.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.Members_Output.Size = new System.Drawing.Size(96, 20);
            this.Members_Output.TabIndex = 17;
            this.Members_Output.Text = "";
            // 
            // Active_Output
            // 
            this.Active_Output.BackColor = System.Drawing.Color.Black;
            this.Active_Output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Active_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Active_Output.ForeColor = System.Drawing.Color.White;
            this.Active_Output.Location = new System.Drawing.Point(697, 336);
            this.Active_Output.Margin = new System.Windows.Forms.Padding(4);
            this.Active_Output.Name = "Active_Output";
            this.Active_Output.ReadOnly = true;
            this.Active_Output.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.Active_Output.Size = new System.Drawing.Size(96, 20);
            this.Active_Output.TabIndex = 18;
            this.Active_Output.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.OrangeRed;
            this.label8.Location = new System.Drawing.Point(16, 407);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 29);
            this.label8.TabIndex = 19;
            this.label8.Text = "Comments";
            // 
            // Comments_Output
            // 
            this.Comments_Output.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Comments_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comments_Output.FormattingEnabled = true;
            this.Comments_Output.HorizontalExtent = 2000;
            this.Comments_Output.HorizontalScrollbar = true;
            this.Comments_Output.ItemHeight = 20;
            this.Comments_Output.Location = new System.Drawing.Point(24, 445);
            this.Comments_Output.Name = "Comments_Output";
            this.Comments_Output.Size = new System.Drawing.Size(1242, 184);
            this.Comments_Output.TabIndex = 7;
            this.Comments_Output.SelectedIndexChanged += new System.EventHandler(this.Comments_Output_SelectedIndexChanged);
            // 
            // Delete_Post_Button
            // 
            this.Delete_Post_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete_Post_Button.Enabled = false;
            this.Delete_Post_Button.ForeColor = System.Drawing.Color.OrangeRed;
            this.Delete_Post_Button.Location = new System.Drawing.Point(1786, 310);
            this.Delete_Post_Button.Name = "Delete_Post_Button";
            this.Delete_Post_Button.Size = new System.Drawing.Size(100, 32);
            this.Delete_Post_Button.TabIndex = 20;
            this.Delete_Post_Button.Text = "Delete Post";
            this.Delete_Post_Button.UseVisualStyleBackColor = true;
            this.Delete_Post_Button.Visible = false;
            this.Delete_Post_Button.Click += new System.EventHandler(this.Delete_Post_Button_Click);
            // 
            // Delete_Comment_Button
            // 
            this.Delete_Comment_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete_Comment_Button.Enabled = false;
            this.Delete_Comment_Button.ForeColor = System.Drawing.Color.OrangeRed;
            this.Delete_Comment_Button.Location = new System.Drawing.Point(1284, 597);
            this.Delete_Comment_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Delete_Comment_Button.Name = "Delete_Comment_Button";
            this.Delete_Comment_Button.Size = new System.Drawing.Size(133, 32);
            this.Delete_Comment_Button.TabIndex = 21;
            this.Delete_Comment_Button.Text = "Delete Comment";
            this.Delete_Comment_Button.UseVisualStyleBackColor = true;
            this.Delete_Comment_Button.Visible = false;
            this.Delete_Comment_Button.Click += new System.EventHandler(this.Delete_Comment_Button_Click);
            // 
            // Reply_Input
            // 
            this.Reply_Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reply_Input.Location = new System.Drawing.Point(1284, 445);
            this.Reply_Input.Multiline = true;
            this.Reply_Input.Name = "Reply_Input";
            this.Reply_Input.Size = new System.Drawing.Size(603, 145);
            this.Reply_Input.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.OrangeRed;
            this.label9.Location = new System.Drawing.Point(1279, 407);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 29);
            this.label9.TabIndex = 23;
            this.label9.Text = "Add Reply";
            // 
            // Reply_Button
            // 
            this.Reply_Button.ForeColor = System.Drawing.Color.LimeGreen;
            this.Reply_Button.Location = new System.Drawing.Point(1761, 596);
            this.Reply_Button.Name = "Reply_Button";
            this.Reply_Button.Size = new System.Drawing.Size(125, 33);
            this.Reply_Button.TabIndex = 24;
            this.Reply_Button.Text = "Add Reply";
            this.Reply_Button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AcceptButton = this.LogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1904, 825);
            this.Controls.Add(this.Reply_Button);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Reply_Input);
            this.Controls.Add(this.Delete_Comment_Button);
            this.Controls.Add(this.Delete_Post_Button);
            this.Controls.Add(this.Comments_Output);
            this.Controls.Add(this.label8);
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
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox Comments_Output;
        private System.Windows.Forms.Button Delete_Post_Button;
        private System.Windows.Forms.Button Delete_Comment_Button;
        private System.Windows.Forms.TextBox Reply_Input;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Reply_Button;
    }
}
