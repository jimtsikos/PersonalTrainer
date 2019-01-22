using System;

namespace Application.Lessons.Dtos
{
    public class LessonDto
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public Guid TrainerId { get; set; }

        public DateTime DateTime { get; set; }

        public int Hour { get; set; }

        public int Minutes { get; set; }

        public bool IsActive { get; set; }

        public bool IsPaid { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
