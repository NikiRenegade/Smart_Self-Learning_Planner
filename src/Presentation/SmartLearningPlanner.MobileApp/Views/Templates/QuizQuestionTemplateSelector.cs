using SmartLearningPlanner.MobileApp.Models;

namespace SmartLearningPlanner.MobileApp.Views.Templates;

public class QuizQuestionTemplateSelector : DataTemplateSelector
{
	public DataTemplate QuizQuestionTextAnswerTemplate { get; set; }
	public DataTemplate QuizQuestionMultipleChoiceTemplate { get; set; }
	public DataTemplate QuizQuestionSingleChoiceTemplate { get; set; }

	protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
	{
		if (item is QuizQuestion question)
		{
			return question.QuestionType.TypeCode switch
			{
				QuizQuestionTypeCode.TextAnswer => QuizQuestionTextAnswerTemplate,
				QuizQuestionTypeCode.MultipleChoice => QuizQuestionMultipleChoiceTemplate,
				QuizQuestionTypeCode.SingleChoice => QuizQuestionSingleChoiceTemplate,
				_ => null
			};
		}
		return null;
	}
}
