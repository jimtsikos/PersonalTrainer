using Base.SpecificationImpl;
using System;
using System.Linq.Expressions;

namespace DomainModel.TrainersImpl
{
    public class TrainerRegisteredSpec : SpecificationBase<Trainer>
    {
        private readonly Guid _id;

        public TrainerRegisteredSpec(Guid id)
        {
            _id = id;
        }

        public override Expression<Func<Trainer, bool>> SpecExpression
        {
            get
            {
                return trainer => trainer.Id == _id;
            }
        }
    }
}
