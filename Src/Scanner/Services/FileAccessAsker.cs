using Scanner.Abstrations;

namespace Scanner;

public class FileAccessAsker : IAccessAsker
{
    public AccessAnswer AskRead(string file)
    {
        try
        {
            // TODO: find other solution
            File.OpenRead(file).Dispose();
            return new AccessAnswer()
            {
                Allowed = true,
            };
        }
        catch (Exception e)
        {
            return new AccessAnswer()
            {
                Message = e.Message,
                Allowed = false
            };
        }
    }
}