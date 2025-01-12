namespace AiAgent;

public interface IAiAgent
{
    string QueryAgent(string input);
}

public class TestAiAgent : IAiAgent
{
    public string QueryAgent(string input)
    {
        return $@"You input {input}";
    }
}
