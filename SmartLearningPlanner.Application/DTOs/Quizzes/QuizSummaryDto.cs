using System;

namespace SmartLearningPlanner.Application.DTOs;

/// <summary>
/// DTO для списка квизов (облегченный).
/// </summary>
public class QuizSummaryDto
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string? Description { get; set; }
	public string CreatedByUserName { get; set; }
	public string CreatedById { get; set; }

}
