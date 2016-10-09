// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
        // TODO: Add any fields needed.
        // TODO: Add an appropriate constructor.

        public Define()
        {

        }

        public override void print(Node t, int n, bool p)
        {
            n--;
            String spaceStr = "";
            // There got to be a more efficient way to print n spaces.
            for (int i = 1; i < n; i++)
                spaceStr += " ";

            Console.Write(spaceStr);

            if (!p)
                Console.Write("(");
            t.getCar().print(n + 1);

            if (t.getCdr().isPair())
            {
                t.getCdr().print(n + 2, true);
            }
            else
            {
                t.getCdr().print(n);
            }
        }
    }
}