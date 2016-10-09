// StringLit -- Parse tree node class for representing string literals

using System;

namespace Tree
{
    public class StringLit : Node
    {
        private string stringVal;

        public StringLit(string s)
        {
            stringVal = s;
        }

        public override void print(int n)
        {
            String spaceStr = "";
            // There got to be a more efficient way to print n spaces.
            for (int i = 1; i < n - 1; i++)
                spaceStr += " ";
            Console.Write(spaceStr);

            if (n == 0)
                Console.WriteLine(stringVal);
            else
                Console.Write(stringVal);
        }

        public override bool isString() { return true; }
        public override string ToString()
        {
            return stringVal;
        }
    }
}

