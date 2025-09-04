using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartLearningPlanner.MobileApp.Models;

/// <summary>
/// Вариант ответа в квизе.
/// </summary>
public partial class QuizQuestionAnswerOption : ObservableObject, IPrototype<QuizQuestionAnswerOption>
{
	[ObservableProperty]
	private int? id;

	/// <summary>
	/// Текст ответа.
	/// </summary>
	[ObservableProperty]
	private string answerText;

	/// <summary>
	/// Флаг, является ли этот ответ правильным.
	/// </summary>
	private bool isCorrect;


	/// <summary>
	/// Вопрос, к которому относится этот вариант ответа.
	/// </summary>
	[ObservableProperty]
	private QuizQuestion quizQuestion;


	public bool IsCorrect
	{
		get => isCorrect;
		set
		{
			if (isCorrect != value)
			{
				isCorrect = value;
				OnPropertyChanged();

				// Если включили этот вариант, снимаем у остальных
				if (isCorrect && QuizQuestion != null && QuizQuestion?.QuestionType.TypeCode == QuizQuestionTypeCode.SingleChoice)
				{
					foreach (var option in QuizQuestion.QuizQuestionAnswerOptions)
					{
						if (option != this)
							option.isCorrect = false; // напрямую, чтобы не вызвать рекурсию
					}
					// Обновляем всех
					foreach (var option in QuizQuestion.QuizQuestionAnswerOptions)
						option.OnPropertyChanged(nameof(IsCorrect));
				}
			}
		}
	}

	public QuizQuestionAnswerOption Clone()
	{
		return new QuizQuestionAnswerOption
		{
			AnswerText = this.AnswerText,
			IsCorrect = this.IsCorrect
		};
	}
}