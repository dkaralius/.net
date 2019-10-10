/********************************************************
 *  PROGRAM : Assignment3                               *
 *                                                      *
 *  PROGRAMMERS : Josue Ballona and Dominykas Karalius  *
 *  ZID : Z1832823 and Z1809478                         *
 *                                                      *
 *  DATE : 10/10/2019 Thursday, October 10th 2019       *
 *                                                      *
 *                                                      *
 * This program mimics the popular application "Reddit",*
 * but this time we have a GUI. The program reads       *
 * provided .txt input files and stores that            *
 * information into SortedSet<> objects. Information    *
 * such as users, subreddits, posts, and comments.      *
 * The user of the program can choose from a variety    *
 * of actions to perfrom; view posts that were posted   *
 * on a specfic date, view lowest,average,highest post- *
 * score per subreddit and user, we can also view the   *
 * awards a subreddit has gotten (silver,gold,platinum),*
 * and finally we can view posts that are within a      *
 * designated score range                               *
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

namespace Assignment3
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

            userButton.Enabled = false;
            postScoreSubreddit.Enabled = false;
            postScoreUser.Enabled = false;

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            List<Post> posts = new List<Post>();
            List<Comment> comments = new List<Comment>();
            ReadInputFiles(users, subreddits, posts, comments);

            //Populate comboBox with users
            foreach (User u in users)
            {
                userBox.Items.Add(u.Name);
            }

            //Populate comboBox with subreddits
            foreach (Subreddit s in subreddits)
            {
                if (s.Name == "all")
                    continue;
                subredditBox.Items.Add(s.Name);
            }
        }
        private void TimeButton_Click_1(object sender, EventArgs e)
        {
            outPutBox.Items.Clear();

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            List<Post> posts = new List<Post>();
            List<Comment> comments = new List<Comment>();
            List<Post> tempPosts = new List<Post>(); //Temporary list of posts that fit the date user selects

            ReadInputFiles(users, subreddits, posts, comments);

            int tempYear = dateTimePicker.Value.Year;
            int tempMonth = dateTimePicker.Value.Month;
            int tempDay = dateTimePicker.Value.Day;

            outPutBox.Items.Add("All posts from " + tempMonth + "/" + tempDay + "/" + tempYear + ":");
            outPutBox.Items.Add("--------------------------------------------------------------------------------------------------------------------------------------------------");

            //Query that outputs all posts that match the date provided by user
            IEnumerable<Post> postQuery =
                from p in posts
                where p.TimeStamp.Year == tempYear
                where p.TimeStamp.Month == tempMonth
                where p.TimeStamp.Day == tempDay
                select p;

            //Takes result of the query, and creates temporory Post collection
            foreach (Post p in postQuery)
            {
                tempPosts.Add(p);
            }

            if (tempPosts.Count() == 0)//If no posts match the date entered, print message to notify user
            {
                outPutBox.Items.Add("No posts found!");
            }
            else
            {
                foreach (Post p in tempPosts)
                {
                    foreach (User u in users.Where(x => x.Id == p.AuthorID))
                    {
                        foreach (Subreddit s in subreddits.Where(x => x.Id == p.SubHome))
                        {
                            if (p.Title.Length > 35)//If the title of the post is too long, truncate it and add "..."
                            {
                                p.Title = p.Title.Substring(0, 35);
                                outPutBox.Items.Add("<" + p.Id + ">  [" + s.Name + "]  (" + p.UpVotes + ") " + p.Title + "... - " + u.Name + " |" + p.TimeStamp + "|");
                            }
                            else//Else title is short, so just print the whole thing
                            {
                                outPutBox.Items.Add("<" + p.Id + ">  [" + s.Name + "]  (" + p.UpVotes + ") " + p.Title + " - " + u.Name + " |" + p.TimeStamp + "|");
                            }
                        }
                    }
                }
                outPutBox.Items.Add("");
                outPutBox.Items.Add("");
                outPutBox.Items.Add("*** END OF QUERY RESULTS ***");
            }
        }
        private void userBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            postScoreSubreddit.Enabled = false;
            postScoreUser.Enabled = false;

            if (userBox.SelectedItem != null)
            {
                userButton.Enabled = true;
            }
        }
        private void subredditButton_Click(object sender, EventArgs e)
        {
            outPutBox.Items.Clear();
            postScoreSubreddit.Enabled = false;
            postScoreUser.Enabled = false;

            string tempSubreddit = subredditBox.SelectedItem.ToString();

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            List<Post> posts = new List<Post>();
            List<Comment> comments = new List<Comment>();

            List<Post> tempPosts = new List<Post>();
            List<Comment> tempComments = new List<Comment>();

            ReadInputFiles(users, subreddits, posts, comments);

            String awards; // string for title

            bool silver = false;
            bool gold = false;
            bool plat = false;

            // check which boxes are checked and fix the title accordingly
            if (silverBox.Checked && goldBox.Checked && platBox.Checked)
            {
                awards = silverBox.Text + ", " + goldBox.Text + ", and " + platBox.Text;
                silver = gold = plat = true;
            }
            else if (silverBox.Checked && goldBox.Checked && !platBox.Checked)
            {
                awards = silverBox.Text + ", and " + goldBox.Text;
                silver = gold = true;
            }
            else if (silverBox.Checked && !goldBox.Checked && platBox.Checked)
            {
                awards = silverBox.Text + ", and " + platBox.Text;
                silver = plat = true;
            }
            else if (!silverBox.Checked && goldBox.Checked && platBox.Checked)
            {
                awards = goldBox.Text + ", and " + platBox.Text;
                gold = plat = true;
            }
            else if (silverBox.Checked && !goldBox.Checked && !platBox.Checked)
            {
                awards = silverBox.Text;
                silver = true;
            }
            else if (!silverBox.Checked && goldBox.Checked && !platBox.Checked)
            {
                awards = goldBox.Text;
                gold = true;
            }
            else if (!silverBox.Checked && !goldBox.Checked && platBox.Checked)
            {
                awards = platBox.Text;
                plat = true;
            }
            else
            {
                outPutBox.Items.Add("Please select an award type.");
                return;
            }

            //print headers
            outPutBox.Items.Add(awards + " awards for '" + subredditBox.SelectedItem.ToString() + "' Subreddit :");
            outPutBox.Items.Add("--------------------------------------------------------------------------------------------------------------------------------------------------");

            // find the subreddit user selected
            var subredditQ = from S in subreddits
                             where S.Name.CompareTo(subredditBox.SelectedItem.ToString()) == 0
                             select S;

            // counters for the various awards
            int[] silvercount = new int[3];
            int[] goldcount = new int[3];
            int[] platcount = new int[3];

            // for the subreddit chosen
            foreach (var s in subredditQ)
            {
                // find posts that are in the chosen subreddit
                IEnumerable<Post> postQ = from P in posts
                            where P.SubHome == s.Id
                            select P;
                
                
                // put posts in temporary list
                foreach (Post p in postQ)
                {
                    tempPosts.Add(p);
                }             
                // if empty
                if (tempPosts.Count == 0)
                {
                    outPutBox.Text = "No posts found with the given criteria.";
                }
                else
                {                    
                    foreach (Post tp in tempPosts)
                    {
                        // if parent id matches the post id, select that comment
                        IEnumerable<Comment> commentQ = from C in comments
                                       where C.ParentID == tp.Id
                                       select C;

                        // add awards depending on which boxes are checked
                        if (silver)
                        {
                            silvercount[0] = silvercount[0] + tp.Awards[0];
                        }
                        if (gold)
                        {
                            goldcount[0] += tp.Awards[1];
                        }
                        if (plat)
                        {
                            platcount[0] += tp.Awards[2];
                        }

                        // for each comment, add it into a temporary list
                        foreach (Comment c in commentQ)
                        {
                            tempComments.Add(c);
                        }

                        if (tempComments.Count() == 0)
                        {
                            outPutBox.Text = "No comments found with the given criteria.";
                        }
                        else
                        {
                            foreach (Comment c in tempComments)
                            {
                                //temporary id
                                uint tempId = c.ID;

                                // for each comment where the parent id matches the id of a comment
                                var cQ1 = from C in comments
                                          where C.ParentID == tempId
                                          select C;


                                // check if boxes are checked and add awards
                                if (silver)
                                {
                                    silvercount[1] += c.Awards[0];
                                }
                                if (gold)
                                {
                                    goldcount[1] += c.Awards[1];
                                }
                                if (plat)
                                {
                                    platcount[1] += c.Awards[2];
                                }

                                // check if boxes are checked and add awards
                                // for every reply to a comment
                                foreach (var c1 in cQ1)
                                {
                                    if (silver)
                                    {
                                        silvercount[2] += c.Awards[0];
                                    }
                                    if (gold)
                                    {
                                        goldcount[2] += c.Awards[1];
                                    }
                                    if (plat)
                                    {
                                        platcount[2] += c.Awards[1];
                                    }
                                }
                            }
                        }
                    }

                }

                // outputs based on what box is checked
                if (silver)
                {
                    outPutBox.Items.Add("\tSilver Awards for Posts: " + silvercount[0]);
                    outPutBox.Items.Add("\tSilver Awards for Top Line Comments: " + silvercount[1]);
                    outPutBox.Items.Add("\tSilver Awards for Comment Replies: " + silvercount[2]);
                    outPutBox.Items.Add("");
                    outPutBox.Items.Add("");
                }
                if (gold)
                {
                    outPutBox.Items.Add("\tGold Awards for Posts: " + goldcount[0]);
                    outPutBox.Items.Add("\tGold Awards for Top Line Comments: " + goldcount[1]);
                    outPutBox.Items.Add("\tGold Awards for Comment Replies: " + goldcount[2]);
                    outPutBox.Items.Add("");
                    outPutBox.Items.Add("");
                }
                if (plat)
                {
                    outPutBox.Items.Add("\tPlatinum Awards for Posts: " + platcount[0]);
                    outPutBox.Items.Add("\tPlatinum Awards for Top Line Comments: " + platcount[1]);
                    outPutBox.Items.Add("\tPlatinum Awards for Comment Replies: " + platcount[2]);
                    outPutBox.Items.Add("");
                    outPutBox.Items.Add("");
                }

                outPutBox.Items.Add("*** END OF QUERY RESULTS ***");

            }
        }
        private void userButton_Click(object sender, EventArgs e)
        {
            outPutBox.Items.Clear();
            postScoreSubreddit.Enabled = false;
            postScoreUser.Enabled = false;

            string tempUser = userBox.SelectedItem.ToString();

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            List<Post> posts = new List<Post>();
            List<Comment> comments = new List<Comment>();

            List<Post> tempPosts = new List<Post>(); //Temporary list of posts that are created by username that user selects
            SortedSet<Subreddit> tempSubreddits = new SortedSet<Subreddit>();

            ReadInputFiles(users, subreddits, posts, comments);


            outPutBox.Items.Add("Subreddits Posted To By '" + userBox.SelectedItem.ToString() + "':");
            outPutBox.Items.Add("--------------------------------------------------------------------------------------------------------------------------------------------------");

            //Query that outputs all posts that match the date provided by user
            IEnumerable<Post> postQuery =
                from p in posts
                from u in users
                where u.Name == userBox.SelectedItem.ToString()
                where p.AuthorID == u.Id
                select p;

            foreach (Post p in postQuery)
            {
                tempPosts.Add(p);
            }

            //Query that outputs all subreddits that match the post's subreddit ID
            IEnumerable<Subreddit> postQuery2 =
                from p in tempPosts
                from s in subreddits
                where p.SubHome == s.Id
                select s;

            //Adds each subreddit from each post made by user, to temporary subreddit collection.(Removes duplicates, since its sortedset
            foreach (Subreddit s in postQuery2)
            {
                tempSubreddits.Add(s);
            }
            //Checks to see if selected user has made any posts
            if (tempSubreddits.Count == 0)
            {
                outPutBox.Items.Add("User has not made any posts yet!");
            }
            else
            {
                //Print results
                foreach (Subreddit s in tempSubreddits)
                {
                    outPutBox.Items.Add(s.Name.PadLeft(20) + Environment.NewLine);
                }
                outPutBox.Items.Add("");
                outPutBox.Items.Add("");
                outPutBox.Items.Add("*** END OF QUERY RESULTS ***");
            }
        }

        //Methods for when each radio button is clicked. Simply enables the "Query" button
        private void Lowest_CheckedChanged(object sender, EventArgs e)
        {
            postScoreSubreddit.Enabled = true;
            lowestUser.Checked = false;
            averageUser.Checked = false;
            highestUser.Checked = false;
            subredditButton.Enabled = false;
            pointsThresholdButton.Enabled = false;
            postScoreSubreddit.Enabled = true;
        }
        private void Average_CheckedChanged(object sender, EventArgs e)
        {
            postScoreSubreddit.Enabled = true;
            lowestUser.Checked = false;
            averageUser.Checked = false;
            highestUser.Checked = false;
            subredditButton.Enabled = false;
            pointsThresholdButton.Enabled = false;
            postScoreSubreddit.Enabled = true;
        }
        private void Highest_CheckedChanged(object sender, EventArgs e)
        {
            postScoreSubreddit.Enabled = true;
            lowestUser.Checked = false;
            averageUser.Checked = false;
            highestUser.Checked = false;
            subredditButton.Enabled = false;
            pointsThresholdButton.Enabled = false;
            postScoreSubreddit.Enabled = true;

        }
        private void lowestUser_CheckedChanged(object sender, EventArgs e)
        {
            postScoreUser.Enabled = true;
            Lowest.Checked = false;
            Average.Checked = false;
            Highest.Checked = false;
            subredditButton.Enabled = false;
            pointsThresholdButton.Enabled = false;
            postScoreSubreddit.Enabled = false;
        }
        private void averageUser_CheckedChanged(object sender, EventArgs e)
        {
            postScoreUser.Enabled = true;
            Lowest.Checked = false;
            Average.Checked = false;
            Highest.Checked = false;
            subredditButton.Enabled = false;
            pointsThresholdButton.Enabled = false;
            postScoreSubreddit.Enabled = false;
        }
        private void highestUser_CheckedChanged(object sender, EventArgs e)
        {
            postScoreUser.Enabled = true;
            Lowest.Checked = false;
            Average.Checked = false;
            Highest.Checked = false;
            subredditButton.Enabled = false;
            pointsThresholdButton.Enabled = false;
            postScoreSubreddit.Enabled = false;
        }

        //Query buttons
        private void postScoreButton_Click(object sender, EventArgs e)
        {
            
            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            SortedSet<Subreddit> tempSubreddits = new SortedSet<Subreddit>();
            List<Post> posts = new List<Post>();
            List<Comment> comments = new List<Comment>();

            ReadInputFiles(users, subreddits, posts, comments);

            postScoreUser.Enabled = false;

            if (Highest.Checked)
            {
                outPutBox.Items.Clear();
                outPutBox.Sorted = true;

                var maxScore =
                    from p in posts
                    group p by p.SubHome into subGroup
                    select new
                    {
                        subreddit = subGroup.Key,
                        max = subGroup.Max(x => x.Score),
                    };

                foreach (var v in maxScore)
                {
                    foreach (Subreddit s in subreddits.Where(x => x.Id == v.subreddit))
                    {
                        outPutBox.Items.Add(s.Name.PadLeft(30) + " --- " + v.max.ToString().PadLeft(10));
                    }
                }

                outPutBox.Sorted = false;

                ListItem temp = new ListItem("Highest Scored Posts For Each Subreddit: ", "value");
                outPutBox.Items.Insert(0, temp);
                ListItem temp2 = new ListItem("--------------------------------------------------------------------------------------------------------------------------------------------------", "value");
                outPutBox.Items.Insert(1, temp2);
                ListItem temp3 = new ListItem("*** END OF QUERY RESULTS ***", "value");
                outPutBox.Items.Add("");
                outPutBox.Items.Add("");
                outPutBox.Items.Add(temp3);
            }
            if (Average.Checked)
            {
                outPutBox.Items.Clear();
                outPutBox.Sorted = true;

                var avgScore =
                    from p in posts
                    group p by p.SubHome into subGroup
                    select new
                    {
                        subreddit = subGroup.Key,
                        avg = subGroup.Average(x => x.Score),
                    };

                foreach (var v in avgScore)
                {
                    foreach (Subreddit s in subreddits.Where(x => x.Id == v.subreddit))
                    {
                        outPutBox.Items.Add(s.Name.PadLeft(30) + " --- " + v.avg.ToString("#.00").PadLeft(10));
                    }
                }

                outPutBox.Sorted = false;

                ListItem temp = new ListItem("Average Score Of Posts For Each Subreddit: ", "value");
                outPutBox.Items.Insert(0, temp);
                ListItem temp2 = new ListItem("--------------------------------------------------------------------------------------------------------------------------------------------------", "value");
                outPutBox.Items.Insert(1, temp2);
                ListItem temp3 = new ListItem("*** END OF QUERY RESULTS ***", "value");
                outPutBox.Items.Add("");
                outPutBox.Items.Add("");
                outPutBox.Items.Add(temp3);
            }
            if (Lowest.Checked)
            {
                outPutBox.Items.Clear();
                outPutBox.Sorted = true;

                var minScore =
                    from p in posts
                    group p by p.SubHome into subGroup
                    select new
                    {
                        subreddit = subGroup.Key,
                        min = subGroup.Min(x => x.Score),
                    };

                foreach (var v in minScore)
                {
                    foreach (Subreddit s in subreddits.Where(x => x.Id == v.subreddit))
                    {
                        outPutBox.Items.Add(s.Name.PadLeft(30) + " --- " + v.min.ToString().PadLeft(10));
                    }
                }

                outPutBox.Sorted = false;

                ListItem temp = new ListItem("Lowest Scored Posts For Each Subreddit: ", "value");
                outPutBox.Items.Insert(0, temp);
                ListItem temp2 = new ListItem("--------------------------------------------------------------------------------------------------------------------------------------------------", "value");
                outPutBox.Items.Insert(1, temp2);
                ListItem temp3 = new ListItem("*** END OF QUERY RESULTS ***", "value");
                outPutBox.Items.Add("");
                outPutBox.Items.Add("");
                outPutBox.Items.Add(temp3);
            }
        }
        private void postScoreUser_Click(object sender, EventArgs e)
        {
            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            SortedSet<Subreddit> tempSubreddits = new SortedSet<Subreddit>();
            List<Post> posts = new List<Post>();
            List<Comment> comments = new List<Comment>();

            ReadInputFiles(users, subreddits, posts, comments);

            Lowest.Checked = false;
            Average.Checked = false;
            Highest.Checked = false;

            postScoreSubreddit.Enabled = false;

            if (highestUser.Checked)
            {
                outPutBox.Items.Clear();
                outPutBox.Sorted = true;

                var maxScore =
                    from u in users
                    from p in posts
                    where p.AuthorID == u.Id
                    group p by u.Id into userGroup
                    select new
                    {
                        user = userGroup.Key,
                        max = userGroup.Max(x => x.Score),
                    };

                foreach (var v in maxScore)
                {
                    foreach (User u in users.Where(x => x.Id == v.user))
                    {
                        outPutBox.Items.Add(u.Name.PadLeft(30) + " --- " + v.max.ToString().PadLeft(10));
                    }
                }

                outPutBox.Sorted = false;

                ListItem temp = new ListItem("Highest Scored Posts For Each User: ", "value");
                outPutBox.Items.Insert(0, temp);
                ListItem temp2 = new ListItem("--------------------------------------------------------------------------------------------------------------------------------------------------", "value");
                outPutBox.Items.Insert(1, temp2);
                ListItem temp3 = new ListItem("*** END OF QUERY RESULTS ***", "value");
                outPutBox.Items.Add("");
                outPutBox.Items.Add("");
                outPutBox.Items.Add(temp3);
            }
            if (averageUser.Checked)
            {
                outPutBox.Items.Clear();
                outPutBox.Sorted = true;

                var avgScore =
                    from u in users
                    from p in posts
                    where p.AuthorID == u.Id
                    group p by u.Id into userGroup
                    select new
                    {
                        user = userGroup.Key,
                        avg = userGroup.Average(x => x.Score),
                    };

                foreach (var v in avgScore)
                {
                    foreach (User u in users.Where(x => x.Id == v.user))
                    {
                        outPutBox.Items.Add(u.Name.PadLeft(30) + " --- " + v.avg.ToString("#.00").PadLeft(10));
                    }
                }

                outPutBox.Sorted = false;

                ListItem temp = new ListItem("Average Score Of Posts For Each User: ", "value");
                outPutBox.Items.Insert(0, temp);
                ListItem temp2 = new ListItem("--------------------------------------------------------------------------------------------------------------------------------------------------", "value");
                outPutBox.Items.Insert(1, temp2);
                ListItem temp3 = new ListItem("*** END OF QUERY RESULTS ***", "value");
                outPutBox.Items.Add("");
                outPutBox.Items.Add("");
                outPutBox.Items.Add(temp3);

            }
            if (lowestUser.Checked)
            {
                outPutBox.Items.Clear();
                outPutBox.Sorted = true;

                var minScore =
                    from u in users
                    from p in posts
                    where p.AuthorID == u.Id
                    group p by u.Id into userGroup
                    select new
                    {
                        user = userGroup.Key,
                        min = userGroup.Min(x => x.Score),
                    };

                foreach (var v in minScore)
                {
                    foreach (User u in users.Where(x => x.Id == v.user))
                    {
                        outPutBox.Items.Add(u.Name.PadLeft(30) + " --- " + v.min.ToString().PadLeft(10));
                    }
                }

                outPutBox.Sorted = false;

                ListItem temp = new ListItem("Lowest Scored Posts For Each User: ", "value");
                outPutBox.Items.Insert(0, temp);
                ListItem temp2 = new ListItem("--------------------------------------------------------------------------------------------------------------------------------------------------", "value");
                outPutBox.Items.Insert(1, temp2);
                ListItem temp3 = new ListItem("*** END OF QUERY RESULTS ***", "value");
                outPutBox.Items.Add("");
                outPutBox.Items.Add("");
                outPutBox.Items.Add(temp3);
            }
        }

        private void subredditBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            subredditButton.Enabled = true;
        }

        private void pointsThresholdButton_Click(object sender, EventArgs e)
        {
            pointsThresholdButton.Enabled = false;

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            SortedSet<Subreddit> tempSubreddits = new SortedSet<Subreddit>();
            List<Post> posts = new List<Post>();
            List<Post> tempPost = new List<Post>();
            List<Comment> comments = new List<Comment>();

            ReadInputFiles(users, subreddits, posts, comments);

            int selectedScore = Convert.ToInt32(scoreUpDown.Value);

            outPutBox.Items.Clear();

            // if less than or equal to
            if (lessOrEqual.Checked)
            {

                // header
                outPutBox.Items.Add("List of Posts/Comments With a Score Less than or Equal To " + selectedScore + ":");
                outPutBox.Items.Add("--------------------------------------------------------------------------------------------------------------------------------------------------");
                outPutBox.Items.Add("Posts:");

                // select posts where the score is less than selected score
                var postQ = from P in posts
                            where P.Score <= selectedScore
                            select P;

                // add to temporary list
                foreach (var p in postQ)
                {
                    tempPost.Add(p);
                }

                foreach (var p in tempPost)
                {
                    if (p.Title == null)
                        continue;
                    if(p.Title.Length > 35)//If the title of the post is too long, truncate it and add "..."
                    {
                        p.Title = p.Title.Substring(0, 35);
                        outPutBox.Items.Add("\t" + p.Title.PadLeft(35) + "... -- ".PadLeft(7) + p.Score.ToString().PadLeft(10));
                    }
                    else//Else title is short, so just print the whole thing
                    {
                        outPutBox.Items.Add("\t" + p.Title.PadLeft(35) + " -- ".PadLeft(7) + p.Score.ToString().PadLeft(10));
                    }
                }

                outPutBox.Items.Add("");
                outPutBox.Items.Add("Top Level Comments:");

                // select comments where score is less than or equal to
                // and where the parent id is a post id
                var commentQ = from C in comments
                               where C.Score <= selectedScore
                               from P in posts
                               where C.ParentID == P.Id
                               select C;

                foreach (var c in commentQ)
                {
                    // program is reading empty (corrupted?) data and this line is a way to temporarily bypass it
                    if (c.Content == null)
                        continue;
                    if (c.Content.Length > 35)//If the title of the post is too long, truncate it and add "..."
                    {
                        c.Content = c.Content.Substring(0, 35);
                        outPutBox.Items.Add("\t" + c.Content.PadLeft(35) + "... -- ".PadLeft(7) + c.Score.ToString().PadLeft(10));
                    }
                    else//Else title is short, so just print the whole thing
                    {
                        outPutBox.Items.Add("\t" + c.Content.PadLeft(35) + " -- ".PadLeft(7) + c.Score.ToString().PadLeft(10));
                    }
                    
                }

                outPutBox.Items.Add("");
                outPutBox.Items.Add("Comment Replies:");

                // select comments
                var tempQ = from C in comments
                            select C;

                foreach (var t in tempQ)
                {
                    // select comments where parent id is a comment id 
                    // and score is less than or equal than selected score
                    var replyQ = from C in comments
                                 where C.ParentID == t.ID && C.Score <= selectedScore
                                 select C;

                    foreach (var r in replyQ)
                    {
                        if (r.Content == null)
                            continue;
                        if (r.Content.Length > 35)//If the title of the post is too long, truncate it and add "..."
                        {
                            r.Content = r.Content.Substring(0, 35);
                            outPutBox.Items.Add("\t" + r.Content.PadLeft(35) + "... -- ".PadLeft(7) + r.Score.ToString().PadLeft(10));
                        }
                        else//Else title is short, so just print the whole thing
                        {
                            outPutBox.Items.Add("\t" + r.Content.PadLeft(35) + " -- ".PadLeft(7) + r.Score.ToString().PadLeft(10));
                        }

                    }
                }

                outPutBox.Items.Add("");
                outPutBox.Items.Add("");
                outPutBox.Items.Add("*** END OF QUERY RESULTS ***");
            }
            else if (greaterOrEqual.Checked)
            {
                //headers
                outPutBox.Items.Add("List of Posts/Comments With a Score Greater than or Equal To " + selectedScore + ":");
                outPutBox.Items.Add("--------------------------------------------------------------------------------------------------------------------------------------------------");
                outPutBox.Items.Add("Posts:");

                // select posts with score greater than or equal to selected score
                var postQ = from P in posts
                            where P.Score >= selectedScore
                            select P;

                // add to temporary list
                foreach (var p in postQ)
                {
                    tempPost.Add(p);
                }

                foreach (var p in tempPost)
                {
                    if (p.Title == null)
                        continue;
                    if (p.Title.Length > 35)//If the title of the post is too long, truncate it and add "..."
                    {
                        p.Title = p.Title.Substring(0, 35);
                        outPutBox.Items.Add("\t" + p.Title.PadLeft(35) + "... -- ".PadLeft(7) + p.Score.ToString().PadLeft(10));
                    }
                    else//Else title is short, so just print the whole thing
                    {
                        outPutBox.Items.Add("\t" + p.Title.PadLeft(35) + " -- ".PadLeft(7) + p.Score.ToString().PadLeft(10));
                    }
                }

                outPutBox.Items.Add("");
                outPutBox.Items.Add("Top Level Comments:");

                var commentQ = from C in comments
                               from P in posts
                               where C.Score >= selectedScore && C.ParentID == P.Id
                               select C;

                foreach (var c in commentQ)
                {
                    if (c.Content == null)
                        continue;
                    if (c.Content.Length > 35)//If the title of the post is too long, truncate it and add "..."
                    {
                        c.Content = c.Content.Substring(0, 35);
                        outPutBox.Items.Add("\t" + c.Content.PadLeft(35) + "... -- ".PadLeft(7) + c.Score.ToString().PadLeft(10));
                    }
                    else//Else title is short, so just print the whole thing
                    {
                        outPutBox.Items.Add("\t" + c.Content.PadLeft(35) + " -- ".PadLeft(7) + c.Score.ToString().PadLeft(10));
                    }

                }

                outPutBox.Items.Add("");
                outPutBox.Items.Add("Comment Replies:");

                var replyQ = from C in comments
                             from C1 in comments
                             where C.ParentID == C1.ID && C.Score >= selectedScore
                             select C;

                foreach (var r in replyQ)
                {
                    if (r.Content == null)
                        continue;
                    if (r.Content.Length > 35)//If the title of the post is too long, truncate it and add "..."
                    {
                        r.Content = r.Content.Substring(0, 35);
                        outPutBox.Items.Add("\t" + r.Content.PadLeft(35) + "... -- ".PadLeft(7) + r.Score.ToString().PadLeft(10));
                    }
                    else//Else title is short, so just print the whole thing
                    {
                        outPutBox.Items.Add("\t" + r.Content.PadLeft(35) + " -- ".PadLeft(7) + r.Score.ToString().PadLeft(10));
                    }

                }

                outPutBox.Items.Add("");
                outPutBox.Items.Add("");
                outPutBox.Items.Add("*** END OF QUERY RESULTS ***");
            }
        }

        private void lessOrEqual_CheckedChanged(object sender, EventArgs e)
        {
            pointsThresholdButton.Enabled = true;
        }

        private void greaterOrEqual_CheckedChanged(object sender, EventArgs e)
        {
            pointsThresholdButton.Enabled = true;
        }

        private void scoreUpDown_ValueChanged(object sender, EventArgs e)
        {
            pointsThresholdButton.Enabled = true;
        }
    }
}