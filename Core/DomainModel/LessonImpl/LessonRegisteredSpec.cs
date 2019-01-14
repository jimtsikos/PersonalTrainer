using Base.SpecificationImpl;
using System;
using System.Linq.Expressions;

namespace DomainModel.LessonImpl
{
    public class LessonRegisteredSpec : SpecificationBase<Lesson>
    {
        private readonly Guid _id;

        public LessonRegisteredSpec(Guid id)
        {
            _id = id;
        }

        public override Expression<Func<Lesson, bool>> SpecExpression
        {
            get
            {
                return lesson => lesson.Id == _id;
            }
        }
    }
}
