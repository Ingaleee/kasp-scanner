using Scanner.Abstrations;

namespace Scanner;

public class DefaultFileScanner : IScanner
{
    private readonly IAccessAsker _access; 
    private readonly IThreatDetector _detector;
    
    public DefaultFileScanner(IAccessAsker access, IThreatDetector detector)
    {
        _access = access;
        _detector = detector;
    }
    
    public ScanReport CreateReport(string path)
    {
        var beingTime = DateTime.UtcNow;
        var report = new ScanReport();
        var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

        var scannedCount = 0ul;
        foreach (var currentFile in files)
        {
            scannedCount++;
            var accessAnswer = _access.AskRead(currentFile);
            if (!accessAnswer.Allowed)
            {
                var error = new ErrorReport
                {
                    Message = accessAnswer.Message,
                    CreatedUtc = DateTime.UtcNow
                };
                
                report.Errors.Add(error);
                continue;
            }
            
            var fileDetails = new FileDetails()
            {
                Name = Path.GetFileNameWithoutExtension(currentFile),
                Extension = Path.GetExtension(currentFile),
                Content = File.ReadAllText(currentFile),
            };

            //TODO: make ScanDetails
            var threatReport = _detector.ReportOrDefault(fileDetails);
            if (threatReport == null)
            {
                continue;;
            }
            
            report.Threats.Add(threatReport);
        }

        report.StartedUtc = beingTime;
        report.TotalCount = scannedCount;

        var endTime = DateTime.UtcNow;
        report.FinishedUtc = endTime;

        return report;
    }
}