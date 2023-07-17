
namespace AcademyWebAppAPI.Repositories.Course
{
    public interface ICourseRepository : IRepository<Models.Course>
    {
        List<Models.TraineeCourseRelation> GetAllByTraineeId(long traineeId);
    }
}
