using System;

namespace SmartLearningPlanner.MobileApp.Models.Responses;

public class QuizEditResponseDto
{
	public int? Id { get; set; }
	public string Title { get; set; }
	public string? Description { get; set; }
	public List<QuizQuestionEditResponseDto>? QuizQuestions { get; set; } = new();
	public string CreatedById { get; set; }
}
