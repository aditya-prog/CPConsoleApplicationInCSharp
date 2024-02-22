using System.Text;

namespace StringsAndItsVariants
{
    public class ROMAN_INT
    {
        private readonly Dictionary<char, int> dict = [];
        List<Tuple<int, string>> intToRoman =
        [
            Tuple.Create(1000, "M"),
            Tuple.Create(900, "CM"),
            Tuple.Create(500, "D"),
            Tuple.Create(400, "CD"),
            Tuple.Create(100, "C"),
            Tuple.Create(90, "XC"),
            Tuple.Create(50, "L"),
            Tuple.Create(40, "XL"),
            Tuple.Create(10, "X"),
            Tuple.Create(9, "IX"),
            Tuple.Create(5, "V"),
            Tuple.Create(4, "IV"),
            Tuple.Create(1, "I")
        ];


        public ROMAN_INT()
        {
            dict['I'] = 1;
            dict['V'] = 5;
            dict['X'] = 10;
            dict['L'] = 50;
            dict['C'] = 100;
            dict['D'] = 500;
            dict['M'] = 1000;
        }

        public int RomanToInt(string s)
        {
            int n = s.Length;
            int res = dict[s[0]];

            for (int i = 1; i < n; i++)
            {
                if (dict[s[i]] > dict[s[i - 1]])
                {
                    res -= dict[s[i - 1]];
                    res += (dict[s[i]] - dict[s[i - 1]]);
                }
                else
                {
                    res += dict[s[i]];
                }
            }

            return res;
        }

        public string IntToRoman(int n)
        {
            string res = "";
            
            foreach (var tuple in intToRoman)
            {
                int cnt  = n /tuple.Item1;
                n %= tuple.Item1;
                while(cnt != 0){
                    res += tuple.Item2;
                    cnt--;
                }
                if(n==0){
                    return res;
                }
            }

            return res;
        }
    }
}