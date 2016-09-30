// Scanner -- The lexical analyzer for the Scheme printer and interpreter

using System;
using System.IO;
using Tokens;

namespace Parse
{
    public class Scanner
    {
        private TextReader In;

        // maximum length of strings and identifier
        private const int BUFSIZE = 1000;
        private char[] buf = new char[BUFSIZE];

        public Scanner(TextReader i) { In = i; }
  
        // TODO: Add any other methods you need

        public Token getNextToken()
        {
            int ch;

            try
            {
                // It would be more efficient if we'd maintain our own
                // input buffer and read characters out of that
                // buffer, but reading individual characters from the
                // input stream is easier.
                ch = In.Read();

                // TODO: skip white space and comments
                if (ch == ' ')
                { ch = In.Read(); }
                if (ch == ';')
                {
                    while (ch != '\n')
                    { ch = In.Read(); }
                    ch = In.Read();
                }

                if (ch == -1)
                    return null;
        
                // Special characters
                else if (ch == '\'')
                    return new Token(TokenType.QUOTE);
                else if (ch == '(')
                    return new Token(TokenType.LPAREN);
                else if (ch == ')')
                    return new Token(TokenType.RPAREN);
                else if (ch == '.')
                    // We ignore the special identifier `...'.
                    return new Token(TokenType.DOT);
                
                // Boolean constants
                else if (ch == '#')
                {
                    ch = In.Read();

                    if (ch == 't')
                        return new Token(TokenType.TRUE);
                    else if (ch == 'f')
                        return new Token(TokenType.FALSE);
                    else if (ch == -1)
                    {
                        Console.Error.WriteLine("Unexpected EOF following #");
                        return null;
                    }
                    else
                    {
                        Console.Error.WriteLine("Illegal character '" +
                                                (char)ch + "' following #");
                        return getNextToken();
                    }
                }

                /**
                 * String constants
                 * if the character is a double quote then the buf char array will take in
                 * the character representation of the integer ch.
                 * then ch will read in the next character which will be put in buf array until
                 * ch is again a double quote, then buf adds a double quote and we return
                 * a string token of buf from 0 to length - 1
                 * 
                 */
                else if (ch == '"')
                {
                    buf[0] = (char)ch;
                    ch = In.Read();

                    int i = 1;

                    while (ch!='"')
                    {
                        buf[i] = (char)ch;
                        ch = In.Read();
                        i++;
                    }
                    buf[i] = '"';
                    return new StringToken(new String(buf, 0, i-1));
                }


                /**
                 * Integer constants
                 * if the character is a number 0 through 9 then make i equal to the number
                 * while the input stream is still giving numbers i is multiplied by 10 
                 * and the new number is added to i
                 * i is returned
                 * 
                 */
                else if (ch >= '0' && ch <= '9')
                {
                    int i = ch - '0';
                    ch = In.Read();
                    while(ch >= '0' && ch <= '9')
                    {
                        i = (i * 10) + (ch - '0');
                        ch = In.Read();
                    }
                    // make sure that the character following the integer
                    // is not removed from the input stream
                    return new IntToken(i);
                }
                //superman=clark kent ident
                else if ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || ch == '!' || (ch >= '$' && ch <= '&')
                        || ch == '*' || ch == '+' || (ch >= '-' && ch <= '/') || ch == ':'
                        || (ch >= '<' && ch <= '@') || ch == '^' || ch == '_' || ch == '~')
                {

                    buf[0] = (char)ch;
                    ch = In.Read();
                    int i = 1;
                    while (ch != ' ')
                    {
                        buf[i] = (char)ch;
                        ch = In.Read();
                        i++;
                    }
                    // make sure that the character following the integer
                    // is not removed from the input stream
                    return new IdentToken(new String(buf, 0, i - 1));
                }

                // Illegal character
                else
                {
                    Console.Error.WriteLine("Illegal input character '"
                                            + (char)ch + '\'');
                    return getNextToken();
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("IOException: " + e.Message);
                return null;
            }
        }
    }

}

