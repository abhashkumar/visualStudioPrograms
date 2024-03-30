// C# code to find number of unique paths
// in a Matrix
using System;
using System.Text.Json;

class Program
{

    // Driver code
    static void Main(string[] args)
    {
        int[,] A = new int[4, 4] { { 0, 0, 0 , 0},
                                    { 0, 1, 0, 0 },
                                    { 0, 1, 1 , 0},
                                    { 0, 1, 0 , 0}};
        uniquePathsWithObstacles(A);
    }

    static void uniquePathsWithObstacles(int[,] A)
    {
        int r = A.GetLength(0);
        int c = A.GetLength(1);
        UniquePathHelper(0, 0, r, c, A);

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                Console.WriteLine($"i = {i}, j = {j}, value = {A[i, j]}");
            }
        }
    }

    static bool UniquePathHelper(int i, int j, int r, int c,
                                int[,] A)
    {
        // boundary condition or constraints
        if (i == r || j == c)
        {
            return false;
        }

        if (A[i, j] == 1)
        {
            return false;
        }

        if (A[i, j] == -1)
        {
            return true;
        }
        // base case
        if (i == r - 1 && j == c - 1)
        {
            if (A[i, j] == 0)
            {
                A[i, j] = -1;
                return true;
            }
            return false;
        }

        if (A[i, j] == 0)
        {
            bool x = UniquePathHelper(i + 1, j, r, c, A);
            bool y = UniquePathHelper(i, j + 1, r, c, A);
            if(x || y)
            {
                A[i, j] = -1;
                return true;
            }
            return false;
        }
        return false;

    }
}

