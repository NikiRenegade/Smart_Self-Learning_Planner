using System;
using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Application.Interfaces;
using SmartLearningPlanner.Application.Mappers;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Domain.Interfaces.Repositories;

namespace SmartLearningPlanner.Application.Services;

public class QuizService : IQuizService
{

	private readonly IQuizRepository _quizRepository;
	private readonly IUserRepository _userRepository;

	public QuizService(IQuizRepository quizRepository, IUserRepository userRepository)
	{
		_quizRepository = quizRepository;
		_userRepository = userRepository;
	}

	public async Task CreateQuizAsync(QuizRequestDto quizDto)
	{
		var quiz = quizDto?.ToEntity();
		await _quizRepository.AddAsync(quiz);
	}

	public async Task DeleteQuizAsync(int id)
	{
		var quiz = await _quizRepository.GetByIdAsync(id);
		if (quiz == null) throw new Exception("Quiz question type not found");

		await _quizRepository.DeleteAsync(id);
	}

	public async Task<IEnumerable<QuizSummaryDto>> GetAllSummariesQuizzesAsync()
	{
		return (await _quizRepository.GetAllSummariesAsync())
						.Select(q => q.ToQuizSummaryDto(q.CreatedBy?.UserName)); ;
	}

	public async Task<QuizDto> GetQuizByIdAsync(int id)
	{
		var quiz = await _quizRepository.GetByIdAsync(id);
		return quiz.ToDto();
	}

	public async Task UpdateQuizQAsync(QuizRequestDto quizDto)
	{
		var quiz = quizDto.ToEntity();
		await _quizRepository.UpdateAsync(quiz);
	}
}