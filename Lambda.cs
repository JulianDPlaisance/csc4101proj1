<<<<<<< HEAD
// Lambda -- Parse tree node strategy for printing the special form lambda

using System;

namespace Tree
{
    public class Lambda : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Lambda() { }

        public override void print(Node t, int n, bool p)
        {
            String spaceStr = "";
            // There got to be a more efficient way to print n spaces.
            for (int i = 0; i < n; i++)
                spaceStr += " ";

            Console.WriteLine(spaceStr);

            if (!p)
                Console.Write("(");

            Console.Write("LAMBDA ");
            t.print(0, !p);
        }
    }
}

=======
// Lambda -- Parse tree node strategy for printing the special form lambda

using System;

namespace Tree
{
    public class Lambda : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Lambda() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
  	}
    }
}

>>>>>>> origin/master
