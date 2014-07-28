namespace DAL
{
    using DAL.Models;
    using System.Data.Entity;

    /// <summary>
    /// TeaDb context
    /// </summary>
    public class TeaContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeaContext"/> class.
        /// </summary>
        public TeaContext()
            : base("TeaDb")
        {
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasRequired(a => a.RightStory)
                .WithMany()
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Gets or sets the answers.
        /// </summary>
        /// <value>
        /// The answers.
        /// </value>
        public DbSet<Answer> Answers { get; set; }

        /// <summary>
        /// Gets or sets the stories.
        /// </summary>
        /// <value>
        /// The stories.
        /// </value>
        public DbSet<Story> Stories { get; set; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        public DbSet<Result> Results { get; set; }

        /// <summary>
        /// Gets or sets the polls.
        /// </summary>
        /// <value>
        /// The polls.
        /// </value>
        public DbSet<Poll> Polls { get; set; }
    }
}