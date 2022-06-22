using University.Domain.Entities;
using University.Service.DTOs;

namespace University.Service.Extentions
{
    public static class Converter
    {
        public static Student ConvertTo(this StudentForCreationDto studentFor)
        {
            return new Student
            {
                FirstName = studentFor.FirstName,
                LastName = studentFor.LastName,
                Email = studentFor.Email,
                Age = studentFor.Age,
                Course = studentFor.Course,
                Faculty = studentFor.Faculty,
            };
        }

        public static StudentViewModel ConvertTo(this Student studentFor)
        {
            return new StudentViewModel
            {
                Id = studentFor.Id,
                FirstName = studentFor.FirstName,
                LastName = studentFor.LastName,
                Email = studentFor.Email,
                Age = studentFor.Age,
                Course = studentFor.Course,
                Faculty = studentFor.Faculty,
            };

        }

        public static Teacher ConvertTo(this TeacherForCreationDto teacherFor)
        {
            return new Teacher
            {
                FirstName = teacherFor.FirstName,
                LastName = teacherFor.LastName,
                Email = teacherFor.Email,
                Age = teacherFor.Age,
                Phone = teacherFor.Phone,
            };
        }

        public static TeacherViewModel ConvertTo(this Teacher teacherFor)
        {
            return new TeacherViewModel
            {
                Id = teacherFor.Id,
                FirstName = teacherFor.FirstName,
                LastName = teacherFor.LastName,
                Email = teacherFor.Email,
                Age = teacherFor.Age,
                Phone = teacherFor.Phone,
            };
        }


    }
}