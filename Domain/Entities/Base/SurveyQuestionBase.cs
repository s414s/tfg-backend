using Domain.Enums;

namespace Domain.Entities.Base;

public class SurveyQuestionBase : EntityBase
{
    public Guid Guid { get; set; }
    public long QuestionId { get; set; }
    public bool IsRequired { get; set; }
    public QuestionType Type { get; set; }
}
