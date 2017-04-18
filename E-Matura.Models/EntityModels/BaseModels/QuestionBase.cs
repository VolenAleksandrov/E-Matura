using System;
using E_Matura.Models.EntityModels.Interfaces;
using E_Matura.Models.Enums;
using E_Matura.Models.Utils;

namespace E_Matura.Models.EntityModels.BaseModels
{
	public abstract class QuestionBase : IQuestion
	{
		private string text;
		private int points;
		private int numberInTest;

		protected QuestionBase(string text, int points, Grade grade, Subject subject, int numberInTest, User author)
		{
			this.Text = text;
			this.Points = points;
			this.Author = author;
			this.Grade = grade;
			this.Subject = subject;
			this.NumberInTest = numberInTest;
		}

		public int Id { get; set; }

		public string Text
		{
			get { return this.text; }
			set
			{
				if (!Utilities.IsValid(value))
				{
					throw new ArgumentNullException("Text must be not empty!");
				}
				this.text = value;
			}
		}

		public int Points
		{
			get { return this.points; }
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("Points must be non negative or zero!");
				}
				this.points = value;
			}
		}

		public Subject Subject { get; set; }
		public Grade Grade { get; set; }

		public int NumberInTest
		{
			get { return this.numberInTest; }
			set
			{
				if (value < 1 || value > 60)
				{
					throw new ArgumentOutOfRangeException("Number in test must be between 1 and 60!");
				}
				this.numberInTest = value;
			}
		}

		public User Author { get; set; }
	}
}
