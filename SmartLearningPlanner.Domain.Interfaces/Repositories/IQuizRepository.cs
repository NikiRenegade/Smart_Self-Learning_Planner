using System;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Domain.Interfaces.Repositories;

public interface IQuizRepository
{
	Task<Quiz> GetByIdAsync(int id);
	Task<IEnumerable<Quiz>> GetAllSummariesAsync();
	Task AddAsync(Quiz quiz);
	Task UpdateAsync(Quiz quiz);
	Task DeleteAsync(int id);

}
