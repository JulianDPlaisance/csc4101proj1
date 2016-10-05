<<<<<<< HEAD
// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree
{
    public class Quote : Special
    {
        // TODO: Add any fields needed.
        private bool isQuoteChr;
        // TODO: Add an appropriate constructor.

	public Quote(bool b)
        {
            isQuoteChr = b;
        }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            if (isQuoteChr)
                Console.Write("'");
            else
                Console.Write("quote");
            t.print(n);
        }
    }
}

=======
// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree
{
    public class Quote : Special
    {
        // TODO: Add any fields needed.
  
        // TODO: Add an appropriate constructor.
	public Quote() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
        }
    }
}

>>>>>>> origin/master
