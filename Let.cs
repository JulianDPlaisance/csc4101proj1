// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            String spaceStr = "";
            // There got to be a more efficient way to print n spaces.
            for (int i = 0; i < n; i++)
                spaceStr += " ";

            Console.WriteLine(spaceStr);

            if (!p)
                Console.Write("(");

            t.getCar().print(0);

            if (t.getCdr().isPair())
                t.getCdr().print(4, true);
            else
                t.getCdr().print(4);
        }
    }
}


