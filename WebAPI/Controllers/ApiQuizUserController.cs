using ApplicationCore.Exceptions;
using BackendLab01;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;

namespace WebAPI.Controllers;

[ApiController]
[Route("/api/v1/users/quizzes")]
public class ApiQuizUserController : ControllerBase
{
    private IQuizUserService _service;

    public ApiQuizUserController(IQuizUserService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Quiz> FindQuizById(int id)
    {
        var quiz = _service.FindQuizById(id);
        return quiz is null ? NotFound() : quiz;
    }

    [HttpPost]
    [Route("{quizId}/items/{itemId}/answers")]
    public ActionResult SaveAnswear(int quizId, int itemId, AnswerDTO dto)
    {
        try
        {
            _service.SaveUserAnswerForQuiz(quizId, 1, itemId, dto.answer);
            return Created();
        }
        catch (DuplicateAnswerException)
        {
            return new BadRequestObjectResult(new
            {
                Error = e.Message
            });
        }
    }

    [HttpGet]
    [Route("{quizId}/answers")]
    public ActionResult<object> ReturnFeedback(int quizId)
    {
        int correct = _service.CountCorrectAnswersForQuizFilledByUser(quizId, 1);
        return new
        {
            CorrectAnswers = correct,
            QuizId = quizId,
            UserId = 1
        };
    }
}