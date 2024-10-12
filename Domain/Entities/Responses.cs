using Domain.Entities.Base;
using System.Text.Json;

namespace Domain.Entities;

public class MultipleChoiceResponse : SurveyResponseBase
{
    public Guid SelectedOptionId { get; set; }
}

// Response for text question
public class TextResponse : SurveyResponseBase
{
    public string Answer { get; set; }
}

public class RatingResponse : SurveyResponseBase
{
    public int Rating { get; set; }
}

public class BooleanResponse : SurveyResponseBase
{
    public bool Answer { get; set; }
}

public class UserSurveyResponse
{
    public long UserId { get; set; }
    public long SurveyId { get; set; }
    public DateTime CompletedAt { get; set; }
    public List<JsonDocument> Responses { get; set; }
}
