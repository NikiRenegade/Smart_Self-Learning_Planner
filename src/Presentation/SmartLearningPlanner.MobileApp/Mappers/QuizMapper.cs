using System;
using SmartLearningPlanner.MobileApp.Models;
using SmartLearningPlanner.MobileApp.Models.Requests;
using SmartLearningPlanner.MobileApp.Models.Responses;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
namespace SmartLearningPlanner.MobileApp.Mappers;

public class QuizMapper
{
	public static QuizEditRequestDto ToEditDto(Quiz quiz)
	{
		return new QuizEditRequestDto
		{
			Id = quiz.Id == 0 ? null : quiz.Id,
			Title = quiz.Title,
			Description = quiz.Description,
			CreatedById = quiz.CreatedById,
			QuizQuestions = quiz.QuizQuestions
						.Select(q => new QuizQuestionEditRequestDto
						{
							Id = q.Id,
							QuestionText = q.QuestionText,
							QuestionTypeId = q.QuestionTypeId,
							CorrectAnswer = q.CorrectAnswer,
							QuizQuestionAnswerOptions = q.QuizQuestionAnswerOptions
										.Select(opt => new QuizQuestionAnswerOptionEditRequestDto
										{
											Id = opt.Id,
											AnswerText = opt.AnswerText,
											IsCorrect = opt.IsCorrect
										})
										.ToList()
						})
						.ToList()
		};
	}
	public static Quiz FromEditDtoToModel(QuizEditResponseDto editDto)
	{
		return new Quiz
		{
			Id = (int)editDto.Id,
			Title = editDto.Title,
			Description = editDto.Description,
			CreatedById = editDto.CreatedById,
			QuizQuestions = new ObservableCollection<QuizQuestion>(
						editDto.QuizQuestions.Select(q => new QuizQuestion
						{
							Id = (int)q.Id,
							QuestionText = q.QuestionText,
							QuestionTypeId = q.QuestionTypeId,
							QuestionType = q.QuizQuestionType,
							CorrectAnswer = q.CorrectAnswer,
							QuizQuestionAnswerOptions = new ObservableCollection<QuizQuestionAnswerOption>(
										q.QuizQuestionAnswerOptions.Select(opt => new QuizQuestionAnswerOption
										{
											Id = (int)opt.Id,
											AnswerText = opt.AnswerText,
											IsCorrect = opt.IsCorrect
										})
								)
						})
		)
		};
	}


}
