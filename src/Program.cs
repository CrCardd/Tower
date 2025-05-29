using Spectre.Console.Cli;
using Tower.Commands;
using System.Text.Json;
using Tower.Configuration;

class Program
{
    static void Main(string[] args)
    {
        var app = new CommandApp();

        int i = Directory.GetCurrentDirectory().LastIndexOf('\\');
        string Name = Directory.GetCurrentDirectory().Substring(i + 1);
        if (File.Exists($"./{Name}Project.json"))
        {
            var json = JsonDocument.Parse(File.ReadAllText($"./{Name}Project.json")).RootElement;
            Config.RootPath = json.GetProperty("Path").GetString() ?? "./";
            Config.ProjectName = json.GetProperty("Name").GetString();
        }

        app.Configure(config =>
        {
            config.SetApplicationName("tower");

            config.AddBranch("new", _new =>
            {
                _new.AddCommand<CleanWA>("cleanWA")
                    .WithDescription("Create a Clean Architecture Project");

                _new.AddCommand<NewEntity>("entity")
                    .WithDescription("Create a new entity");
                _new.AddCommand<NewEntity>("e")
                    .WithDescription("Create a new entity");

                _new.AddCommand<NewFeature>("feature")
                    .WithDescription("Create a new feature");
                _new.AddCommand<NewFeature>("f")
                    .WithDescription("Create a new feature");
            });
        });

        app.Run(args);
    }
}
