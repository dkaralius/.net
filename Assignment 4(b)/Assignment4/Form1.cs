using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace Assignment4
{
    public partial class Form1 : Form
    {
        //Globals
        string redditName;
        string userName;


        public class User : IComparable
        {
            //Private variables
            private readonly uint id;
            private readonly string userType;
            private readonly string name;
            private readonly string passwordHash;
            private int postScore;
            private int commentScore;

            //Public properties
            public uint Id { get => id; }
            public string Usertype { get => userType; }
            public string Name { get => name; }
            public string PasswordHash { get => passwordHash; }
            public int PostScore { get => postScore; set => postScore = value; }
            public int CommentScore { get => commentScore; set => commentScore = value; }

            //Constructor to take number of args as in the text file.
            public User(string[] args)
            {
                List<string> moderatingSubs = new List<string>();

                //If user is not a mod or admin
                if (args.Length == 6)
                {
                    id = Convert.ToUInt32(args[0]);

                    if (args[1] == "0")
                    {
                        userType = "";
                    }
                    if (args[1] == "1")
                    {
                        userType = "(M)";
                    }
                    if (args[1] == "2")
                    {
                        userType = "(A)";
                    }

                    name = args[2];
                    passwordHash = args[3];
                    postScore = Convert.ToInt32(args[4]);
                    commentScore = Convert.ToInt32(args[5]);
                }
                //If the user is a mod or admin and mods 1 subreddit
                if (args.Length == 7)
                {
                    id = Convert.ToUInt32(args[0]);

                    if (args[1] == "0")
                    {
                        userType = "";
                    }
                    if (args[1] == "1")
                    {
                        userType = "(M)";
                    }
                    if (args[1] == "2")
                    {
                        userType = "(A)";
                    }

                    name = args[2];
                    passwordHash = args[3];
                    postScore = Convert.ToInt32(args[4]);
                    commentScore = Convert.ToInt32(args[5]);
                    moderatingSubs.Add(args[6]);
                }
                //If the user is a mod or admin and mods 2 subreddits
                if (args.Length == 8)
                {
                    id = Convert.ToUInt32(args[0]);

                    if (args[1] == "0")
                    {
                        userType = "";
                    }
                    if (args[1] == "1")
                    {
                        userType = "(M)";
                    }
                    if (args[1] == "2")
                    {
                        userType = "(A)";
                    }

                    name = args[2];
                    passwordHash = args[3];
                    postScore = Convert.ToInt32(args[4]);
                    commentScore = Convert.ToInt32(args[5]);
                    moderatingSubs.Add(args[6]);
                    moderatingSubs.Add(args[7]);
                }
            }
            //Overriden CompareTo() to sort by name
            public int CompareTo(Object alpha)
            {
                // check that alpha isnt empty
                if (alpha == null)
                {
                    throw new ArgumentNullException("Empty user.");
                }
                User rightOp = alpha as User;

                if (rightOp != null) // typecast worked
                    return Name.CompareTo(rightOp.Name);
                else
                    throw new ArgumentException("Argument was not a user.");
            }
        }
        public class Subreddit : IComparable
        {
            //Private variables
            private readonly uint id;
            private string name;
            private uint members;
            private uint active;

            //Public properties
            public uint Id => id;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public uint Members
            {
                get { return members; }
                set { members = value; }
            }
            public uint Active
            {
                get { return active; }
                set { active = value; }
            }
            //Constructor to take number of args as in the text file.
            public Subreddit(string[] args)
            {
                if (args.Length == 4)
                {
                    id = Convert.ToUInt32(args[0]);
                    name = args[1];
                    members = Convert.ToUInt32(args[2]);
                    active = Convert.ToUInt32(args[3]);
                }
            }
            //Overriden CompareTo() to sort by name
            public int CompareTo(Object alpha)
            {
                if (alpha == null) throw new ArgumentNullException("argument bad");

                Subreddit rightOp = alpha as Subreddit;

                if (rightOp != null)
                    return name.CompareTo(rightOp.name);
                else
                    throw new ArgumentException("argument was not a name.");
            }
        }
        public class Post
        {
            //Private variables
            readonly uint locked;
            readonly uint id;
            string title;
            readonly uint authorID;
            string postContent;
            readonly uint subHome;
            int upVotes;
            int downVotes;
            uint weight;
            readonly DateTime timeStamp;
            readonly int[] awards;

            //Public properties
            public uint Locked { get => locked; }
            public uint Id { get => id; }
            public string Title
            {
                get { return title; }
                set { title = value; }
            }
            public uint AuthorID { get => authorID; }
            public string PostContent
            {
                get { return postContent; }
                set { postContent = value; }
            }
            public uint SubHome { get => subHome; }
            public int UpVotes
            {
                get { return upVotes; }
                set { upVotes = value; }
            }
            public int DownVotes
            {
                get { return downVotes; }
                set { downVotes = value; }
            }
            public uint Weight
            {
                get { return weight; }
                set { weight = value; }
            }
            public int Score { get => upVotes - downVotes; }
            public int PostRating
            {
                get
                {
                    if (weight == 0)
                    {
                        return Score;
                    }
                    if (weight == 1)
                    {
                        return Score * (2 / 3);
                    }
                    if (weight == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid argument");
                    }
                }
            }
            public DateTime TimeStamp { get => timeStamp; }

            public int[] Awards { get => awards; }

            public Post()
            {
                awards = new int[3];
                locked = 0;
                id = 0;
                title = "";
                authorID = 0;
                postContent = "";
                subHome = 0;
                upVotes = 0;
                downVotes = 0;
                weight = 0;
                timeStamp = new DateTime();
            }
            //Constructor to take number of args as in the text file.
            public Post(string[] args)
            {
                awards = new int[3];
                if (args.Length == 18)
                {
                    locked = Convert.ToUInt32(args[0]);
                    id = Convert.ToUInt32(args[1]);
                    authorID = Convert.ToUInt32(args[2]);
                    title = Convert.ToString(args[3]);
                    postContent = Convert.ToString(args[4]);
                    subHome = Convert.ToUInt32(args[5]);
                    upVotes = Convert.ToInt32(args[6]);
                    downVotes = Convert.ToInt32(args[7]);
                    weight = Convert.ToUInt32(args[8]);

                    int year = Convert.ToInt32(args[9]);
                    int month = Convert.ToInt32(args[10]);
                    int day = Convert.ToInt32(args[11]);
                    int hour = Convert.ToInt32(args[12]);
                    int minute = Convert.ToInt32(args[13]);
                    int second = Convert.ToInt32(args[14]);

                    awards[0] = Convert.ToInt32(args[15]); //Silver
                    awards[1] = Convert.ToInt32(args[16]); //Gold
                    awards[2] = Convert.ToInt32(args[17]); //Platinum

                    timeStamp = new DateTime(year, month, day, hour, minute, second);
                }
            }
        }
        public class Comment : IComparable
        {
            //Private variables
            readonly uint id;
            readonly uint authorID;
            string content;
            readonly uint parentID;
            int upVotes;
            int downVotes;
            readonly DateTime timeStamp;
            readonly int[] awards;

            //Public properties
            public int Score { get => upVotes - downVotes; }
            public uint ID { get => id; }
            public uint AuthorID { get => authorID; }
            public uint ParentID { get => parentID; }
            public int UpVotes
            {
                get { return upVotes; }
                set { upVotes = value; }
            }
            public int DownVotes
            {
                get { return downVotes; }
                set { downVotes = value; }
            }
            public string Content
            {
                get { return content; }
                set { content = value; }
            }
            public DateTime TimeStamp { get => timeStamp; }
            public int[] Awards { get => awards; }

            //Alternate Constructor if all arguements are provided
            public Comment(uint id, uint authorID, string content, uint parentID, int upVotes, int downVotes, int year, int month, int day, int hour, int minute, int second, int[] awards)
            {
                this.id = id;
                this.authorID = authorID;
                this.content = content;
                this.parentID = parentID;
                this.upVotes = upVotes;
                this.downVotes = downVotes;
                this.timeStamp = new DateTime(year, month, day, hour, minute, second);
                this.awards = new int[3];
                this.awards[0] = awards[0];
                this.awards[1] = awards[1];
                this.awards[2] = awards[2];
            }
            //Alternate Constructor where only author id, content, and parent id are provided
            public Comment(uint authorID, string content, uint parentID)
            {
                id = 6068; // temporary
                this.authorID = authorID;
                this.content = content;
                this.parentID = parentID;
                upVotes = 1;
                downVotes = 0;
                timeStamp = DateTime.Now;
                awards = new int[3];
            }
            //Constructor to take number of args as in the text file.
            public Comment(string[] args)
            {
                awards = new int[3];
                if (args.Length == 15)
                {
                    id = Convert.ToUInt32(args[0]);
                    authorID = Convert.ToUInt32(args[1]);
                    content = Convert.ToString(args[2]);
                    parentID = Convert.ToUInt32(args[3]);
                    upVotes = Convert.ToInt32(args[4]);
                    downVotes = Convert.ToInt32(args[5]);

                    int year = Convert.ToInt32(args[6]);
                    int month = Convert.ToInt32(args[7]);
                    int day = Convert.ToInt32(args[8]);
                    int hour = Convert.ToInt32(args[9]);
                    int minute = Convert.ToInt32(args[10]);
                    int second = Convert.ToInt32(args[11]);

                    awards[0] = Convert.ToInt32(args[12]); //Silver
                    awards[1] = Convert.ToInt32(args[13]); //Gold
                    awards[2] = Convert.ToInt32(args[14]); //Platinum

                    timeStamp = new DateTime(year, month, day, hour, minute, second);
                }
            }
            //Overriden CompareTo() to sort by score
            public int CompareTo(Object alpha)
            {
                if (alpha == null) throw new ArgumentNullException("argument bad");

                // else
                Comment rightOp = alpha as Comment;

                if (rightOp != null)
                    return Score.CompareTo(rightOp.Score);
                else
                    throw new ArgumentException("argument was not a student");
            }
        }
        public class DisplayPost
        {
            public System.Windows.Forms.Panel postPanel;
            public System.Windows.Forms.Label redditLabel;
            public System.Windows.Forms.Label contentLabel;
            public System.Windows.Forms.Label userLabel;
            public System.Windows.Forms.Label timeLabel;
            public System.Windows.Forms.Label titleLabel;

            public ToolStrip scoreStrip;
            public ToolStripButton upArrow;
            public ToolStripLabel scoreLabel;
            public ToolStripButton downArrow;

            string subredditName;

            public System.Windows.Forms.Panel PostPanel
            {
                get { return postPanel; }
                set { postPanel = value; }
            }

            public System.Windows.Forms.Label RedditLabel
            {
                get { return redditLabel; }
                set { redditLabel = value; }
            }
            public System.Windows.Forms.Label ContentLabel
            {
                get { return contentLabel; }
                set { contentLabel = value; }
            }

            public System.Windows.Forms.Label UserLabel
            {
                get { return userLabel; }
                set { userLabel = value; }
            }
            public System.Windows.Forms.Label TimeLabel
            {
                get { return timeLabel; }
                set { timeLabel = value; }
            }

            public System.Windows.Forms.Label TitleLabel
            {
                get { return titleLabel; }
                set { titleLabel = value; }
            }
            public string SubredditName
            {
                get { return SubredditName; }
                set { SubredditName = value; }
            }

            public ToolStrip ScoreStrip
            {
                get { return scoreStrip; }
                set { scoreStrip = value; }
            }

            public ToolStripButton UpArrow
            {
                get { return upArrow; }
                set { upArrow = value; }
            }

            public ToolStripLabel ScoreLabel
            {
                get { return scoreLabel; }
                set { scoreLabel = value; }
            }

            public ToolStripButton DownArrow
            {
                get { return downArrow; }
                set { downArrow = value; }
            }

            public DisplayPost()
            {
                postPanel = new System.Windows.Forms.Panel();

                redditLabel = new System.Windows.Forms.Label();

                contentLabel = new System.Windows.Forms.Label();

                userLabel = new System.Windows.Forms.Label();

                timeLabel = new System.Windows.Forms.Label();

                titleLabel = new System.Windows.Forms.Label();

                scoreStrip = new ToolStrip();

                upArrow = new ToolStripButton();

                scoreLabel = new ToolStripLabel();

                downArrow = new ToolStripButton();

                string subredditName = null;
            }

            public DisplayPost(string reddit, string title, string author, DateTime time, string content, int score, int count)
            {
                postPanel = new System.Windows.Forms.Panel();

                subredditName = reddit;

                scoreStrip = new ToolStrip();
                scoreStrip.Dock = DockStyle.Left;
                scoreStrip.BackColor = Color.FromArgb(22, 22, 22);

                upArrow = new ToolStripButton();
                System.Drawing.Image upArrowPic = System.Drawing.Image.FromFile("upArrow.png");
                upArrow.Text = String.Empty;
                upArrow.Image = upArrowPic;
                upArrow.MouseEnter += new EventHandler(upArrow_MouseEnter);
                upArrow.MouseLeave += new EventHandler(upArrow_MouseLeave);

                scoreLabel = new System.Windows.Forms.ToolStripLabel();
                scoreLabel.ForeColor = Color.White;
                scoreLabel.AutoSize = true;
                scoreLabel.Font = new Font("Verdana", 8);
                if (score < 1000 && score > -1000)
                {
                    scoreLabel.Text = score.ToString();
                }
                else
                {
                    scoreLabel.Text = String.Format("{0: 0.#k}", Convert.ToDecimal(score) / 1000);
                }

                downArrow = new ToolStripButton();
                System.Drawing.Image downArrowPic = System.Drawing.Image.FromFile("downArrow.png");
                downArrow.Text = String.Empty;
                downArrow.Image = downArrowPic;
                downArrow.MouseEnter += new EventHandler(downArrow_MouseEnter);
                downArrow.MouseLeave += new EventHandler(downArrow_MouseLeave);

                redditLabel = new System.Windows.Forms.Label();
                redditLabel.ForeColor = Color.White;
                redditLabel.Text = "r/" + reddit;
                redditLabel.AutoSize = true;
                redditLabel.Font = new Font("Verdana", 12);
                redditLabel.Location = new Point(scoreStrip.Bottom + 20, 4);
                int x = RedditLabel.PreferredWidth;
                int y = redditLabel.PreferredHeight;

                titleLabel = new System.Windows.Forms.Label();
                titleLabel.ForeColor = Color.White;
                titleLabel.AutoSize = true;
                titleLabel.MaximumSize = new Size(800, 0);
                titleLabel.Font = new Font("Verdana", 12);
                titleLabel.Text = title;
                titleLabel.Location = new Point(scoreStrip.Bottom + 40, y + 10);

                contentLabel = new System.Windows.Forms.Label();
                contentLabel.AutoSize = true;
                contentLabel.Text = content;
                contentLabel.ForeColor = Color.Gray;
                contentLabel.MaximumSize = new Size(800, 0);
                contentLabel.Font = new Font("Verdana", 12);

                if (content.Length < 100 && title.Length < 100)
                {
                    contentLabel.Location = new Point(scoreStrip.Bottom + 40, y + 40);
                }
                if (content.Length < 100 && title.Length > 100)
                {
                    contentLabel.Location = new Point(scoreStrip.Bottom + 40, y + 50);
                }
                if (content.Length > 200)
                {
                    contentLabel.Location = new Point(scoreStrip.Bottom + 40, y + 30);
                }


                userLabel = new System.Windows.Forms.Label();
                userLabel.ForeColor = Color.Gray;
                userLabel.Text = "| Posted by u/" + author;
                userLabel.AutoSize = true;
                userLabel.Font = new Font("Verdana", 8);
                userLabel.Location = new Point(x + scoreStrip.Bottom + 10, 7);
                int x2 = userLabel.PreferredWidth;

                timeLabel = new System.Windows.Forms.Label();
                timeLabel.ForeColor = Color.Gray;
                timeLabel.AutoSize = true;
                timeLabel.Font = new Font("Verdana", 8);
                timeLabel.Location = new Point(scoreStrip.Bottom + x + x2 + 10, 7);

                DateTime now = DateTime.Now;
                TimeSpan ts = now - time;

                int days = ts.Days;
                int hours = ts.Hours;
                int minutes = ts.Minutes;

                //If was posted within the year, continue
                if (days < 365)
                {
                    //If the year and month are the same, continue
                    if (time.Month == now.Month)
                    {
                        if (time.Day == now.Day)
                        {

                        }
                        //Else, the year and month are the same, but date is different
                        else
                        {
                            //More than 1 day ago
                            if ((now.Day - time.Day) > 1)
                            {
                                timeLabel.Text = (now.Day - time.Day) + " days ago";
                            }
                            //Exactly 1 day ago
                            if ((now.Day - time.Day) == 1)
                            {
                                timeLabel.Text = "a day ago";
                            }
                            //Less than a day ago
                            else
                            {
                                //If there are less than 24 hours but greater than 1 hour between now and post time, print difference
                                if (hours < 24 && hours >= 1)
                                {
                                    timeLabel.Text = hours + " hours ago";
                                }
                                //Else, less than an hour between the two times
                                else
                                {
                                    timeLabel.Text = minutes + " hours ago";
                                }
                            }
                        }
                    }
                    //Else, year is the same, but month is different, print difference
                    else
                    {
                        //More than 1 month ago
                        if ((now.Month - time.Month) > 1)
                        {
                            timeLabel.Text = (now.Month - time.Month) + " months ago";
                        }
                        //1 month ago
                        else
                        {
                            timeLabel.Text = (now.Month - time.Month) + " month ago";
                        }
                    }
                }
                //Else post is greater than or equal to a year old, continue
                else
                {
                    //If difference between years is greater than 1
                    if ((now.Year - time.Year) > 1)
                    {
                        timeLabel.Text = (now.Year - time.Year) + "years ago";
                    }
                    //Else, difference is a year ago
                    else
                    {
                        timeLabel.Text = "a year ago";
                    }
                }
                postPanel.Controls.Add(redditLabel);
                postPanel.Controls.Add(contentLabel);
                postPanel.Controls.Add(userLabel);
                postPanel.Controls.Add(timeLabel);
                postPanel.Controls.Add(titleLabel);
                postPanel.Controls.Add(scoreStrip);
                
                scoreStrip.Items.Add(upArrow);
                scoreStrip.Items.Add(scoreLabel);
                scoreStrip.Items.Add(downArrow);
                
                postPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                postPanel.AutoSize = true;
                postPanel.Location = new Point(10, postPanel.Height * count);
                postPanel.Width = 850;
            }


            private void upArrow_MouseEnter(Object sender, EventArgs e)
            {
                System.Drawing.Image upArrowPic = System.Drawing.Image.FromFile("upArrowRed.png");
                upArrow.Image = upArrowPic;
            }

            private void upArrow_MouseLeave(Object sender, EventArgs e)
            {

                System.Drawing.Image upArrowPic = System.Drawing.Image.FromFile("upArrow.png");
                upArrow.Image = upArrowPic;
            }

            private void downArrow_MouseEnter(Object sender, EventArgs e)
            {
                System.Drawing.Image downArrowPic = System.Drawing.Image.FromFile("downArrowBlue.png");
                downArrow.Image = downArrowPic;
            }

            private void downArrow_MouseLeave(Object sender, EventArgs e)
            {
                System.Drawing.Image downArrowPic = System.Drawing.Image.FromFile("downArrow.png");
                downArrow.Image = downArrowPic;
            }
        }
        //Simple method that checks to see if user input matches the password for the username they want to log in as
        private bool passwordCheck(string toCheck, string password)
        {
            if (toCheck == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Method that reads the text files for each object and creates SortedSet<> for each category
        public static void ReadInputFiles(SortedSet<User> users, SortedSet<Subreddit> subreddits, List<Post> posts, List<Comment> comments)
        {
            String slacker; //Buffer
            String[] tokens; //Used to store tokens of buffer

            using (StreamReader inFile = new StreamReader("..\\..\\users.txt"))
            {
                slacker = inFile.ReadLine();

                while (slacker != null)
                {
                    tokens = slacker.Split('\t');
                    users.Add(new User(tokens));

                    slacker = inFile.ReadLine();
                }
            }
            using (StreamReader inFile = new StreamReader("..\\..\\subreddits.txt"))
            {
                slacker = inFile.ReadLine();

                while (slacker != null)
                {
                    tokens = slacker.Split('\t');
                    subreddits.Add(new Subreddit(tokens));

                    slacker = inFile.ReadLine();
                }
            }
            using (StreamReader inFile = new StreamReader("..\\..\\posts.txt"))
            {
                slacker = inFile.ReadLine();

                while (slacker != null)
                {
                    tokens = slacker.Split('\t');
                    posts.Add(new Post(tokens));

                    slacker = inFile.ReadLine();
                }
            }
            using (StreamReader inFile = new StreamReader("..\\..\\comments.txt"))
            {
                slacker = inFile.ReadLine();

                while (slacker != null)
                {
                    tokens = slacker.Split('\t');
                    comments.Add(new Comment(tokens));

                    slacker = inFile.ReadLine();
                }
            }


        }
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();

            //Disbales minimize and maximize buttons
            MinimizeBox = false;
            MaximizeBox = false;

            //Prevents resizing of window
            FormBorderStyle = FormBorderStyle.FixedSingle;

            panel2.BackColor = Color.FromArgb(219, 223, 232);

            searchTextBox.Enter += new EventHandler(searchTextBox_Enter);
            searchTextBox.Leave += new EventHandler(searchTextBox_Leave);
            searchTextBox_SetText();

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            List<Post> posts = new List<Post>();
            List<Comment> comments = new List<Comment>();
            List<DisplayPost> displays = new List<DisplayPost>();

            ReadInputFiles(users, subreddits, posts, comments);

            int count = 0;
            var pLinq = from P in posts
                        orderby P.Score descending
                        select P;

            foreach (Post p in pLinq)
            {
                var srLinq = from S in subreddits
                             where S.Id == p.SubHome
                             select S;

                var uLinq = from U in users
                            where U.Id == p.AuthorID
                            select U;

                foreach (Subreddit s in srLinq)
                {
                    foreach (User u in uLinq)
                    {
                        DisplayPost temp = new DisplayPost(s.Name, p.Title, u.Name, p.TimeStamp, p.PostContent, p.Score, count);
                        displays.Add(temp);
                        count++;
                    }
                }
            }

            foreach (DisplayPost d in displays)
            {
                d.PostPanel.Click += new EventHandler(panel1_Click);
                d.postPanel.AutoSize = true;
                mainPanel.Controls.Add(d.postPanel);
                d.PostPanel.Tag = d.titleLabel.Text;
            }

            foreach (Subreddit s in subreddits)
            {
                comboBox.Items.Add(s.Name);
            }

            //Changes "all" to "Home"
            comboBox.Items[0] = "Home";
            comboBox.SelectedIndex = 0;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //Event handler for when user clicks on a display post object
        private void panel1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Panel p = sender as System.Windows.Forms.Panel;
            string title = (p.Tag).ToString();
            title = title.Substring(title.IndexOf(':') + 1);

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            List<Post> posts = new List<Post>();
            List<Comment> comments = new List<Comment>();
            List<DisplayPost> displays = new List<DisplayPost>();

            ReadInputFiles(users, subreddits, posts, comments);

            Form newForm = new Form();
            newForm.Size = new Size(800, 500);
            newForm.BackColor = Color.Black;
            newForm.StartPosition = FormStartPosition.CenterParent;
            newForm.MaximizeBox = false;
            newForm.MinimizeBox = false;
            newForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            newForm.Text = "Information about post";

            System.Windows.Forms.Label redditLabel = new System.Windows.Forms.Label();
            System.Windows.Forms.Label titleLabel = new System.Windows.Forms.Label();
            System.Windows.Forms.Label contentLabel = new System.Windows.Forms.Label();
            System.Windows.Forms.Label timeLabel = new System.Windows.Forms.Label();
            System.Windows.Forms.TextBox commentBox = new System.Windows.Forms.TextBox();

            foreach (Post ps in posts.Where(x => x.Title == title.Trim()))
            {

                foreach (Subreddit s in subreddits.Where(xyz => xyz.Id == ps.SubHome))
                {
                    redditLabel = new System.Windows.Forms.Label();
                    redditLabel.ForeColor = Color.White;
                    redditLabel.Text = "r/" + s.Name;
                    redditLabel.AutoSize = true;
                    redditLabel.Font = new Font("Verdana", 8);
                    redditLabel.Location = new Point(0, 10);
                }
                int x = redditLabel.PreferredWidth;
                int y = redditLabel.PreferredHeight;

                titleLabel.AutoSize = true;
                titleLabel.Text = title;
                titleLabel.ForeColor = Color.White;
                titleLabel.MaximumSize = new Size(520, 0);
                titleLabel.Font = new Font("Verdana", 14);
                titleLabel.Location = new Point(x - 8, 4);

                int x2 = titleLabel.PreferredWidth;
                int y2 = titleLabel.PreferredHeight;

                contentLabel.AutoSize = true;
                contentLabel.Text = ps.PostContent;
                contentLabel.ForeColor = Color.Gray;
                contentLabel.MaximumSize = new Size(520, 0);
                contentLabel.Font = new Font("Verdana", 10);
                contentLabel.Location = new Point(15, y2 + 7);

                foreach (User u in users.Where(xy => xy.Id == ps.AuthorID))
                {
                    userLabel = new System.Windows.Forms.Label();
                    userLabel.ForeColor = Color.Gray;
                    userLabel.Text = "| Posted by u/" + u.Name;
                    userLabel.AutoSize = true;
                    userLabel.Font = new Font("Verdana", 8);
                    userLabel.Location = new Point(x2 + 40, 9);
                }

                int x3 = userLabel.PreferredWidth;

                timeLabel = new System.Windows.Forms.Label();
                timeLabel.ForeColor = Color.Gray;
                timeLabel.AutoSize = true;
                timeLabel.Font = new Font("Verdana", 8);
                timeLabel.Location = new Point(x2 + x3 + 40, 9);

                DateTime now = DateTime.Now;
                DateTime time = ps.TimeStamp;
                TimeSpan ts = now - time;

                int days = ts.Days;
                int hours = ts.Hours;
                int minutes = ts.Minutes;

                //If was posted within the year, continue
                if (days < 365)
                {
                    //If the year and month are the same, continue
                    if (time.Month == now.Month)
                    {
                        if (time.Day == now.Day)
                        {

                        }
                        //Else, the year and month are the same, but date is different
                        else
                        {
                            //More than 1 day ago
                            if ((now.Day - time.Day) > 1)
                            {
                                timeLabel.Text = (now.Day - time.Day) + " days ago";
                            }
                            //Exactly 1 day ago
                            if ((now.Day - time.Day) == 1)
                            {
                                timeLabel.Text = "a day ago";
                            }
                            //Less than a day ago
                            else
                            {
                                //If there are less than 24 hours but greater than 1 hour between now and post time, print difference
                                if (hours < 24 && hours >= 1)
                                {
                                    timeLabel.Text = hours + " hours ago";
                                }
                                //Else, less than an hour between the two times
                                else
                                {
                                    timeLabel.Text = minutes + " hours ago";
                                }
                            }
                        }
                    }
                    //Else, year is the same, but month is different, print difference
                    else
                    {
                        //More than 1 month ago
                        if ((now.Month - time.Month) > 1)
                        {
                            timeLabel.Text = (now.Month - time.Month) + " months ago";
                        }
                        //1 month ago
                        else
                        {
                            timeLabel.Text = (now.Month - time.Month) + " month ago";
                        }
                    }
                }
                //Else post is greater than or equal to a year old, continue
                else
                {
                    //If difference between years is greater than 1
                    if ((now.Year - time.Year) > 1)
                    {
                        timeLabel.Text = (now.Year - time.Year) + "years ago";
                    }
                    //Else, difference is a year ago
                    else
                    {
                        timeLabel.Text = "a year ago";
                    }
                }
            }
            commentBox = new System.Windows.Forms.TextBox();

            commentBox.Click += new EventHandler(commentBox_Enter);
            commentBox.Leave += new EventHandler(commentBox_Leave);
            commentBox_SetText();

            commentBox.Multiline = true;
            commentBox.Size = new Size(760, 200);
            commentBox.Location = new Point(12, 100);
            commentBox.SelectionStart = 0;

            newForm.Controls.Add(redditLabel);
            newForm.Controls.Add(titleLabel);
            newForm.Controls.Add(contentLabel);
            newForm.Controls.Add(userLabel);
            newForm.Controls.Add(timeLabel);
            newForm.Controls.Add(commentBox);


            newForm.ShowDialog();

            //Function and event handlers for the comment box
            void commentBox_SetText()
            {
                commentBox.Text = "What are your thoughts?";
                commentBox.ForeColor = Color.Gray;
                return;
            }
            void commentBox_Enter(object sender2, EventArgs e2)
            {
                if (commentBox.ForeColor == Color.Black)
                {
                    return;
                }
                commentBox.Text = "";
                commentBox.ForeColor = Color.Black;

                commentBox.KeyDown += commentBox_KeyDown;

                void commentBox_KeyDown(object sender3, KeyEventArgs e3)
                {
                    if (e3.KeyCode == Keys.Enter)
                    {
                        //Just to see if its working
                        commentBox.Text = "you pressed enter";
                    }
                }
            }
            void commentBox_Leave(object sender4, EventArgs e4)
            {
                if (commentBox.Text.Trim() == "")
                {
                    commentBox_SetText();
                }
            }
        }

        //Event handler for when user clicks the log in button
        private void logInButton_Click(object sender, EventArgs e)
        {
            if (logInButton.Text == "Log Out")
            {
                logInButton.Text = "Log In";
                userLabel.Text = "";
                karmaLabel.Text = "";

                return;
            }
            if (logInButton.Text == "Log In")
            {
                Form logForm = new Form();
                logForm.Size = new System.Drawing.Size(250, 225);
                logForm.StartPosition = FormStartPosition.CenterParent;
                logForm.BackColor = Color.FromArgb(219, 223, 232);
                logForm.MaximizeBox = false;
                logForm.MinimizeBox = false;
                logForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                logForm.Text = "Log-In";

                System.Windows.Forms.Label Prompt = new System.Windows.Forms.Label();
                System.Windows.Forms.Label Username = new System.Windows.Forms.Label();
                System.Windows.Forms.Label Password = new System.Windows.Forms.Label();
                System.Windows.Forms.Label error = new System.Windows.Forms.Label();
                System.Windows.Forms.TextBox usernameInput = new System.Windows.Forms.TextBox();
                System.Windows.Forms.TextBox passwordInput = new System.Windows.Forms.TextBox();

                Prompt.Text = "Sign in";
                Prompt.Font = new Font("Verdana", 14);
                Prompt.AutoSize = false;
                Prompt.TextAlign = ContentAlignment.TopCenter;
                Prompt.Dock = DockStyle.Top;

                error.Text = "";
                error.Font = new Font("Verdana", 9);
                error.ForeColor = Color.FromArgb(237, 67, 55);
                error.AutoSize = false;
                error.TextAlign = ContentAlignment.BottomCenter;
                error.Dock = DockStyle.Bottom;

                Username.Text = "Username";
                Username.Font = new Font("Verdana", 12);
                Username.AutoSize = false;
                Username.Location = new Point(10, 50);

                usernameInput.Text = null;
                usernameInput.MaxLength = 40;
                usernameInput.Multiline = false;
                usernameInput.Width = 150;
                usernameInput.Location = new Point(15, 73);
                usernameInput.KeyDown += passwordCheck_KeyDown;

                Password.Text = "Password";
                Password.Font = new Font("Verdana", 12);
                Password.AutoSize = false;
                Password.Location = new Point(10, 100);

                passwordInput.Text = null;
                passwordInput.MaxLength = 40;
                passwordInput.Multiline = false;
                passwordInput.PasswordChar = '*';
                passwordInput.Width = 150;
                passwordInput.Location = new Point(15, 123);
                passwordInput.KeyDown += passwordCheck_KeyDown;

                logForm.Controls.Add(Prompt);
                logForm.Controls.Add(Username);
                logForm.Controls.Add(usernameInput);
                logForm.Controls.Add(Password);
                logForm.Controls.Add(passwordInput);
                logForm.Controls.Add(error);

                logForm.ShowDialog();

                void passwordCheck_KeyDown(object sender2, KeyEventArgs e2)
                {
                    SortedSet<User> users = new SortedSet<User>();
                    SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
                    List<Post> posts = new List<Post>();
                    List<Comment> comments = new List<Comment>();

                    bool logged = false;

                    ReadInputFiles(users, subreddits, posts, comments);

                    if (e2.KeyCode == Keys.Enter)
                    {
                        string password = passwordInput.Text;
                        password = password.GetHashCode().ToString("X");

                        foreach (User u in users)
                        {
                            if (usernameInput.Text == u.Name && passwordCheck(u.PasswordHash, password))
                            {
                                logged = true;
                                userLabel.Text = u.Name;
                                userLabel.Font = new Font("Verdana", 11);
                                userLabel.AutoSize = true;
                                userLabel.Width = 150;
                                int x = headerLabel.PreferredWidth;
                                int y = headerLabel.PreferredHeight;
                                userLabel.Location = new Point(x + 600, y - 7);
                            }
                        }

                        //If user entered incorrect username or password, prompt error
                        if (!logged)
                        {
                            error.Text = "Incorrect username or password!";
                            usernameInput.Text = "";
                            passwordInput.Text = "";
                        }

                        //If user logged in, close the form and change "log in" to "log out"
                        if (logged)
                        {
                            logForm.Close();
                            logInButton.Text = "Log Out";

                            int karma = 0; //Sum of post score and comment score for the user

                            foreach (User u in users.Where(x => x.Name == userLabel.Text))
                            {
                                karma = u.PostScore + u.CommentScore;
                                karmaLabel.Text = "Karma " + String.Format("{0:n0}", karma);
                                karmaLabel.Font = new Font("Verdana", 8);
                            }
                        }
                    }
                }
            }
        }

        //Event handler for when user changes value of combobox
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            List<Post> posts = new List<Post>();
            List<Comment> comments = new List<Comment>();
            List<DisplayPost> displays = new List<DisplayPost>();

            ReadInputFiles(users, subreddits, posts, comments);

            string temp = comboBox.SelectedItem.ToString();

            int count = 0;
            var pLinq = from P in posts
                        orderby P.Score descending
                        select P;

            if (temp == "Home")
            {
                foreach (Post p in pLinq)
                {
                    var srLinq = from S in subreddits
                                 where S.Id == p.SubHome
                                 select S;

                    var uLinq = from U in users
                                where U.Id == p.AuthorID
                                select U;

                    foreach (Subreddit s in srLinq)
                    {
                        foreach (User u in uLinq)
                        {
                            DisplayPost temp2 = new DisplayPost(s.Name, p.Title, u.Name, p.TimeStamp, p.PostContent, p.Score, count);
                            displays.Add(temp2);
                            count++;
                        }
                    }
                }
                foreach (DisplayPost d in displays)
                {
                    d.PostPanel.Tag = d.titleLabel;
                    d.PostPanel.Click += new EventHandler(panel1_Click);
                    d.postPanel.AutoSize = true;
                    if (d.titleLabel.ToString().Length > 80)
                    {
                        d.postPanel.Height = 100;
                    }
                    mainPanel.Controls.Add(d.postPanel);
                    mainPanel.AutoScroll = true;
                }
            }
            else
            {
                foreach (Post p in pLinq)
                {
                    var srLinq = from S in subreddits
                                 where S.Id == p.SubHome
                                 where S.Name == temp
                                 select S;

                    var uLinq = from U in users
                                where U.Id == p.AuthorID
                                select U;

                    foreach (Subreddit s in srLinq)
                    {
                        foreach (User u in uLinq)
                        {
                            DisplayPost temp2 = new DisplayPost(s.Name, p.Title, u.Name, p.TimeStamp, p.PostContent, p.Score, count);
                            displays.Add(temp2);
                            count++;
                        }
                    }
                }
                foreach (DisplayPost d in displays)
                {
                    d.PostPanel.Tag = d.redditLabel;
                    d.PostPanel.Click += new EventHandler(panel1_Click);

                    mainPanel.Controls.Add(d.postPanel);
                    mainPanel.AutoScroll = true;
                }
            }
        }

        //Function and event handlers for the search box
        protected void searchTextBox_SetText()
        {
            this.searchTextBox.Text = "Search reddit";
            searchTextBox.ForeColor = Color.Gray;
        }
        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            if (searchTextBox.ForeColor == Color.Black)
            {
                return;
            }
            searchTextBox.Text = "";
            searchTextBox.ForeColor = Color.Black;

            searchTextBox.KeyDown += searchTextBox_KeyDown;

            void searchTextBox_KeyDown(object sender2, KeyEventArgs e2)
            {
                if (e2.KeyCode == Keys.Enter)
                {
                    mainPanel.Controls.Clear();

                    SortedSet<User> users = new SortedSet<User>();
                    SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
                    List<Post> posts = new List<Post>();
                    List<Comment> comments = new List<Comment>();
                    List<DisplayPost> displays = new List<DisplayPost>();

                    ReadInputFiles(users, subreddits, posts, comments);

                    string temp = searchTextBox.Text;
                    temp = temp.ToLower();

                    int count = 0;
                    var pLinq = from P in posts
                                orderby P.Score descending
                                select P;

                    foreach (Post p in pLinq)
                    {
                        var srLinq = from S in subreddits
                                     where S.Id == p.SubHome
                                     select S;

                        var uLinq = from U in users
                                    where U.Id == p.AuthorID
                                    select U;

                        foreach (Subreddit s in srLinq)
                        {
                            foreach (User u in uLinq)
                            {
                                if (p.PostContent.ToLower().Contains(temp) || p.Title.ToLower().Contains(temp))
                                {
                                    DisplayPost temp2 = new DisplayPost(s.Name, p.Title, u.Name, p.TimeStamp, p.PostContent, p.Score, count);
                                    displays.Add(temp2);
                                    count++;
                                }
                            }
                        }
                    }
                    foreach (DisplayPost d in displays)
                    {
                        d.PostPanel.Tag = d.redditLabel;
                        d.PostPanel.Click += new EventHandler(panel1_Click);

                        mainPanel.Controls.Add(d.postPanel);
                        mainPanel.AutoScroll = true;
                    }

                    //If no results come up from search, print error message
                    string temp3 = displays.Count().ToString();
                    if (temp3 == "0")
                    {
                        errorLabel.Text = "We're sorry, we found no results!";
                        errorLabel.Font = new Font("Verdana", 12);
                        errorLabel.ForeColor = Color.FromArgb(237, 67, 55);
                        errorLabel.AutoSize = true;
                        errorLabel.Location = new Point(325, 50);
                    }
                    //Else, reset message, if previously was triggered
                    else
                    {
                        errorLabel.Text = "";
                    }
                }
            }
        }
        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            if (searchTextBox.Text.Trim() == "")
            {
                searchTextBox_SetText();
            }
        }


    }
}