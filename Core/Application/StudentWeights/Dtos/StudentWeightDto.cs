using Application.Students.Dtos;
using System;

namespace Application.StudentWeights.Dtos
{
    public class StudentWeightDto
    {
        public Guid Id { get; set; }
        
        public Guid StudentId { get; set; }

        public string StudentName { get; set; }

        public double Weight { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
