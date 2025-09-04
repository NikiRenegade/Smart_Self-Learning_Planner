using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace SmartLearningPlanner.MobileApp.Models;

/// <summary>
/// Вопрос в квизе.
/// </summary>
public partial class QuizQuestion : ObservableObject, IPrototype<QuizQuestion>
{
	/// <summary>
	/// Идентификатор вопроса.
	/// </summary>
	[ObservableProperty]
	private int? id;

	/// <summary>
	/// Текст вопроса.
	/// </summary>
	[ObservableProperty]
	private string questionText;

	/// <summary>
	/// Тип вопроса (один вариант, несколько, текстовый ответ).
	/// </summary>
	[ObservableProperty]
	private int questionTypeId;

	[ObservableProperty]
	private QuizQuestionType questionType;

	/// <summary>
	/// Варианты ответа (если применимо).
	/// </summary>
	[ObservableProperty]
	private ObservableCollection<QuizQuestionAnswerOption> quizQuestionAnswerOptions = new();

	/// <summary>
	/// Правильный ответ (если это текстовый вопрос).
	/// </summary>
	[ObservableProperty]
	private string? correctAnswer;

	public QuizQuestion Clone()
	{
		var quizQuestion = new QuizQuestion
		{
			QuestionText = this.QuestionText,
			QuestionTypeId = this.QuestionTypeId,
			QuestionType = this.QuestionType,
			CorrectAnswer = this.CorrectAnswer,
			QuizQuestionAnswerOptions = new ObservableCollection<QuizQuestionAnswerOption>()
		};
		for (var i = 0; i < this.QuizQuestionAnswerOptions.Count(); i++)
		{
			quizQuestion.QuizQuestionAnswerOptions.Add(this.QuizQuestionAnswerOptions[i].Clone());
			quizQuestion.QuizQuestionAnswerOptions[i].QuizQuestion = quizQuestion;
		}


		return quizQuestion;
	}
}


