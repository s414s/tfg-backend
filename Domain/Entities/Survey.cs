using Domain.Entities.Base;

namespace Domain.Entities;

public class Survey
{
    public Guid Guid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime EndsAt { get; set; }
    public Guid CreatedBy { get; set; }
    public List<SurveyQuestionBase> Questions { get; set; }
    public bool IsActive { get; set; }
}
