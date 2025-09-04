using System;
using SmartLearningPlanner.MobileApp.Models;
namespace SmartLearningPlanner.MobileApp.Services.Quiz.Factories;

public class QuestionFactoryRegistry
{
	private readonly Dictionary<QuizQuestionTypeCode, IQuestionFactory> _factories;

	public QuestionFactoryRegistry(IEnumerable<IQuestionFactory> factories)
	{
		_factories = factories.ToDictionary(f => f.Code, f => f);
	}

	public QuizQuestion CreateQuestion(QuizQuestionType questionType)
	{
		if (_factories.TryGetValue(questionType.TypeCode, out var factory))
			return factory.Create(questionType);

		throw new InvalidOperationException($"Нет фабрики для типа {questionType.TypeCode}");
	}

}
