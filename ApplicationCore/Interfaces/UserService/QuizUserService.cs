﻿using System.Data;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.Criteria;
using ApplicationCore.Interfaces.Repository;

namespace BackendLab01;

public class QuizUserService: IQuizUserService
{
    private readonly IGenericRepository<Quiz, int> quizRepository;
    private readonly IGenericRepository<QuizItem, int> itemRepository;
    private readonly IGenericRepository<QuizItemUserAnswer, string> answerRepository;

    public QuizUserService(IGenericRepository<Quiz, int> quizRepository, IGenericRepository<QuizItemUserAnswer, string> answerRepository, IGenericRepository<QuizItem, int> itemRepository)
    {
        this.quizRepository = quizRepository;
        this.answerRepository = answerRepository;
        this.itemRepository = itemRepository;
    }

    public Quiz CreateAndGetQuizRandom(int count)
    {
        throw new NotImplementedException();
    }

    public Quiz? FindQuizById(int id)
    {
        return quizRepository.FindById(id);
    }

    public void SaveUserAnswerForQuiz(int quizId, int userId, int quizItemId, string answer)
    {
        QuizItem? item = itemRepository.FindById(quizItemId);
        var userAnswer = new QuizItemUserAnswer(quizItem: item, userId: userId, answer: answer, quizId: quizId);
        var find = answerRepository.FindById(userAnswer.Id);
        if (find == null)
        {
            answerRepository.Add(userAnswer);
        }
        else
        {
            throw new DuplicateAnswerException($"User {userId} already answered for question {quizId}");
        }
    }


    public List<QuizItemUserAnswer> GetUserAnswersForQuiz(int quizId, int userId)
    {
        // return answerRepository.FindAll()
        //     .Where(x => x.QuizId == quizId)
        //     .Where(x => x. UserId == userId)
        //     .ToList();
        return answerRepository.FindBySpecification(new QuizItemsForQuizIdFilledByUser(quizId, userId)).ToList();
    }
}