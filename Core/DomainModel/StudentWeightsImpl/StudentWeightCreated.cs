using Base.DomainImpl;

namespace DomainModel.StudentWeightsImpl
{
    public class StudentWeightCreated : DomainEvent
    {
        public StudentWeight StudentWeight { get; set; }

        public override void Flatten()
        {
            this.Args.Add("StudentId", this.StudentWeight.StudentId);
            this.Args.Add("Weight", this.StudentWeight.Weight);
            this.Args.Add("CreatedAt", this.StudentWeight.CreatedAt);
            this.Args.Add("UpdatedAt", this.StudentWeight.UpdatedAt);
        }
    }
}
