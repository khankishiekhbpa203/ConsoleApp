using Domain.Entities;
using Repository.Exceptions;
using Repository.Repositories.Implimentations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private StudentRepository _studentRepository;
        private int _count = 1;
        public StudentService()
        {
            _studentRepository= new StudentRepository();
        }
        public Student Create(Student student)
        {
            student.Id=_count;

            _studentRepository.Create(student);

            _count++;

            return student;
        }
        public void Delete(int id)
        {
            Student student = GetById(id);

            _studentRepository.Delete(student);

        }
        public Student GetById(int id)
        {
            Student student = _studentRepository.Get(s => s.Id == id);
            return student;
        }
        public Student Update(int id, Student student)
        {
            Student dbstudent = GetById(id);

            if (dbstudent is null) return null;

            student.Id = id;

            _studentRepository.Update(student);

            return GetById(id);

        }
        public List<Student> GetStudentByAge(int age)
        {
            List<Student> student = _studentRepository.GetStudentByAge(s => s.Age == age);
            return student;
        }
        public List<Student> GetAll(Predicate<Student> predicate)
        {
            return _studentRepository.GetAll(predicate);
        }
        public List<Student> Search(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Search text cannot be empty");

            var students = _studentRepository.GetAll(s => (s.Name != null && s.Name.ToLower().Contains(text.ToLower())) ||   (s.Surname != null && s.Surname.ToLower().Contains(text.ToLower())));

            if (students == null || students.Count == 0)
                throw new NotFoundException($"No students found matching this  {text}.");

            return students;
        }



    }
}
