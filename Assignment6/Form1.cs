using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Chart2_Load(object sender, EventArgs e)
        {
            chart.Series.Clear();

            String slacker; // buffer
            String[] tokens; // used to store tokens

            using (StreamReader inFile = new StreamReader("..\\..\\chart2.txt"))
            {
                slacker = inFile.ReadLine();

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
                    for (int i = 1; i <= pointcount * 2; i++)
                    {
                        series1.Points.AddXY(Convert.ToString(tokens[i]), Convert.ToDouble(tokens[++i]));
                    }

                    foreach (DataPoint p in series1.Points)
                    {
                        p.Label = "#VALX\n#VALY\n#PERCENT";
                    }
                    chart.Invalidate();
                    slacker = inFile.ReadLine();
                    this.chart.Series.Add(series1);
                }
            }
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