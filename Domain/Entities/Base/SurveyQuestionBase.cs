namespace Domain.Entities.Base;

public class SurveyQuestionBase
{
    public Guid Guid { get; set; }
    public string QuestionText { get; set; }
    public bool IsRequired { get; set; }
    public QuestionType Type { get; set; }
}
