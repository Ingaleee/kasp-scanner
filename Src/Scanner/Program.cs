// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Scanner;
using Scanner.Abstrations;
using Scanner.Mappers;

if (args.Length < 1)
{
    Console.WriteLine("Run utility with args: [path]");
    return;
}
var path = args[0];

var services = new ServiceCollection();

services.AddSingleton<IAccessAsker, FileAccessAsker>();
services.AddSingleton<IThreatDetector, FileThreatDetector>();
services.AddSingleton<IScanner, DefaultFileScanner>();

var provider = services.BuildServiceProvider();

var scanner = provider.GetService<IScanner>();

var scanReport = scanner.CreateReport(path);

var view = ViewMapper.ToConsole(scanReport);
Console.WriteLine(view);