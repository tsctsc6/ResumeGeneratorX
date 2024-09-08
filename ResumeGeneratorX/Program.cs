using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using System.CommandLine;
using System.Text;
using System.Text.Json;

namespace ResumeGeneratorX
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            var inputFileOption = new Option<FileInfo?>(
                name: "--input-file",
                description: "Input file")
            { IsRequired = true };
            inputFileOption.AddAlias("-i");
            inputFileOption.Arity = ArgumentArity.ExactlyOne;

            var outputDirectoryOption = new Option<DirectoryInfo?>(
                name: "--output-directory",
                description: "Output directory");
            outputDirectoryOption.AddAlias("-o");
            outputDirectoryOption.Arity = ArgumentArity.ZeroOrOne;

            var templateOption = new Option<int?>(
                name: "--template",
                description: "Resume template")
                .FromAmong("1", "2", "3");
            templateOption.AddAlias("-t");
            templateOption.Arity = ArgumentArity.ZeroOrOne;

            var rootCommand = new RootCommand("Generate Resume HTML from JSON.\n" +
                "推荐在Microsoft Edge 打印为PDF，记得在打印界面把“更多设置”=>“背景图形”打开");
            rootCommand.AddOption(inputFileOption);
            rootCommand.AddOption(outputDirectoryOption);
            rootCommand.AddOption(templateOption);

            rootCommand.SetHandler(async (input, output, template) =>
            {
                if (input is null) return;
                if (!File.Exists(input.FullName))
                {
                    Console.Error.WriteLine($"Input file \"{input.FullName}\" does not exist.");
                    return;
                }
                await Main2(input, output ?? input.Directory!, template ?? 2);
            }, inputFileOption, outputDirectoryOption, templateOption);

            return await rootCommand.InvokeAsync(args);
        }

        static async Task Main2(FileInfo input, DirectoryInfo output, int template)
        {
            try
            {
                ResumeInfo? rio = JsonSerializer.Deserialize<ResumeInfo>(File.ReadAllText(input.FullName));
                ArgumentNullException.ThrowIfNull(rio);

                var services = new ServiceCollection();
                services.AddLogging();
                var servicesProvider = services.BuildServiceProvider();
                var loggerFactory = servicesProvider.GetRequiredService<ILoggerFactory>();
                await using var htmlRenderer = new HtmlRenderer(servicesProvider, loggerFactory);
                var html = template switch
                {
                    1 => await htmlRenderer.Dispatcher.InvokeAsync(async () =>
                    {
                        var dic = new Dictionary<string, object?>
                        {
                            { "ResumeInfo", rio }
                        };

                        var parameters = ParameterView.FromDictionary(dic);

                        var output = await htmlRenderer.RenderComponentAsync<Template2>(parameters);

                        return output.ToHtmlString();
                    }),
                    2 => await htmlRenderer.Dispatcher.InvokeAsync(async () =>
                    {
                        var dic = new Dictionary<string, object?>
                        {
                            { "ResumeInfo", rio }
                        };

                        var parameters = ParameterView.FromDictionary(dic);

                        var output = await htmlRenderer.RenderComponentAsync<Template2>(parameters);

                        return output.ToHtmlString();
                    }),
                    3 => await htmlRenderer.Dispatcher.InvokeAsync(async () =>
                    {
                        var dic = new Dictionary<string, object?>
                        {
                            { "ResumeInfo", rio }
                        };

                        var parameters = ParameterView.FromDictionary(dic);

                        var output = await htmlRenderer.RenderComponentAsync<Template2>(parameters);

                        return output.ToHtmlString();
                    }),
                    _ => throw new ArgumentOutOfRangeException($"There is no template {template}."),
                };
                var outputHtmlFilePath = Path.Combine(output.FullName, rio.Title + ".html");
                File.WriteAllText(outputHtmlFilePath, html);
                Console.WriteLine($"Output at \"{outputHtmlFilePath}\"");

                var outputPdfFilePath = Path.Combine(output.FullName, rio.Title + ".pdf");
                await GenPdf(outputPdfFilePath, html);
                Console.WriteLine($"Output at \"{outputPdfFilePath}\"");
            }
            catch (Exception e) { Console.Error.WriteLine(e.Message); }
        }

        private static async Task GenPdf(string outputPdfFilePath, string html)
        {
            bool isSuccess = false;
            while (!isSuccess)
            {
                try
                {
                    using var playwright = await Playwright.CreateAsync();
                    var browser = await playwright.Chromium.LaunchAsync(
                        new BrowserTypeLaunchOptions
                        {
                            Headless = true,
                            Channel = "msedge"
                        });
                    var page = await browser.NewPageAsync();
                    await page.SetContentAsync(html);
                    await page.PdfAsync(new PagePdfOptions
                    {
                        Format = "A4",
                        PrintBackground = true,
                        Path = outputPdfFilePath
                    });
                    //await Console.In.ReadLineAsync();
                    await page.CloseAsync();
                    isSuccess = true;
                }
                catch (PlaywrightException e)
                {
                    if (!e.Message.Contains("install")) throw;
                    Console.Error.WriteLine(e.Message);
                    Microsoft.Playwright.Program.Main(["install"]);
                    Console.WriteLine("Install complete");
                } 
            }
        }
    }
}
