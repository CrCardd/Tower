using System.CommandLine;
using Tower.Layers;

namespace scl;

class Program
{
    public static void Main(string[] args)
    {
        var test = new PersistenceLayer("bah_da_roça_mesmo_guri");
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