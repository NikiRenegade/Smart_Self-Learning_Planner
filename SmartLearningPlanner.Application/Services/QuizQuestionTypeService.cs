using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Application.Interfaces;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Domain.Interfaces.Repositories;
using Task = System.Threading.Tasks.Task;

namespace SmartLearningPlanner.Application.Services;

public class QuizQuestionTypeService : IQuizQuestionTypeService
{
    private readonly IQuizQuestionTypeRepository _quizQuestionTypeRepository;

    public QuizQuestionTypeService(IQuizQuestionTypeRepository quizQuestionTypeRepository)
    {
        _quizQuestionTypeRepository = quizQuestionTypeRepository;
    }

    public async Task<QuizQuestionTypeDto> GetQuizQuestionTypeByIdAsync(int id)
    {
        var quizQuestionType = await _quizQuestionTypeRepository.GetByIdAsync(id);

        return new QuizQuestionTypeDto { Id = quizQuestionType.Id, Name = quizQuestionType.Name, TypeCode = quizQuestionType.TypeCode, AllowsMultipleAnswers = quizQuestionType.AllowsMultipleAnswers, RequiresTextAnswer = quizQuestionType.RequiresTextAnswer };
    }

    public async Task<IEnumerable<QuizQuestionTypeDto>> GetAllQuizQuestionTypesAsync()
    {
        var quizQuestionTypes = await _quizQuestionTypeRepository.GetAllAsync();

        return quizQuestionTypes.Select(q => new QuizQuestionTypeDto { Id = q.Id, Name = q.Name, TypeCode = q.TypeCode, AllowsMultipleAnswers = q.AllowsMultipleAnswers, RequiresTextAnswer = q.RequiresTextAnswer });
    }

    public async Task CreateQuizQuestionTypeAsync(QuizQuestionTypeDto quizQuestionTypeDto)
    {
        var quizQuestionType = new QuizQuestionType { Id = quizQuestionTypeDto.Id, Name = quizQuestionTypeDto.Name, TypeCode = quizQuestionTypeDto.TypeCode, AllowsMultipleAnswers = quizQuestionTypeDto.AllowsMultipleAnswers, RequiresTextAnswer = quizQuestionTypeDto.RequiresTextAnswer };
        await _quizQuestionTypeRepository.AddAsync(quizQuestionType);
    }

    public async Task UpdateQuizQuestionTypeAsync(QuizQuestionTypeDto quizQuestionTypeDto)
    {
        var quizQuestionType = await _quizQuestionTypeRepository.GetByIdAsync(quizQuestionTypeDto.Id);
        if (quizQuestionType == null) throw new Exception("Quiz question type not found");

        quizQuestionType.Name = quizQuestionTypeDto.Name;
        quizQuestionType.TypeCode = quizQuestionTypeDto.TypeCode;
        quizQuestionType.AllowsMultipleAnswers = quizQuestionTypeDto.AllowsMultipleAnswers;
        quizQuestionType.RequiresTextAnswer = quizQuestionTypeDto.RequiresTextAnswer;
        await _quizQuestionTypeRepository.UpdateAsync(quizQuestionType);
    }

    public async Task DeleteQuizQuestionTypeAsync(int id)
    {
        var quizQuestionType = await _quizQuestionTypeRepository.GetByIdAsync(id);
        if (quizQuestionType == null) throw new Exception("Quiz question type not found");

        await _quizQuestionTypeRepository.DeleteAsync(id);
    }
}