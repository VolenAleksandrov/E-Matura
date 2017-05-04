using E_Matura.Models.EntityModels;
using E_Matura.Models.EntityModels.Answers;
using E_Matura.Models.EntityModels.BaseModels;
using E_Matura.Models.EntityModels.Matura;
using E_Matura.Models.EntityModels.Questions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace E_Matura.Data
{
	using System.Data.Entity;

	public class EMaturaContext : IdentityDbContext<User>
	{
		public EMaturaContext()
			: base("data source=(LocalDb)\\MSSQLLocalDB;initial catalog=E-MaturaContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
		{
			
		}

		public static EMaturaContext Create()
		{
			return new EMaturaContext();
		}

		public override IDbSet<User> Users { get; set; }
		public virtual DbSet<QuestionBase> Questions { get; set; }
        public virtual DbSet<TakenQuestion> TakenQuestions { get; set; }
		public virtual DbSet<ClosedAnswer> ClosedAnswers { get; set; }
		public virtual DbSet<OpenAnswer> OpenAnswers { get; set; }
        public virtual DbSet<MaturaResult> MaturaResults { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<QuestionClosedAnswer>().ToTable("QuestionClosedAnswer");
			modelBuilder.Entity<QuestionOpenAnswer>().ToTable("QuestionOpenAnswer");
			base.OnModelCreating(modelBuilder);
		}
	}
}