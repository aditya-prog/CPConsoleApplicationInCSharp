using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System;

namespace Recursions
{
    class NQueen
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            var res = new List<IList<string>>();
            var possibleSol = new List<char[]>();
            for (int i = 0; i < n; i++)
            {
                char[] row = new char[n];
                for (int j = 0; j < n; j++)
                {
                    row[j] = '.';
                }
                possibleSol.Add(row);
            }

            SolveQueenUtil(n, 0, possibleSol, res);
            return res;
        }

        private void SolveQueenUtil(int n, int row, List<char[]> possibleSol, List<IList<string>> res)
        {

            if (row == n)
            {
                res.Add(possibleSol.Select(data => new string(data)).ToList());// always
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (IsSafe(n, possibleSol, row, col))
                {
                    possibleSol[row][col] = 'Q';
                    SolveQueenUtil(n, row + 1, possibleSol, res);
                    possibleSol[row][col] = '.'; // backtrack
                }
            }

            return;
        }

        private bool IsSafe(int n, List<char[]> possibleSol, int row, int col)
        {
            IList<IList<int>> positions = GetPositionsOfQueen(possibleSol, n);

            // Check for row and col attack
            foreach (var pos in positions)
            {
                if (row == pos[0] || col == pos[1])
                { // if rows/col matches, then collision
                    return false;
                }
            }

            // Check for diagonal attack
            foreach (var pos in positions)
            {
                int currow = pos[0];
                int currcol = pos[1];
                // Move right upward diagonal
                for (int i = currow - 1, j = currcol + 1; i >= 0 && j < n; i--, j++)
                {
                    if (i == row && j == col)
                    {
                        return false;
                    }
                }

                // Move right downward diagonal
                for (int i = currow + 1, j = currcol + 1; i < n && j < n; i++, j++)
                {
                    if (i == row && j == col)
                    {
                        return false;
                    }
                }

                // Move left upward diagonal
                for (int i = currow - 1, j = currcol - 1; i >= 0 && j >= 0; i--, j--)
                {
                    if (i == row && j == col)
                    {
                        return false;
                    }
                }

                // Move left downward diagonal
                for (int i = currow + 1, j = currcol - 1; i < n && j >= 0; i++, j--)
                {
                    if (i == row && j == col)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private IList<IList<int>> GetPositionsOfQueen(List<char[]> possibleSol, int n)
        {
            var res = new List<IList<int>>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (possibleSol[i][j] == 'Q')
                    {
                        res.Add(new List<int>() { i, j });
                    }
                }
            }

            return res;
        }
    }
}

