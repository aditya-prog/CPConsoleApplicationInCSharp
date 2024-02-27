namespace StringsAndItsVariants
{
    public class MinCharctersForPalindrome
    {
        public int MinCharctersToMakeStringPalindrome(string A)
        {
            string revA = new string(A.Reverse().ToArray());
            string res = A + "_" + revA;
            int[] lps = LPS(res); // Apply LPS on Array+RevArray

            int longestPrefix = lps[^1];
            return A.Length - longestPrefix;
        }

        private static int[] LPS(string str)
        {
            int n = str.Length;
            int[] lps = new int[n];
            lps[0] = 0;

            int j = 0;
            for (int i = 1; i < n;)
            {
                if (str[i] == str[j])
                {
                    lps[i] = j + 1;
                    i++;
                    j++;
                }
                else
                {
                    if (j > 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }

            return lps;
        }
    }
}