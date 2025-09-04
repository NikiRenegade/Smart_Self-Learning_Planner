using Microsoft.EntityFrameworkCore;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Domain.Interfaces.Repositories;
using SmartLearningPlanner.Infrastructure.EntityFramework;
using Task = System.Threading.Tasks.Task;

namespace SmartLearningPlanner.Infrastructure.Repositories;

public class QuizQuestionTypeRepository : IQuizQuestionTypeRepository
{
	private readonly ApplicationDbContext _context;

	public QuizQuestionTypeRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<QuizQuestionType> GetByIdAsync(int id)
	{
		return await _context.QuizQuestionTypes.FindAsync(id);
	}

	public async Task<IEnumerable<QuizQuestionType>> GetAllAsync()
	{
		return await _context.QuizQuestionTypes.ToListAsync();
	}

	public async Task AddAsync(QuizQuestionType quizQuestionType)
	{
		await _context.QuizQuestionTypes.AddAsync(quizQuestionType);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(QuizQuestionType quizQuestionType)
	{
		_context.QuizQuestionTypes.Update(quizQuestionType);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var quizQuestionType = await _context.QuizQuestionTypes.FindAsync(id);
		if (quizQuestionType != null)
		{
			_context.QuizQuestionTypes.Remove(quizQuestionType);
			await _context.SaveChangesAsync();
		}
	}

}
