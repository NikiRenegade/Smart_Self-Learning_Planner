using System;
using SmartLearningPlanner.MobileApp.Models;
namespace SmartLearningPlanner.MobileApp.Services.Quiz.Factories;

public class TextAnswerQuestionFactory : IQuestionFactory
{
	public QuizQuestionTypeCode Code => QuizQuestionTypeCode.TextAnswer;

	public QuizQuestion Create(QuizQuestionType questionType)
	{
		return new QuizQuestion
		{
			QuestionType = questionType,
			QuestionTypeId = questionType.Id,
			CorrectAnswer = string.Empty
		};
	}
}
