using System;
using Application.Students.Dtos;
using Base.Repository;
using Base.Specification;
using DomainModel.Students;
using DomainModel.StudentsImpl;

namespace Application.Students.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudent _student;
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IStudent student, IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _student = student;
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public StudentDto Get(Guid studentId)
        {
            ISpecification<Student> registeredSpec = new StudentRegisteredSpec(studentId);

            Student student = _studentRepository.FindOne(registeredSpec);

            return AutoMapper.Mapper.Map<Student, StudentDto>(student);
        }

        public StudentDto Create(StudentDto studentDto)
        {
            Student student = _student.Create(studentDto.FirstName, studentDto.LastName, studentDto.Description, studentDto.Height, studentDto.PayRate, studentDto.PrepaidMoney, studentDto.IsActive);

            _studentRepository.Create(student);
            _unitOfWork.Commit();

            return AutoMapper.Mapper.Map<Student, StudentDto>(student);
        }

        public void Update(StudentDto studentDto)
        {
            if (studentDto.Id == Guid.Empty)
            {
                throw new Exception("Id can't be empty");
            }

            ISpecification<Student> registeredSpec = new StudentRegisteredSpec(studentDto.Id);

            Student student = _studentRepository.FindOne(registeredSpec);

            if (student == null)
            {
                throw new Exception("No such student exists");
            }

            _studentRepository.Update(student);
            _unitOfWork.Commit();
        }

        public void Delete(Guid studentId)
        {
            ISpecification<Student> registeredSpec = new StudentRegisteredSpec(studentId);

            Student student = _studentRepository.FindOne(registeredSpec);

            if (student == null)
                throw new Exception("No such student exists");

            _studentRepository.Delete(student);
            _unitOfWork.Commit();
        }
    }
}
