using System;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Application.DTOs;

public class QuizRequestDto
{
	public int? Id { get; set; }
	public string Title { get; set; }
	public string? Description { get; set; }
	public List<QuizQuestionRequestDto>? QuizQuestions { get; set; } = new();
	public string CreatedById { get; set; }
}
