using Notes.DataAccess.Interfaces.Repositories;
using Notes.DataAccess.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Notes.IntegrationTests.Stubs
{
	public class NoteRepositoryStub : IRepository<Note>
	{
		private readonly NoteDbContextStub _context;

		public NoteRepositoryStub()
		{
			_context = new NoteDbContextStub();
		}

		public int Count()
		{
			throw new NotImplementedException();
		}

		public void Create(Note entity)
		{
			_context.Notes.Add(entity);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			_context.Notes.Remove(Get(id));
			_context.SaveChanges();
		}

		public Note Get(int id)
		{
			return _context.Notes.Find(id);
		}

		public IQueryable<Note> Get(Expression<Func<Note, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public IQueryable<Note> GetAll()
		{
			return _context.Notes.AsQueryable();
		}

		public void Update(Note entity)
		{
			throw new NotImplementedException();
		}
	}
}
