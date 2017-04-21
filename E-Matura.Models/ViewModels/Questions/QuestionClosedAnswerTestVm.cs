using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Matura.Models.EntityModels;
using E_Matura.Models.Enums;
using E_Matura.Models.ViewModels.Answers;

namespace E_Matura.Models.ViewModels.Questions
{
    public class QuestionClosedAnswerTestVm : IQuestionVm 
    {
        public string Text { get; set; }
        public List<ClosedAnswerVm> AnswerVms { get; set; }
        public int Points { get; set; }
        public int NumberInTest { get; set; }
        public Subject Subject { get; set; }
        public Grade Grade { get; set; }
        public User Author { get; set; }
    }
}
