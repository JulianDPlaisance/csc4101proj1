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
            if (scannerToken == null)
                return null;

            //TODO: write code for parsing an exp
            switch (scannerToken.getType())
                {
                    case TokenType.LPAREN:
                        return parseRest(scannerToken.getType());
                        
                    case TokenType.FALSE:
                        return faLit;
                        
                    case TokenType.TRUE:
                        return trueLit;

                    case TokenType.QUOTE:
                        return new Cons(new Ident("quote"), new Cons(parseExp(), NIN)); //need to check for null here

                    case TokenType.INT:
                        return new IntLit(scannerToken.getIntVal());

                    case TokenType.STRING:
                        return new StringLit(scannerToken.getStringVal());

                    case TokenType.IDENT:
                        return new Ident(scannerToken.getName());

                    default:
                        parseExp();
                        break;
                }
            return null;
        }
  
        protected Node parseRest(TokenType t)
        {
            switch (t)
            {
                case TokenType.RPAREN:
                    return NIN;

                default:
                    return new Cons(parseExp(), parseRest(scannerToken.getType())); // need a . case and a null check
            }
        }

        // TODO: Add any additional methods you might need.
    }
}

