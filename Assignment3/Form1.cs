/********************************************************
 *  PROGRAM : Assignment3                               *
 *                                                      *
 *  PROGRAMMERS : Josue Ballona and Dominykas Karalius  *
 *  ZID : Z1832823 and Z1809478                         *
 *                                                      *
 *  DATE : 9/26/2019 Thursday, September 26th 2019      *
 *                                                      *
 *                                                      *
 * This program mimics the popular application "Reddit",*
 * but this time we have a GUI. The program reads       *
 * provided .txt input files and stores that            *
 * information into SortedSet<> objects. Information    *
 * such as users, subreddits, posts, and comments.      *
 * The user of the program can choose from a variety    *
 * of actions to perfrom; view users, view all posts,   *
 * view posts of single subreddit, and so on.           *
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

            //Constructor to take number of args as in the text file.
            public Post(string[] args)
            {
                int[] awards = new int[3];
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
        //Method that reads the text files for each object and creates SortedSet<> for each category
        public static void ReadInputFiles(SortedSet<User> users, SortedSet<Subreddit> subreddits, List<Post> posts)
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
            ReadInputFiles(users, subreddits, posts);

            //Populate comboBox with users
            foreach(User u in users)
            {
                userBox.Items.Add(u.Name);
            }
        }
        private void TimeButton_Click_1(object sender, EventArgs e)
        {
            outPutBox.Items.Clear();

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            List<Post> posts = new List<Post>();
            List<Post> tempPosts = new List<Post>(); //Temporary list of posts that fit the date user selects

            ReadInputFiles(users, subreddits, posts);

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
                    foreach(User u in users.Where(x => x.Id == p.AuthorID))
                    {
                        foreach(Subreddit s in subreddits.Where(x => x.Id == p.SubHome))
                        {
                            if (p.Title.Length > 35)//If the title of the post is too long, truncate it and add "..."
                            {
                                p.Title = p.Title.Substring(0, 35);
                                outPutBox.Items.Add( "<" + p.Id + ">  [" + s.Name + "]  (" + p.UpVotes + ") " + p.Title + "... - " + u.Name + " |" + p.TimeStamp + "|" + Environment.NewLine);
                            }
                            else//Else title is short, so just print the whole thing
                            {
                                outPutBox.Items.Add("<" + p.Id + ">  [" + s.Name + "]  (" + p.UpVotes + ") " + p.Title + " - " + u.Name + " |" + p.TimeStamp + "|" + Environment.NewLine);
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
        private void userButton_Click(object sender, EventArgs e)
        {
            outPutBox.Items.Clear();
            postScoreSubreddit.Enabled = false;
            postScoreUser.Enabled = false;

            string tempUser = userBox.SelectedItem.ToString();

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            List<Post> posts = new List<Post>();

            List<Post> tempPosts = new List<Post>(); //Temporary list of posts that are created by username that user selects
            SortedSet<Subreddit> tempSubreddits = new SortedSet<Subreddit>();

            ReadInputFiles(users, subreddits, posts);


            outPutBox.Items.Add("Subreddits Post To By '" + userBox.SelectedItem.ToString() + "':");
            outPutBox.Items.Add("--------------------------------------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);

            //Query that outputs all posts that match the date provided by user
            IEnumerable<Post> postQuery =
                from p in posts
                from u in users
                where u.Name == userBox.SelectedItem.ToString()
                where p.AuthorID == u.Id
                select p;

            foreach(Post p in postQuery)
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
            if(tempSubreddits.Count == 0)
            {
                outPutBox.Items.Add("User has not made any posts yet!");
            }
            else
            {
                //Print results
                foreach (Subreddit s in tempSubreddits)
                {
                    outPutBox.Items.Add(s.Name + Environment.NewLine);
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
            postScoreSubreddit.Enabled = true;
        }
        private void Average_CheckedChanged(object sender, EventArgs e)
        {
            postScoreSubreddit.Enabled = true;
            lowestUser.Checked = false;
            averageUser.Checked = false;
            highestUser.Checked = false;
            postScoreSubreddit.Enabled = true;
        }
        private void Highest_CheckedChanged(object sender, EventArgs e)
        {
            postScoreSubreddit.Enabled = true;
            lowestUser.Checked = false;
            averageUser.Checked = false;
            highestUser.Checked = false;
            postScoreSubreddit.Enabled = true;

        }
        private void lowestUser_CheckedChanged(object sender, EventArgs e)
        {
            postScoreUser.Enabled = true;
            Lowest.Checked = false;
            Average.Checked = false;
            Highest.Checked = false;
            postScoreSubreddit.Enabled = false;
        }
        private void averageUser_CheckedChanged(object sender, EventArgs e)
        {
            postScoreUser.Enabled = true;
            Lowest.Checked = false;
            Average.Checked = false;
            Highest.Checked = false;
            postScoreSubreddit.Enabled = false;
        }
        private void highestUser_CheckedChanged(object sender, EventArgs e)
        {
            postScoreUser.Enabled = true;
            Lowest.Checked = false;
            Average.Checked = false;
            Highest.Checked = false;
            postScoreSubreddit.Enabled = false;
        }

        //Query buttons
        private void postScoreButton_Click(object sender, EventArgs e)
        {
            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            SortedSet<Subreddit> tempSubreddits = new SortedSet<Subreddit>();
            List<Post> posts = new List<Post>();

            ReadInputFiles(users, subreddits, posts);

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
                        outPutBox.Items.Add(s.Name + " --- " + v.max);
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
                        outPutBox.Items.Add(s.Name + " --- " + v.avg.ToString("#.00"));
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
                        outPutBox.Items.Add(s.Name + " --- " + v.min);
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

            ReadInputFiles(users, subreddits, posts);

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
                        outPutBox.Items.Add(u.Name + " --- " + v.max);
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
                        outPutBox.Items.Add(u.Name + " --- " + v.avg.ToString("#.00"));
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
                        outPutBox.Items.Add(u.Name + " --- " + v.min);
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
    }
}
