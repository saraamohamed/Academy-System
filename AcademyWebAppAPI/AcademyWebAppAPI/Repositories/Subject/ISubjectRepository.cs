using AcademyWebAppAPI.Models;

namespace AcademyWebAppAPI.Repositories.Subject
{
    public interface ISubjectRepository
    {
        List<Models.Subject> GetAllByCourseId(int courseId);

        Models.Subject? GetById(long id);

        bool Insert(Models.Subject entity);

        bool Update(Models.Subject entity);

        bool Delete(long id);
    }
}
