using System;
using Microsoft.AspNetCore.Mvc;
using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Application.Interfaces;

namespace SmartLearningPlanner.MobileApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizzesController : ControllerBase
{
	private readonly IQuizService _quizService;

	public QuizzesController(IQuizService quizService)
	{
		_quizService = quizService;
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<QuizDto>> GetQuiz(int id)
	{
		var quiz = await _quizService.GetQuizByIdAsync(id);
		if (quiz == null) return NotFound();

		return Ok(quiz);
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<QuizSummaryDto>>> GetAllQuiz()
	{
		var quiz = await _quizService.GetAllSummariesQuizzesAsync();

		return Ok(quiz);
	}

	[HttpPost]
	public async Task<ActionResult> CreateQuiz(QuizRequestDto quizDto)
	{
		await _quizService.CreateQuizAsync(quizDto);

		return Ok();
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> UpdateQuiz(int id, QuizRequestDto quizDto)
	{
		if (id != quizDto.Id) return BadRequest();
		await _quizService.UpdateQuizQAsync(quizDto);

		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteQuizQuestionType(int id)
	{
		await _quizService.DeleteQuizAsync(id);
		return NoContent();
	}
}
