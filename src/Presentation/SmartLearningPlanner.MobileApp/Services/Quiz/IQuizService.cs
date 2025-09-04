using System;
using SmartLearningPlanner.MobileApp.Models;
using SmartLearningPlanner.MobileApp.Models.Responses;
namespace SmartLearningPlanner.MobileApp.Services.Quiz;

public interface IQuizService
{
	/// <summary>
	/// Получить список поддерживаемых типов вопросов.
	/// </summary>
	Task<IEnumerable<QuizQuestionType>> GetQuizQuestionTypesAsync();

	/// <summary>
	/// Получить квиз по идентификатору.
	/// </summary>
	/// <param name="quizId">Идентификатор квиза.</param>
	/// <returns>Квиз.</returns>
	Task<SmartLearningPlanner.MobileApp.Models.Quiz> GetQuizByIdAsync(int quizId);

	/// <summary>
	/// Сохранить квиз.
	/// </summary>
	/// <param name="quiz"></param>
	/// <returns></returns>
	Task SaveQuizAsync(Models.Quiz quiz);


	/// <summary>
	/// Возвращает набор QuizSummaryResponseDto
	/// </summary>
	/// <returns></returns>
	Task<IEnumerable<QuizSummaryResponseDto>> GetQuizSummariesAsync();
	Task DeleteQuizAsync(int quizId);


}
