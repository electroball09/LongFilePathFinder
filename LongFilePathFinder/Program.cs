using System.IO;

start:

Console.Clear();
Console.Write("Base folder: ");
string? folder = Console.ReadLine();
if (!Directory.Exists(folder))
{
    Console.Write($"{folder} does not exist");
    Console.ReadLine();
    return;
}

Console.Write("Length threshold? (empty for 260)");
int.TryParse(Console.ReadLine(), out int threshold);
if (threshold <= 0 || threshold > 260)
    threshold = 260;

void SearchDirectory(string dir)
{
    foreach (var file in Directory.GetFiles(dir))
    {
        if (file.Length >= threshold)
        {
            Console.WriteLine($"{file.Length} - {file}");
        }
    }

    foreach (var subdir in Directory.GetDirectories(dir))
        SearchDirectory(subdir);
}

SearchDirectory(folder);

Console.Write("\n\rFinished! ");
if (Console.ReadLine() == "y")
    goto start;