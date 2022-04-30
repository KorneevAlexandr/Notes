using System;
using System.Linq;
using System.Linq.Expressions;

namespace Notes.DataAccess.Interfaces.Repositories
{
	public interface IRepository<T>
	{
		IQueryable<T> GetAll();

		T Get(int id);

		IQueryable<T> Get(Expression<Func<T, bool>> predicate);

		int Count();

		void Create(T entity);

		void Update(T entity);

		void Delete(int id);
	}
}
