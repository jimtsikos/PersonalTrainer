using Base.SpecificationImpl;
using System;
using System.Linq.Expressions;

namespace DomainModel.StudentWeightsImpl
{
    public class StudentWeightRegisteredSpec : SpecificationBase<StudentWeight>
    {
        private readonly Guid _id;

        public StudentWeightRegisteredSpec(Guid id)
        {
            _id = id;
        }

        public override Expression<Func<StudentWeight, bool>> SpecExpression
        {
            get
            {
                return studentWeight => studentWeight.Id == _id;
            }
        }
    }
}
