namespace Scanner;

public interface IScanner
{
    ScanReport CreateReport(string path);
}