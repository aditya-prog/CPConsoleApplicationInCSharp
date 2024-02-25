namespace StringsAndItsVariants;

public class StringDriver
{
    public static void Drive()
    {
        // Test Reverse words of a string 
        // var reverse = new ReverseWords();
        // string str = "  My name is   khan  ";
        // var res = reverse.ReverseWordsInAString(str);
        // Console.WriteLine($"Input string: {Environment.NewLine} {str}");
        // Console.WriteLine($"Output string: {Environment.NewLine} {res}");

        // Test Longest Palindrome
        // var palindrome = new LongestPalindrome();
        // string palstr = "cbbd";
        // var respalStr = palindrome.LongestPalindromeInString(palstr);
        // Console.WriteLine($"Input string: {Environment.NewLine} {palstr}");
        // Console.WriteLine($"Output string: {Environment.NewLine} {respalStr}");

        // Test Roman To Int
        // var roman  = new ROMAN_INT();
        // Console.WriteLine("Int is:  "+roman.RomanToInt("MCMXCIV")); // 1994
        // Console.WriteLine("Roman is:  "+roman.IntToRoman(1994)); // MCMXCIV

        // Test Atoi
        // var atoi = new Atoi();
        // Console.WriteLine(atoi.MyAtoi("  -962"));

        // Test Longest Common Prefic
        // var lcp = new LCP();
        // string[] lst = {"flower","flow","flight"};
        // lcp.LongestCommonPrefix(lst);

        // Test RabinKarp Algo
        var rabinKarp = new RabinKarp();
        var kmp = new KMP();

        string txt = "ADITYA WEDS ANKITA AT ADITYA HOTEL";
        string pat = "HOTEL";
        rabinKarp.Search(txt, pat);
        Console.WriteLine("Index for KMP Search: "+kmp.Search(txt, pat));

        // var palindrome = new MinCharctersForPalindrome();
        // string str = "ABC";
        // // Palindrome of above string is CBABC
        // Console.WriteLine("MinCharcters required to make string palindrome is: " + palindrome.MinCharctersToMakeStringPalindrome(str)); 
    }
}
