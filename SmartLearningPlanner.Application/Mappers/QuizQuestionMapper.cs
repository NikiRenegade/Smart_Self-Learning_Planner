using System;
using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Application.Mappers;
namespace SmartLearningPlanner.Application.Mappers;

public static class QuizQuestionMapper
{
	public static QuizQuestion ToEntity(this QuizQuestionRequestDto dto) => new QuizQuestion
	{
		Id = dto.Id,
		QuestionText = dto.QuestionText,
		QuestionTypeId = dto.QuestionTypeId,
		CorrectAnswer = dto.CorrectAnswer,
		QuizQuestionAnswerOptions = dto?.QuizQuestionAnswerOptions?
						.Select(q => q?.ToEntity())
						.ToList()
	};

	public static QuizQuestionDto ToDto(this QuizQuestion entity) => new QuizQuestionDto
	{
		Id = entity.Id,
		QuestionText = entity.QuestionText,
		QuestionTypeId = entity.QuestionTypeId,
		QuizQuestionType = entity.QuestionType.ToDto(),
		CorrectAnswer = entity.CorrectAnswer,
		QuizQuestionAnswerOptions = entity?.QuizQuestionAnswerOptions?
						.Select(q => q?.ToDto())
						.ToList()
	};
}
