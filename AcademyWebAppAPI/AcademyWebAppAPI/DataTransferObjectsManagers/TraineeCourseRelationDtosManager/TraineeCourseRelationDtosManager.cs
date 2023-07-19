using AcademyWebAppAPI.DataTransferObjectsManagers.TraineeCourseRelationDtosManager.TraineeCourseDtos;
using AcademyWebAppAPI.DataTransferObjectsManagers.TraineeCourseRelationsDtosManager;
using AcademyWebAppAPI.Models;
using AcademyWebAppAPI.Repositories.TraineeCourseRelation;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.TraineeCourseRelationDtosManager
{
    public class TraineeCourseRelationDtosManager : ITraineeCourseRelationDtosManager
    {
        private readonly ITraineeCourseRelationRepository traineeCourseRelationRepository;

        public TraineeCourseRelationDtosManager(ITraineeCourseRelationRepository traineeCourseRelationRepository)
            => this.traineeCourseRelationRepository = traineeCourseRelationRepository;

        public List<TraineeCourseDto> GetAllCoursesDtos(int traineeId)
        {
            var traineeCourses = traineeCourseRelationRepository.GetAllTraineeCourses(traineeId);
            var traineeCoursesDtos = new List<TraineeCourseDto>();
            
            traineeCourses?.ToList().ForEach(course =>
            {
                traineeCoursesDtos.Add(new TraineeCourseDto(
                    course.CourseName,
                    course.CourseDescription,
                    course.RegistrationDate,
                    course.CourseDurationInHours,
                    course.CourseCost,
                    course.CourseId
                    ));
            });

            return traineeCoursesDtos;
        }

        public bool InsertTraineeCourseRelation(TraineeCourseRelationDto traineeCourseRelationDto)
        {
            return traineeCourseRelationRepository.InsertTraineeCourse(new TraineeCourseRelation()
            {
                TraineeId = traineeCourseRelationDto.TraineeId,
                CourseId = traineeCourseRelationDto.CourseId,
                RegistrationDate = traineeCourseRelationDto.RegistrationDate
            });
        }

        public bool DeleteTraineeCourseRelation(TraineeCourseRelationDto traineeCourseRelationDto)
        {
            return traineeCourseRelationRepository.DeleteTraineeCourse(new TraineeCourseRelation()
            {
                TraineeId = traineeCourseRelationDto.TraineeId,
                CourseId = traineeCourseRelationDto.CourseId,
                RegistrationDate = traineeCourseRelationDto.RegistrationDate
            });
        }
    }
}
