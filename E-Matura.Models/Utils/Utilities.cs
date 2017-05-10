using System.Collections.Generic;
using System.Linq;
using E_Matura.Models.EntityModels.Answers;

namespace E_Matura.Models.Utils
{
	public static class Utilities
	{
		public static bool IsValidQuestionClosedAnswers(IEnumerable<ClosedAnswer> answers)
		{
			if (answers.Count() != 4)
			{
				return false;
			}

		    int trueAnswersCount = answers.Select(answer => answer.IsTrue).Count();

            if (trueAnswersCount != 1 || trueAnswersCount != 2)
			{
				return false;
			}
			return true;
		}
	}
}
