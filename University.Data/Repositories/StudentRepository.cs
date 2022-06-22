using Newtonsoft.Json;
using System.IO;
using University.Data.Configurations;
using University.Data.IRepositories;
using University.Domain.Entities;

namespace University.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        protected override string Path { get; }

        protected override int LastId { get; set; }

        public StudentRepository()
        {
            var res = ReadAppSettings();
            Path = res.Database.Students.Path;
            LastId = res.Database.Students.LastId;
        }

        protected override void Save()
        {
            var res = ReadAppSettings();
            res.Database.Students.LastId = LastId;

            File.WriteAllText(Constants.APP_SETTINGS_PATH, JsonConvert.SerializeObject(res));
        }
    }
}
