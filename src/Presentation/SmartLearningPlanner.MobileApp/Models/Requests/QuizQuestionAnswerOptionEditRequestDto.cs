using System;

namespace SmartLearningPlanner.MobileApp.Models;

public class QuizQuestionAnswerOptionEditRequestDto
{

	public int? Id { get; set; }
	public string AnswerText { get; set; }
	public bool IsCorrect { get; set; }

}
