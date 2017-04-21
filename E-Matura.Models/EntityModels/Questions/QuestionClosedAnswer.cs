using System;
using System.Collections.Generic;
using E_Matura.Models.EntityModels.Answers;
using E_Matura.Models.EntityModels.BaseModels;
using E_Matura.Models.Enums;
using E_Matura.Models.Utils;

namespace E_Matura.Models.EntityModels.Questions
{
	public class QuestionClosedAnswer : QuestionBase
	{
		private List<ClosedAnswer> answers;
		public QuestionClosedAnswer(string text, int points, Grade grade, Subject subject, int numberInTest, User author, List<ClosedAnswer> answers) 
			: base(text, points, grade, subject, numberInTest, author)
		{
			this.Answers = answers;
		}

		public List<ClosedAnswer> Answers
		{
			get { return this.answers; }
			set
			{
				if (Utilities.IsValidQuestionClosedAnswers(value))
				{
					throw new ArgumentOutOfRangeException("Answers must be exacly four!");
				}
				this.answers = value;
			}
		}
	}
}
