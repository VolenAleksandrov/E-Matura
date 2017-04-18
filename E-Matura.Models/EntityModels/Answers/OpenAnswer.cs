using E_Matura.Models.EntityModels.Interfaces;

namespace E_Matura.Models.EntityModels.Answers
{
	public class OpenAnswer : IAnswer
	{
		public OpenAnswer(string variation)
		{
			this.Variation = variation;
		}

		public int Id { get; set; }
		public IQuestion Question { get; set; }
		public string Variation { get; set; }
	}
}
