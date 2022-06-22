using Newtonsoft.Json;
using System.IO;
using University.Data.Configurations;
using University.Data.IRepositories;
using University.Domain.Entities;

namespace University.Data.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        protected override string Path { get; }

        protected override int LastId { get; set; }

        public TeacherRepository()
        {
            var res = ReadAppSettings();
            Path = res.Database.Teachers.Path;
            LastId = res.Database.Teachers.LastId;
        }

        protected override void Save()
        {
            var res = ReadAppSettings();
            res.Database.Teachers.LastId = LastId;

            File.WriteAllText(Constants.APP_SETTINGS_PATH, JsonConvert.SerializeObject(res));
        }
    }
}
