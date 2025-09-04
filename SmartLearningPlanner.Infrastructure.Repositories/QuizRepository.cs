using System;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Domain.Interfaces.Repositories;
using SmartLearningPlanner.Infrastructure.EntityFramework;

namespace SmartLearningPlanner.Infrastructure.Repositories;

public class QuizRepository : IQuizRepository
{

	private readonly ApplicationDbContext _context;

	public QuizRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task AddAsync(Quiz quiz)
	{
		await _context.Quizzes.AddAsync(quiz);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var quiz = await _context.Quizzes.FindAsync(id);
		if (quiz != null)
		{
			_context.Quizzes.Remove(quiz);
			await _context.SaveChangesAsync();
		}
	}

	public async Task<IEnumerable<Quiz>> GetAllSummariesAsync()
	{
		return await _context.Quizzes.Include(q => q.CreatedBy).ToListAsync();
	}

	public async Task<Quiz> GetByIdAsync(int id)
	{
		return await _context.Quizzes
			 .Include(q => q.QuizQuestions)
					 .ThenInclude(qq => qq.QuestionType)
			 .Include(q => q.QuizQuestions)
					 .ThenInclude(qq => qq.QuizQuestionAnswerOptions)
			 .FirstOrDefaultAsync(q => q.Id == id);
	}

	public async Task UpdateAsync(Quiz quiz)
	{
		_context.Quizzes.Update(quiz);
		await _context.SaveChangesAsync();
	}
}
