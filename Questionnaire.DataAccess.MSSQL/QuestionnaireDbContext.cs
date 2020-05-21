using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Questionnaire.Common.Entities;

namespace Questionnaire.DataAccess.MSSQL
{
    public class QuestionnaireDbContext : DbContext
    {
        public QuestionnaireDbContext() : base("QuestionnaireConnection")
        {
        }

        public DbSet<Questionnaires> Questionnaires { get; set; }
        public DbSet<FormSetting> FormSettings { get; set; }
        public DbSet<LogQuestionnaire> LogQuestionnaires { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}