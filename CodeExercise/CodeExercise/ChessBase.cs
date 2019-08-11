using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CodeExercise
{
    public abstract class ChessBase
    {
        public static int width = 6;
        public abstract List<string> Moves(int rowPos, int colPos);
       
        static void PrintRowData(string[] columns)
        {
           string row = "|";
           foreach (string column in columns)
           {
                if (column == null)
                    row += AlignText(" ", 6) + "|";
                else
                    row += AlignText(column, 6) + "|";
           }
            Console.WriteLine(row);
    }

    static string AlignText(string text, int width)
    {
        text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

        if (string.IsNullOrEmpty(text))
        {
            return new string(' ', width);
        }
        else
        {
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
    public static void PrintPossibleMoves(string inputPos, List<string> moves)
    {
            for (int i = 1; i <= 8; i++)
            {
                string[] data = new string[8];
                for (int j = 1; j <= 8; j++)
                {
                    Regex match = new Regex("^" + i + j + "$");
                    foreach (string move in moves)
                    {
                        if (match.IsMatch(move))
                        {
                            if (data[j - 1] == null)
                                data[j - 1] = "Move";
                        }
                        if (match.IsMatch(inputPos))
                        {
                            if (data[j - 1] == null)
                                data[j - 1] = "Pos";
                        }
                    }
                }
                Console.WriteLine(new string('-', 57));
                PrintRowData(data);
            }
            Console.WriteLine(new string('-', 57));
    }
}

    public class Knight: ChessBase
    {
        public override List<string> Moves(int rowPos, int colPos)
        {
            int[] row = { 2, 1, -1, -2, -2, -1, 1, 2 }; //possible moves in x direction
            int[] col = { 1, 2, 2, 1, -1, -2, -2, -1 }; // possible moves in y direction
            List<string> moves = new List<string>();
            string inputPos = rowPos.ToString()+colPos.ToString();

            for (int k = 0; k < 8; k++)
            {
                int newRPos = rowPos + row[k];
                int newCPos = colPos + col[k];

                if (newRPos > 0 && newCPos > 0 && newRPos < 8 && newCPos < 8)
                {
                    moves.Add(newRPos + newCPos.ToString());
                }
            }
            return moves;
        }
    }
    public class Queen:ChessBase
    {
        public override List<string> Moves(int rowPos, int colPos)
        {
            List<string> moves = new List<string>();
            string inputPos = rowPos.ToString() + colPos.ToString();

            for (int i = 1; i <= 8; i++)
            {
                //Left move
                if (rowPos - i > 0 && rowPos - i <= 8 && colPos > 0 && colPos <= 8)
                {
                    moves.Add((rowPos - i).ToString() + (colPos).ToString());
                }
                //Right move
                if (rowPos + i > 0 && rowPos + i <= 8 && colPos > 0 && colPos <= 8)
                {
                    moves.Add((rowPos + i).ToString() + (colPos).ToString());
                }
                //Up move
                if (rowPos > 0 && rowPos <= 8 && colPos + i > 0 && colPos + i <= 8)
                {
                    moves.Add(rowPos.ToString() + ((colPos + i)).ToString());
                }
                //Down move
                if (rowPos > 0 && rowPos <= 8 && colPos - i > 0 && colPos - i <= 8)
                {
                    moves.Add(rowPos.ToString() + ((colPos - i)).ToString());
                }

                if ((rowPos > 0 && rowPos <= 8) && (colPos > 0 && colPos <= 8))
                {
                    //Left down diagonal direction
                    if (rowPos - i > 0 && rowPos - i <= 8 && colPos - i > 0 && colPos - i <= 8)
                    {
                        moves.Add((rowPos - i).ToString() + (colPos - i).ToString());
                    }
                    //Right down diagonal direction   
                    if (rowPos + i > 0 && rowPos + i <= 8 && colPos - i > 0 && colPos - i <= 8)
                    {
                        moves.Add((rowPos + i).ToString() + (colPos - i).ToString());
                    }
                    //Up left diagonal direction   
                    if (rowPos - i > 0 && rowPos - i <= 8 && colPos + i > 0 && colPos + i <= 8)
                    {
                        moves.Add((rowPos - i).ToString() + (colPos + i).ToString());
                    }
                    //Up right diagonal direction
                    if (rowPos + i > 0 && rowPos + i <= 8 && colPos + i > 0 && colPos + i <= 8)
                    {
                        moves.Add((rowPos + i).ToString() + (colPos + i).ToString());
                    }
                }
            }
            return moves;
        }
    }

    public class Rook : ChessBase
    {
        public override List<string> Moves(int rowPos, int colPos)
        {
            List<string> moves = new List<string>();
            string inputPos = rowPos.ToString() + colPos.ToString();

            for (int i = 1; i <= 8; i++)
            {
                //Left move
                if (rowPos - i > 0 && rowPos - i <= 8 && colPos > 0 && colPos <= 8)
                {
                    moves.Add((rowPos - i).ToString() + (colPos).ToString());
                }
                //Right move
                if (rowPos + i > 0 && rowPos + i <= 8 && colPos > 0 && colPos <= 8)
                {
                    moves.Add((rowPos + i).ToString() + (colPos).ToString());
                }
                //Up move
                if (rowPos > 0 && rowPos <= 8 && colPos + i > 0 && colPos + i <= 8)
                {
                    moves.Add(rowPos.ToString() + ((colPos + i)).ToString());
                }
                //Down move
                if (rowPos > 0 && rowPos <= 8 && colPos - i > 0 && colPos - i <= 8)
                {
                    moves.Add(rowPos.ToString() + ((colPos - i)).ToString());
                }
            }
            return moves;
        }
    }

}
