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

            public int CompareTo(object obj)
            {
                return name.CompareTo(obj);
            }

            public IEnumerator GetEnumerator()
            {
                return ((IEnumerable)subPosts).GetEnumerator();
            }
        }
        class Post
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
        }

        class Comment
        {

        }

        static void Main(string[] args)
        {
        }
    }
}
