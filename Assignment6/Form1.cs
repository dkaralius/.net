﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Assignment6
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
            this.FormClosed +=
               new System.Windows.Forms.FormClosedEventHandler(this.FormHome_FormClosed);
            this.Chart1Button.Click += Chart1Button_Click;
            this.Chart2Button.Click += Chart2Button_Click;
            this.Chart3Button.Click += Chart3Button_Click;
            this.Chart4Button.Click += Chart4Button_Click;

        }

        private void FormHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Chart1Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Chart1()).Show();
        }

        private void Chart2Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Chart2()).Show();
        }

        private void Chart3Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Chart3()).Show();
        }

        private void Chart4Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Chart4()).Show();
        }
    }

    //Form for chart 1
    public partial class Chart1 : Form
    {
        public Chart1()
        {
            InitializeComponent();
            this.FormClosed +=
               new System.Windows.Forms.FormClosedEventHandler(this.Chart1_FormClosed);
            this.HomeButton.Click += HomeButton_Click;
        }
        private double f(int i)
        {
            var f1 = 59894 - (8128 * i) + (262 * i * i) - (1.6 * i * i * i);
            return f1;
        }

        private void Chart1_Load(object sender, EventArgs e)
        {
            chart.Series.Clear();
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Series1",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };

            this.chart.Series.Add(series1);

            for (int i = 0; i < 100; i++)
            {
                series1.Points.AddXY(i, f(i));
            }
            chart.Invalidate();
        }

        private void Chart1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            (new FormHome()).Show();
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new FormHome()).Show();
        }
    }

    //Form for chart 2
    public partial class Chart2 : Form
    {
        public Chart2()
        {
            InitializeComponent();
            this.FormClosed +=
               new System.Windows.Forms.FormClosedEventHandler(this.Chart2_FormClosed);
            this.HomeButton.Click += HomeButton_Click;
        }

        private void Chart2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            (new FormHome()).Show();
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new FormHome()).Show();
        }
    }

    //Form for chart 3
    public partial class Chart3 : Form
    {
        public Chart3()
        {
            InitializeComponent();
            this.FormClosed +=
               new System.Windows.Forms.FormClosedEventHandler(this.Chart3_FormClosed);
            this.HomeButton.Click += HomeButton_Click;
        }

        private void Chart3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            (new FormHome()).Show();
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new FormHome()).Show();
        }
    }

    //Form for chart 4
    public partial class Chart4 : Form
    {
        public Chart4()
        {
            InitializeComponent();
            this.FormClosed +=
               new System.Windows.Forms.FormClosedEventHandler(this.Chart4_FormClosed);
            this.HomeButton.Click += HomeButton_Click;
        }

        private void Chart4_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            (new FormHome()).Show();
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new FormHome()).Show();
        }
    }
}
