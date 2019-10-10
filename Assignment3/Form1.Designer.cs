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
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.greaterOrEqual = new System.Windows.Forms.RadioButton();
            this.lessOrEqual = new System.Windows.Forms.RadioButton();
            this.scoreUpDown = new System.Windows.Forms.NumericUpDown();
            this.pointsThresholdButton = new System.Windows.Forms.Button();
            this.postScoreSubredditPanel.SuspendLayout();
            this.PostScoreUserPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scoreUpDown)).BeginInit();
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
            this.outPutBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outPutBox.FormattingEnabled = true;
            this.outPutBox.ItemHeight = 18;
            this.outPutBox.Location = new System.Drawing.Point(416, 32);
            this.outPutBox.Name = "outPutBox";
            this.outPutBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.outPutBox.Size = new System.Drawing.Size(741, 364);
            this.outPutBox.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(12, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(266, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Total Awards Within a Subreddit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.OrangeRed;
            this.label8.Location = new System.Drawing.Point(75, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Subreddit";
            // 
            // subredditBox
            // 
            this.subredditBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subredditBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subredditBox.FormattingEnabled = true;
            this.subredditBox.Location = new System.Drawing.Point(77, 251);
            this.subredditBox.Name = "subredditBox";
            this.subredditBox.Size = new System.Drawing.Size(178, 21);
            this.subredditBox.TabIndex = 21;
            this.subredditBox.SelectedIndexChanged += new System.EventHandler(this.subredditBox_SelectedIndexChanged);
            // 
            // silverBox
            // 
            this.silverBox.AutoSize = true;
            this.silverBox.ForeColor = System.Drawing.Color.White;
            this.silverBox.Location = new System.Drawing.Point(20, 231);
            this.silverBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.silverBox.Name = "silverBox";
            this.silverBox.Size = new System.Drawing.Size(52, 17);
            this.silverBox.TabIndex = 22;
            this.silverBox.Text = "Silver";
            this.silverBox.UseVisualStyleBackColor = true;
            // 
            // goldBox
            // 
            this.goldBox.AutoSize = true;
            this.goldBox.ForeColor = System.Drawing.Color.White;
            this.goldBox.Location = new System.Drawing.Point(20, 251);
            this.goldBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.goldBox.Name = "goldBox";
            this.goldBox.Size = new System.Drawing.Size(48, 17);
            this.goldBox.TabIndex = 23;
            this.goldBox.Text = "Gold";
            this.goldBox.UseVisualStyleBackColor = true;
            // 
            // platBox
            // 
            this.platBox.AutoSize = true;
            this.platBox.ForeColor = System.Drawing.Color.White;
            this.platBox.Location = new System.Drawing.Point(20, 273);
            this.platBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.platBox.Name = "platBox";
            this.platBox.Size = new System.Drawing.Size(66, 17);
            this.platBox.TabIndex = 24;
            this.platBox.Text = "Platinum";
            this.platBox.UseVisualStyleBackColor = true;
            // 
            // subredditButton
            // 
            this.subredditButton.Enabled = false;
            this.subredditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subredditButton.Location = new System.Drawing.Point(293, 251);
            this.subredditButton.Name = "subredditButton";
            this.subredditButton.Size = new System.Drawing.Size(75, 23);
            this.subredditButton.TabIndex = 25;
            this.subredditButton.Text = "Query";
            this.subredditButton.UseVisualStyleBackColor = true;
            this.subredditButton.Click += new System.EventHandler(this.subredditButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.OrangeRed;
            this.label9.Location = new System.Drawing.Point(12, 368);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(310, 20);
            this.label9.TabIndex = 26;
            this.label9.Text = "Points Threshold for Posts/Comments";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.greaterOrEqual);
            this.groupBox1.Controls.Add(this.lessOrEqual);
            this.groupBox1.Location = new System.Drawing.Point(16, 398);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(157, 67);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // greaterOrEqual
            // 
            this.greaterOrEqual.AutoSize = true;
            this.greaterOrEqual.ForeColor = System.Drawing.Color.White;
            this.greaterOrEqual.Location = new System.Drawing.Point(9, 41);
            this.greaterOrEqual.Name = "greaterOrEqual";
            this.greaterOrEqual.Size = new System.Drawing.Size(146, 17);
            this.greaterOrEqual.TabIndex = 15;
            this.greaterOrEqual.TabStop = true;
            this.greaterOrEqual.Text = "Greater Than or Equal To";
            this.greaterOrEqual.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.greaterOrEqual.UseVisualStyleBackColor = true;
            this.greaterOrEqual.CheckedChanged += new System.EventHandler(this.greaterOrEqual_CheckedChanged);
            // 
            // lessOrEqual
            // 
            this.lessOrEqual.AutoSize = true;
            this.lessOrEqual.ForeColor = System.Drawing.Color.White;
            this.lessOrEqual.Location = new System.Drawing.Point(9, 18);
            this.lessOrEqual.Name = "lessOrEqual";
            this.lessOrEqual.Size = new System.Drawing.Size(133, 17);
            this.lessOrEqual.TabIndex = 14;
            this.lessOrEqual.TabStop = true;
            this.lessOrEqual.Text = "Less Than or Equal To";
            this.lessOrEqual.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lessOrEqual.UseVisualStyleBackColor = true;
            this.lessOrEqual.CheckedChanged += new System.EventHandler(this.lessOrEqual_CheckedChanged);
            // 
            // scoreUpDown
            // 
            this.scoreUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.scoreUpDown.Location = new System.Drawing.Point(177, 422);
            this.scoreUpDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scoreUpDown.Maximum = new decimal(new int[] {
            250000,
            0,
            0,
            0});
            this.scoreUpDown.Minimum = new decimal(new int[] {
            700000,
            0,
            0,
            -2147483648});
            this.scoreUpDown.Name = "scoreUpDown";
            this.scoreUpDown.ReadOnly = true;
            this.scoreUpDown.Size = new System.Drawing.Size(90, 20);
            this.scoreUpDown.TabIndex = 28;
            this.scoreUpDown.ValueChanged += new System.EventHandler(this.scoreUpDown_ValueChanged);
            // 
            // pointsThresholdButton
            // 
            this.pointsThresholdButton.Enabled = false;
            this.pointsThresholdButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsThresholdButton.Location = new System.Drawing.Point(293, 422);
            this.pointsThresholdButton.Name = "pointsThresholdButton";
            this.pointsThresholdButton.Size = new System.Drawing.Size(75, 23);
            this.pointsThresholdButton.TabIndex = 29;
            this.pointsThresholdButton.Text = "Query";
            this.pointsThresholdButton.UseVisualStyleBackColor = true;
            this.pointsThresholdButton.Click += new System.EventHandler(this.pointsThresholdButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1174, 526);
            this.Controls.Add(this.pointsThresholdButton);
            this.Controls.Add(this.scoreUpDown);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
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
            this.Name = "Form1";
            this.Text = "Reddit\'s Query System";
            this.postScoreSubredditPanel.ResumeLayout(false);
            this.postScoreSubredditPanel.PerformLayout();
            this.PostScoreUserPanel.ResumeLayout(false);
            this.PostScoreUserPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scoreUpDown)).EndInit();
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton greaterOrEqual;
        private System.Windows.Forms.RadioButton lessOrEqual;
        private System.Windows.Forms.NumericUpDown scoreUpDown;
        private System.Windows.Forms.Button pointsThresholdButton;
    }
}