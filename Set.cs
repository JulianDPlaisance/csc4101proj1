// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Set() { }
	
        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            String spaceStr = "";
            // There got to be a more efficient way to print n spaces.
            for (int i = 0; i < n; i++)
                spaceStr += " ";
            Console.Write(spaceStr + "set!");
            t.print(1);
        }
    }
}

