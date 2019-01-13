﻿using System;

namespace Application.Trainers.Dtos
{
    public class TrainerDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public double PayRate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        //public ICollection<Lesson> Lessons { get; set; }
    }
}
