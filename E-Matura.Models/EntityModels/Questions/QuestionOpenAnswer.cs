using System;
using System.Collections.Generic;
using System.Linq;
using E_Matura.Models.EntityModels.Answers;
using E_Matura.Models.EntityModels.BaseModels;
using E_Matura.Models.Enums;

namespace E_Matura.Models.EntityModels.Questions
{
	public class QuestionOpenAnswer : QuestionBase
	{
		private IEnumerable<OpenAnswer> answerVariations;

		public QuestionOpenAnswer(string text, int points, Grade grade, Subject subject, int numberInTest, User author, IEnumerable<OpenAnswer> answerVariations) 
			: base(text, points, grade, subject, numberInTest, author)
		{
			this.AnswerVariations = answerVariations;
		}

	    public QuestionOpenAnswer()
	    {
	        
	    }
		public IEnumerable<OpenAnswer> AnswerVariations
		{
			get { return this.answerVariations; }
			set
			{
				if (!value.Any())
				{
					throw new ArgumentOutOfRangeException("Open answer variations must be one minimum!");
				}
				this.answerVariations = value;
			}
		}
	}
}
