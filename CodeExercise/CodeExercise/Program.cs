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
            if (args.Length != 2)
            {
                Console.WriteLine("Please Provide chess piece type and its X,Y Position");
                Console.WriteLine("Usage: CodeExercise1 <Knight> <d2>");
                return;
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
            int rowPos = 0;
            int colPos = int.Parse(c[1].ToString());
            var res = Regex.Matches(args[1], "^[a-z]\\d$");

            if (res.Count == 0)
            {
                Console.WriteLine("Invalid input paramater for position, please provide d8 format");
                return;
            }

            switch (ch)
            {
                case 'a':
                    rowPos = 1;
                    break;
                case 'b':
                    rowPos = 2;
                    break;
                case 'c':
                    rowPos = 3;
                    break;
                case 'd':
                    rowPos = 4;
                    break;
                case 'e':
                    rowPos = 5;
                    break;
                case 'f':
                    rowPos = 6;
                    break;
                case 'g':
                    rowPos = 7;
                    break;
                case 'h':
                    rowPos = 8;
                    break;
                default:
                    break;
            }
            if ((rowPos <= 0 || rowPos > 8) || (colPos <= 0 || colPos > 8))
            {
                Console.WriteLine("Piece position is invalid, Please provide valid positions ");
                return;
            }
            if (pieceType.Equals("Knight", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Below are the possible moves of Knight at " + ch + colPos.ToString() + " position are: ");
                string inputPos = rowPos.ToString() + colPos.ToString();
                Knight moves = new Knight();
                List<string> movesList = moves.Moves(rowPos, colPos);
                ChessBase.PrintPossibleMoves(inputPos, movesList);
            }
            else if (pieceType.Equals("Rook", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Below are the possible moves of Rook at " + ch + colPos.ToString() + " position are: ");
                string inputPos = rowPos.ToString() + colPos.ToString();
                Rook moves = new Rook();
                List<string> movesList = moves.Moves(rowPos, colPos);
                ChessBase.PrintPossibleMoves(inputPos, movesList);
            }
            else if (pieceType.Equals("Queen", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Below are the possible moves of Queen at " + ch + colPos.ToString() + " position are: ");
                string inputPos = rowPos.ToString() + colPos.ToString();
                Queen moves = new Queen();
                List<string> movesList = moves.Moves(rowPos, colPos);
                ChessBase.PrintPossibleMoves(inputPos, movesList);
            }
            else
            {
                Console.WriteLine("Invalid input. Only Knight,Rook and Queen moves are supported");
                return;
            }
            Console.ReadKey();
        }
    }
}
