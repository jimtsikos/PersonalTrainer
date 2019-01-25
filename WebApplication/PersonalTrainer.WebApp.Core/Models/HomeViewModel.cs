using Application.Extensions.Paging;
using Application.Lessons.Dtos;

namespace PersonalTrainer.WebApp.Core.Models
{
    public class HomeViewModel
    {
        public int TotalTrainers { get; set; }
        public int TotalStudents { get; set; }
        public int TotalLessons { get; set; }
        public PaginatedList<LessonDto> YesterdayLessons { get; set; }
        public PaginatedList<LessonDto> TodayLessons { get; set; }
    }
}
