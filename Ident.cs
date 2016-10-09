// Ident -- Parse tree node class for representing identifiers

using System;

namespace Tree
{
    public class Ident : Node
    {
        private string name;

        public Ident(string n)
        {
            name = n;
        }

        public override void print(int n)
        {
            String spaceStr = "";
            // There got to be a more efficient way to print n spaces.
            for (int i = 1; i < n; i++)
                spaceStr += " ";

            Console.Write(spaceStr);
            if (n == 0)
                Console.WriteLine(name);
            else
                Console.Write(name);

                
        }

        public override bool isSymbol() { return true; }

        public override string ToString()
        {
            return name;
        }
    }
}

