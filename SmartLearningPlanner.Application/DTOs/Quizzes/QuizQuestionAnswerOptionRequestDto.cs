using System;

namespace SmartLearningPlanner.Application.DTOs;

public class QuizQuestionAnswerOptionRequestDto
{
	public int? Id { get; set; }
	public string AnswerText { get; set; }
	public bool IsCorrect { get; set; }
}
