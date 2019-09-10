using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "fudge, shoot, baddie, test, hi, hello, butthead";
            string[] censoredWords = { "fudge", "shoot", "butthead", "baddie" };
            string censoredMessage = message;

            Console.Write("Uncensored message: '");
            Console.Write(message);
            Console.Write("'");
            Console.WriteLine("");

            foreach (string x in censoredWords)
            {
                if (message.Contains(x))
                {
                    message = message.Replace(x, "*****");
                    censoredMessage = message;
                }
            }
            Console.Write("Censored message: '");
            Console.Write(censoredMessage);
            Console.WriteLine("'");
        }
    }
}
