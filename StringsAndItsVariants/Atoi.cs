namespace StringsAndItsVariants
{
    public class Atoi
    {
        public int MyAtoi(string s)
        {
            int index = 0;
            int sign = 1;
            long result = 0;

            // Remove leading whitespace
            while (index < s.Length && s[index] == ' ')
                index++;

            // Check sign
            if (index < s.Length && (s[index] == '+' || s[index] == '-'))
            {
                sign = (s[index] == '-') ? -1 : 1;
                index++;
            }

            // Convert digits
            while (index < s.Length && Char.IsDigit(s[index]))
            {
                int digit = s[index] - '0';
                result = result * 10 + digit;
                if (result > int.MaxValue)
                {
                    return (sign == 1) ? int.MaxValue : int.MinValue;
                }
                index++;
            }

            return (int)result * sign;
        }
    }
}

