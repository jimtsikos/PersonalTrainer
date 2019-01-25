using System;
using System.Collections.Generic;
using Application.Extensions.Paging;
using Application.Handlers;
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

        public ResultHandler<StudentDto> Get(Guid studentId)
        {
            ResultHandler<StudentDto> resultHandler = new ResultHandler<StudentDto>();

            try
            {
                Student student = _studentRepository.FindOne(studentId);
                resultHandler.Data = AutoMapper.Mapper.Map<Student, StudentDto>(student);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<PaginatedList<StudentDto>> GetList()
        {
            ResultHandler<PaginatedList<StudentDto>> resultHandler = new ResultHandler<PaginatedList<StudentDto>>();

            try
            {
                IEnumerable<Student> students = _studentRepository.FindAll();
                resultHandler.Data = AutoMapper.Mapper.Map<IEnumerable<Student>, PaginatedList<StudentDto>>(students);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<PaginatedList<StudentDto>> GetList(string name)
        {
            ResultHandler<PaginatedList<StudentDto>> resultHandler = new ResultHandler<PaginatedList<StudentDto>>();

            try
            {
                IEnumerable<Student> students = _studentRepository.FindByName(name);
                resultHandler.Data = AutoMapper.Mapper.Map<IEnumerable<Student>, PaginatedList<StudentDto>>(students);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<StudentDto> Create(StudentDto studentDto)
        {
            ResultHandler<StudentDto> resultHandler = new ResultHandler<StudentDto>();

            try
            {
                Student student = _student.Create(studentDto.FirstName, studentDto.LastName, studentDto.Description, studentDto.Height, studentDto.PayRate, studentDto.PrepaidMoney, studentDto.IsActive);
                _studentRepository.Create(student);
                resultHandler.Data = AutoMapper.Mapper.Map<Student, StudentDto>(student);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<StudentDto> Update(StudentDto studentDto)
        {
            ResultHandler<StudentDto> resultHandler = new ResultHandler<StudentDto>();

            if (studentDto.Id == Guid.Empty)
            {
                resultHandler.Errors.Add("Student id can't be empty");
                return resultHandler;
            }

            try
            {
                Student student = _studentRepository.FindOne(studentDto.Id);

                if (student == null)
                {
                    resultHandler.Errors.Add("No such student exists");
                    return resultHandler;
                }

                student = _student.Update(student, studentDto.FirstName, studentDto.LastName, studentDto.Description, studentDto.Height, studentDto.PayRate, studentDto.PrepaidMoney, studentDto.IsActive);
                _studentRepository.Update(student);

                resultHandler.Data = AutoMapper.Mapper.Map<Student, StudentDto>(student);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<StudentDto> Delete(Guid studentId)
        {
            ResultHandler<StudentDto> resultHandler = new ResultHandler<StudentDto>();

            try
            {
                Student student = _studentRepository.FindOne(studentId);

                if (student == null)
                {
                    resultHandler.Errors.Add("No such student exists");
                    return resultHandler;
                }

                _studentRepository.Delete(student);

                resultHandler.Data = AutoMapper.Mapper.Map<Student, StudentDto>(student);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }
    }
}
