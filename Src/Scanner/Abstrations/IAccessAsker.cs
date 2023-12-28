namespace Scanner.Abstrations;

public interface IAccessAsker
{
    AccessAnswer AskRead(string file);
}