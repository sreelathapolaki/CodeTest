using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise
{
    //PieceMoves 
    public class PieceMoves
    {
        public static void KnightMoves(int x, int y)
        {
            int[] row = { 2, 1, -1, -2, -2, -1, 1, 2 }; //possible moves in x direction
            int[] col = { 1, 2, 2, 1, -1, -2, -2, -1 }; // possible moves in y direction
            /*int x = 0;

            switch (c)
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
            */
            char[] pos = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
           
            List<string> moves = new List<string>();

            for (int k = 0; k < 8; k++)
            {
                int newX = x + row[k];
                int newY = y + col[k];

                if (newX > 0 && newY > 0 && newX < 8 && newY < 8)
                {
                    moves.Add(pos[newX-1] + newY.ToString());
                }
            }
            foreach(string item in moves)
            {
                Console.Write(item + "  ");
            }

        }

        public static void RookMoves(int x , int y)
        {
           /* int x = 0;

            switch (c)
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
            */
            char[] pos = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            List<string> lmoves = new List<string>();
            List<string> rmoves = new List<string>();
            List<string> umoves = new List<string>();
            List<string> dmoves = new List<string>();
            for (int i = 1; i <= 8; i++)
            {
                //Left move
                if(x-i > 0 && x-i <=8 && y > 0 && y <=8)
                {
                    lmoves.Add(pos[(x-i) -1].ToString() + (y).ToString());
                }

                //Right move
                if (x + i > 0 && x + i <= 8 && y > 0 && y <= 8)
                {
                    rmoves.Add(pos[(x + i) - 1].ToString() + (y).ToString());
                }

                //Up move
                if (x  > 0 && x <= 8 && y+i > 0 && y+i <= 8)
                {
                    umoves.Add(pos[x - 1].ToString() + ((y+i)).ToString());
                }

                //Down move
                if (x > 0 && x <= 8 && y - i > 0 && y - i <= 8)
                {
                    dmoves.Add(pos[x - 1].ToString() + ((y - i) ).ToString());
                }
              
            }
            Console.WriteLine("Left Moves: ");
            foreach(string item in lmoves)
            {
                Console.Write(item+"  ");
            }
            Console.WriteLine("\nRight Moves: ");
            {
                foreach (string item in rmoves)
                {
                    Console.Write(item + "  ");
                }
            }
            Console.WriteLine("\nUp Moves: ");
            {
                foreach (string item in umoves)
                {
                    Console.Write(item + "  ");
                }
            }
            Console.WriteLine("\nDown Moves: ");
            {
                foreach (string item in dmoves)
                {
                    Console.Write(item + "  ");
                }
            }
         
        }

        public static void BishopMoves(int x, int y)
        {
           /* int x = 0;

            switch (c)
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
            */
            char[] pos = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            List<string> ldown = new List<string>();
            List<string> rdown = new List<string>();
            List<string> uleft = new List<string>();
            List<string> uright = new List<string>();

            for (int i = 1; i <= 8; i++)
            {
                if ((x >0 && x <= 8) && (y > 0 && y <= 8))
                {
                    //Left down diagonal direction
                    if (x - i > 0 && x - i <= 8 && y - i > 0 && y - i <= 8)
                    {
                      ldown.Add(pos[(x-i)-1] + (y-i).ToString());

                    }
                    //Right down diagonal direction   
                    if (x + i > 0 && x + i <= 8 && y - i > 0 && y - i <= 8)
                    {
                      rdown.Add(pos[(x+i)-1]+ (y-i).ToString());
                    }
                    //Up left diagonal direction   
                    if (x - i > 0 && x - i <= 8 && y + i > 0 && y + i <= 8)
                    {
                       uleft.Add(pos[(x-i)-1]+(y+i).ToString());
                    }
                    //Up right diagonal direction
                    if (x + i > 0 && x + i <= 8 && y + i > 0 && y + i <= 8)
                    {
                       uright.Add(pos[(x + i) - 1] + (y + i).ToString());
                    }
                        
                }
            }

            Console.WriteLine("Left Down Diagonal Moves: ");
            foreach (string item in ldown)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine("\nRight Down Diagonal Moves: ");
            {
                foreach (string item in rdown)
                {
                    Console.Write(item + "  ");
                }
            }
            Console.WriteLine("\nUp Left Diagonal Moves: ");
            {
                foreach (string item in uleft)
                {
                    Console.Write(item + "  ");
                }
            }
            Console.WriteLine("\nUp Right Diagonal RMoves: ");
            {
                foreach (string item in uright)
                {
                    Console.Write(item + "  ");
                }
            }

        }


    }


}
