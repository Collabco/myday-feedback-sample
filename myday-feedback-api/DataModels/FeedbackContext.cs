namespace Myday.Feedback.DataModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class FeedbackContext : DbContext
    {
        // Your context has been configured to use a 'FeedbackModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Myday.Feedback.DataModels.FeedbackModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FeedbackModel' 
        // connection string in the application configuration file.
        public FeedbackContext()
            : base("name=FeedbackModel")
        {
        }

        public virtual DbSet<FeedbackResponse> FeedbackResponses { get; set; }

        public virtual DbSet<FeedbackCategory> FeedbackCategories { get; set; }

        public virtual DbSet<FeedbackQuestion> FeedbackQuestions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}