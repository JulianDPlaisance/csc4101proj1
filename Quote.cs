// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree
{
    public class Quote : Special
    {
        // TODO: Add any fields needed.
        // TODO: Add an appropriate constructor.

	public Quote()
        { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            String spaceStr = "";
            // There got to be a more efficient way to print n spaces.
            for (int i = 1; i < n; i++)
                spaceStr += " ";

            Console.Write(spaceStr);



            t.getCar().print(n);
            if (!p)
                Console.Write("(");


            if (t.getCdr().isPair())
            {
                t.getCdr().print(n, true);
            }
            else
            {
                t.getCdr().print(n);
            }
        }
    }
}

