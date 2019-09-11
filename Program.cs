using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment1
{
    class Program
    {
        public class User : IComparable
        {
            private readonly uint id;
            private readonly string name;
            private int commentScore;
            private int postScore;

            public uint ID { get => id; }
            public string Name { get => name; }
            public int PostScore { get => postScore; set => postScore = value; }
            public int CommentScore { get => commentScore; set => commentScore = value; }
            public int TotalScore { get => (CommentScore + PostScore); }

            //Default Constructor
            public User()
            {
                id = 0;
                name = "";
                commentScore = 0;
                postScore = 0;
            }

            //Alternate Constructor if provided all arguements for the user
            public User(uint id, string name, int commentScore, int postScore)
            {
                this.id = id;
                this.name = name;
                this.commentScore = commentScore;
                this.postScore = postScore;
            }

            //Alternate Constructor if provided only ID and username for the user
            public User(uint id, string name)
            {
                this.id = id;
                this.name = name;
                commentScore = 0;
                postScore = 0;
            }

            public User(string[] args)
            {
                if (args.Length == 4)
                {
                    id = Convert.ToUInt32(args[0]);
                    name = args[1];
                    postScore = Convert.ToInt32(args[2]);
                    CommentScore = Convert.ToInt32(args[3]);
                }
            }

            //Sort by Name, in ascending order(default)
            public int CompareTo(Object alpha)
            {
                if (alpha == null) throw new ArgumentNullException("argument bad");

                User rightOp = alpha as User;

                if (rightOp != null)
                    return name.CompareTo(rightOp.name);
                else
                    throw new ArgumentException("argument was not a name.");
            }

            //Overriden ToString() method
            public override string ToString()
            {
                return String.Format("User: {1}({0}) has a post score of {2} and comment score of {3}", id, name, postScore, commentScore);
            }

        }
        public class Subreddit : IComparable //, IEnumerable
        {
            readonly uint id;
            string name;
            uint members;
            uint active;
            SortedSet<Post> subPosts;

            //Default Constructor
            public Subreddit()
            {
                id = 0;
                name = "";
                members = 0;
                active = 0;
            }

            //Alternate Constructor if provided all arguements for the user
            public Subreddit(uint id, string name, uint members, uint active)
            {
                this.id = id;
                this.name = name;
                this.members = members;
                this.active = active;
            }

            //Alternate Constructor if provided only ID and username for the user
            public Subreddit(uint id, string name)
            {
                this.id = id;
                this.name = name;
                members = 0;
                active = 0;
            }
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

            public int CompareTo(Object alpha)
            {
                if (alpha == null) throw new ArgumentNullException("argument bad");

                Subreddit rightOp = alpha as Subreddit;

                if (rightOp != null)
                    return name.CompareTo(rightOp.name);
                else
                    throw new ArgumentException("argument was not a name.");
            }
            /*
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerable) GetEnumerator();
            }

            public SubEnum GetEnumerator()
            {
                return new SubEnum(subPosts);
            }
        }
        public class SubEnum : IEnumerator
        {
            public SortedSet<Post> subPosts;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            int position = -1;

            public SubEnum(SortedSet<Post> list)
            {
                subPosts = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < subPosts.Length);
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

            public SubReddit Current
            {
                get
                {
                    try
                    {
                        return subPosts[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
        */
            public class Post : IComparable//, IEnumerable
            {
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

                //Properties
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
                    timeStamp = new DateTime(0, 0, 0, 0, 0, 0);
                }
                //Alternate Constructor if provided all arguements for the user
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
                //Alternate Constructor if provided only a title, authorID, postContent, and subHome
                public Post(uint id, uint authorID, string title, string postContent, uint subHome)
                {
                    this.id = id;
                    this.authorID = authorID;
                    this.title = title;
                    this.postContent = postContent;
                    this.subHome = subHome;
                    this.upVotes = 1;
                    this.downVotes = 0;
                }

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
                public int CompareTo(Object alpha)
                {
                    if (alpha == null) throw new ArgumentNullException("argument bad");

                    Post rightOp = alpha as Post;

                    if (rightOp != null)
                        return PostRating.CompareTo(rightOp.PostRating);
                    else
                        throw new ArgumentException("argument was not a student");
                }
                /*
                 * IEnumberable
                 */
            }

            public class Comment : IComparable //, IEnumerable
            {
                readonly uint id;
                readonly uint authorID;
                string content;
                readonly uint parentID;
                uint upVotes;
                uint downVotes;
                readonly DateTime timeStamp;
                SortedSet<Comment> commentReplies;

                public uint Score { get => upVotes - downVotes; }

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

                //Alternate Constructor if provided all arguements for the user
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

                public Comment(uint authorID, string content, uint parentID)
                {
                    this.authorID = authorID;
                    this.content = content;
                    this.parentID = parentID;
                    upVotes = 1;
                    downVotes = 0;
                }
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
                /*
                 * IEnumberable
                 */
            }

            public static void ReadInputFiles(SortedSet<User> users, SortedSet<Subreddit> subreddits, SortedSet<Post> subPosts, SortedSet<Comment> comments)
            {
                String slacker;
                String[] tokens;

                //For users and users.txt
                try
                {
                    using (StreamReader inFile = new StreamReader("..\\..\\users.txt"))
                    {
                        slacker = inFile.ReadLine();

                        while(slacker != null)
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
            static void Main(string[] args)
            {
                SortedSet<User> users = new SortedSet<User>();
                SortedSet<Subreddit> subreddits = new SortedSet<Subreddit>();
                SortedSet<Post> subPosts = new SortedSet<Post>();
                SortedSet<Comment> comments = new SortedSet<Comment>();

                ReadInputFiles(users, subreddits, subPosts, comments);

                foreach(User i in users)
                {
                    Console.WriteLine(i.ToString());
                }
                string input;
                string[] options = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "q", "Q", "e", "E", "quit", "exit" };
                string[] exitCondition = { "q", "Q", "e", "E", "quit", "exit" };

                do
                {
                    mainMenu();
                    input = Console.ReadLine();

                    if (!options.Any(x => x == input))
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid input!");
                    }

                    switch(input)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("You've entered: 1");
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("You've entered: 2");
                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine("You've entered: 3");
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine("You've entered: 4");
                            break;
                        case "5":
                            Console.Clear();
                            Console.WriteLine("You've entered: 5");
                            break;
                        case "6":
                            Console.Clear();
                            Console.WriteLine("You've entered: 6");
                            break;
                        case "7":
                            Console.Clear();
                            Console.WriteLine("You've entered: 7");
                            break;
                        case "8":
                            Console.Clear();
                            Console.WriteLine("You've entered: 8");
                            break;
                        case "9":
                            Console.Clear();
                            Console.WriteLine("You've entered: 9");
                            break;
                    }
                } while (!exitCondition.Any(x => x == input));

                Console.Write("Closing Reddit...");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("");
                Environment.Exit(1);
            }
        }
    }
}
