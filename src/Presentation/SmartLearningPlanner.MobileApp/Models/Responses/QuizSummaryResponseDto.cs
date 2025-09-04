using System;

namespace SmartLearningPlanner.MobileApp.Models.Responses;

public class QuizSummaryResponseDto
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string? Description { get; set; }
	public string CreatedByUserName { get; set; }
	public string CreatedById { get; set; }
}
