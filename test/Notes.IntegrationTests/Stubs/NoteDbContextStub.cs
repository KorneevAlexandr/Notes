using Microsoft.EntityFrameworkCore;
using Notes.DataAccess.Models;

namespace Notes.IntegrationTests.Stubs
{
    public class NoteDbContextStub : DbContext
    {
        private readonly string _connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog = NotesDatabase; Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";

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
