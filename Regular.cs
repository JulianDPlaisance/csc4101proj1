// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
        // TODO: Add any fields needed.
    
        // TODO: Add an appropriate constructor.
        public Regular() { }

        public override void print(Node t, int n, bool p)
        {
            n--;
            // TODO: Implement this function.
            String spaceStr = "";
            // There got to be a more efficient way to print n spaces.
            for (int i = 1; i < n; i++)
                spaceStr += " ";
            Console.Write(spaceStr);

            if (!p)
                Console.Write("(");

            if (t.getCar().isPair())
            {
                t.getCar().print(1, false);
                //Console.WriteLine(")");
            }
            else
            {
                //Console.WriteLine();
                t.getCar().print(1);
            }

            if (t.getCdr().isPair())
            {
               //Console.WriteLine();
                t.getCdr().print(2, true);
            }
            else
            {
               // Console.WriteLine();
                t.getCdr().print(1);
            }

        }
    }
}


