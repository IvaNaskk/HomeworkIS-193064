using System;
using HomeworkIS_193064.Domain.Domainmodels;

namespace HomeworkIS_193064.Repository.Interface
{
	public interface IRepository<T> where T: BaseEntity
	{
		IEnumerable<T> GetAll();

		T Get(int id);

		void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}

