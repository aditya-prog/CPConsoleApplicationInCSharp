namespace StringsAndItsVariants
{
    public class KMP
    {
        public int Search(string haystack, string needle)
        {
            var lps = new LongestCommonPrefix().LongestPrefix(needle); // lps will be used for pattern and not text string

            int i=0;
            int j=0; 
            int m = needle.Length;
            int n = haystack.Length;

            while(i<n && j<m){
                if(haystack[i] == needle[j]){
                    i++;
                    j++;
                }
                else{
                    if(j > 0){
                        j = lps[j-1];
                    }
                    else{
                        // Means j==0 and chars are unequal i.e haystack[i] != needle[j]
                        i++;

                    }
                }
            }

            // if needle/pattern is found 
            if(j==m){
                return i-m; // return index of the found pattern in haystack/text
            }
            return -1;
        }
    }
}