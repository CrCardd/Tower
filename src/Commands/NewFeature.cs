using System.ComponentModel;
using System.Globalization;
using Spectre.Console.Cli;
using Tower.Configuration;
using Tower.Layers.Api;
using Tower.Layers.Application;
using Tower.Layers.Domain;
using Tower.Layers.Persistence;

namespace Tower.Commands;

public class NewFeature : Command<NewFeature.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandOption("-f|--featureFolderName")]
        [Description("featureName")]
        public string? FeatureFolderName { get; set; }

        [CommandArgument(0, "[entity]")]
        [Description("Feature's owner")]
        public required string FeatureEntity { get; set; }
        [CommandArgument(0, "[name]")]
        [Description("Feature's name")]
        public required string Name { get; set; }
    }
    public override int Execute(CommandContext context, Settings settings)
    {
        if (Config.ProjectName is null)
            return 1;

        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        settings.FeatureEntity = ti.ToTitleCase(settings.FeatureEntity);

        Config.Api = new ApiLayer(Config.ProjectName);
        Config.Application = new ApplicationLayer(Config.ProjectName);
        Config.Domain = new DomainLayer(Config.ProjectName);
        Config.Persistence = new PersistenceLayer(Config.ProjectName);

        Config.Api.CreateFeature(settings.Name, settings.FeatureEntity, settings.FeatureFolderName);
        Config.Application.CreateFeature(settings.Name, settings.FeatureEntity, settings.FeatureFolderName);
        Config.Domain.CreateFeature(settings.Name, settings.FeatureEntity, settings.FeatureFolderName);
        Config.Persistence.CreateFeature(settings.Name, settings.FeatureEntity, settings.FeatureFolderName);
        return 0;
    }
}