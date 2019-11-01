/********************************************************
 *  PROGRAM : Assignment4                               *
 *                                                      *
 *  PROGRAMMERS : Josue Ballona and Dominykas Karalius  *
 *  ZID : Z1832823 and Z1809478                         *
 *                                                      *
 *  DATE : 10/31/2019 Thursday, October 31st 2019       *
 *                                                      *
 *                                                      *
 * This program mimics the popular application "Reddit",*
 * but this time we have a GUI. The program reads       *
 * provided .txt input files and stores that            *
 * information into SortedSet<> objects. Information    *
 * such as users, subreddits, posts, and comments.      *
 * The user of the program can choose from a variety    *
 * of actions to perfrom; view posts and their comments,*
 * creat a new post/comment, log-in, upvote and         *
 * downvote, search by keyword and sort by subreddit.   *
 *******************************************************/
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
        string loggedUser = null;
        bool logged;
        bool temp = false;


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
            public System.Windows.Forms.Label commentLabel;
            public ToolStrip scoreStrip;
            public ToolStripButton upArrow;
            public ToolStripLabel scoreLabel;
            public ToolStripButton downArrow;

            bool logged;
            bool upVoted;
            bool downVoted;
            decimal score;

            string subredditName;

            public bool UpVoted
            {
                get { return upVoted; }
                set { upVoted = value; }
            }
            public bool DownVoted
            {
                get { return downVoted; }
                set
                { downVoted = value; }
            }
            public decimal Score
            {
                get { return score; }
                set { score = value; }
            }
            public bool Logged
            {
                get { return logged; }
                set { logged = value; }
            }

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
            public System.Windows.Forms.Label CommentLabel
            {
                get { return commentLabel; }
                set { commentLabel = value; }
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

                commentLabel = new System.Windows.Forms.Label();

                scoreStrip = new ToolStrip();

                upArrow = new ToolStripButton();

                scoreLabel = new ToolStripLabel();

                downArrow = new ToolStripButton();

                score = 1;

                logged = false;

                upVoted = downVoted = false;

                string subredditName = null;
            }

            public DisplayPost(string reddit, string title, string author, DateTime time, string content, int score, int count, int commentNum, bool logged)
            {
                postPanel = new System.Windows.Forms.Panel();
                subredditName = reddit;
                upVoted = false;
                downVoted = false;

                this.score = score;
                this.logged = logged;

                scoreStrip = new ToolStrip();
                scoreStrip.Dock = DockStyle.Left;
                scoreStrip.BackColor = Color.FromArgb(22, 22, 22);
                scoreStrip.AutoSize = true;

                System.Drawing.Image upArrowPic;
                upArrow = new ToolStripButton();
                upArrowPic = System.Drawing.Image.FromFile("upArrow.png");
                upArrow.Text = String.Empty;
                upArrow.Image = upArrowPic;
                upArrow.MouseEnter += new EventHandler(upArrow_MouseEnter);
                upArrow.MouseLeave += new EventHandler(upArrow_MouseLeave);
                upArrow.Click += new EventHandler(upArrow_Click);


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
                downArrow.Click += new EventHandler(downArrow_Click);

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
                int x2 = titleLabel.PreferredWidth;

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
                int x3 = userLabel.PreferredWidth;

                timeLabel = new System.Windows.Forms.Label();
                timeLabel.ForeColor = Color.Gray;
                timeLabel.AutoSize = true;
                timeLabel.Font = new Font("Verdana", 8);
                timeLabel.Location = new Point(scoreStrip.Bottom + x + 10, 7);


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

                if (count > 0)
                {
                    redditLabel.Location = new Point(scoreStrip.Bottom + 15, 28);
                    int x4 = RedditLabel.PreferredWidth;
                    int y4 = redditLabel.PreferredHeight;

                    titleLabel.Location = new Point(redditLabel.Location.X, y + 36);

                    if (content.Length < 100 && title.Length < 100)
                    {
                        contentLabel.Location = new Point(redditLabel.Location.X, y + 65);
                    }
                    if (content.Length < 100 && title.Length > 100)
                    {
                        contentLabel.Location = new Point(redditLabel.Location.X, y + 88);
                    }
                    if (content.Length > 200)
                    {
                        contentLabel.Location = new Point(redditLabel.Location.X, y + 68);
                    }
                    userLabel.Location = new Point(x +scoreStrip.Bottom + 2, 31);
                    int x5 = userLabel.PreferredWidth;
                    timeLabel.Location = new Point(scoreStrip.Bottom + x + x5 + 5, 31);
                }

                System.Windows.Forms.PictureBox commentIcon = new System.Windows.Forms.PictureBox();
                commentIcon.Image = System.Drawing.Image.FromFile("..\\..\\comment_icon.png");
                commentIcon.SizeMode = PictureBoxSizeMode.AutoSize;
                commentIcon.Location = new Point(scoreStrip.Bottom + 20, 150);

                commentLabel = new System.Windows.Forms.Label();
                commentLabel.ForeColor = Color.Gray;
                commentLabel.AutoSize = true;

                if (commentNum > 1 || commentNum == 0)
                {
                    commentLabel.Text = commentNum + " comments";
                    commentLabel.Font = new Font("Verdana", 8);
                    commentLabel.Location = new Point(scoreStrip.Bottom + 40, 154);
                }
                else
                {
                    commentLabel.Text = commentNum + " comment";
                    commentLabel.Font = new Font("Verdana", 8);
                    commentLabel.Location = new Point(scoreStrip.Bottom + 40, 154);
                }

                postPanel.Controls.Add(redditLabel);
                postPanel.Controls.Add(contentLabel);
                postPanel.Controls.Add(userLabel);
                postPanel.Controls.Add(timeLabel);
                postPanel.Controls.Add(titleLabel);
                postPanel.Controls.Add(commentIcon);
                postPanel.Controls.Add(commentLabel);
                postPanel.Controls.Add(scoreStrip);

                scoreStrip.Items.Add(upArrow);
                scoreStrip.Items.Add(scoreLabel);
                scoreStrip.Items.Add(downArrow);

                postPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                postPanel.Width = 850;
                postPanel.Height = 150;

                postPanel.Location = new Point(10, (postPanel.Height + 20) * count );
            }
            private void upArrow_MouseEnter(Object sender, EventArgs e)
            {
                ToolStripButton s = (ToolStripButton)sender;

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
                ToolStripButton s = (ToolStripButton)sender;

                System.Drawing.Image downArrowPic = System.Drawing.Image.FromFile("downArrowBlue.png");
                downArrow.Image = downArrowPic;
            }

            private void downArrow_MouseLeave(Object sender, EventArgs e)
            {
                System.Drawing.Image downArrowPic = System.Drawing.Image.FromFile("downArrow.png");
                downArrow.Image = downArrowPic;
            }

            private void upArrow_Click(object sender, EventArgs e)
            {
                ToolStripButton s = (ToolStripButton)sender;

                if (upVoted)
                    return;
                else
                {
                    if (scoreLabel.Text[scoreLabel.Text.Length - 1] == 'k')
                    {
                        score += 1;

                        if (score < 1000 && score > -1000)
                        {
                            scoreLabel.Text = score.ToString();
                        }
                        else
                        {
                            scoreLabel.Text = String.Format("{0: 0.#k}", Convert.ToDecimal(score) / 1000);
                        }

                        System.Drawing.Image upArrowPic = System.Drawing.Image.FromFile("upArrowRed.png");
                        upArrow.Image = System.Drawing.Image.FromFile("upArrowRed.png");


                    }
                    else
                    {

                        score += 1;

                        if (score < 1000 && score > -1000)
                        {
                            scoreLabel.Text = score.ToString();
                        }
                        else
                        {
                            scoreLabel.Text = String.Format("{0: 0.#k}", Convert.ToDecimal(score) / 1000);
                        }
                        System.Drawing.Image upArrowPic = System.Drawing.Image.FromFile("upArrow.png");
                        s.Image = upArrowPic;
                    }

                    upArrow.Enabled = false;
                    downArrow.Enabled = true;
                    upVoted = true;
                    downVoted = false;
                }
            }
            private void downArrow_Click(object sender, EventArgs e)
            {
                ToolStripButton s = (ToolStripButton)sender;


                if (downVoted)
                    return;
                else
                { 
                    if (scoreLabel.Text[scoreLabel.Text.Length - 1] == 'k')
                    {
                        score -= 1;

                        if (score < 1000 && score > -1000)
                        {
                            scoreLabel.Text = score.ToString();
                        }
                        else
                        {
                            scoreLabel.Text = String.Format("{0: 0.#k}", Convert.ToDecimal(score) / 1000);
                        }
                    }
                    else
                    {
                        score -= 1;

                        if (score < 1000 && score > -1000)
                        {
                            scoreLabel.Text = score.ToString();
                        }
                        else
                        {
                            scoreLabel.Text = String.Format("{0: 0.#k}", Convert.ToDecimal(score) / 1000);
                        }
                    }

                    downVoted = true;
                    upVoted = false;
                    downArrow.Enabled = false;

                    upArrow.Enabled = true;
                }

            }
        }
    public class DisplayComment
        {
            //Panel where all info about a comment will be stored
            public System.Windows.Forms.Panel commentPanel;

            public System.Windows.Forms.Label userLabel; //Author
            public System.Windows.Forms.Label scoreLabel; //Score
            public System.Windows.Forms.Label timeLabel; //Time frame ago
            public System.Windows.Forms.Label contentLabel; //Content
            string userName;

            //Public properties
            public System.Windows.Forms.Panel CommentPanel
            {
                get { return CommentPanel; }
                set { CommentPanel = value; }
            }
            public System.Windows.Forms.Label UserLabel
            {
                get { return userLabel; }
                set { userLabel = value; }
            }
            public System.Windows.Forms.Label ScoreLabel
            {
                get { return scoreLabel; }
                set { scoreLabel = value; }
            }
            public System.Windows.Forms.Label TimeLabel
            {
                get { return timeLabel; }
                set { timeLabel = value; }
            }
            public System.Windows.Forms.Label ContentLabel
            {
                get { return contentLabel; }
                set { contentLabel = value; }
            }
            public string UserName
            {
                get { return userName; }
                set { userName = value; }
            }

            //Default constructor
            public DisplayComment()
            {
                commentPanel = new System.Windows.Forms.Panel();
                userLabel = new System.Windows.Forms.Label();
                scoreLabel = new System.Windows.Forms.Label();
                timeLabel = new System.Windows.Forms.Label();
                contentLabel = new System.Windows.Forms.Label();
                userName = null;
            }

            //Alternate constructor
            public DisplayComment(string author, int score, DateTime time, string content, int count, string userName)
            {
                commentPanel = new System.Windows.Forms.Panel();

                System.Windows.Forms.RichTextBox replyBox = new System.Windows.Forms.RichTextBox();
                System.Windows.Forms.Button submitReply = new System.Windows.Forms.Button();
                System.Windows.Forms.Button cancelReply = new System.Windows.Forms.Button();
                List<DisplayReply> replies = new List<DisplayReply>();

                userLabel = new System.Windows.Forms.Label();
                userLabel.ForeColor = Color.White;
                userLabel.Text = author;
                userLabel.AutoSize = true;
                userLabel.Font = new Font("Verdana", 12);
                userLabel.Location = new Point(0, 4);

                int x = UserLabel.PreferredWidth;
                int y = UserLabel.PreferredHeight;

                scoreLabel = new System.Windows.Forms.Label();
                scoreLabel.ForeColor = Color.Gray;
                scoreLabel.AutoSize = true;
                scoreLabel.MaximumSize = new Size(800, 0);
                scoreLabel.Font = new Font("Verdana", 8);
                scoreLabel.Text = " | " + String.Format("{0:n0}", score + " points");
                scoreLabel.Location = new Point(x - 4, 7);

                int x2 = ScoreLabel.PreferredWidth;
                int y2 = scoreLabel.PreferredHeight;

                timeLabel = new System.Windows.Forms.Label();
                timeLabel.ForeColor = Color.Gray;
                timeLabel.AutoSize = true;
                timeLabel.Font = new Font("Verdana", 8);
                timeLabel.Location = new Point(x + x2, 7);

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
                            if (time.Hour == now.Hour)
                            {
                                if (time.Minute == now.Minute)
                                {
                                    timeLabel.Text = (now.Second - time.Second) + " seconds ago";
                                }
                                else
                                {
                                    timeLabel.Text = (now.Minute - time.Minute) + " minutes ago";
                                }
                            }
                            else
                            {
                                timeLabel.Text = (now.Hour - time.Hour) + " hours ago";
                            }

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

                contentLabel = new System.Windows.Forms.Label();
                contentLabel.AutoSize = true;
                contentLabel.Text = content;
                contentLabel.ForeColor = Color.Gray;
                contentLabel.MaximumSize = new Size(730, 0);
                contentLabel.Font = new Font("Verdana", 10);
                contentLabel.Location = new Point(2, 25);

                System.Windows.Forms.PictureBox replyIcon = new System.Windows.Forms.PictureBox();
                replyIcon.Image = System.Drawing.Image.FromFile("..\\..\\reply_icon.png");
                replyIcon.SizeMode = PictureBoxSizeMode.AutoSize;
                replyIcon.Location = new Point(0, 70);
                replyIcon.Click += new EventHandler(replyIcon_Click);
                replyIcon.Cursor = Cursors.Hand;

                commentPanel.Controls.Add(userLabel);
                commentPanel.Controls.Add(scoreLabel);
                commentPanel.Controls.Add(timeLabel);
                commentPanel.Controls.Add(contentLabel);
                commentPanel.Controls.Add(replyIcon);

                commentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                commentPanel.AutoSize = true;
                commentPanel.Location = new Point(12, (commentPanel.Height * count) + 325);
                commentPanel.Width = 740;

                void replyIcon_Click(object sender, EventArgs e)
                {
                    if (userName == null)
                    {
                        MessageBox.Show("Please log in to comment.");
                        return;
                    }

                    submitReply.Text = "Submit";
                    submitReply.Font = new Font("Verdana", 8);
                    submitReply.Location = new Point(590, 193);
                    submitReply.BackColor = Color.White;
                    submitReply.Click += new EventHandler(submitReply_Click);

                    cancelReply.Text = "Cancel";
                    cancelReply.Font = new Font("Verdana", 8);
                    cancelReply.Location = new Point(666, 193); //yikes
                    cancelReply.BackColor = Color.White;
                    cancelReply.Click += new EventHandler(cancelReply_Click);

                    replyBox.Text = "What are your thoughts?";
                    replyBox.Font = new Font("Verdana", 8);
                    replyBox.ForeColor = Color.Gray;
                    replyBox.Width = 740;
                    replyBox.Location = new Point(0, 98);

                    commentPanel.Controls.Add(replyBox);
                    commentPanel.Controls.Add(submitReply);
                    commentPanel.Controls.Add(cancelReply);

                    replyBox.Enter += new EventHandler(replyBox_Enter);
                    replyBox.Leave += new EventHandler(replyBox_Leave);
                    replyBox_SetText();

                    //Function and event handlers for the comment box
                    void replyBox_SetText()
                    {
                        replyBox.Text = "What are your thoughts?";
                        replyBox.ForeColor = Color.Gray;
                        return;
                    }
                    void replyBox_Enter(object sender2, EventArgs e2)
                    {
                        if (replyBox.ForeColor == Color.Black)
                        {
                            return;
                        }
                        replyBox.Text = "";
                        replyBox.ForeColor = Color.Black;
                    }
                    void replyBox_Leave(object sender3, EventArgs e3)
                    {
                        if (replyBox.Text.Trim() == "")
                        {
                            replyBox_SetText();
                        }
                    }
                }
                //If user hits submit, submit his reply to comment
                void submitReply_Click(object sender, EventArgs e)
                {
                    MessageBox.Show("User: " + userName + " Text: " + replyBox.Text + "time: " + DateTime.Now); //Just to show it works

                    //If text box is empty
                    if (replyBox.Text == "What are your thoughts?")
                    {
                        MessageBox.Show("Please enter a comment!");
                    }

                    DisplayReply temp = new DisplayReply(userName, 1, DateTime.Now, replyBox.Text, count);
                    replies.Insert(0, temp);
                    count++;
                    replyBox.Text = "What are your thoughts?";
                    replyBox.ForeColor = Color.Gray;

                    commentPanel.Controls.Remove(replyBox);
                    commentPanel.Controls.Remove(submitReply);
                    commentPanel.Controls.Remove(cancelReply);

                    foreach (DisplayReply d in replies)
                    {
                        d.replyPanel.AutoSize = true;
                        commentPanel.Controls.Add(d.replyPanel);
                    }
                }
                //If user hits cancel, remove textbox and buttons
                void cancelReply_Click(object sender, EventArgs e)
                {
                    commentPanel.Controls.Remove(replyBox);
                    commentPanel.Controls.Remove(submitReply);
                    commentPanel.Controls.Remove(cancelReply);
                }
            }
        }
        public class DisplayReply
        {
            //Panel where all info about a comment will be stored
            public System.Windows.Forms.Panel replyPanel;

            public System.Windows.Forms.Label userLabel; //Author
            public System.Windows.Forms.Label scoreLabel; //Score
            public System.Windows.Forms.Label timeLabel; //Time frame ago
            public System.Windows.Forms.Label contentLabel; //Content

            //Public properties
            public System.Windows.Forms.Panel CommentPanel
            {
                get { return CommentPanel; }
                set { CommentPanel = value; }
            }
            public System.Windows.Forms.Label UserLabel
            {
                get { return userLabel; }
                set { userLabel = value; }
            }
            public System.Windows.Forms.Label ScoreLabel
            {
                get { return scoreLabel; }
                set { scoreLabel = value; }
            }
            public System.Windows.Forms.Label TimeLabel
            {
                get { return timeLabel; }
                set { timeLabel = value; }
            }
            public System.Windows.Forms.Label ContentLabel
            {
                get { return contentLabel; }
                set { contentLabel = value; }
            }

            //Default constructor
            public DisplayReply()
            {
                replyPanel = new System.Windows.Forms.Panel();
                userLabel = new System.Windows.Forms.Label();
                scoreLabel = new System.Windows.Forms.Label();
                timeLabel = new System.Windows.Forms.Label();
                contentLabel = new System.Windows.Forms.Label();
            }

            //Alternate constructor
            public DisplayReply(string author, int score, DateTime time, string content, int count)
            {
                replyPanel = new System.Windows.Forms.Panel();
                replyPanel.BackColor = Color.FromArgb(60, 60, 60);

                userLabel = new System.Windows.Forms.Label();
                userLabel.ForeColor = Color.White;
                userLabel.Text = author;
                userLabel.AutoSize = true;
                userLabel.Font = new Font("Verdana", 12);
                userLabel.Location = new Point(0, 4);

                int x = UserLabel.PreferredWidth;
                int y = UserLabel.PreferredHeight;

                scoreLabel = new System.Windows.Forms.Label();
                scoreLabel.ForeColor = Color.Gray;
                scoreLabel.AutoSize = true;
                scoreLabel.MaximumSize = new Size(800, 0);
                scoreLabel.Font = new Font("Verdana", 8);
                scoreLabel.Text = " | " + String.Format("{0:n0}", score + " points");
                scoreLabel.Location = new Point(x - 4, 7);

                int x2 = ScoreLabel.PreferredWidth;
                int y2 = scoreLabel.PreferredHeight;

                timeLabel = new System.Windows.Forms.Label();
                timeLabel.ForeColor = Color.Gray;
                timeLabel.AutoSize = true;
                timeLabel.Font = new Font("Verdana", 8);
                timeLabel.Location = new Point(x + x2, 7);

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
                            if (time.Hour == now.Hour)
                            {
                                if (time.Minute == now.Minute)
                                {
                                    timeLabel.Text = (now.Second - time.Second) + " seconds ago";
                                }
                                else
                                {
                                    timeLabel.Text = (now.Minute - time.Minute) + " minutes ago";
                                }
                            }
                            else
                            {
                                timeLabel.Text = (now.Hour - time.Hour) + " hours ago";
                            }

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

                contentLabel = new System.Windows.Forms.Label();
                contentLabel.AutoSize = true;
                contentLabel.Text = content;
                contentLabel.ForeColor = Color.Gray;
                contentLabel.MaximumSize = new Size(730, 0);
                contentLabel.Font = new Font("Verdana", 10);
                contentLabel.Location = new Point(2, 25);

                replyPanel.Controls.Add(userLabel);
                replyPanel.Controls.Add(scoreLabel);
                replyPanel.Controls.Add(timeLabel);
                replyPanel.Controls.Add(contentLabel);

                replyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                replyPanel.AutoSize = true;
                replyPanel.Location = new Point(12, (replyPanel.Height * count) + 100);
                replyPanel.Width = 740;
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

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            List<Post> posts = new List<Post>();
            List<Comment> comments = new List<Comment>();
            List<DisplayPost> displays = new List<DisplayPost>();

            ReadInputFiles(users, subreddits, posts, comments);

            int count = 0;
            int i = 0;

            //Disbales minimize and maximize buttons
            MinimizeBox = false;
            MaximizeBox = false;

            //Prevents resizing of window
            FormBorderStyle = FormBorderStyle.FixedSingle;

            panel2.BackColor = Color.FromArgb(219, 223, 232);

            searchTextBox.Enter += new EventHandler(searchTextBox_Enter);
            searchTextBox.Leave += new EventHandler(searchTextBox_Leave);
            searchTextBox_SetText();

            createPost.Click += new EventHandler(createPost_Click);

            void createPost_Click(object sender, EventArgs e)
            {
                if (!logged)
                {
                    MessageBox.Show("Please log in to create a post.");
                }
                if (logged)
                {
                    System.Windows.Forms.Panel p = sender as System.Windows.Forms.Panel;

                    Form newForm = new Form();
                    newForm.Size = new Size(800, 350);
                    newForm.BackColor = Color.Black;
                    newForm.StartPosition = FormStartPosition.CenterParent;
                    newForm.MaximizeBox = false;
                    newForm.MinimizeBox = false;
                    newForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                    newForm.Text = "Create a post";

                    System.Windows.Forms.Label redditLabel = new System.Windows.Forms.Label();
                    System.Windows.Forms.ComboBox reddits = new System.Windows.Forms.ComboBox();
                    System.Windows.Forms.RichTextBox content = new System.Windows.Forms.RichTextBox();
                    System.Windows.Forms.RichTextBox title = new System.Windows.Forms.RichTextBox();
                    System.Windows.Forms.Label titleLabel = new System.Windows.Forms.Label();
                    System.Windows.Forms.Label contentLabel = new System.Windows.Forms.Label();
                    System.Windows.Forms.Button submitPost = new System.Windows.Forms.Button();
                    System.Windows.Forms.Button cancel = new System.Windows.Forms.Button();

                    redditLabel = new System.Windows.Forms.Label();
                    redditLabel.ForeColor = Color.White;
                    redditLabel.Text = "Choose a community: ";
                    redditLabel.AutoSize = true;
                    redditLabel.Font = new Font("Verdana", 12);
                    redditLabel.Location = new Point(0, 10);

                    reddits = new System.Windows.Forms.ComboBox();
                    reddits.AutoSize = true;
                    reddits.Font = new Font("Verdana", 10);
                    reddits.DropDownStyle = ComboBoxStyle.DropDownList;
                    reddits.Location = new Point(190, 6);
                    foreach (Subreddit s in subreddits)
                    {
                        reddits.Items.Add(s.Name);
                    }
                    reddits.Items.Remove("all");
                    reddits.SelectedIndex = 0;

                    titleLabel = new System.Windows.Forms.Label();
                    titleLabel.ForeColor = Color.White;
                    titleLabel.Text = "Title: ";
                    titleLabel.AutoSize = true;
                    titleLabel.Font = new Font("Verdana", 12);
                    titleLabel.Location = new Point(0, 45);

                    title = new System.Windows.Forms.RichTextBox();
                    title.Location = new Point(100, 42);
                    title.Multiline = false;
                    title.Font = new Font("Verdana", 10);
                    title.Size = new Size(300, 20);
                    title.MaxLength = 100;

                    contentLabel = new System.Windows.Forms.Label();
                    contentLabel.ForeColor = Color.White;
                    contentLabel.Text = "Content: ";
                    contentLabel.AutoSize = true;
                    contentLabel.Font = new Font("Verdana", 12);
                    contentLabel.Location = new Point(0, 80);

                    content = new System.Windows.Forms.RichTextBox();
                    content.Location = new Point(100, 80);
                    content.Multiline = false;
                    content.Size = new Size(550, 200);
                    content.Font = new Font("Verdana", 10);
                    content.Text = "Text(optional)";
                    content.ForeColor = Color.Gray;
                    content.MaxLength = 300;

                    content.Enter += new EventHandler(content_Enter);
                    content.Leave += new EventHandler(content_Leave);
                    content_SetText();

                    submitPost.Text = "Submit";
                    submitPost.AutoSize = true;
                    submitPost.Font = new Font("Verdana", 8);
                    submitPost.Location = new Point(490, 285);
                    submitPost.BackColor = Color.White;
                    submitPost.Click += new EventHandler(submitPost_Click);

                    cancel.Text = "Cancel";
                    cancel.AutoSize = true;
                    cancel.Font = new Font("Verdana", 8);
                    cancel.Location = new Point(576, 285);
                    cancel.BackColor = Color.White;
                    cancel.Click += new EventHandler(cancel_Click);

                    newForm.Controls.Add(redditLabel);
                    newForm.Controls.Add(reddits);
                    newForm.Controls.Add(titleLabel);
                    newForm.Controls.Add(title);
                    newForm.Controls.Add(contentLabel);
                    newForm.Controls.Add(content);
                    newForm.Controls.Add(submitPost);
                    newForm.Controls.Add(cancel);

                    newForm.ShowDialog();

                    //Event handling for RTB
                    void content_SetText()
                    {
                        content.Text = "Text(optional)";
                        content.ForeColor = Color.Gray;
                        return;
                    }
                    void content_Enter(object sender2, EventArgs e2)
                    {
                        if (content.ForeColor == Color.Black)
                        {
                            return;
                        }
                        content.Text = "";
                        content.ForeColor = Color.Black;
                    }
                    void content_Leave(object sender3, EventArgs e3)
                    {
                        if (content.Text.Trim() == "")
                        {
                            content_SetText();
                        }
                    }
                    void submitPost_Click(object sender4, EventArgs e4)
                    {
                        if (title.Text == "")
                        {
                            MessageBox.Show("Title is empty!");
                        }
                        DateTime time = DateTime.Now;

                        DisplayPost temp = new DisplayPost(reddits.SelectedItem.ToString(), title.Text, loggedUser, time, content.Text, 1, count, 0, logged);
                        displays.Insert(0, temp);
                        count++;

                        foreach (DisplayPost d in displays)
                        {
                            d.postPanel.AutoSize = true;
                            newForm.Controls.Add(d.postPanel);
                        }

                        using (StreamWriter w = File.AppendText(@"..\\..\\posts.txt"))
                        {
                            int min = 0000;
                            int max = 9999;
                            Random rng = new Random();
                            int id = rng.Next(min, max);

                            foreach (Subreddit s in subreddits.Where(xyz => xyz.Name == reddits.Text.Trim()))
                            {
                                foreach (User u in users.Where(x => x.Name == loggedUser))
                                {
                                    w.WriteLine();
                                    w.WriteLine(0 + "\t" + id + "\t" + u.Id + "\t" + title.Text + "\t" + content.Text + "\t" + s.Id + "\t" + 1 + "\t" + 0 + "\t" + 0 + "\t" +
                                        time.Year + "\t" + time.Month + "\t" + time.Day + "\t" + time.Hour + "\t" + time.Minute + "\t" + time.Second + "\t" + 0 + "\t" + 0 + "\t" + 0);
                                }
                            }
                        }

                        newForm.Close();
                    }
                    //Closes the post making window
                    void cancel_Click(object sender5, EventArgs e5)
                    {
                        newForm.Close();
                    }
                }

            }

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

                var cLinq = from C in comments
                            where C.ParentID == p.Id
                            select C;

                foreach (Subreddit s in srLinq)
                {
                    foreach (User u in uLinq)
                    {
                        foreach (Comment c in cLinq)
                        {
                            i++;
                        }
                        DisplayPost temp = new DisplayPost(s.Name, p.Title, u.Name, p.TimeStamp, p.PostContent, p.Score, count, i, logged);
                        displays.Add(temp);
                        count++;
                    }
                }
            }

            foreach (DisplayPost d in displays)
            {
                d.PostPanel.Click += new EventHandler(panel1_Click);
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
            List<DisplayComment> displays = new List<DisplayComment>();

            ReadInputFiles(users, subreddits, posts, comments);

            Form newForm = new Form();
            newForm.Size = new Size(880, 500);
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
            System.Windows.Forms.Label commentLabel = new System.Windows.Forms.Label();
            System.Windows.Forms.Button submitComment = new System.Windows.Forms.Button();


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
                    userLabel.Location = new Point(x + x2 - 7, 9);
                }

                int x3 = userLabel.PreferredWidth;

                timeLabel = new System.Windows.Forms.Label();
                timeLabel.ForeColor = Color.Gray;
                timeLabel.AutoSize = true;
                timeLabel.Font = new Font("Verdana", 8);
                timeLabel.Location = new Point(x + x2 + x3 - 7, 9);

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

            commentBox.Enter += new EventHandler(commentBox_Enter);
            commentBox.Leave += new EventHandler(commentBox_Leave);
            commentBox_SetText();

            commentBox.Multiline = true;
            commentBox.Size = new Size(740, 200);
            commentBox.Location = new Point(12, 100);
            commentBox.SelectionStart = 0;

            int count = 0;

            submitComment.Text = "Comment";
            submitComment.Location = new Point(678, 300);
            submitComment.BackColor = Color.White;
            submitComment.Font = new Font("Verdana", 8);
            submitComment.Click += new EventHandler(submitComment_Click);

            if (!logged)
            {
                submitComment.Enabled = false;
            }
            if (logged)
            {
                submitComment.Enabled = true;
            }

            var cLinq = from C in comments
                        orderby C.Score descending
                        select C;

            foreach (Comment c in cLinq)
            {
                var pLinq = from P in posts
                            where P.Id == c.ParentID
                            select P;

                var uLinq = from U in users
                            where U.Id == c.AuthorID
                            select U;

                foreach (Post p1 in pLinq.Where(xyz => xyz.Title == title.Trim()))
                {
                    foreach (User u in uLinq)
                    {
                        DisplayComment temp = new DisplayComment(u.Name, c.Score, c.TimeStamp, c.Content, count, loggedUser);
                        displays.Add(temp);
                        count++;
                    }
                }
            }

            int i = 0;

            foreach (DisplayComment d in displays)
            {
                d.commentPanel.AutoSize = true;
                newForm.Controls.Add(d.commentPanel);
                i++;
            }

            commentLabel = new System.Windows.Forms.Label();
            commentLabel.ForeColor = Color.Gray;
            commentLabel.AutoSize = true;

            if (i > 1 || i == 0)
            {
                commentLabel.Text = i + " comments";
                commentLabel.Font = new Font("Verdana", 8);
                commentLabel.Location = new Point(35, 104);
            }
            else
            {
                commentLabel.Text = i + " comment";
                commentLabel.Font = new Font("Verdana", 8);
                commentLabel.Location = new Point(35, 104);
            }

            System.Windows.Forms.PictureBox commentIcon = new System.Windows.Forms.PictureBox();
            commentIcon.Image = System.Drawing.Image.FromFile("..\\..\\comment_icon.png");
            commentIcon.SizeMode = PictureBoxSizeMode.AutoSize;
            commentIcon.Location = new Point(12, 100);

            newForm.Controls.Add(redditLabel);
            newForm.Controls.Add(titleLabel);
            newForm.Controls.Add(contentLabel);
            newForm.Controls.Add(userLabel);
            newForm.Controls.Add(timeLabel);
            newForm.Controls.Add(commentBox);
            newForm.Controls.Add(commentIcon);
            newForm.Controls.Add(commentLabel);
            newForm.Controls.Add(submitComment);

            newForm.ActiveControl = redditLabel;
            newForm.AutoScroll = true;

            newForm.ShowDialog();

            //Function and event handlers for the comment box
            void commentBox_SetText()
            {
                if (logged)
                {
                    commentBox.Text = "What are your thoughts?";
                    commentBox.ForeColor = Color.Gray;
                    return;
                }
                if (!logged)
                {
                    commentBox.Text = "Please log in to comment.";
                    commentBox.ForeColor = Color.Gray;
                    commentBox.Enabled = false;
                    return;
                }

            }
            void commentBox_Enter(object sender2, EventArgs e2)
            {
                if (commentBox.ForeColor == Color.Black)
                {
                    return;
                }
                commentBox.Text = "";
                commentBox.ForeColor = Color.Black;
            }
            void commentBox_Leave(object sender3, EventArgs e3)
            {
                if (commentBox.Text.Trim() == "")
                {
                    commentBox_SetText();
                }
            }
            void submitComment_Click(object sender4, EventArgs e4)
            {
                //If text box is empty
                if (commentBox.Text == "What are your thoughts?")
                {
                    MessageBox.Show("Please enter a comment!"); //Just to show it works
                }
                DateTime time = DateTime.Now;

                DisplayComment temp = new DisplayComment(loggedUser, 1, time, commentBox.Text, count, loggedUser);
                displays.Insert(0, temp);
                count++;

                foreach (DisplayComment d in displays)
                {
                    d.commentPanel.AutoSize = true;
                    newForm.Controls.Add(d.commentPanel);
                }

                using (StreamWriter w = File.AppendText(@"..\\..\\comments.txt"))
                {
                    int min = 0000;
                    int max = 9999;
                    Random rng = new Random();
                    int id = rng.Next(min, max);

                    foreach (Post p2 in posts.Where(xy => xy.Title == titleLabel.Text.Trim()))
                    {
                        foreach (User u in users.Where(x => x.Name == loggedUser))
                        {
                            w.WriteLine();
                            w.WriteLine(id + "\t" + u.Id + "\t" + commentBox.Text + "\t" + p2.Id + "\t" + 1 + "\t" + 0 + "\t" + time.Year + "\t" + time.Month + "\t" + time.Day
                                + "\t" + time.Hour + "\t" + time.Minute + "\t" + time.Second + "\t" + 0 + "\t" + 0 + "\t" + 0);
                        }
                    }
                }
                commentBox.Text = "What are your thoughts?";
                commentBox.ForeColor = Color.Gray;
            }
        }

        //Event handler for when user clicks the log in button
        private void logInButton_Click(object sender, EventArgs e)
        {
            if (logInButton.Text == "Log Out")
            {
                logInButton.Text = "Log In";
                userLabel.Text = null;
                karmaLabel.Text = " ";

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

                    logged = false;

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
                            loggedUser = userLabel.Text;
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
            int test = 0;
            var pLinq = from P in posts
                        orderby P.Score descending
                        select P;

            if (temp == "Home")
            {
                foreach (Post p in pLinq)
                {
                    int i = 0;

                    var srLinq = from S in subreddits
                                 where S.Id == p.SubHome
                                 select S;

                    var uLinq = from U in users
                                where U.Id == p.AuthorID
                                select U;

                    var cLinq = from C in comments
                                where C.ParentID == p.Id
                                select C;

                    foreach (Subreddit s in srLinq)
                    {
                        foreach (User u in uLinq)
                        {
                            foreach (Comment c in cLinq)
                            {
                                i++;
                            }

                            DisplayPost temp2 = new DisplayPost(s.Name, p.Title, u.Name, p.TimeStamp, p.PostContent, p.Score, count, i, logged);
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
                    int i = 0;

                    var srLinq = from S in subreddits
                                 where S.Id == p.SubHome
                                 where S.Name == temp
                                 select S;

                    var uLinq = from U in users
                                where U.Id == p.AuthorID
                                select U;

                    var cLinq = from C in comments
                                where C.ParentID == p.Id
                                select C;

                    foreach (Subreddit s in srLinq)
                    {
                        foreach (User u in uLinq)
                        {
                            foreach (Comment c in cLinq)
                            {
                                i++;
                            }
                            DisplayPost temp2 = new DisplayPost(s.Name, p.Title, u.Name, p.TimeStamp, p.PostContent, p.Score, count, i, logged);
                            displays.Add(temp2);
                            count++;
                        }
                    }
                }
                foreach (DisplayPost d in displays)
                {
                    d.PostPanel.Tag = d.titleLabel;
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
                        int i = 0;

                        var srLinq = from S in subreddits
                                     where S.Id == p.SubHome
                                     select S;

                        var uLinq = from U in users
                                    where U.Id == p.AuthorID
                                    select U;

                        var cLinq = from C in comments
                                    where C.ParentID == p.Id
                                    select C;

                        foreach (Subreddit s in srLinq)
                        {
                            foreach (User u in uLinq)
                            {
                                foreach (Comment c in cLinq)
                                {
                                    i++;
                                }
                                if (p.PostContent.ToLower().Contains(temp) || p.Title.ToLower().Contains(temp))
                                {
                                    DisplayPost temp2 = new DisplayPost(s.Name, p.Title, u.Name, p.TimeStamp, p.PostContent, p.Score, count, i, logged);
                                    displays.Add(temp2);
                                    count++;
                                }
                            }
                        }
                    }
                    foreach (DisplayPost d in displays)
                    {
                        d.PostPanel.Tag = d.titleLabel;
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