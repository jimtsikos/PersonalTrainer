using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Lessons.Dtos
{
    public class LessonDto
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public string StudentName { get; set; }

        public double Money { get; set; }

        public Guid TrainerId { get; set; }

        public string TrainerName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateTime { get; set; }

        public int Hour { get; set; }

        public string HourDescription { get; set; }

        public int Minutes { get; set; }

        public string MinutesDescription { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
