// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Begin() { }

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
            Console.Write(n);
            t.getCar().print(n);

            if (t.getCdr().isPair())
            {
                t.getCdr().print(n + 4, true);
            }
            else
            {
                t.getCdr().print(n + 4);
            }
        }
    }
}

