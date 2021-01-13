using Microsoft.EntityFrameworkCore;

namespace QuizTime.Api.Rest
{
    public class QuizTimeDbContext : DbContext
    {
        public DbSet<QuizTime.Shared.Data.QuizItemDto> QuizItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("QuizTime");
        }
    }
}