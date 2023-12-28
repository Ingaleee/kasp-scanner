namespace Scanner;

public interface IThreatDetector
{
    ThreatReport ReportOrDefault(FileDetails file);
}