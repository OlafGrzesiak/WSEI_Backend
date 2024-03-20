using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();

            var q1 = new QuizItem(101, "3 + 5", new List<string>() { "2", "4", "6" }, "8");
            var q2 = new QuizItem(101, "3 + 5", new List<string>() { "2", "4", "6" }, "8");

            quizItemRepo.Add(q1);
            quizItemRepo.Add(q2);
            var quiz = new Quiz(1, new List<QuizItem>() { q1, q2 }, "Arytmetyka");
            quizRepo.Add(quiz);
        }
    }
}