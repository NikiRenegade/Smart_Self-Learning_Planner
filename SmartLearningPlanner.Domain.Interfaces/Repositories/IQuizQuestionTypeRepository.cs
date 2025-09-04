using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Domain.Interfaces.Repositories;

public interface IQuizQuestionTypeRepository
{
    Task<QuizQuestionType> GetByIdAsync(int id);
    Task<IEnumerable<QuizQuestionType>> GetAllAsync();
    Task AddAsync(QuizQuestionType quizQuestionType);
    Task UpdateAsync(QuizQuestionType quizQuestionType);
    Task DeleteAsync(int id);
}