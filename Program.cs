using Tower.Layers.Api;
using Tower.Layers.Application;
using Tower.Layers.Archives;
using Tower.Layers.Domain;
using Tower.Layers.Persistence;

// class Program
// {
//     public static void Main(string[] args)
//     {
//         string name = "Jeremias";
//         Layer Api = new ApiLayer(name);
//         Layer Application = new ApplicationLayer(name);
//         Layer Domain = new DomainLayer(name);
//         Layer Persistence = new PersistenceLayer(name);


        

        // Api.CreateLayer();
        // Application.CreateLayer();
        // Domain.CreateLayer();
        // Persistence.CreateLayer();

        // Api.InstallPackages();
        // Application.InstallPackages();
        // Domain.InstallPackages();
        // Persistence.InstallPackages();

        // Api.CreateReferences();
        // Application.CreateReferences();
        // Domain.CreateReferences();
        // Persistence.CreateReferences();

//     }
// }



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
            Config.RootPath = json.GetProperty("Output").GetString() ?? "./";
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
                });
            });

        app.Run(args);
    }
}
