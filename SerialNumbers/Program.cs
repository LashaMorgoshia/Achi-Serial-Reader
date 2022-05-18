// See https://aka.ms/new-console-template for more information
using System.Text;

try
{

    Console.Write("Input the folder path and press Enter to read serials: ");
    var path = Console.ReadLine();
    var files = Directory.GetFiles(path);

    StringBuilder sb = new StringBuilder();
    FileInfo fileInfo;

    foreach (var file in files)
    {
        try
        {
            if (!file.EndsWith("csv")) continue;

            fileInfo = new FileInfo(file);

            var lines = File.ReadAllText(file);
            var splitLines = lines.Split("\r\n");
            Console.WriteLine($"{file} {string.Join("\n", lines)}");

            if (splitLines.Length > 0)
                sb.AppendLine($"{fileInfo.Name} - {splitLines[1]}");
            else Console.WriteLine($"ERROR - {file}");
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        
    }

    File.WriteAllText($"{path}\\serials.txt", sb.ToString());
}
catch(Exception ex) { Console.WriteLine(ex.Message); }
Console.WriteLine("done");
