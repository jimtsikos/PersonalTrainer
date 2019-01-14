using Application.Lessons.Dtos;
using Application.StudentWeights.Dtos;
using System;
using System.Collections.Generic;

namespace Application.Students.Dtos
{
    public class StudentDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public double Height { get; set; }

        public double PayRate { get; set; }

        public double PrepaidMoney { get; set; }

        public bool IsActive { get; set; }

        public ICollection<StudentWeightDto> StudentWeights { get; set; }

        public ICollection<LessonDto> Lessons { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
