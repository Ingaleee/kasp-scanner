namespace Scanner;

public class ScanReport
{
    public ICollection<ThreatReport> Threats { get; set; } = new List<ThreatReport>();
    public ICollection<ErrorReport> Errors { get; set; } = new List<ErrorReport>();
    public ulong TotalCount { get; set; }
    public DateTime StartedUtc { get; set; }
    public DateTime FinishedUtc { get; set; }
}