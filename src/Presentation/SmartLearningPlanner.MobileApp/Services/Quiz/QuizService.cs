using System;
using SmartLearningPlanner.MobileApp.Models;
using SmartLearningPlanner.MobileApp.Services;
using SmartLearningPlanner.MobileApp.Mappers;
using SmartLearningPlanner.MobileApp.Models.Responses;
using SmartLearningPlanner.MobileApp.Models.Requests;
namespace SmartLearningPlanner.MobileApp.Services.Quiz;

public class QuizService : IQuizService
{
	private readonly ApiClient _apiClient;
	public QuizService(ApiClient apiClient)
	{
		_apiClient = apiClient;

	}

	public async Task<Models.Quiz> GetQuizByIdAsync(int quizId)
	{
		var a = await _apiClient.GetAsync<Models.Requests.QuizEditRequestDto>($"quizzes/{quizId}");
		return QuizMapper.FromEditDtoToModel(await _apiClient.GetAsync<Models.Responses.QuizEditResponseDto>($"quizzes/{quizId}"))
		?? throw new Exception("Нет квиза");
	}

	public async Task<IEnumerable<QuizQuestionType>> GetQuizQuestionTypesAsync()
	{
		return await _apiClient
				.GetAsync<IEnumerable<QuizQuestionType>>("quizQuestionTypes")
				?? throw new Exception("Нет типов квиза");
	}

	public async Task<IEnumerable<QuizSummaryResponseDto>> GetQuizSummariesAsync()
	{
		return await _apiClient.GetAsync<IEnumerable<QuizSummaryResponseDto>>("quizzes");
	}

	public async Task SaveQuizAsync(Models.Quiz quiz)
	{
		if (quiz.Id == null)
		{
			await _apiClient.PostAsync<Models.Quiz>("quizzes", QuizMapper.ToEditDto(quiz));
		}
		else
		{
			await _apiClient.PutAsync<Models.Quiz>($"quizzes/{quiz.Id}", QuizMapper.ToEditDto(quiz));
		}

	}
	public async Task DeleteQuizAsync(int quizId)
	{
		await _apiClient.DeleteAsync($"quizzes/{quizId}");
	}
}
