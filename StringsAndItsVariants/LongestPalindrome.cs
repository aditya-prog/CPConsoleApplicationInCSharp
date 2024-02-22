
namespace StringsAndItsVariants
{
    public class LongestPalindrome
    {
        // Logic here str[i...j] is palindrome only if str[i] == str[j] and str[i+1...j-1] is also palindrome
        public string LongestPalindromeInString(string str)
        {
            int n = str.Length;
            var mat = new bool[n][];
            for(int i=0; i<n; i++){
                mat[i] = new bool[n];
            }

            for(int len=1; len<=n;len++){
                for(int i=0; i<n-len+1; i++){
                    int j = i+len-1;
                    if(len == 1){
                        mat[i][j] = true;
                    }
                    else if(len == 2){
                        mat[i][j] = str[i] == str[j];
                    }
                    else{
                        if(mat[i+1][j-1] && str[i] == str[j]){
                            mat[i][j] = true;
                        }
                        else{
                            mat[i][j] = false;
                        }
                    }
                }
            }

            // Now iterate through matrix to figure out longest palindromic substring
            int startIndex = 0;
            int maxLen = 1;
            for(int i=0; i<n; i++){
                for(int j=0; j<n; j++){
                    if(mat[i][j] && maxLen < j-i+1){
                        startIndex = i;
                        maxLen = j-i+1;
                    }
                }
            }

            return str.Substring(startIndex, maxLen);

        }

        public string LongestPalindromeInString_Naive(string str)
        {
            int n = str.Length;
            int maxLen = 1;
            int startIndex = 0;

            //Generate all substrin O(N^2)) and check if palindrome or not O(N)
            // i is start index of string and j is end index of string
            for(int i=0;i<n;i++)
            {
                for(int j=i; j<n; j++){
                    if(IsPalindrome(str, i, j) && maxLen < j-i+1){
                        maxLen = j-i+1;
                        startIndex = i;
                    }
                }
            }

            return str.Substring(startIndex, maxLen);

        }

        private bool IsPalindrome(string str, int i, int j)
        {
            while(i<j){
                if(str[i] == str[j]){
                    i++; 
                    j--;
                }
                else{
                    return false;
                }
            }
            return true;
        }
    }
}