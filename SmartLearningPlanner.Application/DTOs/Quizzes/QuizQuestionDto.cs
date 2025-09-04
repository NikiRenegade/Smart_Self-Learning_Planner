using System;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Application.DTOs;

public class QuizQuestionDto
{
	public int? Id { get; set; }
	public string QuestionText { get; set; }
	public int QuestionTypeId { get; set; }
	public QuizQuestionTypeDto QuizQuestionType { get; set; }
	public List<QuizQuestionAnswerOptionDto> QuizQuestionAnswerOptions { get; set; } = new();
	public string? CorrectAnswer { get; set; }

}
