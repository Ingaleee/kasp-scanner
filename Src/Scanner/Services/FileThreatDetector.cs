using Scanner.Abstrations;

namespace Scanner;

public class FileThreatDetector : IThreatDetector
{
    // TODO: make app settings
    private const string EVIL_SCRIPT_LINE = @"<script>evil_script()</script>";
    private const string REMOVE_LINE = @"rm -rf %userprofile%\Documents";
    private const string DLL_RUN_LINE = @"Rundll32 sys.dll SysEntry";
    
    public ThreatReport ReportOrDefault(FileDetails file)
    {
        // TODO: strategy pattern can be used
        if (file.Extension is ".js" && file.Content.Contains(EVIL_SCRIPT_LINE))
        {
            return new ThreatReport
            {
                Path = file.Path,
                Type = ThreatType.EvilScript
            };
        }
        
        if (file.Content.Contains(REMOVE_LINE))
        {
            return new ThreatReport
            {
                Path = file.Path,
                Type = ThreatType.Remover
            };
        }
        
        if (file.Content.Contains(DLL_RUN_LINE))
        {
            return new ThreatReport
            {
                Path = file.Path,
                Type = ThreatType.DllRunner
            };
        }

        return null;
    } 
}