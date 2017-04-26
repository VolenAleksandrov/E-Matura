using E_Matura.Models.EntityModels;
using E_Matura.Models.EntityModels.Answers;
using E_Matura.Models.EntityModels.BaseModels;

namespace E_Matura.Data.Contracts
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        IRepository<User> Users { get; }
        IRepository<QuestionBase> Questions { get; }
        IRepository<ClosedAnswer> ClosedAnswers { get; }
        IRepository<OpenAnswer> OpenAnswers { get; }
    }
}
