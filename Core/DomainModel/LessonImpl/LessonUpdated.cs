using Base.DomainImpl;

namespace DomainModel.LessonImpl
{
    public class LessonUpdated : DomainEvent
    {
        public Lesson Lesson { get; set; }

        public override void Flatten()
        {
            this.Args.Add("Student", this.Lesson.Student);
            this.Args.Add("Trainer", this.Lesson.Trainer);
            this.Args.Add("DateTime", this.Lesson.DateTime);
            this.Args.Add("Hour", this.Lesson.Hour);
            this.Args.Add("Minutes", this.Lesson.Minutes);
            this.Args.Add("IsActive", this.Lesson.IsActive);
            this.Args.Add("IsPaid", this.Lesson.IsPaid);
            this.Args.Add("UpdatedAt", this.Lesson.UpdatedAt);
        }
    }
}
