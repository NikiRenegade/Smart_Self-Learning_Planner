using SmartLearningPlanner.Application.DTOs;

namespace SmartLearningPlanner.Application.Interfaces;

public interface IQuizQuestionTypeService
{
    Task<QuizQuestionTypeDto> GetQuizQuestionTypeByIdAsync(int id);
    Task<IEnumerable<QuizQuestionTypeDto>> GetAllQuizQuestionTypesAsync();
    Task CreateQuizQuestionTypeAsync(QuizQuestionTypeDto quizQuestionTypeDto);
    Task UpdateQuizQuestionTypeAsync(QuizQuestionTypeDto quizQuestionTypeDto);
    Task DeleteQuizQuestionTypeAsync(int id);
}