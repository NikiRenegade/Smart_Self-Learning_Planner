using System;

namespace SmartLearningPlanner.MobileApp.Models.Responses;

public class QuizQuestionAnswerOptionEditResponseDto
{

	public int? Id { get; set; }
	public string AnswerText { get; set; }
	public bool IsCorrect { get; set; }

}
