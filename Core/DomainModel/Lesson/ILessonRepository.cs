using Base.Repository;

namespace DomainModel.Lesson
{
    public interface ILessonRepository : IRepository<LessonImpl.Lesson>
    {
    }
}
