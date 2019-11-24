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
            this.Chart1Button.Location = new System.Drawing.Point(0, 0);
            this.Chart1Button.Name = "Chart1Button";
            this.Chart1Button.Size = new System.Drawing.Size(75, 23);
            this.Chart1Button.TabIndex = 0;
            this.Chart1Button.Text = "Line";
            // 
            // Chart2Button
            // 
            this.Chart2Button.Location = new System.Drawing.Point(0, 0);
            this.Chart2Button.Name = "Chart2Button";
            this.Chart2Button.Size = new System.Drawing.Size(75, 23);
            this.Chart2Button.TabIndex = 1;
            this.Chart2Button.Text = "Pie";
            // 
            // Chart3Button
            // 
            this.Chart3Button.Location = new System.Drawing.Point(0, 0);
            this.Chart3Button.Name = "Chart3Button";
            this.Chart3Button.Size = new System.Drawing.Size(75, 23);
            this.Chart3Button.TabIndex = 2;
            this.Chart3Button.Text = "Column";
            // 
            // Chart4Button
            // 
            this.Chart4Button.Location = new System.Drawing.Point(0, 0);
            this.Chart4Button.Name = "Chart4Button";
            this.Chart4Button.Size = new System.Drawing.Size(75, 23);
            this.Chart4Button.TabIndex = 3;
            this.Chart4Button.Text = "Point";
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 133);
            this.Controls.Add(this.Chart1Button);
            this.Controls.Add(this.Chart2Button);
            this.Controls.Add(this.Chart3Button);
            this.Controls.Add(this.Chart4Button);
            this.Location = new System.Drawing.Point(100, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chart Home";
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
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.chart);
            this.Name = "Chart1";
            this.Text = "Line Chart";
            this.Load += new System.EventHandler(this.Chart1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
            this.HomeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();


            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();

            //
            // chart
            //
            chartArea2.Name = "ChartArea2";
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend2";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(50, 50);
            this.chart.Size = new System.Drawing.Size(500, 300);
            this.chart.Name = "chart2";
            this.chart.TabIndex = 0;
            this.chart.Text = "Pie Chart";
            this.chart.Titles.Add("Games I Own Per System.");
            // 
            // HomeButton
            // 
            this.HomeButton.Location = new System.Drawing.Point(12, 12);
            this.HomeButton.Name = "Home1Button";
            this.HomeButton.Size = new System.Drawing.Size(75, 23);
            this.HomeButton.TabIndex = 0;
            this.HomeButton.Text = "Home";

            // 
            // Chart2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.chart);
            this.Name = "Chart2";
            this.Text = "Pie Chart";
            this.Load += new System.EventHandler(this.Chart2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button HomeButton;
        System.Windows.Forms.DataVisualization.Charting.Chart chart;
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
            this.HomeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();


            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();

            //
            // chart
            //
            chartArea3.Name = "ChartArea3";
            this.chart.ChartAreas.Add(chartArea3);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend3";
            this.chart.Legends.Add(legend3);
            this.chart.Location = new System.Drawing.Point(50, 50);
            this.chart.Size = new System.Drawing.Size(500, 300);
            this.chart.Name = "chart3";
            this.chart.TabIndex = 0;
            this.chart.Text = "chart3";
            this.chart.Titles.Add("Average Daily Hours of Sleep Per Year.");
            chartArea3.AxisX.Title = "Year";
            chartArea3.AxisY.Title = "Average Hours Slept Per Day";
            // 
            // HomeButton
            // 
            this.HomeButton.Location = new System.Drawing.Point(12, 12);
            this.HomeButton.Name = "Home1Button";
            this.HomeButton.Size = new System.Drawing.Size(75, 23);
            this.HomeButton.TabIndex = 0;
            this.HomeButton.Text = "Home";

            // 
            // Chart3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.chart);
            this.Name = "Column";
            this.Text = "Column Chart";
            this.Load += new System.EventHandler(this.Chart3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button HomeButton;
        System.Windows.Forms.DataVisualization.Charting.Chart chart;
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

            this.HomeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();


            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();

            //
            // chart
            //
            chartArea4.Name = "ChartArea4";
            this.chart.ChartAreas.Add(chartArea4);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend4";
            this.chart.Legends.Add(legend4);
            this.chart.Location = new System.Drawing.Point(50, 50);
            this.chart.Size = new System.Drawing.Size(500, 300);
            this.chart.Name = "chart4";
            this.chart.TabIndex = 0;
            this.chart.Text = "chart4";
            this.chart.Titles.Add("Number of Students Expected To Get Certain Grades In the Final");
            chartArea4.AxisX.Title = "Grade Percentage";
            chartArea4.AxisY.Title = "Number of Students";
         
            // 
            // HomeButton
            // 
            this.HomeButton.Location = new System.Drawing.Point(12, 12);
            this.HomeButton.Name = "Home1Button";
            this.HomeButton.Size = new System.Drawing.Size(75, 23);
            this.HomeButton.TabIndex = 0;
            this.HomeButton.Text = "Home";

            // 
            // Chart4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.chart);
            this.Name = "Chart4";
            this.Text = "Point Chart";
            this.Load += new System.EventHandler(this.Chart4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button HomeButton;
        System.Windows.Forms.DataVisualization.Charting.Chart chart;

    }
}