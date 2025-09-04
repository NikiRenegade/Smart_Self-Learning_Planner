using System;

namespace SmartLearningPlanner.MobileApp.Models.Requests;

public class QuizEditRequestDto
{
	public int? Id { get; set; }
	public string Title { get; set; }
	public string? Description { get; set; }
	public List<QuizQuestionEditRequestDto>? QuizQuestions { get; set; } = new();
	public string CreatedById { get; set; }
}
