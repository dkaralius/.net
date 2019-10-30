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
            public System.Windows.Forms.Label userLabel;
            public System.Windows.Forms.Label timeLabel;
            //public System.Windows.Forms.Label scoreLabel;

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

            public DisplayPost()
            {
                postPanel = new System.Windows.Forms.Panel();

                redditLabel = new System.Windows.Forms.Label();

                userLabel = new System.Windows.Forms.Label();

                timeLabel = new System.Windows.Forms.Label();
            }

            public DisplayPost(string reddit, string title, string author, DateTime time, int count)
            {
                postPanel = new System.Windows.Forms.Panel();

                redditLabel = new System.Windows.Forms.Label();
                redditLabel.ForeColor = Color.White;
                redditLabel.Text = "r/" + reddit;
                redditLabel.AutoSize = true;
                redditLabel.Font = new Font("Verdana", 12);
                redditLabel.Location = new Point(0, 4);
                int x = RedditLabel.PreferredWidth;

                userLabel = new System.Windows.Forms.Label();
                userLabel.ForeColor = Color.Gray;
                userLabel.Text = "| Posted by u/" + author;
                userLabel.AutoSize = true;
                userLabel.Font = new Font("Verdana", 8);
                userLabel.Location = new Point(x + 2, 7);
                int x2 = userLabel.PreferredWidth;

                timeLabel = new System.Windows.Forms.Label();
                timeLabel.ForeColor = Color.Gray;
                timeLabel.AutoSize = true;
                timeLabel.Font = new Font("Verdana", 8);
                timeLabel.Location = new Point(x + x2 + 5 , 7);

                DateTime now = DateTime.Now;
                TimeSpan ts = now - time;

                int days = ts.Days;
                int hours = ts.Hours;
                int minutes = ts.Minutes;

                //If was posted within the year, continue
                if(days < 365)
                {
                    //If the year and month are the same, continue
                    if(time.Month == now.Month)
                    {
                        if(time.Day == now.Day)
                        {

                        }
                        //Else, the year and month are the same, but date is different
                        else
                        {
                            //More than 1 day ago
                            if((now.Day - time.Day) > 1)
                            {
                                timeLabel.Text = (now.Day - time.Day) + " days ago";
                            }
                            //Exactly 1 day ago
                            if((now.Day - time.Day) == 1)
                            {
                                timeLabel.Text = "a day ago";
                            }
                            //Less than a day ago
                            else
                            {
                                //If there are less than 24 hours but greater than 1 hour between now and post time, print difference
                                if(hours < 24 && hours >= 1)
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
                        if((now.Month - time.Month) > 1)
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
                    if((now.Year - time.Year) > 1)
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
                postPanel.Controls.Add(userLabel);
                postPanel.Controls.Add(timeLabel);

                postPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                postPanel.AutoSize = true;
                postPanel.Location = new Point(10, postPanel.Height * count);
                postPanel.Width = 850;
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
            panel2.BackColor = Color.FromArgb(219, 223, 232);

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

                Point previous = new Point();

                foreach (Subreddit s in srLinq)
                {
                    foreach (User u in uLinq)
                    {
                        DisplayPost temp = new DisplayPost(s.Name,p.Title, u.Name, p.TimeStamp, count);
                        displays.Add(temp);
                        count++;
                    }
                }
            }

            //MessageBox.Show(count.ToString());
            foreach (DisplayPost d in displays)
            {
                d.PostPanel.Tag = d.redditLabel;
                d.PostPanel.Click += new EventHandler(panel1_Click);

                mainPanel.Controls.Add(d.postPanel);
            }
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Panel p = sender as System.Windows.Forms.Panel;
            string test = (p.Tag).ToString();
            string test2 = test.Substring(test.IndexOf('/') + -1);

            Form newForm = new Form();
            newForm.StartPosition = FormStartPosition.CenterParent;
            newForm.MaximizeBox = false;
            newForm.MinimizeBox = false;

            System.Windows.Forms.Label newLabel = new System.Windows.Forms.Label();

            newLabel.Location = new Point(13, 13);
            newLabel.Text = test2;

            newForm.Controls.Add(newLabel);

            newForm.ShowDialog();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            if(logInButton.Text == "Log Out")
            {
                logInButton.Text = "Log In";
                userLabel.Text = " ";
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
                                userLabel.Text = "Welcome, " + u.Name + "!";
                                userLabel.Font = new Font("Verdana", 11);
                                userLabel.Width = 150;
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
                        }
                    }
                }
            }
        }
    }
}
