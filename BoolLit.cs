// BoolLit -- Parse tree node class for representing boolean literals

using System;

namespace Tree
{
    public class BoolLit : Node
    {
        private bool boolVal;
  
        public BoolLit(bool b)
        {
            boolVal = b;
        }
  
        public override void print(int n)
        {
            String spaceStr = "";
            // There got to be a more efficient way to print n spaces.
            for (int i = 1; i < n; i++)
                spaceStr += " ";

            Console.Write(spaceStr);

            if (n == 0)
            {
                if (boolVal)
                    Console.WriteLine("#t");
                else
                    Console.WriteLine("#f");
            }
            else
            {
                if (boolVal)
                    Console.Write("#t");
                else
                    Console.Write("#f");
            }
        }

        public override bool isBool() { return true; }  // BoolLit
    }
}
