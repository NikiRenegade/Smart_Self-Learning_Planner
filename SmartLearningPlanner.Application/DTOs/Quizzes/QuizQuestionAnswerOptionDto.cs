using System;

namespace SmartLearningPlanner.Application.DTOs;

public class QuizQuestionAnswerOptionDto
{
	public int? Id { get; set; }
	public string AnswerText { get; set; }
	public bool IsCorrect { get; set; }
}
