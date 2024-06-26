﻿using System.CommandLine;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
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

            rootCommand.SetHandler((input, output, template) =>
            {
                if (input is null) return;
                if (!File.Exists(input.FullName))
                {
                    Console.Error.WriteLine($"Input file \"{input.FullName}\" does not exist.");
                    return;
                }
                Main2(input, output ?? input.Directory!, template ?? 2);
            }, inputFileOption, outputDirectoryOption, templateOption);

            return await rootCommand.InvokeAsync(args);
        }

        static void Main2(FileInfo input, DirectoryInfo output, int template)
        {
            try
            {
                ResumeInfo? rio = JsonSerializer.Deserialize<ResumeInfo>(File.ReadAllText(input.FullName));
                ArgumentNullException.ThrowIfNull(rio);
                HtmlGenBase htmlGen = template switch
                {
                    1 => new Template1Gen(rio),
                    2 => new Template2Gen(rio),
                    3 => new Template3Gen(rio),
                    _ => throw new ArgumentOutOfRangeException($"There is no template {template}."),
                };
                var s = htmlGen.GenHtml();
                var outputFile = $"{output.FullName}\\{Path.GetFileNameWithoutExtension(input.Name)}.html";
                File.WriteAllText(outputFile, s.ToString());
                Console.WriteLine($"Output at \"{outputFile}\"");
            }
            catch(Exception e) { Console.Error.WriteLine(e.Message); }
        }
    }
}
