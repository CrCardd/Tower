using Tower.Layers.Archives;

namespace Tower.Configuration;

public static class Config
{
    public static string RootPath { get; set; } = "./";
    public static string? ProjectName { get; set; }


    public static Layer? Api { get; set; }
    public static Layer? Application { get; set; }
    public static Layer? Domain { get; set; }
    public static Layer? Persistence { get; set; }
}