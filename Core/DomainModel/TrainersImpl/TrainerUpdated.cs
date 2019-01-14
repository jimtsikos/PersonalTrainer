using Base.DomainImpl;

namespace DomainModel.TrainersImpl
{
    public class TrainerUpdated : DomainEvent
    {
        public Trainer Trainer { get; set; }

        public override void Flatten()
        {
            this.Args.Add("FirstName", this.Trainer.FirstName);
            this.Args.Add("LastName", this.Trainer.LastName);
            this.Args.Add("Description", this.Trainer.Description);
            this.Args.Add("PayRate", this.Trainer.PayRate);
            this.Args.Add("UpdatedAt", this.Trainer.UpdatedAt);
            this.Args.Add("IsActive", this.Trainer.IsActive);
        }
    }
}
