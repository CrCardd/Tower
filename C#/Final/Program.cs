using System.CommandLine;
using Tower.Layers.Api;
using Tower.Layers.Application;
using Tower.Layers.Archives;
using Tower.Layers.Domain;
using Tower.Layers.Persistence;

namespace scl;

class Program
{
    public static void Main(string[] args)
    {
        string name = "Jeremias";
        Layer Api = new ApiLayer(name);
        Layer Application = new ApplicationLayer(name);
        Layer Domain = new DomainLayer(name);
        Layer Persistence = new PersistenceLayer(name);


        Api.CreateReferences();
        Application.CreateReferences();
        Domain.CreateReferences();
        Persistence.CreateReferences();

        Api.InstallPackages();
        Application.InstallPackages();
        Domain.InstallPackages();
        Persistence.InstallPackages();
    }
}



// using System.CommandLine;

// namespace scl;

// class Program
// {
//     static async Task<int> Main(string[] args)
//     {
//         var fileOption = new Option<FileInfo?>(
//             name: "--file",
//             description: "The file to read and display on the console.");

//         var rootCommand = new RootCommand("Sample app for System.CommandLine");
//         rootCommand.AddOption(fileOption);

//         rootCommand.SetHandler((file) => 
//             { 
//                 ReadFile(file!); 
//             },
//             fileOption);

//         return await rootCommand.InvokeAsync(args);
//     }

//     static void ReadFile(FileInfo file)
//     {
//         File.ReadLines(file.FullName).ToList()
//             .ForEach(line => Console.WriteLine(line));
//     }
// }