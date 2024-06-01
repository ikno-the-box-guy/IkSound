namespace IkSound.Utils;

public static class HttpUtils
{
    public static string BaseUrl { get; set; } = "";
    
    public static string GetUrl(string path)
    {
        return $"{BaseUrl}{path}";
    }
}