using System.Collections.Generic;
using System.Linq;
using E_Matura.Models.EntityModels.Answers;

namespace E_Matura.Models.Utils
{
	public static class Utilities
	{
		public static bool IsValid(string text)
		{
			if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
			{
				return false;
			}
			return true;
		}

		public static bool IsValidQuestionClosedAnswers(IEnumerable<ClosedAnswer> answers)
		{
			if (answers.Count() != 4)
			{
				return false;
			}
			if (answers.Select(answer => answer.IsTrue == true).Count() != 1)
			{
				return false;
			}
			return true;
		}
	}
}
