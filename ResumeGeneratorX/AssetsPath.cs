namespace ResumeGeneratorX;

public class AssetsPath
{
    public static string Assets => Path.Combine(AppContext.BaseDirectory, "Assets");
    public static string SvgPath => Path.Combine(Assets, "svg.path");
    public static string MobileSvgPath = File.ReadAllText(Path.Combine(SvgPath, "mobile.txt"));
}
