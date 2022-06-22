using System;
using System.Collections.Generic;
using System.Linq;
using University.Data.IRepositories;
using University.Data.Repositories;
using University.Domain.Entities;
using University.Service.DTOs;
using University.Service.Extentions;
using University.Service.Interfaces;

namespace University.Service.Services
{

    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService()
        {
            _teacherRepository = new TeacherRepository();
        }

        public TeacherViewModel Create(TeacherForCreationDto entity)
        {
            var res = _teacherRepository.Create(entity.ConvertTo());

            if (res is null)
                throw new Exception("Student was not created");

            return res.ConvertTo();
        }

        public bool Delete(int id)
            => _teacherRepository.Delete(id);

        public TeacherViewModel Get(Func<Teacher, bool> predicate)
            => _teacherRepository.Get(predicate).ConvertTo();

        public IEnumerable<TeacherViewModel> GetAll(Func<Teacher, bool> predicate = null)
            => _teacherRepository.GetAll(predicate).Select(x => x.ConvertTo());

        public TeacherViewModel Update(int id, TeacherForCreationDto entity)
        {
            var res = entity.ConvertTo();
            res.CreatedAt = _teacherRepository.Get(p => p.Id == id).CreatedAt;
            res.Id = id;

            return _teacherRepository.Update(res).ConvertTo();
        }
    }
}
