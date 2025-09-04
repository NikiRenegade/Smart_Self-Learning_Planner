using System;
using SmartLearningPlanner.Application.DTOs;

namespace SmartLearningPlanner.Application.Interfaces;

public interface IQuizService
{
	Task<QuizDto> GetQuizByIdAsync(int id);
	Task<IEnumerable<QuizSummaryDto>> GetAllSummariesQuizzesAsync();
	Task CreateQuizAsync(QuizRequestDto quizDto);
	Task UpdateQuizQAsync(QuizRequestDto quizDto);
	Task DeleteQuizAsync(int id);

}
