namespace Domain.Entities;

public class QuestionAnalytics
{
    public long QuestionId { get; set; }
    public int TotalResponses { get; set; }
    public Dictionary<Guid, int> OptionBreakdown { get; set; } // Key: OptionId, Value: Number of responses
}
