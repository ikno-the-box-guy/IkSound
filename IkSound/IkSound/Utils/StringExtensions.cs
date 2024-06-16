using System.Globalization;

namespace IkSound.Utils;

public static class StringExtensions
{
    public static string ToTitleCase(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }

        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
    }
    
    public static string CapitalizeFirst(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }

        return char.ToUpper(str[0]) + str.Substring(1);
    }
}