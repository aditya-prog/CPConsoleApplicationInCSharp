namespace StringsAndItsVariants
{
    public class RepeatedString
    {
        public int RepeatedStringMatch(string a, string b)
        {
            // String match can happen only when when length of a is >= length of b, so first make len a >= len b and then check if b exists in a.
            // If b doesn't exists in a , repeat a once more and check again (because some charcters of b might be left out while matching)
            // that's why we reapetd once more, if still doesn't exists then return -1;

            // Eg: a = "abc", b = "cabcabcab"
            // repeatedA = "abcabcabcabc" // repeated 4 times because in 3 times repetition last 2 chacters of b was left out

            int repeats = b.Length / a.Length;


            //Eg: if b.len = 10 and a.len = 4, then we need to repeat at least 3 times, to make length of a >= length of b
            if (b.Length % a.Length != 0)
            {
                repeats++;
            }

            // Make len a >= len b
            string res = "";
            for (int i = 1; i <= repeats; i++)
            {
                res += a;
            }

            if (res.Contains(b))
            {
                return repeats;
            }

            res += a; // add one more time and check

            if (res.Contains(b))
            {
                return repeats + 1;
            }
            
            return -1;

        }
    }
}