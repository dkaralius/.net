namespace Assignment3
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TimeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.userBox = new System.Windows.Forms.ComboBox();
            this.userButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Lowest = new System.Windows.Forms.RadioButton();
            this.Average = new System.Windows.Forms.RadioButton();
            this.Highest = new System.Windows.Forms.RadioButton();
            this.postScoreSubredditPanel = new System.Windows.Forms.Panel();
            this.postScoreSubreddit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.PostScoreUserPanel = new System.Windows.Forms.Panel();
            this.lowestUser = new System.Windows.Forms.RadioButton();
            this.highestUser = new System.Windows.Forms.RadioButton();
            this.averageUser = new System.Windows.Forms.RadioButton();
            this.postScoreUser = new System.Windows.Forms.Button();
            this.outPutBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.subredditBox = new System.Windows.Forms.ComboBox();
            this.silverBox = new System.Windows.Forms.CheckBox();
            this.goldBox = new System.Windows.Forms.CheckBox();
            this.platBox = new System.Windows.Forms.CheckBox();
            this.subredditButton = new System.Windows.Forms.Button();
            this.postScoreSubredditPanel.SuspendLayout();
            this.PostScoreUserPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Location = new System.Drawing.Point(21, 38);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker.TabIndex = 1;
            // 
            // TimeButton
            // 
            this.TimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeButton.Location = new System.Drawing.Point(391, 34);
            this.TimeButton.Margin = new System.Windows.Forms.Padding(4);
            this.TimeButton.Name = "TimeButton";
            this.TimeButton.Size = new System.Drawing.Size(100, 28);
            this.TimeButton.TabIndex = 2;
            this.TimeButton.Text = "Query";
            this.TimeButton.UseVisualStyleBackColor = true;
            this.TimeButton.Click += new System.EventHandler(this.TimeButton_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Posts From A Specific Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(549, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(16, 364);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(377, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "List of Subreddits Posted to By a User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(17, 389);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "User";
            // 
            // userBox
            // 
            this.userBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userBox.FormattingEnabled = true;
            this.userBox.Location = new System.Drawing.Point(21, 409);
            this.userBox.Margin = new System.Windows.Forms.Padding(4);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(265, 24);
            this.userBox.TabIndex = 8;
            this.userBox.SelectedIndexChanged += new System.EventHandler(this.userBox_SelectedIndexChanged);
            // 
            // userButton
            // 
            this.userButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userButton.Location = new System.Drawing.Point(391, 409);
            this.userButton.Margin = new System.Windows.Forms.Padding(4);
            this.userButton.Name = "userButton";
            this.userButton.Size = new System.Drawing.Size(100, 28);
            this.userButton.TabIndex = 9;
            this.userButton.Text = "Query";
            this.userButton.UseVisualStyleBackColor = true;
            this.userButton.Click += new System.EventHandler(this.userButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.OrangeRed;
            this.label5.Location = new System.Drawing.Point(16, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "PostScore Per Subreddit";
            // 
            // Lowest
            // 
            this.Lowest.AutoSize = true;
            this.Lowest.ForeColor = System.Drawing.Color.White;
            this.Lowest.Location = new System.Drawing.Point(4, 4);
            this.Lowest.Margin = new System.Windows.Forms.Padding(4);
            this.Lowest.Name = "Lowest";
            this.Lowest.Size = new System.Drawing.Size(73, 21);
            this.Lowest.TabIndex = 11;
            this.Lowest.TabStop = true;
            this.Lowest.Text = "Lowest";
            this.Lowest.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Lowest.UseVisualStyleBackColor = true;
            this.Lowest.CheckedChanged += new System.EventHandler(this.Lowest_CheckedChanged);
            // 
            // Average
            // 
            this.Average.AutoSize = true;
            this.Average.ForeColor = System.Drawing.Color.White;
            this.Average.Location = new System.Drawing.Point(91, 4);
            this.Average.Margin = new System.Windows.Forms.Padding(4);
            this.Average.Name = "Average";
            this.Average.Size = new System.Drawing.Size(82, 21);
            this.Average.TabIndex = 12;
            this.Average.TabStop = true;
            this.Average.Text = "Average";
            this.Average.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Average.UseVisualStyleBackColor = true;
            this.Average.CheckedChanged += new System.EventHandler(this.Average_CheckedChanged);
            // 
            // Highest
            // 
            this.Highest.AutoSize = true;
            this.Highest.ForeColor = System.Drawing.Color.White;
            this.Highest.Location = new System.Drawing.Point(179, 4);
            this.Highest.Margin = new System.Windows.Forms.Padding(4);
            this.Highest.Name = "Highest";
            this.Highest.Size = new System.Drawing.Size(77, 21);
            this.Highest.TabIndex = 13;
            this.Highest.TabStop = true;
            this.Highest.Text = "Highest";
            this.Highest.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Highest.UseVisualStyleBackColor = true;
            this.Highest.CheckedChanged += new System.EventHandler(this.Highest_CheckedChanged);
            // 
            // postScoreSubredditPanel
            // 
            this.postScoreSubredditPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.postScoreSubredditPanel.Controls.Add(this.Lowest);
            this.postScoreSubredditPanel.Controls.Add(this.Highest);
            this.postScoreSubredditPanel.Controls.Add(this.Average);
            this.postScoreSubredditPanel.Location = new System.Drawing.Point(21, 114);
            this.postScoreSubredditPanel.Margin = new System.Windows.Forms.Padding(4);
            this.postScoreSubredditPanel.Name = "postScoreSubredditPanel";
            this.postScoreSubredditPanel.Size = new System.Drawing.Size(266, 30);
            this.postScoreSubredditPanel.TabIndex = 14;
            // 
            // postScoreSubreddit
            // 
            this.postScoreSubreddit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postScoreSubreddit.Location = new System.Drawing.Point(391, 114);
            this.postScoreSubreddit.Margin = new System.Windows.Forms.Padding(4);
            this.postScoreSubreddit.Name = "postScoreSubreddit";
            this.postScoreSubreddit.Size = new System.Drawing.Size(100, 28);
            this.postScoreSubreddit.TabIndex = 15;
            this.postScoreSubreddit.Text = "Query";
            this.postScoreSubreddit.UseVisualStyleBackColor = true;
            this.postScoreSubreddit.Click += new System.EventHandler(this.postScoreButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(16, 162);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "PostScore Per User";
            // 
            // PostScoreUserPanel
            // 
            this.PostScoreUserPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PostScoreUserPanel.Controls.Add(this.lowestUser);
            this.PostScoreUserPanel.Controls.Add(this.highestUser);
            this.PostScoreUserPanel.Controls.Add(this.averageUser);
            this.PostScoreUserPanel.Location = new System.Drawing.Point(21, 191);
            this.PostScoreUserPanel.Margin = new System.Windows.Forms.Padding(4);
            this.PostScoreUserPanel.Name = "PostScoreUserPanel";
            this.PostScoreUserPanel.Size = new System.Drawing.Size(266, 30);
            this.PostScoreUserPanel.TabIndex = 15;
            // 
            // lowestUser
            // 
            this.lowestUser.AutoSize = true;
            this.lowestUser.ForeColor = System.Drawing.Color.White;
            this.lowestUser.Location = new System.Drawing.Point(4, 4);
            this.lowestUser.Margin = new System.Windows.Forms.Padding(4);
            this.lowestUser.Name = "lowestUser";
            this.lowestUser.Size = new System.Drawing.Size(73, 21);
            this.lowestUser.TabIndex = 11;
            this.lowestUser.TabStop = true;
            this.lowestUser.Text = "Lowest";
            this.lowestUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lowestUser.UseVisualStyleBackColor = true;
            this.lowestUser.CheckedChanged += new System.EventHandler(this.lowestUser_CheckedChanged);
            // 
            // highestUser
            // 
            this.highestUser.AutoSize = true;
            this.highestUser.ForeColor = System.Drawing.Color.White;
            this.highestUser.Location = new System.Drawing.Point(179, 4);
            this.highestUser.Margin = new System.Windows.Forms.Padding(4);
            this.highestUser.Name = "highestUser";
            this.highestUser.Size = new System.Drawing.Size(77, 21);
            this.highestUser.TabIndex = 13;
            this.highestUser.TabStop = true;
            this.highestUser.Text = "Highest";
            this.highestUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.highestUser.UseVisualStyleBackColor = true;
            this.highestUser.CheckedChanged += new System.EventHandler(this.highestUser_CheckedChanged);
            // 
            // averageUser
            // 
            this.averageUser.AutoSize = true;
            this.averageUser.ForeColor = System.Drawing.Color.White;
            this.averageUser.Location = new System.Drawing.Point(91, 4);
            this.averageUser.Margin = new System.Windows.Forms.Padding(4);
            this.averageUser.Name = "averageUser";
            this.averageUser.Size = new System.Drawing.Size(82, 21);
            this.averageUser.TabIndex = 12;
            this.averageUser.TabStop = true;
            this.averageUser.Text = "Average";
            this.averageUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.averageUser.UseVisualStyleBackColor = true;
            this.averageUser.CheckedChanged += new System.EventHandler(this.averageUser_CheckedChanged);
            // 
            // postScoreUser
            // 
            this.postScoreUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postScoreUser.Location = new System.Drawing.Point(391, 188);
            this.postScoreUser.Margin = new System.Windows.Forms.Padding(4);
            this.postScoreUser.Name = "postScoreUser";
            this.postScoreUser.Size = new System.Drawing.Size(100, 28);
            this.postScoreUser.TabIndex = 17;
            this.postScoreUser.Text = "Query";
            this.postScoreUser.UseVisualStyleBackColor = true;
            this.postScoreUser.Click += new System.EventHandler(this.postScoreUser_Click);
            // 
            // outPutBox
            // 
            this.outPutBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outPutBox.FormattingEnabled = true;
            this.outPutBox.ItemHeight = 25;
            this.outPutBox.Location = new System.Drawing.Point(555, 39);
            this.outPutBox.Margin = new System.Windows.Forms.Padding(4);
            this.outPutBox.Name = "outPutBox";
            this.outPutBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.outPutBox.Size = new System.Drawing.Size(987, 479);
            this.outPutBox.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(16, 253);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(323, 25);
            this.label7.TabIndex = 19;
            this.label7.Text = "Total Awards Within a Subreddit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.OrangeRed;
            this.label8.Location = new System.Drawing.Point(100, 288);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Subreddit";
            // 
            // subredditBox
            // 
            this.subredditBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subredditBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subredditBox.FormattingEnabled = true;
            this.subredditBox.Location = new System.Drawing.Point(103, 309);
            this.subredditBox.Margin = new System.Windows.Forms.Padding(4);
            this.subredditBox.Name = "subredditBox";
            this.subredditBox.Size = new System.Drawing.Size(236, 24);
            this.subredditBox.TabIndex = 21;
            this.subredditBox.SelectedIndexChanged += new System.EventHandler(this.subredditBox_SelectedIndexChanged);
            // 
            // silverBox
            // 
            this.silverBox.AutoSize = true;
            this.silverBox.ForeColor = System.Drawing.Color.White;
            this.silverBox.Location = new System.Drawing.Point(26, 284);
            this.silverBox.Name = "silverBox";
            this.silverBox.Size = new System.Drawing.Size(65, 21);
            this.silverBox.TabIndex = 22;
            this.silverBox.Text = "Silver";
            this.silverBox.UseVisualStyleBackColor = true;
            // 
            // goldBox
            // 
            this.goldBox.AutoSize = true;
            this.goldBox.ForeColor = System.Drawing.Color.White;
            this.goldBox.Location = new System.Drawing.Point(26, 309);
            this.goldBox.Name = "goldBox";
            this.goldBox.Size = new System.Drawing.Size(60, 21);
            this.goldBox.TabIndex = 23;
            this.goldBox.Text = "Gold";
            this.goldBox.UseVisualStyleBackColor = true;
            // 
            // platBox
            // 
            this.platBox.AutoSize = true;
            this.platBox.ForeColor = System.Drawing.Color.White;
            this.platBox.Location = new System.Drawing.Point(26, 336);
            this.platBox.Name = "platBox";
            this.platBox.Size = new System.Drawing.Size(84, 21);
            this.platBox.TabIndex = 24;
            this.platBox.Text = "Platinum";
            this.platBox.UseVisualStyleBackColor = true;
            // 
            // subredditButton
            // 
            this.subredditButton.Enabled = false;
            this.subredditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subredditButton.Location = new System.Drawing.Point(391, 309);
            this.subredditButton.Margin = new System.Windows.Forms.Padding(4);
            this.subredditButton.Name = "subredditButton";
            this.subredditButton.Size = new System.Drawing.Size(100, 28);
            this.subredditButton.TabIndex = 25;
            this.subredditButton.Text = "Query";
            this.subredditButton.UseVisualStyleBackColor = true;
            this.subredditButton.Click += new System.EventHandler(this.subredditButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1559, 554);
            this.Controls.Add(this.subredditButton);
            this.Controls.Add(this.platBox);
            this.Controls.Add(this.goldBox);
            this.Controls.Add(this.silverBox);
            this.Controls.Add(this.subredditBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.outPutBox);
            this.Controls.Add(this.postScoreUser);
            this.Controls.Add(this.PostScoreUserPanel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.postScoreSubreddit);
            this.Controls.Add(this.postScoreSubredditPanel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.userButton);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TimeButton);
            this.Controls.Add(this.dateTimePicker);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.postScoreSubredditPanel.ResumeLayout(false);
            this.postScoreSubredditPanel.PerformLayout();
            this.PostScoreUserPanel.ResumeLayout(false);
            this.PostScoreUserPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button TimeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox userBox;
        private System.Windows.Forms.Button userButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton Lowest;
        private System.Windows.Forms.RadioButton Average;
        private System.Windows.Forms.RadioButton Highest;
        private System.Windows.Forms.Panel postScoreSubredditPanel;
        private System.Windows.Forms.Button postScoreSubreddit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel PostScoreUserPanel;
        private System.Windows.Forms.RadioButton lowestUser;
        private System.Windows.Forms.RadioButton highestUser;
        private System.Windows.Forms.RadioButton averageUser;
        private System.Windows.Forms.Button postScoreUser;
        private System.Windows.Forms.ListBox outPutBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox subredditBox;
        private System.Windows.Forms.CheckBox silverBox;
        private System.Windows.Forms.CheckBox goldBox;
        private System.Windows.Forms.CheckBox platBox;
        private System.Windows.Forms.Button subredditButton;
    }
}