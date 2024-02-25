namespace StringsAndItsVariants
{
    // RabinKarp is just a kind of custom implementation of IndexOf method of string
    // Eg int idx = strA.IndexOf(strB); // returns first occurence of strrB in strA;

    // If pattern is abc
    // we want to form a ploynomial to compute hash ax^2+bx+c where x is base prime 

    // Worst Time complexity = O(M*N), avg  = O(M+N)
    // Worst TC occurs when hash of all substrings of txt matches with hash of pattern
    class RabinKarp
    {
        private const int Prime = 101; // Prime number for hashing
        private const int Mod = 1000000007; // Modulus value to avoid overflow

        // Function to implement Rabin-Karp algorithm
        public void Search(string text, string pattern)
        {
            int n = text.Length;
            int m = pattern.Length;
            int patternHash = CalculateHash(pattern, 0, m);
            int textHash = CalculateHash(text, 0, m);
            int h = ModularExponentiation(Prime, m - 1, Mod);

            for (int i = 0; i < n - m + 1; i++)
            {
                if (textHash == patternHash && CompareStrings(text, i, pattern, 0, m))
                {
                    Console.WriteLine("Pattern found at index " + i);
                }

                // Recalculate hash for the next substring
                if (i < n - m)
                {
                    textHash = RecalculateHash(textHash, text[i], text[i + m], h, m);
                }
            }
        }

        // Function to calculate the hash value of a substring
        private int CalculateHash(string str, int start, int length)
        {
            int hash = 0;
            for (int i = start; i < start + length; i++)
            {
                hash = (hash * Prime + str[i]) % Mod;
            }
            return hash;
        }

        // Function to recalculate hash for the next substring
        private int RecalculateHash(int oldHash, char oldChar, char newChar, int h, int m)
        {
            int newHash = (oldHash - oldChar * h % Mod + Mod) % Mod; // Remove leading digit
            newHash = (newHash * Prime + newChar) % Mod; // Add trailing digit
            return (newHash+Mod)%Mod;
        }

        // Function to compare two strings
        private bool CompareStrings(string text, int start1, string pattern, int start2, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (text[start1 + i] != pattern[start2 + i])
                    return false;
            }
            return true;
        }

        // Function to calculate (base^exponent) % modulus
        private int ModularExponentiation(int baseValue, int exponent, int modulus)
        {
            // Time O(Log(exponent))

            // Base case: if exponent is 0, result is 1 (base case for exponentiation)
            if (exponent == 0)
                return 1;

            if (exponent % 2 == 0)
            {
                int temp = ModularExponentiation(baseValue, exponent / 2, modulus);
                return (temp * temp) % modulus;
            }
            else
            {
                int temp = ModularExponentiation(baseValue, exponent - 1, modulus);
                return (baseValue * temp) % modulus;
            }
        }

        private int ModularExponentiation2(int baseValue, int exponent, int modulus)
        {
            // Time O(exponent)
            int res = 1;
            for (int i = 0; i < exponent; i++)
            {
                res = (res * baseValue) % modulus;
            }

            return res;
        }

    }

}