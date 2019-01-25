using System;
using System.Collections.Generic;
using Application.Extensions.Paging;
using Application.Handlers;
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

        public ResultHandler<StudentWeightDto> Get(Guid studentWeightId)
        {
            ResultHandler<StudentWeightDto> resultHandler = new ResultHandler<StudentWeightDto>();

            try
            {
                StudentWeight studentWeight = _studentWeightRepository.FindOne(studentWeightId);
                resultHandler.Data = AutoMapper.Mapper.Map<StudentWeight, StudentWeightDto>(studentWeight);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<PaginatedList<StudentWeightDto>> GetList()
        {
            ResultHandler<PaginatedList<StudentWeightDto>> resultHandler = new ResultHandler<PaginatedList<StudentWeightDto>>();

            try
            {
                IEnumerable<StudentWeight> studentWeights = _studentWeightRepository.FindAll();
                resultHandler.Data = AutoMapper.Mapper.Map<IEnumerable<StudentWeight>, PaginatedList<StudentWeightDto>>(studentWeights);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<PaginatedList<StudentWeightDto>> GetList(Guid studentId)
        {
            ResultHandler<PaginatedList<StudentWeightDto>> resultHandler = new ResultHandler<PaginatedList<StudentWeightDto>>();

            try
            {
                Student student = _studentRepository.FindOne(studentId);
                if (student == null)
                {
                    throw new Exception("No such student exists");
                }

                IEnumerable<StudentWeight> studentWeights = _studentWeightRepository.FindAll(student);
                resultHandler.Data = AutoMapper.Mapper.Map<IEnumerable<StudentWeight>, PaginatedList<StudentWeightDto>>(studentWeights);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<StudentWeightDto> Create(StudentWeightDto studentWeightDto)
        {
            ResultHandler<StudentWeightDto> resultHandler = new ResultHandler<StudentWeightDto>();

            try
            {
                StudentWeight studentWeight = _studentWeight.Create(_studentRepository.FindOne(studentWeightDto.StudentId), studentWeightDto.Weight);
                _studentWeightRepository.Create(studentWeight);
                resultHandler.Data = AutoMapper.Mapper.Map<StudentWeight, StudentWeightDto>(studentWeight);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<StudentWeightDto> Update(StudentWeightDto studentWeightDto)
        {
            ResultHandler<StudentWeightDto> resultHandler = new ResultHandler<StudentWeightDto>();

            try
            {
                if (studentWeightDto.Id == Guid.Empty)
                {
                    resultHandler.Errors.Add("Student weight id can't be empty");
                    return resultHandler;
                }

                StudentWeight studentWeight = _studentWeightRepository.FindOne(studentWeightDto.Id);
                Student student = _studentRepository.FindOne(studentWeightDto.StudentId);

                if (studentWeight == null)
                {
                    resultHandler.Errors.Add("No such student weight exists");
                    return resultHandler;
                }

                if (student == null)
                {
                    resultHandler.Errors.Add("No such student exists");
                    return resultHandler;
                }

                studentWeight = _studentWeight.Update(studentWeight, student, studentWeightDto.Weight);
                _studentWeightRepository.Update(studentWeight);
                resultHandler.Data = AutoMapper.Mapper.Map<StudentWeight, StudentWeightDto>(studentWeight);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<StudentWeightDto> Delete(Guid studentWeightId)
        {
            ResultHandler<StudentWeightDto> resultHandler = new ResultHandler<StudentWeightDto>();

            try
            {
                StudentWeight studentWeight = _studentWeightRepository.FindOne(studentWeightId);
                if (studentWeight == null)
                {
                    resultHandler.Errors.Add("No such student weight exists");
                }

                _studentWeightRepository.Delete(studentWeight);

                resultHandler.Data = AutoMapper.Mapper.Map<StudentWeight, StudentWeightDto>(studentWeight);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }
    }
}
