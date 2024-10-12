namespace Domain.Entities;

public class SurveyAnalytics
{
    public long SurveyId { get; set; }
    public int TotalResponses { get; set; }
    public List<QuestionAnalytics> QuestionAnalytics { get; set; } // Breakdown of analytics by question
}
