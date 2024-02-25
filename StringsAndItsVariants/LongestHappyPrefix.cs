namespace StringsAndItsVariants
{
    public class LongestCommonPrefix
    {
         // Use KMP algo first part
        public int[] LongestPrefix(string s)
        {
            int n = s.Length;
            // prefix[i] stores length of longest prefix which is also a suffix for a string ending at ith index
            int[] prefix = new int[n]; 

            int i = 1;
            int j = 0;
            prefix[0] = 0;

            while (i < n)
            {
                if (s[i] == s[j])
                {
                    prefix[i] = j + 1; // we need length that's why j+1
                    i++;
                    j++;
                }
                else
                {
                    if (j > 0)
                    {
                        // Move back j
                        j = prefix[j - 1];
                    }
                    else
                    {
                        // Actually , below if condition will nvr be executed so can be removed safely
                        if (s[i] == s[j]) // if j == 0 and chars are equal, set prefix[i] = 1 and increment both
                        {
                            prefix[i] = j + 1;
                            i++;
                            j++;
                        }
                        else
                        {
                            // If j == 0 and chars are not equal, set prefix[i] = 0 and only increment i
                            prefix[i] = 0;
                            i++;
                        }
                    }
                }


            }
            // Result
            Console.WriteLine("Longest prefix which is also a suffix: "+s.Substring(0, prefix[n - 1]));

            return prefix; // return this for some other utility
        }
    }
}