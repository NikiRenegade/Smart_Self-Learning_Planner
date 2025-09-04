using System;
using SmartLearningPlanner.MobileApp.Models;
namespace SmartLearningPlanner.MobileApp.Services.Quiz.Factories;

public interface IQuestionFactory
{
	QuizQuestionTypeCode Code { get; }
	QuizQuestion Create(QuizQuestionType questionType);
}
