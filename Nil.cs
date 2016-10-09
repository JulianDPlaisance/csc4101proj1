// Nil -- Parse tree node class for representing the empty list

using System;

namespace Tree
{
    public class Nil : Node
    {
        public Nil() { }
  
        public override void print(int n)
        {
            print(n, false);
        }

        public override void print(int n, bool p)
        {
            n--;
            String spaceStr = "";
            // There got to be a more efficient way to print n spaces.
            for (int i = 1; i < n; i++)
                spaceStr += " ";

            Console.Write(spaceStr);

            if (n == 0)
            {
                if (!p)
                    Console.WriteLine(")");
                else
                    Console.WriteLine("()");
            }
            else
            {
                if (!p)
                    Console.Write(")");
                else
                    Console.Write("()");
            }

        }

        public override bool isNull() { return true; }
    }
}
