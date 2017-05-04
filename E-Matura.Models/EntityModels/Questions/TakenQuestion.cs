using System;
using E_Matura.Models.EntityModels.Answers;
using E_Matura.Models.EntityModels.BaseModels;
using E_Matura.Models.EntityModels.Interfaces;

namespace E_Matura.Models.EntityModels.Questions
{
    public class TakenQuestion : ITakenQuestion
    {
        public int Id { get; set; }
        public QuestionBase Question { get; set; }
        public ClosedAnswer ChoosenAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public User User { get; set; }
        public DateTime DateOfTake { get; set; }
    }
}
