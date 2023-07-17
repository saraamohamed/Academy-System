using AcademyWebAppAPI.DataTransferObjectsManagers.CourseDtosManager.CourseDtos;
using AcademyWebAppAPI.Models;
using AcademyWebAppAPI.Repositories.Course;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.CourseDtosManager
{
    public class CourseDtosManager : ICourseDtosManager
    {
        private readonly ICourseRepository courseRepository;

        public CourseDtosManager(ICourseRepository courseRepository)
            => this.courseRepository = courseRepository;

        public List<CourseDto> GetAllDtos()
        {
            var courses = courseRepository.GetAll();
            var coursesDtos = new List<CourseDto>();

            courses?.ForEach(course =>
            {
                coursesDtos.Add(new CourseDto(
                    course.CourseName,
                    course.CourseDescription,
                    course.CourseCost,
                    course.CourseDurationInHours,
                    course.CourseId));
            });

            return coursesDtos;
        }

        public List<CourseDto> GetAllDtosByTraineeId(long traineeId)
        {
            var relations = courseRepository.GetAllByTraineeId(traineeId);
            var coursesDtos = new List<CourseDto>();

            relations.ForEach(relation =>
            {
                coursesDtos.Add(new CourseDto(
                    relation.Course.CourseName,
                    relation.Course.CourseDescription,
                    relation.Course.CourseCost,
                    relation.Course.CourseDurationInHours,
                    relation.CourseId));
            });

            return coursesDtos;
        }

        public CourseDto? GetDtoById(int id)
        {
            var course = courseRepository.GetById(id);

            return course is null ?
                null
                : new CourseDto(
                    course.CourseName,
                    course.CourseDescription,
                    course.CourseCost,
                    course.CourseDurationInHours,
                    course.CourseId);
        }

        public bool InsertEntityUsingDto(CourseDto entity)
        {
            return courseRepository.Insert(new Models.Course()
            {
                CourseName = entity.CourseName,
                CourseDescription = entity.CourseDescription,
                CourseCost = entity.CourseCost,
                CourseDurationInHours = entity.CourseDurationInHours,
            });
        }

        public bool UpdateEntityUsingDto(CourseDto entity)
        {
            return courseRepository.Update(new Models.Course()
            {
                CourseId = entity.CourseId,
                CourseName = entity.CourseName,
                CourseDescription = entity.CourseDescription,
                CourseCost = entity.CourseCost,
                CourseDurationInHours = entity.CourseDurationInHours,
            });
        }

        public bool DeleteEntity(int id)
        {
            return courseRepository.Delete(id);
        }

    }
}
