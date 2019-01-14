using Base.DomainImpl;

namespace DomainModel.StudentsImpl
{
    public class StudentUpdated : DomainEvent
    {
        public Student Student { get; set; }

        public override void Flatten()
        {
            this.Args.Add("FirstName", this.Student.FirstName);
            this.Args.Add("LastName", this.Student.LastName);
            this.Args.Add("Description", this.Student.Description);
            this.Args.Add("Height", this.Student.Height);
            this.Args.Add("PayRate", this.Student.PayRate);
            this.Args.Add("PrepaidMoney", this.Student.PrepaidMoney);
            this.Args.Add("UpdatedAt", this.Student.UpdatedAt);
            this.Args.Add("IsActive", this.Student.IsActive);
        }
    }
}
