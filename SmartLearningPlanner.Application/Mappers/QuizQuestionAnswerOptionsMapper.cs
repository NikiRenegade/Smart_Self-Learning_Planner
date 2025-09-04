using System;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Application.DTOs;
namespace SmartLearningPlanner.Application.Mappers;

public static class QuizQuestionAnswerOptionsMapper
{
	public static QuizQuestionAnswerOption ToEntity(this QuizQuestionAnswerOptionRequestDto dto) => new QuizQuestionAnswerOption
	{
		Id = dto.Id,
		AnswerText = dto.AnswerText,
		IsCorrect = dto.IsCorrect
	};

	public static QuizQuestionAnswerOptionDto ToDto(this QuizQuestionAnswerOption entity) => new QuizQuestionAnswerOptionDto
	{
		Id = entity.Id,
		AnswerText = entity.AnswerText,
		IsCorrect = entity.IsCorrect
	};
}
