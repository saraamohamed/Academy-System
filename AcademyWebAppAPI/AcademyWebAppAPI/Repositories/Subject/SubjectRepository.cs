using AcademyWebAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebAppAPI.Repositories.Subject
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AcademyWebAppContext academyWebAppContext;

        public SubjectRepository(AcademyWebAppContext academyWebAppContext)
            => this.academyWebAppContext = academyWebAppContext;

        public List<Models.Subject> GetAllByCourseId(int courseId)
        {
            return academyWebAppContext
                .Subjects
                .Where(subject =>
                    subject.CourseId == courseId &&
                    subject.IsDeleted == false)
                .Include(subject => subject.Course)
                .AsNoTracking()
                .ToList();
        }

        public Models.Subject? GetById(long id)
        {
            return academyWebAppContext
                .Subjects
               .Where(subject =>
                    subject.SubjectId == id &&
                    subject.IsDeleted == false)
                .Include(subject => subject.Course)
                .FirstOrDefault();
        }

            public bool Insert(Models.Subject entity)
        {
            try
            {
                academyWebAppContext.Subjects.Add(entity);
                academyWebAppContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Models.Subject entity)
        {
            try
            {
                academyWebAppContext.Subjects.Update(entity);
                academyWebAppContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var subject = GetById(id);
                if (subject != null)
                {
                    subject.IsDeleted = true;
                    academyWebAppContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
