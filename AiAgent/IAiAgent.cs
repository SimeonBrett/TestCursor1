namespace AiAgent;

public interface IAiAgent
{
    string QueryAgent(string input);
    string GetDetailedRecommendation(long productId, string products);
}

public class TestAiAgent : IAiAgent
{
    public string QueryAgent(string input)
    {
        return $@"You input {input}";
    }

    public string GetDetailedRecommendation(long productId, string products)
    {
        throw new NotImplementedException();
    }
}
