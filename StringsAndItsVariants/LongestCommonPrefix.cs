namespace StringsAndItsVariants
{
    public class LCP
    {
        public string LongestCommonPrefix(string[] strs)
        {
            int n = strs.Length;
            int maxLen = 0;
            // Traverse first charcter of all string and put in hashset, if hashset count is 1, 
            // it means all the first chacters were same. So my max length has become 1 now
            // Next, repeat the same process for 2nd char, 3rd char and all.
            var hashSet = new HashSet<char>(); 
            int index = 0;

            while (true)
            {

                for (int i = 0; i < strs.Length; i++)
                {
                    if (index == strs[i].Length)
                    {
                        return strs[0].Substring(0, maxLen);
                    }
                    hashSet.Add(strs[i][index]);
                }

                if (hashSet.Count != 1)
                {
                    return strs[0].Substring(0, maxLen);
                }

                hashSet.Clear(); // clear set for next index of a string

                maxLen++;
                index++;
            }
        }
    }
}