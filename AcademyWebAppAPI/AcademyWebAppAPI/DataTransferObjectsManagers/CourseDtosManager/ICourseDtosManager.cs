using AcademyWebAppAPI.DataTransferObjectsManagers.CourseDtosManager.CourseDtos;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.CourseDtosManager
{
    public interface ICourseDtosManager : IDtosManager<CourseDto>
    {
        List<CourseDto> GetAllDtos();
        List<CourseDto> GetAllDtosByTraineeId(long traineeId);
    }
}
