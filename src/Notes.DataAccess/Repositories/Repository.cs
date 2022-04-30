using Microsoft.EntityFrameworkCore;
using Notes.DataAccess.Data;
using Notes.DataAccess.Interfaces.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Notes.DataAccess.Repositories
{
	public class Repository<T> : IRepository<T>
		where T : class
	{
		private readonly NoteDbContext _context;
		private readonly DbSet<T> _dbSet;

		public Repository(NoteDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public IQueryable<T> GetAll()
		{
			return _dbSet.AsQueryable();
		}

		public T Get(int id)
		{
			return _dbSet.Find(id);
		}

		public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
		{
			return _dbSet.Where(predicate);
		}

		public int Count()
		{
			return _dbSet.Count();
		}

		public void Create(T entity)
		{
			_dbSet.Add(entity);
			SaveChanges();
		}

		public void Delete(int id)
		{
			T item = Get(id);
			_dbSet.Remove(item);
			SaveChanges();
		}

		public void Update(T entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			SaveChanges();
		}

		private void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
