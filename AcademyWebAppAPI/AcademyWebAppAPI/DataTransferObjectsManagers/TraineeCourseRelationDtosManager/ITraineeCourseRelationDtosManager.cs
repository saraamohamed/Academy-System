using AcademyWebAppAPI.DataTransferObjectsManagers.TraineeCourseRelationDtosManager.TraineeCourseDtos;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.TraineeCourseRelationsDtosManager
{
    public interface ITraineeCourseRelationDtosManager
    {
        List<TraineeCourseDto> GetAllCoursesDtos(int traineeId);
        bool InsertTraineeCourseRelation(TraineeCourseRelationDto traineeCourseRelationDto);
        bool DeleteTraineeCourseRelation(TraineeCourseRelationDto traineeCourseRelationDto);
    }
}
