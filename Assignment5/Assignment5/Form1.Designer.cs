namespace Assignment5
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Label();
            this.piece = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.linesLabel = new System.Windows.Forms.Label();
            this.lines = new System.Windows.Forms.Label();
            this.levels = new System.Windows.Forms.Label();
            this.tetris = new System.Windows.Forms.Label();
            this.game = new Game();
            this.shapePreview = new ShapePreview();
            ((System.ComponentModel.ISupportInitialize)(this.game)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shapePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // Button1 (newGame)
            // 
            this.Button1.BackColor = System.Drawing.Color.Gray;
            this.Button1.ForeColor = System.Drawing.Color.Black;
            this.Button1.Location = new System.Drawing.Point(100, 523);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.Text = "New Game";
            this.Button1.UseVisualStyleBackColor = false;
            // 
            // Button2 (How to play)
            // 
            this.Button2.BackColor = System.Drawing.Color.Gray;
            this.Button2.ForeColor = System.Drawing.Color.Black;
            this.Button2.Location = new System.Drawing.Point(175, 523);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.Text = "How to Play";
            this.Button2.UseVisualStyleBackColor = false;
            // 
            // Button3 (Pause/Resume)
            // 
            this.Button3.BackColor = System.Drawing.Color.Gray;
            this.Button3.ForeColor = System.Drawing.Color.Black;
            this.Button3.Location = new System.Drawing.Point(250, 523);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(75, 23);
            this.Button3.Text = "Pause";
            this.Button3.UseVisualStyleBackColor = false;
            this.Button3.Enabled = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Broadway", 10);
            this.scoreLabel.ForeColor = System.Drawing.Color.Black;
            this.scoreLabel.Location = new System.Drawing.Point(366, 133);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(84, 26);
            this.scoreLabel.Text = "000000";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Broadway", 16);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(366, 105);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(75, 26);
            this.Label1.Text = "Score";
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Broadway", 16);
            this.timerLabel.ForeColor = System.Drawing.Color.Black;
            this.timerLabel.Location = new System.Drawing.Point(366, 60);
            this.timerLabel.Name = "timeLabel";
            this.timerLabel.Size = new System.Drawing.Size(75, 26);
            this.timerLabel.Text = "Time Played";
            // 
            // timer
            // 
            this.timer.AutoSize = true;
            this.timer.Font = new System.Drawing.Font("Broadway", 10);
            this.timer.ForeColor = System.Drawing.Color.Black;
            this.timer.Location = new System.Drawing.Point(366, 85);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(0, 13);
            // 
            // piece
            // 
            this.piece.AutoSize = true;
            this.piece.Font = new System.Drawing.Font("Broadway", 16);
            this.piece.ForeColor = System.Drawing.Color.Black;
            this.piece.Location = new System.Drawing.Point(366, 235);
            this.piece.Name = "piece";
            this.piece.Size = new System.Drawing.Size(75, 26);
            this.piece.Text = "Next block";
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Font = new System.Drawing.Font("Broadway", 16);
            this.levelLabel.ForeColor = System.Drawing.Color.Black;
            this.levelLabel.Location = new System.Drawing.Point(366, 150);
            this.levelLabel.Name = "level";
            this.levelLabel.Size = new System.Drawing.Size(75, 26);
            this.levelLabel.Text = "Level";
            // 
            // levels
            // 
            this.levels.AutoSize = true;
            this.levels.Font = new System.Drawing.Font("Broadway", 10);
            this.levels.ForeColor = System.Drawing.Color.Black;
            this.levels.Location = new System.Drawing.Point(366, 175);
            this.levels.Name = "levels";
            this.levels.Size = new System.Drawing.Size(75, 26);
            this.levels.Text = "1";
            // 
            // linesLabel
            // 
            this.linesLabel.AutoSize = true;
            this.linesLabel.Font = new System.Drawing.Font("Broadway", 16);
            this.linesLabel.ForeColor = System.Drawing.Color.Black;
            this.linesLabel.Location = new System.Drawing.Point(366, 195);
            this.linesLabel.Name = "linesLabel";
            this.linesLabel.Size = new System.Drawing.Size(75, 26);
            this.linesLabel.Text = "Lines";
            // 
            // lines
            // 
            this.lines.AutoSize = true;
            this.lines.Font = new System.Drawing.Font("Broadway", 10);
            this.lines.ForeColor = System.Drawing.Color.Black;
            this.lines.Location = new System.Drawing.Point(366, 220);
            this.lines.Name = "lines";
            this.lines.Size = new System.Drawing.Size(75, 26);
            this.lines.Text = "0";
            // 
            // tetris
            // 
            this.tetris.AutoSize = true;
            this.tetris.Font = new System.Drawing.Font("Broadway", 40);
            this.tetris.ForeColor = System.Drawing.Color.Black;
            this.tetris.Name = "tetris";
            this.tetris.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tetris.Text = "TETRIS";
            // 
            // game
            // 
            this.game.AllowUserToAddRows = false;
            this.game.AllowUserToDeleteRows = false;
            this.game.AllowUserToResizeColumns = false;
            this.game.AllowUserToResizeRows = false;
            this.game.BackgroundColor = System.Drawing.Color.DarkGray;
            this.game.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.game.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.game.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.game.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Transparent;
            this.game.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Transparent;
            this.game.DefaultCellStyle = dataGridViewCellStyle1;
            this.game.DefaultCellStyle.BackColor = System.Drawing.Color.Transparent;
            this.game.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.game.ReadOnly = true;
            this.game.GridColor = System.Drawing.Color.Black;
            this.game.Location = new System.Drawing.Point(62, 62);
            this.game.Name = "game";
            this.game.RowHeadersVisible = false;
            this.game.Size = new System.Drawing.Size(303, 453);
            // 
            // shapePreview
            // 
            this.shapePreview.AllowUserToAddRows = false;
            this.shapePreview.AllowUserToDeleteRows = false;
            this.shapePreview.AllowUserToResizeColumns = false;
            this.shapePreview.AllowUserToResizeRows = false;
            this.shapePreview.BackgroundColor = System.Drawing.Color.DarkGray;
            this.shapePreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shapePreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shapePreview.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.shapePreview.DefaultCellStyle = dataGridViewCellStyle2;
            this.shapePreview.GridColor = System.Drawing.Color.DarkGray;
            this.shapePreview.Location = new System.Drawing.Point(369, 260);
            this.shapePreview.Name = "shapePreview";
            this.shapePreview.RowHeadersVisible = false;
            this.shapePreview.Size = new System.Drawing.Size(200, 200);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(550, 560);
            this.Controls.Add(this.shapePreview);
            this.Controls.Add(this.game);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.piece);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.linesLabel);
            this.Controls.Add(this.lines);
            this.Controls.Add(this.levels);
            this.Controls.Add(this.tetris);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.game)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shapePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Button Button3;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label timer;
        private System.Windows.Forms.Label piece;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label linesLabel;
        private System.Windows.Forms.Label lines;
        private System.Windows.Forms.Label levels;
        private System.Windows.Forms.Label tetris;
        private Game game;
        private ShapePreview shapePreview;
    }
}