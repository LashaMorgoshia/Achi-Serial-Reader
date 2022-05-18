// See https://aka.ms/new-console-template for more information
using System.Text;

Console.Write("Input the folder path and press Enter to read serials: ");
var path = Console.ReadLine();
var files = Directory.GetFiles(path);

StringBuilder sb = new StringBuilder();

foreach (var file in files)
{
    if (!file.EndsWith("csv")) continue;

    FileInfo fileInfo = new FileInfo(file);

    var lines = File.ReadAllText(file);
    Console.WriteLine(string.Join("\n", lines));

    sb.AppendLine($"{fileInfo.Name} - {lines.Split("\r\n")[1]}");
}

File.WriteAllText($"{path}\\serials.txt", sb.ToString());

Console.WriteLine("done");
