namespace ResumeGeneratorX;

public class AssetsPath
{
    public static string Assets => Path.Combine(AppContext.BaseDirectory, "Assets");
    public static string SvgPath => Path.Combine(Assets, "svg.path");
    public static string GetSvgPath(string name)
    {
        return File.ReadAllText(Path.Combine(SvgPath, $"{name}.txt"));
    }
}
