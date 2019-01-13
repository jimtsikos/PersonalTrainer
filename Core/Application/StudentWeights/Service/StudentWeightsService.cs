using System;
using Application.StudentWeights.Dtos;
using Base.Repository;
using Base.Specification;
using DomainModel.StudentWeights;
using DomainModel.StudentWeightsImpl;

namespace Application.StudentWeights.Service
{
    public class StudentWeightsService : IStudentWeightsService
    {
        private readonly IStudentWeight _studentWeight;
        private readonly IStudentWeightRepository _studentWeightRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentWeightsService(IStudentWeight studentWeight, IStudentWeightRepository studentWeightRepository, IUnitOfWork unitOfWork)
        {
            _studentWeight = studentWeight;
            _studentWeightRepository = studentWeightRepository;
            _unitOfWork = unitOfWork;
        }

        public StudentWeightDto Get(Guid studentWeightId)
        {
            ISpecification<StudentWeight> registeredSpec = new StudentWeightRegisteredSpec(studentWeightId);

            StudentWeight studentWeight = _studentWeightRepository.FindOne(registeredSpec);

            return AutoMapper.Mapper.Map<StudentWeight, StudentWeightDto>(studentWeight);
        }

        public StudentWeightDto Create(StudentWeightDto studentWeightDto)
        {
            StudentWeight studentWeight = _studentWeight.Create(studentWeightDto.StudentId, studentWeightDto.Weight);

            _studentWeightRepository.Create(studentWeight);
            _unitOfWork.Commit();

            return AutoMapper.Mapper.Map<StudentWeight, StudentWeightDto>(studentWeight);
        }

        public void Update(StudentWeightDto studentWeightDto)
        {
            if (studentWeightDto.Id == Guid.Empty)
            {
                throw new Exception("Id can't be empty");
            }

            ISpecification<StudentWeight> registeredSpec = new StudentWeightRegisteredSpec(studentWeightDto.Id);

            StudentWeight studentWeight = _studentWeightRepository.FindOne(registeredSpec);

            if (studentWeight == null)
            {
                throw new Exception("No such student weight exists");
            }

            _studentWeightRepository.Update(studentWeight);
            _unitOfWork.Commit();
        }

        public void Delete(Guid studentWeightId)
        {
            ISpecification<StudentWeight> registeredSpec = new StudentWeightRegisteredSpec(studentWeightId);

            StudentWeight studentWeight = _studentWeightRepository.FindOne(registeredSpec);

            if (studentWeight == null)
                throw new Exception("No such student weight exists");

            _studentWeightRepository.Delete(studentWeight);
            _unitOfWork.Commit();
        }
    }
}
