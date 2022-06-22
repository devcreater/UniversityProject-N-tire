using System;
using System.Collections.Generic;
using University.Domain.Entities;

namespace University.Data.IRepositories
{
    public interface IGenericRepository<TSourse> where TSourse : Auditable
    {
        public IEnumerable<TSourse> GetAll(Func<TSourse, bool> predicate = null);

        public TSourse Create(TSourse entity);

        public bool Delete(int id);

        public TSourse Update(TSourse entity);

        public TSourse Get(Func<TSourse, bool> predicate);

    }
}
