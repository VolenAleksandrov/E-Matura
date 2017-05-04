using E_Matura.Models.EntityModels.Interfaces;

namespace E_Matura.Models.EntityModels.Answers
{
	public class ClosedAnswer : IAnswer
	{
		private string text;

		public ClosedAnswer(string text, bool isTrue)
		{
			this.IsTrue = isTrue;
			this.Text = text;
		}

	    public ClosedAnswer()
	    {
	        
	    }

		public int Id { get; set; }

		public string Text
		{
			get { return this.text; }
			set
			{
				//if (!Utilities.IsValid(value))
				//{
				//	throw new ArgumentNullException("Text must be not empty!");
				//}
				this.text = value;
			}
		}
		
		public IQuestion Question { get; set; }
		public bool IsTrue { get; set; }
	}
}
