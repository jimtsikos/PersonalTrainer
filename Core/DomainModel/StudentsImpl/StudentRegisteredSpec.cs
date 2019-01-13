using Base.SpecificationImpl;
using System;
using System.Linq.Expressions;

namespace DomainModel.StudentsImpl
{
    public class StudentRegisteredSpec : SpecificationBase<Student>
    {
        private readonly Guid _id;

        public StudentRegisteredSpec(Guid id)
        {
            _id = id;
        }

        public override Expression<Func<Student, bool>> SpecExpression
        {
            get
            {
                return trainer => trainer.Id == _id;
            }
        }
    }
}
