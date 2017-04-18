using System;
using System.Collections.Generic;
using E_Matura.Models.EntityModels.Answers;
using E_Matura.Models.EntityModels.BaseModels;
using E_Matura.Models.EntityModels.Interfaces;
using E_Matura.Models.Enums;
using E_Matura.Models.Utils;

namespace E_Matura.Models.EntityModels.Questions
{
	public class QuestionClosedAnswer : QuestionBase, IQuestionClosedAnswer
	{
		private IEnumerable<ClosedAnswer> answers;
		public QuestionClosedAnswer(string text, int points, Grade grade, Subject subject, int numberInTest, User author, IEnumerable<ClosedAnswer> answers) 
			: base(text, points, grade, subject, numberInTest, author)
		{
			this.Answers = answers;
		}

		public IEnumerable<ClosedAnswer> Answers
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
