using System.Text.RegularExpressions;

namespace ResumeGeneratorX;

public partial class AssetsHelper
{
    public static string Assets => Path.Combine(AppContext.BaseDirectory, "Assets");
    public static string SvgPath => Path.Combine(Assets, "svg.path");
    public static string GetSvgPath(string name)
    {
        return File.ReadAllText(Path.Combine(SvgPath, $"{name}.txt"));
    }

    public static string GetImgSize(string sizeString)
    {
        var sizeStrings = sizeString.Split('x');
        double w = double.Parse(sizeStrings[0]);
        double h = double.Parse(sizeStrings[1]);
        return (84 * h / w).ToString();
    }

    public static string ImgToBase64(string filePath)
    {
        var extension = Path.GetExtension(filePath)[1..];
        var avatarBase64 = Convert.ToBase64String(File.ReadAllBytes(filePath));
        return $"data:image/{extension};base64,{avatarBase64}";
    }

    [GeneratedRegex("height: (\\d+)px")]
    private static partial Regex FindHeight();
}
