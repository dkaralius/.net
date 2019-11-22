namespace Assignment6
{
    partial class FormHome
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
            this.Chart1Button = new System.Windows.Forms.Button();
            this.Chart2Button = new System.Windows.Forms.Button();
            this.Chart3Button = new System.Windows.Forms.Button();
            this.Chart4Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Chart1Button
            // 
            this.Chart1Button.Location = new System.Drawing.Point(12, 12);
            this.Chart1Button.Name = "Chart1Button";
            this.Chart1Button.Size = new System.Drawing.Size(75, 23);
            this.Chart1Button.TabIndex = 0;
            this.Chart1Button.Text = "Chart 1";
            // 
            // Chart2Button
            // 
            this.Chart2Button.Location = new System.Drawing.Point(12, 41);
            this.Chart2Button.Name = "Chart2Button";
            this.Chart2Button.Size = new System.Drawing.Size(75, 23);
            this.Chart2Button.TabIndex = 1;
            this.Chart2Button.Text = "Chart 2";
            // 
            // Chart3Button
            // 
            this.Chart3Button.Location = new System.Drawing.Point(12, 70);
            this.Chart3Button.Name = "Chart3Button";
            this.Chart3Button.Size = new System.Drawing.Size(75, 23);
            this.Chart3Button.TabIndex = 2;
            this.Chart3Button.Text = "Chart 3";
            // 
            // Chart4Button
            // 
            this.Chart4Button.Location = new System.Drawing.Point(12, 99);
            this.Chart4Button.Name = "Chart4Button";
            this.Chart4Button.Size = new System.Drawing.Size(75, 23);
            this.Chart4Button.TabIndex = 3;
            this.Chart4Button.Text = "Chart 4";
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 450);
            this.Controls.Add(this.Chart1Button);
            this.Controls.Add(this.Chart2Button);
            this.Controls.Add(this.Chart3Button);
            this.Controls.Add(this.Chart4Button);
            this.Location = new System.Drawing.Point(100, 200);
            this.MaximizeBox = false;
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Chart1Button;
        private System.Windows.Forms.Button Chart2Button;
        private System.Windows.Forms.Button Chart3Button;
        private System.Windows.Forms.Button Chart4Button;
    }

    //Form for chart 1
    partial class Chart1
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

            this.HomeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();


            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();

            //
            // chart
            //
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(50, 50);
            this.chart.Size = new System.Drawing.Size(500, 300);
            this.chart.Name = "chart1";
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            this.chart.Titles.Add("Computer Science Doctorates Awarded in the US");
            chartArea1.AxisX.Title = "Years";
            chartArea1.AxisY.Title = "Computer Science Doctorates";

            // 
            // HomeButton
            // 
            this.HomeButton.Location = new System.Drawing.Point(12, 12);
            this.HomeButton.Name = "Home1Button";
            this.HomeButton.Size = new System.Drawing.Size(75, 23);
            this.HomeButton.TabIndex = 0;
            this.HomeButton.Text = "Home";

            // 
            // Chart1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 439);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.chart);
            this.Name = "Chart1";
            this.Text = "Chart 1";
            this.Load += new System.EventHandler(this.Chart1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button HomeButton;
        System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }

    //Form for chart 2
    partial class Chart2
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
            this.SuspendLayout();
            // 
            // Chart2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 450);
            this.CenterToScreen();
            this.Name = "Chart2";
            this.Text = "Chart 2";
            this.ResumeLayout(false);
            this.MaximizeBox = false;
            this.HomeButton = new System.Windows.Forms.Button();
            this.Controls.Add(this.HomeButton);

            // 
            // HomeButton
            // 
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Text = "Home";
        }

        #endregion

        private System.Windows.Forms.Button HomeButton;
    }

    //Form for chart 3
    partial class Chart3
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
            this.SuspendLayout();
            // 
            // Chart3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 450);
            this.CenterToScreen();
            this.Name = "Chart3";
            this.Text = "Chart 3";
            this.ResumeLayout(false);
            this.MaximizeBox = false;
            this.HomeButton = new System.Windows.Forms.Button();
            this.Controls.Add(this.HomeButton);

            // 
            // HomeButton
            // 
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Text = "Home";
        }

        #endregion

        private System.Windows.Forms.Button HomeButton;
    }

    //Form for chart 4
    partial class Chart4
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
            this.SuspendLayout();
            // 
            // Chart4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 450);
            this.CenterToScreen();
            this.Name = "Chart4";
            this.Text = "Chart 4";
            this.ResumeLayout(false);
            this.MaximizeBox = false;
            this.HomeButton = new System.Windows.Forms.Button();
            this.Controls.Add(this.HomeButton);

            // 
            // HomeButton
            // 
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Text = "Home";
        }

        #endregion

        private System.Windows.Forms.Button HomeButton;
    }
}