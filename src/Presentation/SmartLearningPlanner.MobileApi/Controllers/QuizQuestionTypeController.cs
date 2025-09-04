using Microsoft.AspNetCore.Mvc;
using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Application.Interfaces;

namespace SmartLearningPlanner.MobileApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizQuestionTypesController : ControllerBase
{
    private readonly IQuizQuestionTypeService _quizQuestionTypeService;

    public QuizQuestionTypesController(IQuizQuestionTypeService quizQuestionTypeService)
    {
        _quizQuestionTypeService = quizQuestionTypeService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<QuizQuestionTypeDto>> GetQuizQuestionType(int id)
    {
        var quizQuestionType = await _quizQuestionTypeService.GetQuizQuestionTypeByIdAsync(id);
        if (quizQuestionType == null) return NotFound();

        return Ok(quizQuestionType);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuizQuestionTypeDto>>> GetAllQuizQuestionTypes()
    {
        var quizQuestionTypes = await _quizQuestionTypeService.GetAllQuizQuestionTypesAsync();

        return Ok(quizQuestionTypes);
    }

    [HttpPost]
    public async Task<ActionResult> CreateQuizQuestionType(QuizQuestionTypeDto quizQuestionTypeDto)
    {
        await _quizQuestionTypeService.CreateQuizQuestionTypeAsync(quizQuestionTypeDto);

        return CreatedAtAction(nameof(GetQuizQuestionType), new { id = quizQuestionTypeDto.Id }, quizQuestionTypeDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateQuizQuestionType(int id, QuizQuestionTypeDto quizQuestionTypeDto)
    {
        if (id != quizQuestionTypeDto.Id) return BadRequest();
        await _quizQuestionTypeService.UpdateQuizQuestionTypeAsync(quizQuestionTypeDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteQuizQuestionType(int id)
    {
        await _quizQuestionTypeService.DeleteQuizQuestionTypeAsync(id);
        return NoContent();
    }
}