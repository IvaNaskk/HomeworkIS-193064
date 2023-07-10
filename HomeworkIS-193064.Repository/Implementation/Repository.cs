using System;
using HomeworkIS_193064.Domain.Domainmodels;
using HomeworkIS_193064.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HomeworkIS_193064.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(z => z.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }
            entities.Update(entity);
        }
    }
}

