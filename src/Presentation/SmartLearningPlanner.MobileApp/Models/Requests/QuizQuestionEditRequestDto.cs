using System;

namespace SmartLearningPlanner.MobileApp.Models.Requests;

public class QuizQuestionEditRequestDto
{
	public int? Id { get; set; }
	public string QuestionText { get; set; }
	public int QuestionTypeId { get; set; }
	public List<QuizQuestionAnswerOptionEditRequestDto> QuizQuestionAnswerOptions { get; set; } = new();
	public string? CorrectAnswer { get; set; }
}
