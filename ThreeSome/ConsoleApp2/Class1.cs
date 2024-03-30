using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Solution
    {
        public void GameOfLife(int[][] board)
        {
            List<Tuple<int, int>> tul = new List<Tuple<int, int>>();


            // count number of zeros and ones in the neighbour, these values has to be updated before updating the cell
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                   int countOnes =  Solution.populateNeighbour(i, j, board);
                    Tuple<int, int> ij = new Tuple<int, int>(i,j);
                    if (board[i][j] == 1)
                    {
                        if (countOnes < 2 || countOnes > 3)
                            tul.Add(ij);
                    }
                    else
                    {
                        if (countOnes == 3) board[i][j] = 1;
                        tul.Add(ij);
                    }
                }
            }
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if(tul.FindIndex(x => x.Item1 == i && x.Item2 == j) != -1 )
                        board[i][j] = board[i][j] == 1? 0: 1;
                }
            }

        }
        public static int populateNeighbour(int i, int j, int[][] board)
        {
            int countOnes = 0;
            int rows = Math.Min(board.Length, 3);
            int columns = Math.Min(board[0].Length, 3);
            int start_i = i - 1;
            int start_j = j - 1;
            for(int x = start_i; x < rows; x++)
            {
                for(int y = start_j; y < columns; y++)
                {
                    if(x != y)
                    {
                        if (board[x][y] == 1)
                            countOnes += 1;
                    }
                }
            }
            return countOnes;
        }
    }
}
