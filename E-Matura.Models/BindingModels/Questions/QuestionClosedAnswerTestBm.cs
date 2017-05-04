using System.Collections.Generic;
using E_Matura.Models.EntityModels;
using E_Matura.Models.Enums;
using E_Matura.Models.ViewModels.Answers;

namespace E_Matura.Models.BindingModels.Questions
{
    public class QuestionClosedAnswerTestBm
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<ClosedAnswerVm> AnswerVms { get; set; }
        public int Points { get; set; }
        public int NumberInTest { get; set; }
        public Subject Subject { get; set; }
        public Grade Grade { get; set; }
        public User Author { get; set; }
    }
}
