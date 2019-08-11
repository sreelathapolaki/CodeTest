using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeExercise;
using System.Collections.Generic;

namespace ChessMovesTest
{
    [TestClass]
    public class PieceMovesTest
    {
        [TestMethod]
        public void KnightMovesTest()
        {
            ChessBase moves = new Knight();
            List<string> posMoves = new List<string> { "21", "61", "23", "63", "34", "54" };
            List<string> movesList = moves.Moves(4, 2);
            List<string> expList = new List<string>();


            bool isMatch = false;
            foreach (var item1 in posMoves)
            {
                foreach (var item2 in movesList)
                {
                    if (item2 == item1)
                    {
                        expList.Add(item1);
                    }
                }
            }

            if (expList.Count == posMoves.Count)
            {
                isMatch = true;
            }

            Assert.AreEqual(true, isMatch);
        }

        [TestMethod]
        public void RookMovesTest()
        {
            ChessBase moves = new Rook();
            List<string> posMoves = new List<string> { "55", "75", "66", "64", "45", "85", "67", "63", "35", "68", "62", "25", "61", "15" };

            List<string> movesList = moves.Moves(6, 5);
            List<string> expList = new List<string>();


            bool isMatch = false;
            foreach (var item1 in posMoves)
            {
                foreach (var item2 in movesList)
                {
                    if (item2 == item1)
                    {
                        expList.Add(item1);
                    }
                }
            }

            if (expList.Count == posMoves.Count)
            {
                isMatch = true;
            }
          
            Assert.AreEqual(true, isMatch);
        }

        [TestMethod]
        public void QueenMovesTest()
        {
            ChessBase moves = new Queen();
            List<string> posMoves = new List<string> { "43", "63", "54", "52", "42", "62", "44", "64", "33", "73", "55", "51", "31", "71", "35", "75", "23", "83", "56", "26", "86", "13", "57", "17", "58" };

            List<string> movesList = moves.Moves(5, 3);
            List<string> expList = new List<string>();


            bool isMatch = false;
            foreach (var item1 in posMoves)
            {
                foreach (var item2 in movesList)
                {
                    if (item2 == item1)
                    {
                        expList.Add(item1);
                    }
                }
            }

            if (expList.Count == posMoves.Count)
            {
                isMatch = true;
            }

            Assert.AreEqual(true, isMatch);
        }
    }
}
