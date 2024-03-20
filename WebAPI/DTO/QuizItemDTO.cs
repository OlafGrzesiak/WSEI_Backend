using BackendLab01;

namespace WebAPI.DTO;

public class QuizItemDTO
{
    public int Id { get; set; }
    public string Question { get; set; }
    public List<string> Options { get; set; }

    public static QuizItemDTO Of(QuizItem item)
    {
        var options = new List<string>(item.IncorrectAnswers)
        {
            item.CorrectAnswer
        };
        
        return new QuizItemDTO()
        {
            Id = item.Id,
            Question = item.Question,
            Options = options
        };
    }
}

