using System.Text;

namespace Scanner.Mappers;

public class ViewMapper
{
    public static string ToConsole(ScanReport report)
    {
        var totalCount = report.TotalCount;
        var jsCount = report.Threats.Count(t => t.Type == ThreatType.EvilScript);
        var removerCount = report.Threats.Count(t => t.Type == ThreatType.Remover);
        var runnerCount = report.Threats.Count(t => t.Type == ThreatType.DllRunner);
        var errorCount = report.Errors.Count;
        var executionTime = TimeSpan.FromTicks((report.FinishedUtc - report.StartedUtc).Ticks);

        var builder = new StringBuilder();

        builder.AppendLine("====== Scan result ======");
        builder.AppendLine($"Processed files: {totalCount}");
        builder.AppendLine($"JS detects: {jsCount}");
        builder.AppendLine($"rm -rf detects: {removerCount}");
        builder.AppendLine($"RunDll32 detects: {runnerCount}");
        builder.AppendLine($"Errors: {errorCount}");
        builder.AppendLine($"Execution time: {executionTime}");
        builder.AppendLine("=========================");

        return builder.ToString();
    }
}