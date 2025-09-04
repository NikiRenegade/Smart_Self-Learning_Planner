using System;
using SmartLearningPlanner.MobileApp.Models;
namespace SmartLearningPlanner.MobileApp.Services.Quiz.Factories;

public class MultipleChoiceQuestionFactory : IQuestionFactory
{
	public QuizQuestionTypeCode Code => QuizQuestionTypeCode.MultipleChoice;

	public QuizQuestion Create(QuizQuestionType questionType)
	{
		var question = new QuizQuestion
		{
			QuestionType = questionType,
			QuestionTypeId = questionType.Id
		};

		question.QuizQuestionAnswerOptions = new System.Collections.ObjectModel.ObservableCollection<QuizQuestionAnswerOption>
		{
				new() { AnswerText = string.Empty, QuizQuestion = question },
				new() { AnswerText = string.Empty, QuizQuestion = question }
		};
		return question;
	}
}
