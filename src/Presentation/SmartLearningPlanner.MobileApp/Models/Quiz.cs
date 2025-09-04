using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
namespace SmartLearningPlanner.MobileApp.Models;

public partial class Quiz : ObservableObject, IPrototype<Quiz>
{
	[ObservableProperty]
	private int? id;


	/// <summary>
	/// Название квиза.
	/// </summary>
	[ObservableProperty]
	private string title;

	/// <summary>
	/// Описание к квизу.
	/// </summary>
	[ObservableProperty]
	private string? description;

	/// <summary>
	/// Вопросы, входящие в этот квиз.
	/// </summary>
	[ObservableProperty]
	private ObservableCollection<QuizQuestion> quizQuestions = new();

	/// <summary>
	/// Идентификатор узла (MindmapNode), к которому относится прогресс.
	/// </summary>
	[ObservableProperty]
	private int mindmapNodeId;

	[ObservableProperty]
	private string createdById;

	public Quiz Clone()
	{

		var quiz = new Quiz
		{
			Title = this.Title,
			Description = this.Description,
			QuizQuestions = new ObservableCollection<QuizQuestion>()
		};
		foreach (QuizQuestion quizQuestion in this.quizQuestions)
		{
			quiz.quizQuestions.Add(quizQuestion.Clone());
		}
		return quiz;

	}
}
