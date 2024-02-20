namespace StackAndQueue
{
    using System;
    class Celibrity
    {
        public int Celebrity(int[,] M, int n)
        {
            int i = 0;
            int j = n - 1;

            while (i < j)
            {
                if (M[i, j] == 1)
                {
                    // if i knows j , then i can't be ceibrity but j can be
                    i++;
                }
                else
                {
                    // j can't be celebrity, because i don't know j
                    j--;
                }
            }

            if (IsValidCelebrity(i, n, M))
            {
                return i;
            }

            return -1;
        }

        private bool IsValidCelebrity(int celeb, int n, int[,] mat)
        {
            for (int i = 0; i < n; i++)
            {
                if (i != celeb && (mat[i, celeb] == 0 || mat[celeb, i] == 1))
                {
                    return false;
                }
            }
            return true;

        }
    }

    /*
        The idea is to use two pointers, one from start and one from the end. 
        Assume the start person is A, and the end person is B. If A knows B, then A must not 
        be the celebrity so increment A. Else, B must not be the celebrity so decrement B. At the end of the loop, only one
         index will be left as a celebrity. 
         Now cross verify/validate if the leftover person is actually a celebrity.
    */
}