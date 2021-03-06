﻿/********************************************************
 *  PROGRAM : Assignment1                               *
 *                                                      *
 *  PROGRAMMERS : Josue Ballona and Dominykas Karalius  *
 *  ZID : Z1832823 and Z1809478                         *
 *                                                      *
 *  DATE : 9/9/2019 Monday, September 9th 2019          *
 *                                                      *
 *                                                      *
 * This program mimics the popular application "Reddit",*
 * however is done in the command line. The program     *
 * reads provided .txt input files and stores that      *
 * information into SortedSet<> objects. Information    *
 * such as users, subreddits, posts, and comments.      *
 * The user of the program can choose from a variety    *
 * of actions to perfrom; view users, view all posts,   *
 * view posts of single subreddit, and so on.           *
 *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Collections;

namespace Assignment_1
{
    class Assignment1
    {
        public class User : IComparable
        {
            //Private variables
            private readonly uint id;
            private readonly string name;
            private int postScore;
            private int commentScore;

            //Public properties
            public uint Id { get => id; }
            public string Name { get => name; }
            public int PostScore { get => postScore; set => postScore = value; }
            public int CommentScore { get => commentScore; set => commentScore = value; }
            public int TotalScore { get => (CommentScore + PostScore); }

            //Default constructor
            public User()
            {
                id = 0;
                name = "";
                postScore = 0;
                commentScore = 0;
            }

            //Alternate constructor where all arguments are provided
            public User(uint id, string name, int postScore, int commentScore)
            {
                this.id = id;
                this.name = name;
                this.postScore = postScore;
                this.commentScore = commentScore;
            }

            //Alternate constructor where only id and name are provided
            public User(uint id, string name)
            {
                this.id = id;
                this.name = name;
                postScore = 0;
                commentScore = 0;
            }

            //Alternate constructor to take n number of args
            public User(string[] args)
            {
                if (args.Length == 4)
                {
                    id = Convert.ToUInt32(args[0]);
                    name = args[1];
                    postScore = Convert.ToInt32(args[2]);
                    commentScore = Convert.ToInt32(args[3]);
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

            //Overriden ToString() to print out user neatly
            public override string ToString()
            {
                return String.Format("User: {1}({0}) has a post score of {2} and comment score of {3}", id, name, postScore, commentScore);
            }
        }

        public class Subreddit : IComparable, IEnumerable
        {
            //Private variables
            private readonly uint id;
            private string name;
            private uint members;
            private uint active;
            SortedSet<Post> subPosts;

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

            // Implementation for the GetEnumerator method
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }

            public SubEnum GetEnumerator()
            {
                return new SubEnum(subPosts.ToArray());
            }
        }

        public class Post : IComparable, IEnumerable
        {
            //Private variables
            readonly uint id;
            string title;
            readonly uint authorID;
            string postContent;
            readonly uint subHome;
            uint upVotes;
            uint downVotes;
            uint weight;
            readonly DateTime timeStamp;
            SortedSet<Comment> postComments;

            //Public properties
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
            public Post(uint id, uint authorID, string title, string postContent, uint subHome, uint upVotes, uint downVotes, uint weight, int year, int month, int day, int hour, int minute, int second)
            {
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
                if (args.Length == 14)
                {
                    id = Convert.ToUInt32(args[0]);
                    authorID = Convert.ToUInt32(args[1]);
                    title = Convert.ToString(args[2]);
                    postContent = Convert.ToString(args[3]);
                    subHome = Convert.ToUInt32(args[4]);
                    upVotes = Convert.ToUInt32(args[5]);
                    downVotes = Convert.ToUInt32(args[6]);
                    weight = Convert.ToUInt32(args[7]);

                    int year = Convert.ToInt32(args[8]);
                    int month = Convert.ToInt32(args[9]);
                    int day = Convert.ToInt32(args[10]);
                    int hour = Convert.ToInt32(args[11]);
                    int minute = Convert.ToInt32(args[12]);
                    int second = Convert.ToInt32(args[13]);

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
                    throw new ArgumentException("argument was not a student");
            }

            // Implementation for the GetEnumerator method.
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }

            public PostEnum GetEnumerator()
            {
                return new PostEnum(postComments.ToArray());
            }

        }

        public class Comment : IComparable, IEnumerable
        {
            //Private variables
            readonly uint id;
            readonly uint authorID;
            string content;
            readonly uint parentID;
            uint upVotes;
            uint downVotes;
            readonly DateTime timeStamp;
            SortedSet<Comment> commentReplies;
            
            //Public properties
            public uint Score { get => upVotes - downVotes; }
            public uint ID { get => id; }
            public uint AuthorID { get => authorID; }
            public uint ParentID { get => parentID; }
            public string Content { get => content; }
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
            public Comment(uint id, uint authorID, string content, uint parentID, uint upVotes, uint downVotes, int year, int month, int day, int hour, int minute, int second)
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
                    upVotes = Convert.ToUInt32(args[4]);
                    downVotes = Convert.ToUInt32(args[5]);

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

            // Implementation for the GetEnumerator method.
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }

            public CommentEnum GetEnumerator()
            {
                return new CommentEnum(commentReplies.ToArray());
            }
        }

        //Enum class implementation for Comment SortedSet<>
        public class CommentEnum : IEnumerator
        {
            public Comment[] _comment;

            int position = -1;

            public CommentEnum(Comment[] list)
            {
                _comment = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _comment.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public Comment Current
            {
                get
                {
                    try
                    {
                        return _comment[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        //Enum class implementation for Post SortedSet<>
        public class PostEnum : IEnumerator
        {
            public Comment[] _post;

            int position = -1;

            public PostEnum(Comment[] list)
            {
                _post = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _post.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public Comment Current
            {
                get
                {
                    try
                    {
                        return _post[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        //Enum class implementation for Subreddit SortedSet<>
        public class SubEnum : IEnumerator
        {
            public Post[] _post;

            int position = -1;

            public SubEnum(Post[] list)
            {
                _post = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _post.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public Post Current
            {
                get
                {
                    try
                    {
                        return _post[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        //Method that is used to read the provided input files and store the information into their respective SortedSet<> objects
        public static void ReadInputFiles(SortedSet<User> users, SortedSet<Subreddit> subreddits, SortedSet<Post> subPosts, SortedSet<Comment> comments)
        {
            String slacker; //Buffer
            String[] tokens; //Used to store tokens of buffer

            //For users and users.txt
            try
            {
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
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            //For subreddits and subreddits.txt
            try
            {
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
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            //For posts and posts.txt
            try
            {
                using (StreamReader inFile = new StreamReader("..\\..\\posts.txt"))
                {
                    slacker = inFile.ReadLine();

                    while (slacker != null)
                    {
                        tokens = slacker.Split('\t');
                        subPosts.Add(new Post(tokens));

                        slacker = inFile.ReadLine();
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            //For comments and comments.txt
            try
            {
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
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        //Method used to print the main menu of application, so user can keep using it until the want to leave
        public static void mainMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Reddit, The Command Line Version!");
            Console.WriteLine("");
            Console.WriteLine("1. List All Subreddits");
            Console.WriteLine("2. List All Posts from All Subreddits");
            Console.WriteLine("3. List All Posts from A Single Subreddit");
            Console.WriteLine("4. View Comments From A Single Post");
            Console.WriteLine("5. Add Comment to Post");
            Console.WriteLine("6. Add Reply to Comment");
            Console.WriteLine("7. Create New Post");
            Console.WriteLine("8. Delete Post");
            Console.WriteLine("9. Quit");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        //Exception for when user enters restricted word
        public class FoulMouthException : Exception { }

        //Method used to check the input provided by user, for restricted words.
        //Returns boolean value of true, if user didn't use any restricted words.
        //If user enters a restricted word, throws the FoulMouth exception.
        public static bool LanguageFilter(String input)
        {
            string[] badWords = { "baddie", "butthead", "shoot", "fudge" };

            if (!badWords.Any(x => x == input))
            {
                return true; // No bad words
            }
            else
                throw new FoulMouthException();
        }

        //Main program
        static void Main(string[] args)
        {
            //SortedSet<> objects
            SortedSet<User> users = new SortedSet<User>();
            SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
            SortedSet<Post> subPosts = new SortedSet<Post>();
            SortedSet<Comment> comments = new SortedSet<Comment>();

            ReadInputFiles(users, subreddits, subPosts, comments); //Read the files

            string input; //User input will be stored here
            string[] options = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "q", "Q", "e", "E", "quit", "exit" }; //Options user is allowed to choose from. All other inputs, give error message
            string[] exitCondition = { "q", "Q", "e", "E", "quit", "exit", "9" }; //If user input is equal to one of these values, program exits

            bool tf = false;

            //Program cycles itself until user wants to exit
            do
            {
                mainMenu();
                input = Console.ReadLine(); //Asks what user wants to do

                //Checks to see if input is a valid choice, if not, tells them their input is invalid
                if (!options.Any(x => x == input))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid input!");
                }

                //Else, executes the case the user entered (1-9)
                switch (input)
                {
                    //Case where user wants to see all users on the subreddit
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Name -- (Active members/Total members)");
                        foreach (Subreddit s in subreddits)
                        {
                            Console.WriteLine("<" + s.Id + ">" + " " + s.Name + " -- <" + s.Active + "/" + s.Members + ">");
                        }
                        break;

                    //Case where user wants to see all posts from all subreddits
                    case "2":
                        Console.Clear();
                        Console.WriteLine("<ID> [Subreddit] (Score) Title + PostContent - PosterName |TimeStamp|\n");

                        foreach (Post i in subPosts)
                        {
                            foreach (Subreddit j in subreddits)
                            {
                                foreach (User u in users)
                                {
                                    if (j.Id.CompareTo(i.SubHome) == 0 && i.AuthorID.CompareTo(u.Id) == 0)
                                    {
                                        Console.WriteLine("        <" + String.Format("{0000}", i.Id) + "> [" + j.Name + "] (" + i.Score + ") "
                                            + i.Title + " " + i.PostContent + " - " + u.Name + " |" + i.TimeStamp + "|");
                                    }
                                }
                            }
                        }
                        break;

                    //Case where user wants to all posts from a desired subreddit
                    case "3":
                        Console.Clear();
                        Console.Write("Enter the name of the Subreddit to list from: ");
                        input = Console.ReadLine();
                        Console.WriteLine("<ID> [Subreddit] (Score) Title + PostContent - PosterName |TimeStamp|");
                        Console.WriteLine("");

                        if (subreddits.Any(x => x.Name == input))
                        {
                            foreach (Subreddit i in subreddits.Where(x => x.Name == input))
                            {
                                foreach (Post s in subPosts.Where(x => x.SubHome == i.Id))
                                {
                                    foreach (User u in users)
                                    {
                                        if (i.Id.CompareTo(s.SubHome) == 0 && s.AuthorID.CompareTo(u.Id) == 0)
                                        {
                                            Console.WriteLine("        <" + s.Id + "> [" + i.Name + "] (" + s.Score + ") "
                                            + s.Title + " " + s.PostContent + " - " + u.Name + " |" + s.TimeStamp + "|");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("I cannot find the " + input + " subreddit! Returning to main menu!");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                        }
                        break;

                    //Case where user wants to view all comments to a requested subreddit post
                    case "4":
                        Console.Clear();
                        Console.Write("Enter the ID of the post you'd like to see the comments for: ");

                        input = Console.ReadLine();
                        int num = -1;

                        //Checks to see if user is entering only a number, if not, returns to main menu
                        if (!int.TryParse(input, out num))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Please enter a number!");
                            Console.WriteLine("Returning to main menu...");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            if (subPosts.Any(x => x.Id == Convert.ToUInt32(input))) //If the entered ID exists for a post, continue
                            {
                                Console.WriteLine("");
                                foreach (Post s in subPosts.Where(x => x.Id == Convert.ToUInt32(input)))
                                {
                                    foreach (Subreddit i in subreddits.Where(x => x.Id == s.SubHome))
                                    {
                                        foreach (Comment c in comments.Where(x => x.ParentID == s.Id))
                                        {
                                            foreach (User u in users)
                                            {
                                                if (i.Id.CompareTo(s.SubHome) == 0 && s.AuthorID.CompareTo(u.Id) == 0)
                                                {
                                                    Console.WriteLine("        <" + s.Id + "> [" + i.Name + "] (" + s.Score + ") "
                                                       + s.Title + " " + s.PostContent + " - " + u.Name + " |" + s.TimeStamp + "|");
                                                    Console.WriteLine("");
                                                }
                                            }
                                        }
                                    }
                                }
                                foreach (Post s in subPosts.Where(x => x.Id == Convert.ToUInt32(input)))
                                {
                                    foreach (Comment c in comments.Where(x => x.ParentID == s.Id))
                                    {
                                        foreach (User n in users.Where(x => x.Id == c.AuthorID))
                                        {

                                            Console.WriteLine("        <" + c.ID + "> (" + c.Score + ") " + c.Content +
                                                " - " + n.Name + " |" + c.TimeStamp + "|");
                                            Console.WriteLine("");
                                        }
                                        foreach (Comment d in comments.Where(x => x.ParentID == c.ID))
                                        {
                                            foreach (User m in users.Where(x => x.Id == d.AuthorID))
                                            {
                                                Console.WriteLine("                <" + d.ID + "> (" + d.Score + ") " + d.Content +
                                                    " - " + m.Name + " |" + d.TimeStamp + "|");
                                                Console.WriteLine("");
                                            }
                                        }
                                    }
                                }
                            }
                            else //Else, post doesn't exist with requested ID and returns to main menu
                            {
                                Console.WriteLine("");
                                Console.WriteLine("I cannot find the a post with ID: " + input + "! Returning to main menu!");
                                System.Threading.Thread.Sleep(3000);
                                Console.Clear();
                            }
                        }
                        break;

                    //Case where user wants to comment on a post of their choice
                    case "5":
                        Console.Clear();
                        Console.Write("Enter the ID of the post you'd like to comment on: ");

                        input = Console.ReadLine();

                        //Checks to see if user is entering only a number, if not, returns to main menu
                        if (!int.TryParse(input, out num))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Please enter a number!");
                            Console.WriteLine("Returning to main menu...");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        }

                        else
                        {

                            foreach (Post j in subPosts)
                            {
                                if (Convert.ToUInt32(input) == j.Id) //If post exists with desired ID, continue
                                {
                                    Console.WriteLine("Post Found!");
                                    tf = true;
                                    break;
                                }
                            }

                            uint tempId = Convert.ToUInt32(input);

                            if (tf)
                            {
                                Console.Write("Please enter your comment: ");
                                input = Console.ReadLine();
                                try
                                {
                                    LanguageFilter(input); //Checks to see if desired comment contains any censored words

                                    Comment tempcomm = new Comment(0001, input, tempId);

                                    comments.Add(tempcomm);
                                    tf = false;

                                    Console.WriteLine("Comment sent.");
                                }
                                catch (FoulMouthException e) //If it does contain censored words, gives error and returns to main menu
                                {
                                    Console.Clear();
                                    Console.WriteLine("You entered a censored word! Please do not use censored words in posts and comments!");
                                    Console.WriteLine("Returning to main menu...");
                                    System.Threading.Thread.Sleep(3000);
                                    Console.Clear();
                                }
                            }
                            else //No post exists with provided ID and returns to main menu
                            {
                                Console.WriteLine("No post with that ID was found.");
                                Console.WriteLine("Returning to main menu...");
                                System.Threading.Thread.Sleep(3000);
                                Console.Clear();
                                break;
                            }
                        }
                        break;

                    case "6":
                        Console.Clear();
                        Console.Write("Enter the ID of the comment you'd like to add a reply to: ");

                        input = Console.ReadLine();
                        int tempi = -1;

                        //Checks to see if user is entering only a number, if not, returns to main menu
                        if (!int.TryParse(input, out tempi))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Please enter a number!");
                            Console.WriteLine("Returning to main menu...");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        }

                        uint tid = Convert.ToUInt32(input);
                        Comment tcomm = null;
                        tf = false;

                        foreach (Comment tcmt in comments)
                        {
                            if (tcmt.ID == tid) //If comment exists with desired ID, continue
                            {
                                Console.WriteLine("Comment found");
                                tf = true;
                                break;
                            }
                        }

                        if (!tf) //If no comment exists with provided ID, gives error and returns to main menu
                        {
                            Console.WriteLine("Comment does not exist.");
                            Console.WriteLine("Returning to main menu...");
                            System.Threading.Thread.Sleep(3000);
                            break;
                        }

                        Console.Write("Enter your reply: ");
                        input = Console.ReadLine();

                        try
                        {
                            LanguageFilter(input); //Checks to see if desired reply contains any censored words

                            tcomm = new Comment(0001, input, tid);

                            comments.Add(tcomm);

                            Console.WriteLine("Reply sent.");
                        }
                        catch (FoulMouthException e) //If it does contain censored words, gives error and returns to main menu
                        {
                            Console.Clear();
                            Console.WriteLine("You entered a censored word! Please do not use censored words in posts and comments!");
                            Console.WriteLine("Returning to main menu...");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                        }
                        break;

                    case "7":

                        Console.Clear();

                        uint tempid = 0;

                        Console.Write("Enter the name of the subreddit you'd like to post in: ");
                        input = Console.ReadLine();
                        string tempname = input;

                        foreach (Subreddit s in subreddits)
                        {
                            if (tempname == s.Name)
                            {
                                Console.WriteLine("Subreddit found!"); //If subreddit exists with desired ID, continue
                                tf = true;
                                tempid = s.Id;
                                break;
                            }
                        }

                        if (!tf) //If no subreddit exists with provided ID, gives error and returns to main menu
                        {
                            Console.WriteLine("No subreddit with that name was found.");
                            Console.WriteLine("Returning to main menu...");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        }

                        tf = false;

                        Console.Write("Enter the title of your new post: ");
                        input = Console.ReadLine();

                        try
                        {
                            string temptitle = input;
                            Console.Write("Enter any content you'd like to add: ");
                            input = Console.ReadLine();
                            string tempcontent = input;

                            LanguageFilter(temptitle); //Checks to see if desired title and content contain any censored words
                            LanguageFilter(tempcontent);

                            Post p = new Post(4260, 0001, temptitle, tempcontent, tempid);
                            Console.WriteLine("Post added.");
                            subPosts.Add(p);
                        }
                        catch (FoulMouthException e) //If they do contain censored words, gives error and returns to main menu
                        {
                            Console.Clear();
                            Console.WriteLine("You entered a censored word! Please do not use censored words in posts and comments!");
                            Console.WriteLine("Returning to main menu...");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                        }
                        break;

                    case "8":
                        Console.Clear();
                        Console.Write("Enter the ID of the post you would like to delete: ");

                        input = Console.ReadLine();

                        Post temppost = null;

                        //Checks to see if user is entering only a number, if not, returns to main menu
                        if (!int.TryParse(input, out num))
                        {
                            Console.WriteLine("Please enter a number for the ID.");
                            Console.WriteLine("Returning to main menu...");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        }
                        tf = false;
                        tid = 0;
                        tempid = 0;
                        foreach (Post k in subPosts)
                        {
                            if (k.Id == Convert.ToUInt32(input) && k.AuthorID == 0001)
                            {
                                Console.WriteLine("Removing post...");
                                temppost = new Post(k.Id, k.AuthorID, k.Title, k.PostContent, k.SubHome, k.UpVotes, k.DownVotes, k.Weight, k.TimeStamp.Year, k.TimeStamp.Month, k.TimeStamp.Day, k.TimeStamp.Hour, k.TimeStamp.Minute, k.TimeStamp.Second);
                                Console.WriteLine("Returning to main menu...");
                                tf = true;
                                tid = Convert.ToUInt32(input);
                                tempid = k.AuthorID;
                                System.Threading.Thread.Sleep(3000);
                                Console.Clear();
                            }
                        }
                        if (tf)
                        {
                            subPosts.Remove(temppost);
                            break;
                        }
                        if (tid == Convert.ToUInt32(input) && tempid != 0001) //If user tries to delete other user's posts, gives error and returns to main menu
                        {
                            Console.WriteLine("You can't delete other user's posts.");
                            Console.WriteLine("Returning to main menu...");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        }
                        else //If no post exists with provided ID, gives error and returns to main menu
                        {
                            Console.WriteLine("No post with that ID found.");
                            Console.WriteLine("Returning to main menu...");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        }

                    //Case where user wants to exit the program
                    case "9":
                        Console.Clear();
                        break;
                }
            } while (!exitCondition.Any(x => x == input)); //Program will go back to top of loop until user press 9, or one of the exit condition strings

            //When user does enter one of the exit condition strings, lets user know program is shutting down and terminates.
            Console.Write("Closing Reddit...");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("");
            Environment.Exit(1);
        }
    }
}