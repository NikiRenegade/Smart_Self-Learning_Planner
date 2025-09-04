using System;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Application.DTOs;

public class QuizQuestionRequestDto
{
	public int? Id { get; set; }
	public string QuestionText { get; set; }
	public int QuestionTypeId { get; set; }
	public List<QuizQuestionAnswerOptionRequestDto> QuizQuestionAnswerOptions { get; set; } = new();
	public string? CorrectAnswer { get; set; }

}
