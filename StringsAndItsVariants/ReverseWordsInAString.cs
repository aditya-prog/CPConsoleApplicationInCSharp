using System.Text;

namespace StringsAndItsVariants
{
    public class ReverseWords
    {
        public string ReverseWordsInAString(string str)
        {
            var sb = new StringBuilder();
            string temp = "";
            for(int i=0; i<str.Length; i++){
                //If whitespace encountered
                if(str[i] == ' '){
                    if(temp != ""){
                        sb.Insert(0, temp+" "); // Insert at beginning
                        temp = "";
                    }
                }
                else{
                    temp += str[i];
                }
            }

            sb.Insert(0, temp+" ");

            var res = sb.ToString();
            return res.Substring(0, res.Length - 1);
        }
    }
}