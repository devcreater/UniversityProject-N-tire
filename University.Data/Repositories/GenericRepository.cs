using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using University.Data.Configurations;
using University.Data.IRepositories;
using University.Domain.Entities;

namespace University.Data.Repositories
{
    public abstract class GenericRepository<TSourse> : IGenericRepository<TSourse> where TSourse : Auditable
    {
        protected abstract string Path { get; }
        protected abstract int LastId { get; set; }


        public TSourse Create(TSourse entity)
        {
            entity.Id = ++LastId;
            entity.CreatedAt = DateTime.Now;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Append(entity)));
            Save();

            return entity;
        }

        public bool Delete(int id)
        {
            if (Get(x => x.Id == id) is null)
                return false;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Where(x => x.Id != id)));
            return true;
        }

        public TSourse Get(Func<TSourse, bool> predicate)
            => GetAll().FirstOrDefault(predicate);

        public IEnumerable<TSourse> GetAll(Func<TSourse, bool> predicate = null)
        {
            if (!File.Exists(Path))
                File.WriteAllText(Path, "[]");

            string json = File.ReadAllText(Path);

            if (string.IsNullOrEmpty(json))
            {
                File.WriteAllText(Path, "[]");
                json = "[]";
            }
            if (predicate is null)
                return JsonConvert.DeserializeObject<IEnumerable<TSourse>>(json);
            else
                return JsonConvert.DeserializeObject<IEnumerable<TSourse>>(json).Where(predicate);

        }

        public TSourse Update(TSourse entity)
        {
            entity.UpdatedAt = DateTime.Now;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Select(p => p.Id == entity.Id ? entity : p)));

            return entity;
        }

        protected abstract void Save();

        protected dynamic ReadAppSettings()
        {
            return JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.APP_SETTINGS_PATH));
        }
    }
}
