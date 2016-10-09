// Cons -- Parse tree node class for representing a Cons node

using System;

namespace Tree
{
    public class Cons : Node
    {
        private Node car;
        private Node cdr;
        private Special form;
        String ident;
    
        public Cons(Node a, Node d)
        {
            car = a;
            cdr = d;
            parseList();
        }
    
        // parseList() `parses' special forms, constructs an appropriate
        // object of a subclass of Special, and stores a pointer to that
        // object in variable form.  It would be possible to fully parse
        // special forms at this point.  Since this causes complications
        // when using (incorrect) programs as data, it is easiest to let
        // parseList only look at the car for selecting the appropriate
        // object from the Special hierarchy and to leave the rest of
        // parsing up to the interpreter.
        void parseList()
        {
            // TODO: implement this function and any helper functions
            // you might need.

            if (car.isSymbol())
            {
                ident = ((Ident)car).ToString().ToUpper();

                switch (ident)
                {
                    case "BEGIN":
                        form = new Begin();
                        break;
                    case "COND":
                        form = new Cond();
                        break;
                    case "DEFINE":
                        form = new Define();
                        break;
                    case "IF":
                        form = new If();
                        break;
                    case "LAMBDA":
                        form = new Lambda();
                        break;
                    case "LET":
                        form = new Let();
                        break;
                    case "'":
                        //Console.WriteLine("AMERICA FIN");
                        form = new Quote();
                        break;
                    case "QUOTE":
                        //Console.WriteLine("ORAORAORAORAORAORAORAORAORA");
                        form = new Quote();
                        break;
                    case "SET":
                        form = new Set();
                        break;
                    case "SET!":
                        form = new Set();
                        break;
                    default:
                       // Console.WriteLine("DORADORADORADORATHEEXPLORATHEEXPLORA");
                        form = new Regular();
                        break;
                }
            }
            else
            {
                //Console.WriteLine("FINISHED WITH THE LEMONLAIDE");
                form = new Regular();
            }

        }

        public override Node getCar()
        {
            return car;
        }

        public override Node getCdr()
        {
            return cdr;
        }

        public override void setCar(Node a)
        {
            car = a;
            parseList();
        }

        public override void setCdr(Node d)
        {
            cdr = d;
        }

        public override void print(int n)
        {
            form.print(this, n + 1, false);
        }

        public override void print(int n, bool p)
        {
            form.print(this, n + 1, p);
        }

        public override bool isPair() { return true; }
    }
}

