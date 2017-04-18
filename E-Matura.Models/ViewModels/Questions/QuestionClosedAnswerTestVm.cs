using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Matura.Models.ViewModels.Answers;

namespace E_Matura.Models.ViewModels.Questions
{
    public class QuestionClosedAnswerTestVm
    {
        public string Text { get; set; }
        public IEnumerable<ClosedAnswerVm> Answers { get; set; }
    }
}
