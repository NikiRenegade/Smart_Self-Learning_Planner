using System;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Application.DTOs;

public class QuizDto
{
	public int? Id { get; set; }
	public string Title { get; set; }
	public string? Description { get; set; }
	public List<QuizQuestionDto>? QuizQuestions { get; set; } = new();
	public string CreatedById { get; set; }
}
