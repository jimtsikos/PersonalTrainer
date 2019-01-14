using System;
using System.Collections.Generic;
using Application.StudentWeights.Dtos;
using DomainModel.Students;
using DomainModel.StudentsImpl;
using DomainModel.StudentWeights;
using DomainModel.StudentWeightsImpl;

namespace Application.StudentWeights.Service
{
    public class StudentWeightsService : IStudentWeightsService
    {
        private readonly IStudentWeight _studentWeight;
        private readonly IStudentWeightRepository _studentWeightRepository;
        private readonly IStudentRepository _studentRepository;

        public StudentWeightsService(IStudentWeight studentWeight, IStudentWeightRepository studentWeightRepository, IStudentRepository studentRepository)
        {
            _studentWeight = studentWeight;
            _studentWeightRepository = studentWeightRepository;
            _studentRepository = studentRepository;
        }

        public StudentWeightDto Get(Guid studentWeightId)
        {
            StudentWeight studentWeight = _studentWeightRepository.FindById(studentWeightId);

            return AutoMapper.Mapper.Map<StudentWeight, StudentWeightDto>(studentWeight);
        }

        public IEnumerable<StudentWeightDto> GetList(Guid studentId)
        {
            Student student = _studentRepository.FindById(studentId);

            IEnumerable<StudentWeight> studentWeights = _studentWeightRepository.FindAll(student);

            return AutoMapper.Mapper.Map<IEnumerable<StudentWeight>, IEnumerable<StudentWeightDto>>(studentWeights);
        }

        public StudentWeightDto Create(StudentWeightDto studentWeightDto)
        {
            StudentWeight studentWeight = _studentWeight.Create(_studentRepository.FindById(studentWeightDto.StudentId), studentWeightDto.Weight);

            _studentWeightRepository.Create(studentWeight);

            return AutoMapper.Mapper.Map<StudentWeight, StudentWeightDto>(studentWeight);
        }

        public void Update(StudentWeightDto studentWeightDto)
        {
            if (studentWeightDto.Id == Guid.Empty)
            {
                throw new Exception("Id can't be empty");
            }

            StudentWeight studentWeight = _studentWeightRepository.FindById(studentWeightDto.Id);

            if (studentWeight == null)
            {
                throw new Exception("No such student weight exists");
            }

            _studentWeightRepository.Update(studentWeight);
        }

        public void Delete(Guid studentWeightId)
        {
            StudentWeight studentWeight = _studentWeightRepository.FindById(studentWeightId);

            if (studentWeight == null)
                throw new Exception("No such student weight exists");

            _studentWeightRepository.Delete(studentWeight);
        }
    }
}
