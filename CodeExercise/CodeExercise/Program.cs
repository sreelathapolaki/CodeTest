using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CodeExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please Provide chess piece type and its X,Y Position");
                Console.WriteLine("Usage: CodeExercise1 <Knight> <d2>");
            }

            string pieceType = args[0];
            char[] c = new char[args[1].Length];
            int i = 0;
            foreach (char b in args[1])
            {
                c[i] = b;
                i++;
            }

            char ch = c[0];
            int x = 0;

            int y = int.Parse(c[1].ToString());

            var res = Regex.Matches(args[1], "^[a-z]\\d$");

            if (res.Count == 0)
            {
                Console.WriteLine("Invalid input paramater for position, please provide d8 format");
                return;
            }

            switch (ch)
            {
                case 'a':
                    x = 1;
                    break;
                case 'b':
                    x = 2;
                    break;
                case 'c':
                    x = 3;
                    break;
                case 'd':
                    x = 4;
                    break;
                case 'e':
                    x = 5;
                    break;
                case 'f':
                    x = 6;
                    break;
                case 'g':
                    x = 7;
                    break;
                case 'h':
                    x = 8;
                    break;
                default:
                    break;
            }

            if ((x <= 0 || x > 8) || (y <= 0 || y > 8))
            {
                Console.WriteLine("Piece position is invalid, Please provide valid positions ");
                return;
            }

            if (pieceType.Equals("Knight", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Below are the possible moves of Knight at " + ch + y.ToString() + " position are: ");
                PieceMoves.KnightMoves(x, y);
            }
            else if (pieceType.Equals("Rook", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Below are the possible moves of Rook at " + ch + y.ToString() + " position are: ");
                PieceMoves.RookMoves(x, y);
            }
            else if (pieceType.Equals("Queen", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Below are the possible moves of Queen at " + ch + y.ToString() + "position are: ");
                PieceMoves.RookMoves(x, y);
                PieceMoves.BishopMoves(x, y);
            }
            else
            {
                Console.WriteLine("Invalid input. Only Knight,Rook and Queen moves are supported");
            }
            Console.ReadKey();

        }
    }
}
