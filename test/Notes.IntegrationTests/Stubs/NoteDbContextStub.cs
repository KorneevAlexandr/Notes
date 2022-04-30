using Microsoft.EntityFrameworkCore;
using Notes.DataAccess.Models;

namespace Notes.IntegrationTests.Stubs
{
    public class NoteDbContextStub : DbContext
    {
        private readonly string _connectionString = "Data Source=localhost; Initial Catalog = NotesGit; Integrated Security=False;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";

        public NoteDbContextStub()
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public DbSet<Note> Notes { get; set; }
    }
}
