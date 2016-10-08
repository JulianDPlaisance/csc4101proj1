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
                //Console.Write("NullParseExp()   ");
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
                  //  Console.Write("YEA BOI (    ");
                    return parseRest();
                        
                    case TokenType.FALSE:
                  //  Console.Write("YEA FALSE#    ");
                    return faLit;
                        
                    case TokenType.TRUE:
                 //   Console.Write("YEA #TRUE    ");
                    return trueLit;

                    case TokenType.QUOTE:
                 //   Console.Write("YEA QUOTE    ");
                    return new Cons(new Ident(scannerToken.getName()), new Cons(parseExp(), NIN)); //need to check for null here

                    case TokenType.INT:
                //    Console.WriteLine(scannerToken.getIntVal() + "INT");
                    return new IntLit(scannerToken.getIntVal());

                    case TokenType.STRING:
                  //  Console.Write("YEA STRING THEORY    ");
                    return new StringLit(scannerToken.getStringVal());

                    case TokenType.IDENT:
                   // Console.Write("Clark Wayne?    ");
                    return new Ident(scannerToken.getName());

                    default:
                  //  Console.Write("DEFAULT MODE ACTIVATION  ");
                    return null;
                }
        }
  
        protected Node parseRest()
        {
            scannerToken = scanner.getNextToken();
            //Console.WriteLine(scannerToken + "Rest");
            if (scannerToken == null)
            {
                //Console.Write("NullRestDetected");
                return null;
            }
            else
            {
                switch (scannerToken.getType())
                {
                    case TokenType.RPAREN:
                        //Console.Write("DON'T WANT TO BE AN AMERICAN RPAREN  ");
                        return NIN;

                    case TokenType.DOT:
                       // Console.Write("The Warner Brothers and their Sister DOT     ");
                        return new Cons(parseExp(), parseRest());

                    default:
                       // Console.Write("FKCLFKAJSKDJ     ");
                        return new Cons(parseExp(scannerToken), parseRest());
                }
            }
        }

        // TODO: Add any additional methods you might need.
    }
}

