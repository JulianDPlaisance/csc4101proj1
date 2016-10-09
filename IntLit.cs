// IntLit -- Parse tree node class for representing integer literals

using System;

namespace Tree
{
    public class IntLit : Node
    {
        private int intVal;

        public IntLit(int i)
        {
            intVal = i;
        }

        public override void print(int n)
        {
            String spaceStr = "";
            // There got to be a more efficient way to print n spaces.
            for (int i = 1; i < n; i++)
                spaceStr += " ";

            Console.Write(spaceStr);
            if (n == 0)
                Console.WriteLine(intVal);
            else
                Console.Write(intVal);
        }

        public override bool isNumber() { return true; }
    }
}
