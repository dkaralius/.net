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
        public static SortedSet<User> users;

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

                    if(args[1] == "0")
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
        public static void ReadInputFiles(SortedSet<User> users, SortedSet<Subreddit> subreddits)
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
        }
            public Form1()
        {
            InitializeComponent();

            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();

            ReadInputFiles(users,subreddits);

            foreach (User u in users)
            {
                User_Output.Items.Add(u.Name + "   " +  u.Usertype + "         (" + u.PostScore + " / " + u.CommentScore + ")" + Environment.NewLine);
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
            System_Output.Text = "Please provide the password for User '" + tokens[0] + "'.";
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            string[] tokens = User_Output.SelectedItem.ToString().Split(' ');

            string username = tokens[0];
            string password = Password.Text;
            string correctPassword = "";

            //Hardcoded from input file, not sure how to read them otherwise
            if(username == "GallowBoob")
            {
                correctPassword = "F2381EF2";
            }
            if (username == "poem_for_your_sprog")
            {
                correctPassword = "E1308036";
            }
            if (username == "Rogness")
            {
                correctPassword = "BB4EEE6E";
            }
            if (username == "crappymorph")
            {
                correctPassword = "5DC8199";
            }
            if (username == "Unexpected_Gimli")
            {
                correctPassword = "AAA558A0";
            }
            if (username == "PM_YOUR_CODE")
            {
                correctPassword = "6D86019";
            }
            if (username == "NervousPigeon")
            {
                correctPassword = "45DC58F4";
            }
            if (username == "ConfusedPenguin")
            {
                correctPassword = "D352C017";
            }
            if (username == "IsThisAMeme")
            {
                correctPassword = "E87F22F3";
            }
            if (username == "KarmaCop")
            {
                correctPassword = "93AB176";
            }
            if (username == "BlueEyesWhiteDragon")
            {
                correctPassword = "C7E772E2";
            }

            string hexValue = password.GetHashCode().ToString("X");

            if(correctPassword == hexValue)
            {
                System_Output.Text = "Authentication successful! Hello '" + username + "'." + Environment.NewLine +
                    "Displaying all posts and comments made by user '" + username + "'.";
                LogIn.Text = "Log-In";
            }
            else
            {
                System_Output.Text = "Incorrect password. Please try again.";
                LogIn.Text = "Retry";
            }
        }
    }
}
