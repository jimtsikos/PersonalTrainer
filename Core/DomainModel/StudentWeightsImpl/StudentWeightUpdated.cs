using Base.DomainImpl;

namespace DomainModel.StudentWeightsImpl
{
    public class StudentWeightUpdated : DomainEvent
    {
        public StudentWeight StudentWeight { get; set; }

        public override void Flatten()
        {
            this.Args.Add("Student", this.StudentWeight.Student);
            this.Args.Add("Weight", this.StudentWeight.Weight);
            this.Args.Add("UpdatedAt", this.StudentWeight.UpdatedAt);
        }
    }
}
