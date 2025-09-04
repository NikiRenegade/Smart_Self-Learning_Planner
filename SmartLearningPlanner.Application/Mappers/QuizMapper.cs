using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Application.Mappers;

public static class QuizMapper
{
	public static Quiz ToEntity(this QuizRequestDto dto) => new Quiz
	{
		Id = dto.Id,
		Title = dto.Title,
		Description = dto.Description,
		CreatedById = dto.CreatedById,
		QuizQuestions = dto?.QuizQuestions?
					.Select(q => q?.ToEntity())
					.ToList()
	};
	public static QuizSummaryDto ToQuizSummaryDto(this Quiz entity, string CreatedByUserName) => new QuizSummaryDto
	{
		Id = (int)entity.Id,
		Title = entity.Title,
		Description = entity.Description,
		CreatedById = entity.CreatedById,
		CreatedByUserName = CreatedByUserName
	};
	public static QuizDto ToDto(this Quiz entity) => new QuizDto
	{
		Id = entity.Id,
		Title = entity.Title,
		Description = entity.Description,
		CreatedById = entity.CreatedById,
		QuizQuestions = entity?.QuizQuestions?
						.Select(q => q?.ToDto())
						.ToList()
	};


}
