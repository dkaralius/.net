using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO

namespace Assignment1
{
    class Program
    {
        class User : IComparable
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

            //Sort by Name, in ascending order(default)
            public int CompareTo(object obj)
            {
                return name.CompareTo(obj);
            }

            //Overriden ToString() method
            public override string ToString()
            {
                return base.ToString();
            }

        }
        class Subreddit : IComparable, IEnumerable
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

            public int CompareTo(Subreddit obj)
            {
                return this.name.CompareTo(obj.name);
            }

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
        class Post : IComparable, IEnumerable
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
                    if(weight == 0)
                    {
                        return Score;
                    }
                    if(weight == 1)
                    {
                        return Score * (2 / 3);
                    }
                    if (weight == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        Console.Write("Invalid weight provided.");
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
                timeStamp = new DateTime(0,0,0,0,0,0);
            }
            //Alternate Constructor if provided all arguements for the user
            public Post(uint id, uint authorID, string title, string postContent, uint subHome, uint upVotes, uint downVotes,uint weight, int year, int month, int day, int hour, int minute, int second)
            {
                this.id = id;
                this.authorID = authorID;
                this.title = title;
                this.postContent = postContent;
                this.subHome = subHome;
                this.upVotes = upVotes;
                this.downVotes = downVotes;
                this.weight = weight;
                this.timeStamp = new DateTime(year,month,day,hour,minute,second);
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

            public int CompareTo(Post obj)
            {
                return obj.PostRating.CompareTo(this.PostRating);
            }


        }

        class Comment
        {

        }

        static void Main(string[] args)
        {
        }
    }
}
