using E_Matura.Models.EntityModels;
using E_Matura.Models.Enums;

namespace E_Matura.Models.ViewModels.Questions
{
    public interface IQuestionVm
    {
        string Text { get; set; }
        int Points { get; set; }
        int NumberInTest { get; set; }
        Subject Subject { get; set; }
        Grade Grade { get; set; }
        User Author { get; set; }
    }
}
