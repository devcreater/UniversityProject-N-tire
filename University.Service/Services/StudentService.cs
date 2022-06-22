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

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public StudentViewModel Create(StudentForCreationDto entity)
        {
            var res = _studentRepository.Create(entity.ConvertTo());

            if (res is null)
                throw new Exception("Student was not created");

            return res.ConvertTo();

        }

        public bool Delete(int id)
            => _studentRepository.Delete(id);

        public StudentViewModel Get(Func<Student, bool> predicate)
            => _studentRepository.Get(predicate).ConvertTo();

        public IEnumerable<StudentViewModel> GetAll(Func<Student, bool> predicate = null)
            => _studentRepository.GetAll(predicate).Select(x => x.ConvertTo());

        public StudentViewModel Update(int id, StudentForCreationDto entity)
        {
            var res = entity.ConvertTo();
            res.CreatedAt = _studentRepository.Get(p => p.Id == id).CreatedAt;
            res.Id = id;

            return _studentRepository.Update(res).ConvertTo();
        }
    }
}
