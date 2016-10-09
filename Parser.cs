// Parser -- the parser for the Scheme printer and interpreter
//
// Defines
//
//   class Parser;
//
// Parses the language
//
//   exp  ->  ( rest
//         |  #f
//         |  #t
//         |  ' exp
//         |  integer_constant
//         |  string_constant
//         |  identifier
//    rest -> )
//         |  exp+ [. exp] )
//
// and builds a parse tree.  Lists of the form (rest) are further
// `parsed' into regular lists and special forms in the constructor
// for the parse tree node class Cons.  See Cons.parseList() for
// more information.
//
// The parser is implemented as an LL(0) recursive descent parser.
// I.e., parseExp() expects that the first token of an exp has not
// been read yet.  If parseRest() reads the first token of an exp
// before calling parseExp(), that token must be put back so that
// it can be reread by parseExp() or an alternative version of
// parseExp() must be called.
//
// If EOF is reached (i.e., if the scanner returns a NULL) token,
// the parser returns a NULL tree.  In case of a parse error, the
// parser discards the offending token (which probably was a DOT
// or an RPAREN) and attempts to continue parsing with the next token.

using System;
using Tokens;
using Tree;

namespace Parse
{
    public class Parser {
	
        private Scanner scanner;
        private Token scannerToken;
        private Nil NIN = new Nil();
        private BoolLit trueLit = new BoolLit(true), faLit = new BoolLit(false);
        public Parser(Scanner s)
        {
            scanner = s;
            
        }

        public Node parseExp()
        {
            scannerToken = scanner.getNextToken();
            //Console.WriteLine(scannerToken + "ExpACL");
            if (scannerToken == null)
            {
               // Console.WriteLine("NullParseExp()   ");
                return null;
            }
            else
                return parseExp(scannerToken);
        }
        public Node parseExp(Token t)
        {
            //Console.WriteLine(scannerToken + "Exp(Token)");
            //TODO: write code for parsing an exp
            switch (scannerToken.getType())
                {
                    case TokenType.LPAREN:
                  //  Console.WriteLine("YEA BOI (    ");
                    return parseRest();
                        
                    case TokenType.FALSE:
                    //  Console.WriteLine("YEA FALSE#    ");
                   // faLit.print(0);
                    return faLit;
                        
                    case TokenType.TRUE:
                    //Console.WriteLine("YEA #TRUE    ");
                   // trueLit.print(0);
                    return trueLit;

                    case TokenType.QUOTE:
                  //  Console.WriteLine("YEA QUOTE    ");
                    return new Cons(new Ident("'"), parseExp());

                case TokenType.INT:
                    //       Console.WriteLine(scannerToken.getIntVal() + "INT");
                    //new IntLit(scannerToken.getIntVal()).print(0);
                    return new IntLit(scannerToken.getIntVal());

                    case TokenType.STRING:
                    //      Console.WriteLine("YEA STRING THEORY    ");
                   // new StringLit(scannerToken.getStringVal()).print(0);
                    return new StringLit(scannerToken.getStringVal());

                    case TokenType.IDENT:
                    //   Console.WriteLine("Clark Wayne?    ");
                    //new Ident(scannerToken.getName()).print(0);
                    return new Ident(scannerToken.getName());

                    default:
                    //Console.WriteLine("DEFAULT MODE ACTIVATION  ");
                    return null;
                }
        }
  
        protected Node parseRest()
        {
            scannerToken = scanner.getNextToken();
            //Console.WriteLine(scannerToken + "Rest");
            if (scannerToken == null)
            {
                //Console.WriteLine(")");
                return null;
            }
            else
            {
                switch (scannerToken.getType())
                {
                    case TokenType.RPAREN:
                   //     Console.WriteLine("DON'T WANT TO BE AN AMERICAN RPAREN  ");
                        return NIN;

                    case TokenType.DOT:
                     //   Console.WriteLine("The Warner Brothers and their Sister DOT     ");
                        return new Cons(parseExp(), parseRest());

                    default:
                    //    Console.WriteLine("FKCLFKAJSKDJ     ");
                        return new Cons(parseExp(scannerToken), parseRest());
                }
            }
        }

        // TODO: Add any additional methods you might need.
    }
}

