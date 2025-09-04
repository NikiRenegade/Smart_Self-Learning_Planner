using System;

namespace SmartLearningPlanner.MobileApp.Models.Responses;

public class QuizQuestionEditResponseDto
{
	public int? Id { get; set; }
	public string QuestionText { get; set; }
	public int QuestionTypeId { get; set; }
	public QuizQuestionType QuizQuestionType { get; set; }
	public List<QuizQuestionAnswerOptionEditResponseDto> QuizQuestionAnswerOptions { get; set; } = new();
	public string? CorrectAnswer { get; set; }
}
