/********************************************************
 *  PROGRAM : Assignment6                               *
 *                                                      *
 *  PROGRAMMERS : Josue Ballona and Dominykas Karalius  *
 *  ZID : Z1832823 and Z1809478                         *
 *                                                      *
 *  DATE : 11/25/2019 Monday, November 25th 2019        *
 *                                                      *
 *                                                      *
 *  A program that allows the user to choose between 4  *
 *  charts with different data for each chart. The user *
 *  may return to the home screen at any time from any  *
 *  given chart, by simply pressing "Home" or exitting  *
 *  out the chart window.                               *
 *******************************************************/
using System;
using System.IO;
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

            //Event handlers for clicking the chart buttons
            this.Chart1Button.Click += Chart1Button_Click;
            this.Chart2Button.Click += Chart2Button_Click;
            this.Chart3Button.Click += Chart3Button_Click;
            this.Chart4Button.Click += Chart4Button_Click;

            //Centers the chart buttons on the home screen
            Chart1Button.Left = ((Chart1Button.Parent.Width - Chart1Button.Width) / 2) - 10;
            Chart1Button.Top = ((Chart1Button.Parent.Height - Chart1Button.Height) / 2) - 60;

            Chart2Button.Left = ((Chart2Button.Parent.Width - Chart2Button.Width) / 2) - 10;
            Chart2Button.Top = ((Chart2Button.Parent.Height - Chart2Button.Height) / 2) - 35;

            Chart3Button.Left = ((Chart3Button.Parent.Width - Chart3Button.Width) / 2) - 10;
            Chart3Button.Top = ((Chart3Button.Parent.Height - Chart3Button.Height) / 2) - 10;

            Chart4Button.Left = ((Chart4Button.Parent.Width - Chart4Button.Width) / 2) - 10;
            Chart4Button.Top = ((Chart4Button.Parent.Height - Chart4Button.Height) / 2) + 15;
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

        //Method for loading the 1st chart
        private void Chart1_Load(object sender, EventArgs e)
        {
            chart.Series.Clear();

            String slacker; // buffer
            String[] tokens; // used to store tokens

            using (StreamReader inFile = new StreamReader("..\\..\\chart1.txt"))
            {
                slacker = inFile.ReadLine();

                while (slacker != null)
                {
                    tokens = slacker.Split(' ');
                    var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Series1",
                        Color = System.Drawing.Color.Green,
                        IsVisibleInLegend = false,
                        IsXValueIndexed = false,
                        ChartType = SeriesChartType.Line
                    };

                    int pointcount = Convert.ToInt32(tokens[0].Trim());
                    for (int i = 1; i <= pointcount * 2; i++)
                    {
                        series1.Points.AddXY(Convert.ToDouble(tokens[i]), Convert.ToDouble(tokens[++i]));
                    }
                    chart.Invalidate();
                    slacker = inFile.ReadLine();
                    this.chart.Series.Add(series1);
                }
            }
        }

        //If user presses the "X" in chart window, just go back to home screen
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

        //Method for loading the 2nd chart
        private void Chart2_Load(object sender, EventArgs e)
        {
            chart.Series.Clear();

            String slacker; // buffer
            String[] tokens; // used to store tokens

            using (StreamReader inFile = new StreamReader("..\\..\\chart2.txt"))
            {
                slacker = inFile.ReadLine();

                System.Drawing.Color[] pieColors = { System.Drawing.Color.Green, System.Drawing.Color.RoyalBlue,
                System.Drawing.Color.Red, System.Drawing.Color.Silver }; 

                while (slacker != null)
                {
                    tokens = slacker.Split('\t');
                    var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Series2",
                        Color = System.Drawing.Color.Yellow,
                        IsVisibleInLegend = true,
                        IsXValueIndexed = false,
                        ChartType = SeriesChartType.Pie,

                    };


                    int pointcount = Convert.ToInt32(tokens[0].Trim());
                    int colorcount = 0;
                    for (int i = 1; i <= pointcount * 2; i++)
                    {
                        series1.Points.AddXY(Convert.ToString(tokens[i]), Convert.ToDouble(tokens[++i]));
                    }

                    foreach (DataPoint p in series1.Points)
                    {
                        p.Label = "#PERCENT";
                        p.LegendText = "#AXISLABEL";
                        p.Color = pieColors[colorcount];
                        colorcount++;
                    }
                    chart.Invalidate();
                    slacker = inFile.ReadLine();
                    this.chart.Series.Add(series1);
                }
            }
        }

        //If user presses the "X" in chart window, just go back to home screen
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

        //Method for loading the 3rd chart
        private void Chart3_Load(object sender, EventArgs e)
        {
            chart.Series.Clear();

            String slacker; // buffer
            String[] tokens; // used to store tokens
            int seriescount = 1;

            using (StreamReader inFile = new StreamReader("..\\..\\chart3.txt"))
            {
                slacker = inFile.ReadLine();

                while (slacker != null)
                {
                    tokens = slacker.Split('\t');
                    var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = tokens[0].ToString(),
                        Color = System.Drawing.Color.Blue,
                        IsVisibleInLegend = true,
                        IsXValueIndexed = false,
                        ChartType = SeriesChartType.Column,

                    };

                    if (seriescount == 1)
                    {
                        series1.Color = System.Drawing.Color.Blue;
                    }
                    else if (seriescount == 2)
                    {
                        series1.Color = System.Drawing.Color.Red;
                    }
                    else if (seriescount == 3)
                    {
                        series1.Color = System.Drawing.Color.Yellow;
                    }
                    else if (seriescount == 4)
                    {
                        series1.Color = System.Drawing.Color.Green;
                    }
                    int pointcount = Convert.ToInt32(tokens[1].Trim());
                    for (int i = 2; i <= pointcount * 2; i++)
                    {
                        series1.Points.AddXY(Convert.ToString(tokens[i]), Convert.ToDouble(tokens[++i]));
                    }

                    chart.Invalidate();
                    slacker = inFile.ReadLine();
                    this.chart.Series.Add(series1);
                    seriescount++;
                }
            }
        }

        //If user presses the "X" in chart window, just go back to home screen
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

        //Method for loading the 4th chart
        private void Chart4_Load(object sender, EventArgs e)
        {
            chart.Series.Clear();

            String slacker; // buffer
            String[] tokens; // used to store tokens

            using (StreamReader inFile = new StreamReader("..\\..\\chart4.txt"))
            {
                slacker = inFile.ReadLine();

                while (slacker != null)
                {
                    tokens = slacker.Split('\t');
                    var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Series2",
                        Color = System.Drawing.Color.Red,
                        IsVisibleInLegend = false,
                        IsXValueIndexed = false,
                        ChartType = SeriesChartType.Point,


                    };

                    int pointcount = Convert.ToInt32(tokens[0].Trim());
                    for (int i = 1; i <= pointcount * 2; i++)
                    {
                        series1.Points.AddXY(Convert.ToString(tokens[i]), Convert.ToDouble(tokens[++i]));
                    }

                    chart.Invalidate();
                    slacker = inFile.ReadLine();
                    this.chart.Series.Add(series1);
                }
            }
        }

        //If user presses the "X" in chart window, just go back to home screen
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