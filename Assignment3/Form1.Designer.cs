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
            this.postScoreSubredditPanel.SuspendLayout();
            this.PostScoreUserPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Location = new System.Drawing.Point(16, 31);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 1;
            // 
            // TimeButton
            // 
            this.TimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeButton.Location = new System.Drawing.Point(293, 28);
            this.TimeButton.Name = "TimeButton";
            this.TimeButton.Size = new System.Drawing.Size(75, 23);
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
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Posts From A Specific Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(412, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(12, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(316, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "List of Subreddits Posted to By a User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(13, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "User";
            // 
            // userBox
            // 
            this.userBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userBox.FormattingEnabled = true;
            this.userBox.Location = new System.Drawing.Point(16, 332);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(200, 21);
            this.userBox.TabIndex = 8;
            this.userBox.SelectedIndexChanged += new System.EventHandler(this.userBox_SelectedIndexChanged);
            // 
            // userButton
            // 
            this.userButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userButton.Location = new System.Drawing.Point(293, 332);
            this.userButton.Name = "userButton";
            this.userButton.Size = new System.Drawing.Size(75, 23);
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
            this.label5.Location = new System.Drawing.Point(12, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(207, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "PostScore Per Subreddit";
            // 
            // Lowest
            // 
            this.Lowest.AutoSize = true;
            this.Lowest.ForeColor = System.Drawing.Color.White;
            this.Lowest.Location = new System.Drawing.Point(3, 3);
            this.Lowest.Name = "Lowest";
            this.Lowest.Size = new System.Drawing.Size(59, 17);
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
            this.Average.Location = new System.Drawing.Point(68, 3);
            this.Average.Name = "Average";
            this.Average.Size = new System.Drawing.Size(65, 17);
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
            this.Highest.Location = new System.Drawing.Point(134, 3);
            this.Highest.Name = "Highest";
            this.Highest.Size = new System.Drawing.Size(61, 17);
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
            this.postScoreSubredditPanel.Location = new System.Drawing.Point(16, 93);
            this.postScoreSubredditPanel.Name = "postScoreSubredditPanel";
            this.postScoreSubredditPanel.Size = new System.Drawing.Size(200, 25);
            this.postScoreSubredditPanel.TabIndex = 14;
            // 
            // postScoreSubreddit
            // 
            this.postScoreSubreddit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postScoreSubreddit.Location = new System.Drawing.Point(293, 93);
            this.postScoreSubreddit.Name = "postScoreSubreddit";
            this.postScoreSubreddit.Size = new System.Drawing.Size(75, 23);
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
            this.label6.Location = new System.Drawing.Point(12, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "PostScore Per User";
            // 
            // PostScoreUserPanel
            // 
            this.PostScoreUserPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PostScoreUserPanel.Controls.Add(this.lowestUser);
            this.PostScoreUserPanel.Controls.Add(this.highestUser);
            this.PostScoreUserPanel.Controls.Add(this.averageUser);
            this.PostScoreUserPanel.Location = new System.Drawing.Point(16, 155);
            this.PostScoreUserPanel.Name = "PostScoreUserPanel";
            this.PostScoreUserPanel.Size = new System.Drawing.Size(200, 25);
            this.PostScoreUserPanel.TabIndex = 15;
            // 
            // lowestUser
            // 
            this.lowestUser.AutoSize = true;
            this.lowestUser.ForeColor = System.Drawing.Color.White;
            this.lowestUser.Location = new System.Drawing.Point(3, 3);
            this.lowestUser.Name = "lowestUser";
            this.lowestUser.Size = new System.Drawing.Size(59, 17);
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
            this.highestUser.Location = new System.Drawing.Point(134, 3);
            this.highestUser.Name = "highestUser";
            this.highestUser.Size = new System.Drawing.Size(61, 17);
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
            this.averageUser.Location = new System.Drawing.Point(68, 3);
            this.averageUser.Name = "averageUser";
            this.averageUser.Size = new System.Drawing.Size(65, 17);
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
            this.postScoreUser.Location = new System.Drawing.Point(293, 153);
            this.postScoreUser.Name = "postScoreUser";
            this.postScoreUser.Size = new System.Drawing.Size(75, 23);
            this.postScoreUser.TabIndex = 17;
            this.postScoreUser.Text = "Query";
            this.postScoreUser.UseVisualStyleBackColor = true;
            this.postScoreUser.Click += new System.EventHandler(this.postScoreUser_Click);
            // 
            // outPutBox
            // 
            this.outPutBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outPutBox.FormattingEnabled = true;
            this.outPutBox.ItemHeight = 20;
            this.outPutBox.Location = new System.Drawing.Point(416, 32);
            this.outPutBox.Name = "outPutBox";
            this.outPutBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.outPutBox.Size = new System.Drawing.Size(741, 404);
            this.outPutBox.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1169, 450);
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
    }
}

