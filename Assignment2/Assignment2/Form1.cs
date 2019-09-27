using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Form1 : Form
    {
        public class User : IComparable
        {
            private readonly uint id;
            private readonly string userType;
            private readonly string name;
            private readonly string passwordHash;
            private int postScore;
            private int commentScore;
            List<string> moderatingSubs;

            public uint Id { get => id; }
            public string Usertype { get => userType; }
            public string Name { get => name; }
            public string PasswordHash { get => passwordHash; }
            public int PostScore { get => postScore; set => postScore = value; }
            public int CommentScore { get => commentScore; set => commentScore = value; }

            public User()
            {
                id = 0;
                userType = "";
                name = "";
                postScore = 0;
                commentScore = 0;
            }
            public User(string[] args)
            {
                List<string> moderatingSubs = new List<string>();

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

            //Default constructor
            public Subreddit()
            {
                id = 0;
                name = "";
                members = 0;
                active = 0;
            }

            //Alternate constructor where all arguments are provided
            public Subreddit(uint id, string name, uint members, uint active)
            {
                this.id = id;
                this.name = name;
                this.members = members;
                this.active = active;
            }

            //Alternate constructor where only id and name are provided
            public Subreddit(uint id, string name)
            {
                this.id = id;
                this.name = name;
                members = 0;
                active = 0;
            }

            //Alternate constructor to take n number of args
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
        public class Post : IComparable
        {
            //Private variables
            readonly uint locked;
            readonly uint id;
            string title;
            readonly uint authorID;
            string postContent;
            readonly uint subHome;
            uint upVotes;
            uint downVotes;
            uint weight;
            readonly DateTime timeStamp;

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
            public uint UpVotes
            {
                get { return upVotes; }
                set { upVotes = value; }
            }
            public uint DownVotes
            {
                get { return downVotes; }
                set { downVotes = value; }
            }
            public uint Weight
            {
                get { return weight; }
                set { weight = value; }
            }
            public uint Score { get => upVotes - downVotes; }
            public uint PostRating
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

            //Default Constructor
            public Post()
            {
                locked = 0;
                id = 0;
                authorID = 0;
                title = "";
                postContent = "";
                subHome = 0;
                upVotes = 0;
                downVotes = 0;
                weight = 0;
                timeStamp = DateTime.Now;
            }

            //Alternate constructor where all arguments are provided
            public Post(uint locked, uint id, uint authorID, string title, string postContent, uint subHome, uint upVotes, uint downVotes, uint weight, int year, int month, int day, int hour, int minute, int second)
            {
                this.locked = locked;
                this.id = id;
                this.authorID = authorID;
                this.title = title;
                this.postContent = postContent;
                this.subHome = subHome;
                this.upVotes = upVotes;
                this.downVotes = downVotes;
                this.weight = weight;
                this.timeStamp = new DateTime(year, month, day, hour, minute, second);
            }

            //Alternate Constructor where only title, authorID, postContent, and subHome are provided
            public Post(uint id, uint authorID, string title, string postContent, uint subHome)
            {
                this.id = id;
                this.authorID = authorID;
                this.title = title;
                this.postContent = postContent;
                this.subHome = subHome;
                this.upVotes = 1;
                this.downVotes = 0;
                timeStamp = DateTime.Now;
            }

            //Alternate constructor to take n number of args
            public Post(string[] args)
            {
                if (args.Length == 15)
                {
                    locked = Convert.ToUInt32(args[0]);
                    id = Convert.ToUInt32(args[1]);
                    authorID = Convert.ToUInt32(args[2]);
                    title = Convert.ToString(args[3]);
                    postContent = Convert.ToString(args[4]);
                    subHome = Convert.ToUInt32(args[5]);
                    upVotes = Convert.ToUInt32(args[6]);
                    downVotes = Convert.ToUInt32(args[7]);
                    weight = Convert.ToUInt32(args[8]);

                    int year = Convert.ToInt32(args[9]);
                    int month = Convert.ToInt32(args[10]);
                    int day = Convert.ToInt32(args[11]);
                    int hour = Convert.ToInt32(args[12]);
                    int minute = Convert.ToInt32(args[13]);
                    int second = Convert.ToInt32(args[14]);

                    timeStamp = new DateTime(year, month, day, hour, minute, second);
                }
            }
            //Overriden CompareTo() to sort by post rating
            public int CompareTo(Object alpha)
            {
                if (alpha == null) throw new ArgumentNullException("argument bad");

                Post rightOp = alpha as Post;

                if (rightOp != null)
                    return PostRating.CompareTo(rightOp.PostRating);
                else
                    throw new ArgumentException("argument was not a post");
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
            SortedSet<Comment> commentReplies;

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
            public string Content {
                get { return content; }
                set { content = value; }
            }
            public DateTime TimeStamp { get => timeStamp; }

            //Default Constructor
            public Comment()
            {
                id = 0;
                authorID = 0;
                content = "";
                parentID = 0;
                upVotes = 0;
                downVotes = 0;
                timeStamp = new DateTime(0, 0, 0, 0, 0, 0);
            }

            //Alternate Constructor if all arguements are provided
            public Comment(uint id, uint authorID, string content, uint parentID, int upVotes, int downVotes, int year, int month, int day, int hour, int minute, int second)
            {
                this.id = id;
                this.authorID = authorID;
                this.content = content;
                this.parentID = parentID;
                this.upVotes = upVotes;
                this.downVotes = downVotes;
                this.timeStamp = new DateTime(year, month, day, hour, minute, second);
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
            }

            //Alternate constructor to take n number of args
            public Comment(string[] args)
            {
                if (args.Length == 12)
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

        public static void ReadInputFiles(SortedSet<User> users, SortedSet<Subreddit> subreddits, SortedSet<Post> posts, SortedSet<Comment> comments)
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

        public void printPosts(SortedSet<Post> posts)
        {
            string[] tokens = Subreddit_Output.SelectedItem.ToString().Split(' ');

            string subname = tokens[0];
            subname = subname.Trim();


        }
        public Form1()
        {
            InitializeComponent();

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            SortedSet<Post> posts = new SortedSet<Post>();
            SortedSet<Comment> comments = new SortedSet<Comment>();

            ReadInputFiles(users, subreddits, posts, comments);

            foreach (User u in users)
            {
                User_Output.Items.Add(u.Name + "   " + u.Usertype + "         (" + u.PostScore + " / " + u.CommentScore + ")" + Environment.NewLine);
            }
            foreach (Subreddit s in subreddits)
            {
                Subreddit_Output.Items.Add(s.Name + Environment.NewLine);
            }

            System_Output.Text = "Please select a user.";
        }

        private void User_Output_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] tokens = User_Output.SelectedItem.ToString().Split(' ');
            Subreddit_Output.SetSelected(0, true);
            
            System_Output.Text = "Please provide the password for User '" + tokens[0] + "'.";
            LogIn.Text = "Log-In";
            Delete_Post_Button.Enabled = false;
            Delete_Post_Button.Visible = false;
            Comments_Output.Items.Clear();
            Delete_Comment_Button.Visible = false;
            Reply_Input.ReadOnly = false;
        }

        private void LogIn_Click(object sender, EventArgs e)
        {

            string[] tokens = User_Output.SelectedItem.ToString().Split(' ');

            string username = tokens[0];
            string password = Password.Text;
            password = password.GetHashCode().ToString("X");

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            SortedSet<Post> posts = new SortedSet<Post>();
            SortedSet<Comment> comments = new SortedSet<Comment>();

            ReadInputFiles(users, subreddits, posts, comments);

            
            foreach (User u in users.Where(x => x.Name == username))
            {
                if (passwordCheck(u.PasswordHash, password))
                {
                    System_Output.Text = "Authentication successful! Hello '" + username + "'." + Environment.NewLine +
                    "Displaying all posts and comments made by user '" + username + "'.";
                    LogIn.Text = "Log-In";

                    Delete_Post_Button.Visible = true;
                    
                    Delete_Comment_Button.Enabled = false;

                    
                    foreach (Comment c in comments.Where(x => x.AuthorID == u.Id))
                    {

                        Comments_Output.Items.Add("<" + c.ID + "> (" + c.Score + ") " + c.Content +
                                          " - " + u.Name + " |" + c.TimeStamp + "|");
                    }

                }
                else
                {
                    System_Output.Text = "Incorrect password. Please try again.";
                    LogIn.Text = "Retry";
                }
            }
        }
        private void Subreddit_Output_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] tokens = Subreddit_Output.SelectedItem.ToString().Split(' ');

            string subname = tokens[0];
            subname = subname.Trim();

            Comments_Output.Items.Clear();
            Post_Output.Items.Clear();

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            SortedSet<Post> posts = new SortedSet<Post>();
            SortedSet<Comment> comments = new SortedSet<Comment>();


            ReadInputFiles(users, subreddits, posts, comments);

            

            foreach (Subreddit s in subreddits.Where(x => x.Name == subname))
            {
                Members_Output.Text = s.Members.ToString();
                Active_Output.Text = s.Active.ToString();
                var result = s.Id.ToString().PadLeft(4, '0');

                foreach (Post p in posts)
                {
                    var test = p.SubHome.ToString().PadLeft(4, '0');
                    if (test == result)
                    {
                        foreach (User u in users.Where(x => x.Id == p.AuthorID))
                        {
                            if (p.Title.Length > 35)
                            {
                                p.Title = p.Title.Substring(0, 35);
                                Post_Output.Items.Add("<" + p.Id + ">" + " [" + subname + "] " + "(" + p.PostRating + ") " + p.Title + "... - " + u.Name + " |" + p.TimeStamp + "|");
                            }
                            else
                            {
                                Post_Output.Items.Add("<" + p.Id + ">" + " [" + subname + "] " + "(" + p.PostRating + ") " + p.Title + " - " + u.Name + " |" + p.TimeStamp + "|");
                            }
                        }
                    }
                }
            }
            if (Subreddit_Output.SelectedItem != null)
                Delete_Comment_Button.Enabled = true;
            Delete_Post_Button.Enabled = false;
        }
        private void Post_Output_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] tokens = Post_Output.SelectedItem.ToString().Split(' ');

            string postID = tokens[0];
            string postSub = tokens[1];

            Reply_Button.Visible = true;
            Reply_Button.Enabled = false;

            //Removes "<" and ">" from the ID of post
            postID = postID.Remove(0, 1);
            postID = postID.Remove(4, 1);

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            SortedSet<Post> posts = new SortedSet<Post>();
            SortedSet<Comment> comments = new SortedSet<Comment>();


            ReadInputFiles(users, subreddits, posts, comments);

            foreach (Post p in posts)
            {
                if (p.Id == Convert.ToUInt32(postID))
                {
                    foreach (User u in users.Where(x => x.Id == p.AuthorID))
                    {
                        System_Output.Text = "<" + p.Id + ">" + " " + postSub + " " + "(" + p.PostRating + ") " + p.Title + " " + p.PostContent + " - " + u.Name + " |" + p.TimeStamp + "|";
                        Comments_Output.Items.Clear();
                    }

                }


            }

            foreach (Post p in posts.Where(x => x.Id == Convert.ToUInt32(postID)))
            {
                foreach (User u in users)
                {

                    if (p.AuthorID == u.Id)
                    {
                        foreach (Comment c in comments.Where(x => x.ParentID == Convert.ToUInt32(postID)))
                        {
                            foreach (User u1 in users.Where(x => x.Id == c.AuthorID))
                            {
                                    Comments_Output.Items.Add("<" + c.ID + "> (" + c.Score + ") " + c.Content +
                                          " - " + u1.Name + " |" + c.TimeStamp + "|");
                            }
                            foreach (Comment c1 in comments.Where(x => x.ParentID == c.ID))
                            {
                                foreach (User u2 in users.Where(x => x.Id == c1.AuthorID))
                                {
                                    Comments_Output.Items.Add("     <" + c1.ID + "> (" + c1.Score + ") " + c1.Content +
                                              " - " + u2.Name + " |" + c1.TimeStamp + "|");
                                }
                            }
                        }
                    }
                }
            }
            if (Comments_Output.SelectedItem != null)
            {
                Delete_Post_Button.Enabled = true;
                
            }

        }


        private void Delete_Post_Button_Click(object sender, EventArgs e)
        {
            

            
            
            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            SortedSet<Post> postSet = new SortedSet<Post>();
            SortedSet<Comment> comments = new SortedSet<Comment>();

            
            

            ReadInputFiles(users, subreddits, postSet, comments);

            string[] tokens = Post_Output.SelectedItem.ToString().Split(' ');

            string postID = tokens[0];
            string postSub = tokens[1];

            //Removes "<" and ">" from the ID of post
            postID = postID.Remove(0, 1);
            postID = postID.Remove(4, 1);

            string[] tokens2 = Subreddit_Output.SelectedItem.ToString().Split(' ');

            string subname = tokens[0];
            subname = subname.Trim();

            subname = subname.Remove(0, 1);
            int lindex = subname.Length - 1;
            subname = subname.Remove(lindex, 1);

            postSub = postSub.Remove(0, 1);
            postSub = postSub.Remove(postSub.Length - 1, 1);
            String[] tokens3 = User_Output.SelectedItem.ToString().Split(' ');

            string username = tokens3[0];
            uint userId = 0;

            foreach (User u in users)
            {
                if (username == u.Name)
                    userId = u.Id;
            }

            Post temp = null;

            foreach (User u in users)
            {
                if (u.Id == userId)
                {
                    foreach (Post p in postSet)
                    {
                        if (p.AuthorID == u.Id && p.Id == Convert.ToUInt32(postID))
                            temp = new Post(p.Locked, p.Id, p.AuthorID, p.Title, p.PostContent, p.SubHome, p.UpVotes, p.DownVotes, p.Weight, p.TimeStamp.Year, p.TimeStamp.Month, p.TimeStamp.Day, p.TimeStamp.Hour, p.TimeStamp.Minute, p.TimeStamp.Second);
                    }
                }
            }
            if (temp == null)
            {
                System_Output.Text = "Unable to delete post. Choose a different post.";
            }
            else if (temp.AuthorID == userId)
            {
                postSet.Remove(temp);
                Post_Output.Items.Clear();
                Delete_Post_Button.Enabled = false;
                foreach (Subreddit s in subreddits.Where(x => x.Name == postSub))
                {
                   
                    var result = s.Id.ToString().PadLeft(4, '0');

                    foreach (Post p in postSet)
                    {
                        var test = p.SubHome.ToString().PadLeft(4, '0');
                        if (p.SubHome == s.Id)
                        {
                            foreach (User u in users.Where(x => x.Id == p.AuthorID))
                            {
                                if (p.Title.Length > 35)
                                {
                                    p.Title = p.Title.Substring(0, 35);
                                    Post_Output.Items.Add("<" + p.Id + ">" + " [" + s.Name + "] " + "(" + p.PostRating + ") " + p.Title + "... - " + u.Name + " |" + p.TimeStamp + "|");
                                }
                                else
                                {
                                    Post_Output.Items.Add("<" + p.Id + ">" + " [" + s.Name + "] " + "(" + p.PostRating + ") " + p.Title + " - " + u.Name + " |" + p.TimeStamp + "|");
                                }
                            }
                        }
                    }
                }
                System_Output.Text = "Post successfully deleted.";
            }
            Post_Output.Update();
            Comments_Output.Update();

            temp = null;
            //System_Output.Text = userId + " " + username + " " + postID + " " + subname + " " + postSub;
        }

        private void Comments_Output_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] tokens = Comments_Output.SelectedItem.ToString().Split(' ');

            string commentID = tokens[0];
            string parentID = tokens[1];

            //Removes "<" and ">" from the ID of post
            commentID = commentID.Remove(0, 1);
            commentID = commentID.Remove(4, 1);

            if (User_Output.SelectedItem != null)
                Delete_Comment_Button.Enabled = true;

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            SortedSet<Post> posts = new SortedSet<Post>();
            SortedSet<Comment> comments = new SortedSet<Comment>();


            ReadInputFiles(users, subreddits, posts, comments);

            Delete_Comment_Button.Visible = true;



        }

        private void Delete_Comment_Button_Click(object sender, EventArgs e)
        {

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            SortedSet<Post> posts = new SortedSet<Post>();
            SortedSet<Comment> comments = new SortedSet<Comment>();

            ReadInputFiles(users, subreddits, posts, comments);

            string[] tokens = Comments_Output.SelectedItem.ToString().Split(' ');

            string postID = tokens[0];
            string postSub = tokens[1];

            //Removes "<" and ">" from the ID of post
            postID = postID.Remove(0, 1);
            postID = postID.Remove(4, 1);

            string[] tokens2 = Subreddit_Output.SelectedItem.ToString().Split(' ');

            string subname = tokens[0];
            subname = subname.Trim();

            subname = subname.Remove(0, 1);
            int lindex = subname.Length - 1;
            subname = subname.Remove(lindex, 1);

            postSub = postSub.Remove(0, 1);
            postSub = postSub.Remove(postSub.Length - 1, 1);
            String[] tokens3 = User_Output.SelectedItem.ToString().Split(' ');

            string username = tokens3[0];
            uint userId = 0;

            foreach (User u in users)
            {
                if (username == u.Name)
                    userId = u.Id;
            }

            Comment temp = null;

            foreach (User u in users)
            {
                if (u.Id == userId)
                {
                    foreach (Comment c in comments)
                    {
                        if (c.AuthorID == u.Id && c.ID == Convert.ToUInt32(postID))
                            temp = new Comment(c.ID, c.AuthorID, c.Content, c.ParentID, c.UpVotes, c.DownVotes, c.TimeStamp.Year, c.TimeStamp.Month, c.TimeStamp.Day, c.TimeStamp.Hour, c.TimeStamp.Minute, c.TimeStamp.Second);
                    }
                }
            }
            if (temp == null)
            {
                System_Output.Text = "Unable to delete comment. Choose a different comment.";
            }
            else if (temp.AuthorID == userId)
            {
                comments.Remove(temp);

                Comments_Output.Items.Clear();
                Delete_Comment_Button.Enabled = false;
                foreach (Subreddit s in subreddits.Where(x => x.Name == postSub))
                {

                    var result = s.Id.ToString().PadLeft(4, '0');

                    foreach (Comment c in comments)
                    {
                        var test = c.ParentID.ToString().PadLeft(4, '0');
                        if (c.ParentID == s.Id)
                        {
                            foreach (User u in users.Where(x => x.Id == c.AuthorID))
                            {
                                Comments_Output.Items.Add("<" + c.ID + ">" + " [" + u.Name + "] " + "(" + c.Score + ") " + c.Content + " - " + u.Name + " |" + c.TimeStamp + "|");
                            }
                        }
                    }
                }
                System_Output.Text = "Comment successfully deleted.";
            }
            Post_Output.Update();
           // Comments_Output.Update();
            temp = null;
            //System_Output.Text = userId + " " + username + " " + postID + " " + subname + " " + postSub;

        }

        private void Reply_Input_TextChanged(object sender, EventArgs e)
        {
            Reply_Button.Enabled = true;

        }

        private void Reply_Button_Click(object sender, EventArgs e)
        {
            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            SortedSet<Post> posts = new SortedSet<Post>();
            SortedSet<Comment> comments = new SortedSet<Comment>();

            ReadInputFiles(users, subreddits, posts, comments);

            String tempcontent = Reply_Input.Text;
            string tempname = "";

            if (Comments_Output.SelectedItem == null)
            {
                string[] tokens = Post_Output.SelectedItem.ToString().Split(' ');
                string[] utokens = User_Output.SelectedItem.ToString().Split(' ');
                

                string postID = tokens[0];
                string postSub = tokens[1];

                Comment temp = null;

                uint locked = 0;

                //Removes "<" and ">" from the ID of post
                postID = postID.Remove(0, 1);
                postID = postID.Remove(4, 1);
                foreach (Post p in posts.Where(x => x.Id == Convert.ToUInt32(postID)))
                {
                    foreach (User u in users.Where(x => x.Id == p.AuthorID))
                    {
                        temp = new Comment(p.AuthorID, tempcontent, p.SubHome);
                        tempname = u.Name;
                        locked = p.Locked;

                    }
                }
                if (locked == 0)
                    Comments_Output.Items.Add("<" + temp.ID + ">" + " " + "(" + temp.Score + ") " + temp.Content + " - " + utokens[0] + " |" + temp.TimeStamp + "|");
                else
                    System_Output.Text = "Cannot create a comment. The post is locked";
            }
            else
            {
                string[] tokens = Post_Output.SelectedItem.ToString().Split(' ');
                string[] utokens = User_Output.SelectedItem.ToString().Split(' ');
                string[] ctokens = Comments_Output.SelectedItem.ToString().Split(' ');


                string postID = tokens[0];
                string postSub = tokens[1];

                string commentID = ctokens[0];

                // remove brackets
                commentID = postID.Remove(0, 1);
                //postID = postID.Remove(4, 1);

                Comment temp = null;

                //Removes "<" and ">" from the ID of post
                postID = postID.Remove(0, 1);
                postID = postID.Remove(4, 1);
                foreach (Comment c in comments)//.Where(x => x.Id == Convert.ToUInt32(postID)))
                {
                    foreach (User u in users.Where(x => x.Id == c.AuthorID))
                    {
                        //if (p.AuthorID == u.Id)
                        //{
                        temp = new Comment(c.ID, tempcontent, c.ParentID);
                        tempname = u.Name;
                        //}

                    }
                }
                Comments_Output.Items.Add("     <" + temp.ID + ">" + " " + "(" + temp.Score + ") " + temp.Content + " - " + utokens[0] + " |" + temp.TimeStamp + "|");
            }
            Reply_Button.Enabled = false;
        }
    }
    
}