﻿namespace CarHireDataAccess.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using CarHireDataAccess.Models.Vehicles;

    public class Repo<T>  where T : class
    {
        public CarHireContext Context { get; set; }
        public DbSet<T> Dataset { get; set; }

        public void Repository(CarHireContext context)
        {
            this.Context = context;
            this.Dataset = context.Set<T>();
        }

        public void Insert(T entity)
        {
            this.Dataset.Add(entity);
            this.Context.SaveChanges();
        }

        public void Delete(T entity) => this.Dataset.Remove(entity);

        public void SaveChanges() => this.Context.SaveChanges();

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate) => this.Dataset.Where(predicate);

        public IQueryable<T> Get() => this.Dataset;

    }
}