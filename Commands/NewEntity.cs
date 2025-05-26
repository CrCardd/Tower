using System.ComponentModel;
using Spectre.Console.Cli;
using Tower.Configuration;
using Tower.Layers.Api;
using Tower.Layers.Application;
using Tower.Layers.Domain;
using Tower.Layers.Persistence;

namespace Tower.Commands;

public class NewEntity : Command<NewEntity.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "[name]")]
        [Description("New entity name")]
        public required string Name { get; set; }
    }
    public override int Execute(CommandContext context, Settings settings)
    {
        if (Config.ProjectName is null)
            return 1;

        Config.Api = new ApiLayer(Config.ProjectName);
        Config.Application = new ApplicationLayer(Config.ProjectName);
        Config.Domain = new DomainLayer(Config.ProjectName);
        Config.Persistence = new PersistenceLayer(Config.ProjectName);


        Config.Api.CreateEntity(settings.Name);
        Config.Application.CreateEntity(settings.Name);
        Config.Domain.CreateEntity(settings.Name);
        Config.Persistence.CreateEntity(settings.Name);
        

        return 0;
    }
}