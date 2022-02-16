using Microsoft.EntityFrameworkCore;

namespace lab5FAQ.Models
{
    public class FaqContext : DbContext
    {
        public FaqContext(DbContextOptions<FaqContext> options) : base(options){  }

        public DbSet<FAQ> FAQs { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = "js", TopicName = "JavaScript" },
                new Topic { TopicId = "boot", TopicName = "BootStrap" },
                new Topic { TopicId = "c#", TopicName = "C#" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "gen", CategoryName = "General" },
                new Category { CategoryId = "hist", CategoryName = "History" }
                );

            modelBuilder.Entity<FAQ>().HasData(
                new FAQ 
                { 
                    Id = 1, 
                    Question = "What is BootStrap?",
                    Answer = "A css framework for creating responsive web apps for multiple screens.",
                    CategoryId = "gen",
                    TopicId = "boot"
                },
                new FAQ
                {
                    Id = 2,
                    Question = "What is C#?",
                    Answer = "A general purpose object-oriented language that uses a concise, Java-like syntax",
                    CategoryId = "gen",
                    TopicId = "c#"
                },
                new FAQ
                {
                    Id = 3,
                    Question = "What is JavaScript?",
                    Answer = "A general purpose scripting language that executes in a browser",
                    CategoryId = "gen",
                    TopicId = "js"
                },
                new FAQ
                {
                    Id = 4,
                    Question = "Why is JavaScript?",
                    Answer = "For things.",
                    CategoryId = "hist",
                    TopicId = "js"
                },
                new FAQ
                {
                    Id = 5,
                    Question = "Who is BootStrap?",
                    Answer = "Bootstrap is your friend.",
                    CategoryId = "hist",
                    TopicId = "boot"
                }
                );
        }
    }
}
