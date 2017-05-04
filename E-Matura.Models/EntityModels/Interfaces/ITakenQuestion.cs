using System;
using E_Matura.Models.EntityModels.BaseModels;

namespace E_Matura.Models.EntityModels.Interfaces
{
    public interface ITakenQuestion
    {
        int Id { get; }
        QuestionBase Question { get; }
        DateTime DateOfTake { get; }
    }
}
