using Microsoft.EntityFrameworkCore;
using Notes.DataAccess.Models;

namespace Notes.IntegrationTests.Stubs
{
    public class NoteDbContextStub : DbContext
    {
        private readonly string _connectionString = "server=localhost,1433;Database=NotesGit;User ID=kura;Password=W~08irasa";

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
