using E_Matura.Data.Contracts;
using E_Matura.Models.EntityModels;
using E_Matura.Models.EntityModels.Answers;
using E_Matura.Models.EntityModels.BaseModels;
using E_Matura.Models.EntityModels.Matura;
using E_Matura.Models.EntityModels.Questions;

namespace E_Matura.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private EMaturaContext context;

        private IRepository<QuestionBase> questions;
        private IRepository<ClosedAnswer> closedAnswers;
        private IRepository<User> users;
        private IRepository<OpenAnswer> openAnswers;
        private IRepository<TakenQuestion> takenQuestions;
        private IRepository<MaturaResult> maturaResults;

        public UnitOfWork()
        {
            this.context = Data.Context;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
        public IRepository<User> Users
            => this.users ??
               (this.users = new Repository<User>(this.context.Users));

        public IRepository<ClosedAnswer> ClosedAnswers
            => this.closedAnswers ??
            (this.closedAnswers = new Repository<ClosedAnswer>(this.context.ClosedAnswers));

        public IRepository<OpenAnswer> OpenAnswers
           => this.openAnswers ??
           (this.openAnswers = new Repository<OpenAnswer>(this.context.OpenAnswers));
        public IRepository<QuestionBase> Questions
           => this.questions ??
           (this.questions = new Repository<QuestionBase>(this.context.Questions));
        public IRepository<TakenQuestion> TakenQuestions
           => this.takenQuestions ??
           (this.takenQuestions = new Repository<TakenQuestion>(this.context.TakenQuestions));
        public IRepository<MaturaResult> MaturaResults
           => this.maturaResults ??
           (this.maturaResults = new Repository<MaturaResult>(this.context.MaturaResults));
    }
}
