using Domain.Entities.Base;

namespace Domain.Entities;

public class MultipleChoiceQuestion : SurveyQuestionBase
{
    public List<ChoiceOption> Options { get; set; }
}

public class TextQuestion : SurveyQuestionBase
{
    public string Placeholder { get; set; }
}

public class RatingQuestion : SurveyQuestionBase
{
    public int MinRating { get; set; }
    public int MaxRating { get; set; }
}

public class BooleanQuestion : SurveyQuestionBase
{

}
