using System;
using System.Collections.Generic;
using Application.Students.Dtos;
using DomainModel.Students;
using DomainModel.StudentsImpl;

namespace Application.Students.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudent _student;
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudent student, IStudentRepository studentRepository)
        {
            _student = student;
            _studentRepository = studentRepository;
        }

        public StudentDto Get(Guid studentId)
        {
            Student student = _studentRepository.FindById(studentId);

            return AutoMapper.Mapper.Map<Student, StudentDto>(student);
        }

        public IEnumerable<StudentDto> GetList()
        {
            IEnumerable<Student> students = _studentRepository.FindAll();

            return AutoMapper.Mapper.Map<IEnumerable<Student>, IEnumerable<StudentDto>>(students);
        }

        public StudentDto Create(StudentDto studentDto)
        {
            Student student = _student.Create(studentDto.FirstName, studentDto.LastName, studentDto.Description, studentDto.Height, studentDto.PayRate, studentDto.PrepaidMoney, studentDto.IsActive);

            _studentRepository.Create(student);

            return AutoMapper.Mapper.Map<Student, StudentDto>(student);
        }

        public void Update(StudentDto studentDto)
        {
            if (studentDto.Id == Guid.Empty)
            {
                throw new Exception("Id can't be empty");
            }

            Student student = _studentRepository.FindById(studentDto.Id);

            if (student == null)
            {
                throw new Exception("No such student exists");
            }

            _studentRepository.Update(student);
        }

        public void Delete(Guid studentId)
        {
            Student student = _studentRepository.FindById(studentId);

            if (student == null)
                throw new Exception("No such student exists");

            _studentRepository.Delete(student);
        }
    }
}
