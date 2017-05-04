using E_Matura.Models.Enums;

namespace E_Matura.Models.EntityModels.Interfaces
{
	public interface IQuestion
	{
        int Id { get; set; }
		string Text { get; }
		int Points { get; }
		User Author { get; }
		Grade Grade { get; }
		Subject Subject { get; }
		int NumberInTest { get; }
	}
}
