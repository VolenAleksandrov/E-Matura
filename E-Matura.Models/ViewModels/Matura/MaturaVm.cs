using System.Collections.Generic;
using E_Matura.Models.ViewModels.Questions;

namespace E_Matura.Models.ViewModels.Matura
{
    public class MaturaVm
    {
        public MaturaVm()
        {
            this.Questions = new List<QuestionClosedAnswerTestVm>();
        }
        public int Time { get; set; }

        public List<QuestionClosedAnswerTestVm> Questions { get; set; }
    }
}
