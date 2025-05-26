using System.ComponentModel;
using System.Text.Json;
using Spectre.Console.Cli;
using Tower.Configuration;
using Tower.Layers.Api;
using Tower.Layers.Application;
using Tower.Layers.Domain;
using Tower.Layers.Persistence;

namespace Tower.Commands;

public class CleanWA : Command<CleanWA.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandOption("-o|--output")]
        [Description("Output path")]
        public string? Output { get; set; } = "./";

        [CommandArgument(0, "[name]")]
        [Description("Clean Architecture project name")]
        public string? Name { get; set; }
    }
    public override int Execute(CommandContext context, Settings settings)
    {
        if (!(settings.Output == Config.RootPath))
            Config.RootPath = $"{settings.Output}";

        if (settings.Name is null)
        {
            if (settings.Output == Config.RootPath)
            {
                int i = Directory.GetCurrentDirectory().LastIndexOf('\\');
                settings.Name = Directory.GetCurrentDirectory().Substring(i + 1);
            }
            else
            {
                int i = Config.RootPath.LastIndexOf('/');
                settings.Name = Config.RootPath.Substring(i + 1);
            }
        }
        else
        {
            Config.RootPath += $"{settings.Name}";
            settings.Output = Config.RootPath;
        }
        Config.ProjectName = settings.Name;

        Config.Api = new ApiLayer(settings.Name);
        Config.Application = new ApplicationLayer(settings.Name);
        Config.Domain = new DomainLayer(settings.Name);
        Config.Persistence = new PersistenceLayer(settings.Name);

        Console.WriteLine("----------------------------------------------");

        Config.Api.CreateLayer();
        Config.Application.CreateLayer();
        Config.Domain.CreateLayer();
        Config.Persistence.CreateLayer();

        Console.WriteLine("----------------------------------------------");

        Config.Api.CreateReferences();
        Config.Application.CreateReferences();
        Config.Domain.CreateReferences();
        Config.Persistence.CreateReferences();

        Console.WriteLine("----------------------------------------------");

        Config.Api.InstallPackages();
        Config.Application.InstallPackages();
        Config.Domain.InstallPackages();
        Config.Persistence.InstallPackages();

        SaveJson(settings);
        return 0;
    }

    public static void SaveJson(Settings settings)
    {
        string json = JsonSerializer.Serialize(settings);
        File.WriteAllText($"{Config.RootPath}/{Config.ProjectName}Project.json", json);
    }

    
}