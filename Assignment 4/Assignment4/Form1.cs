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
            /*public System.Windows.Forms.Label timeLabel;
            public System.Windows.Forms.Label scoreLabel;*/
            
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

            public DisplayPost()
            {
                postPanel = new System.Windows.Forms.Panel();

                redditLabel = new System.Windows.Forms.Label();

                userLabel = new System.Windows.Forms.Label();


            }

            public DisplayPost(string reddit, string author, int count)
            {
                postPanel = new System.Windows.Forms.Panel();

                redditLabel = new System.Windows.Forms.Label();
                redditLabel.ForeColor = Color.White;
                redditLabel.Text = "r/" + reddit;
                redditLabel.AutoSize = true;
                //redditLabel.Location = new Point(10, 10 * count);
                //redditLabel.Top = 10 * count;
                //redditLabel.Left = 10;

                userLabel = new System.Windows.Forms.Label();
                userLabel.ForeColor = Color.Gray;
                userLabel.Text = " | u/" + author;
                userLabel.AutoSize = true;
                userLabel.Location = new Point(redditLabel.PreferredWidth, redditLabel.Location.Y);
                                
                postPanel.Controls.Add(redditLabel);
                postPanel.Controls.Add(userLabel);
                postPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                postPanel.AutoSize = true;
                postPanel.Location = new Point(10, postPanel.Height * count);
                //postPanel.Location = new Point(MenuStrip.Siz)
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
                        DisplayPost temp = new DisplayPost(s.Name, u.Name, count);
                        //temp.redditLabel.Location = new Point(10, 10 * count);
                        displays.Add(temp);

                        //mainPanel.Controls.Add(temp.redditLabel);
                        
                        //temp.Location = new Point(temp.Height, temp.Width * count);
                       // previous = temp.Location;
                       // panel1.Controls.Add(temp);
                        count++;
                        
                    }
                }
                           

            }

            //MessageBox.Show(count.ToString());
            foreach (DisplayPost d in displays)
            {
                
                mainPanel.Controls.Add(d.postPanel);
                
                //count++;
            }
        }


    }
}
