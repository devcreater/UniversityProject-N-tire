using System;
using System.Collections.Generic;
using University.Domain.Entities;
using University.Service.DTOs;

namespace University.Service.Interfaces
{
    public interface ITeacherService
    {
        public IEnumerable<TeacherViewModel> GetAll(Func<Teacher, bool> predicate = null);

        public TeacherViewModel Create(TeacherForCreationDto entity);

        public bool Delete(int id);

        public TeacherViewModel Update(int id, TeacherForCreationDto entity);

        public TeacherViewModel Get(Func<Teacher, bool> predicate);
    }
}
