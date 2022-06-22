using System;
using System.Collections.Generic;
using University.Domain.Entities;
using University.Service.DTOs;

namespace University.Service.Interfaces
{
    public interface IStudentService
    {
        public IEnumerable<StudentViewModel> GetAll(Func<Student, bool> predicate = null);

        public StudentViewModel Create(StudentForCreationDto entity);

        public bool Delete(int id);

        public StudentViewModel Update(int id, StudentForCreationDto entity);

        public StudentViewModel Get(Func<Student, bool> predicate);
    }
}
