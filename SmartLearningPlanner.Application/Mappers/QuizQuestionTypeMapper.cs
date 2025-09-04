using System;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Application.DTOs.Quizzes;
namespace SmartLearningPlanner.Application.Mappers;

public static class QuizQuestionTypeMapper
{
	public static QuizQuestionType ToEntity(this QuizQuestionTypeRequestDto dto) => new QuizQuestionType
	{
		Id = dto.Id,
		TypeCode = dto.TypeCode,
		Name = dto.Name,
		AllowsMultipleAnswers = dto.AllowsMultipleAnswers,
		RequiresTextAnswer = dto.RequiresTextAnswer
	};

	public static QuizQuestionTypeDto ToDto(this QuizQuestionType entity) => new QuizQuestionTypeDto
	{
		Id = entity.Id,
		TypeCode = entity.TypeCode,
		Name = entity.Name,
		AllowsMultipleAnswers = entity.AllowsMultipleAnswers,
		RequiresTextAnswer = entity.RequiresTextAnswer
	};
}
