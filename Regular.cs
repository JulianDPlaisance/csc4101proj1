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
            // TODO: Implement this function.
            String spaceStr = "";
            // There got to be a more efficient way to print n spaces.
            for (int i = 0; i < n; i++)
                spaceStr += " ";
            t.print(n);
        }
    }
}


