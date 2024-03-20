using BackendLab01;
using Microsoft.AspNetCore.Mvc;

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
    public Quiz? FindQuizById(int id)
    {
        return _service.FindQuizById(id);
    }
}