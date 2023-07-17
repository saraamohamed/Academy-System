using AcademyWebAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebAppAPI.Repositories.Course
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AcademyWebAppContext academyWebAppContext;

        public CourseRepository(AcademyWebAppContext academyWebAppContext)
            => this.academyWebAppContext = academyWebAppContext;

        public List<Models.Course>? GetAll()
        {
            return academyWebAppContext
                .Courses
                .Where(course => course.IsDeleted == false)
                .AsNoTracking()
                .ToList();
        }

        public List<Models.TraineeCourseRelation> GetAllByTraineeId(long traineeId)
        {
            return academyWebAppContext
                .TraineeCourseRelations
                .Where(relation => relation.TraineeId == traineeId)
                .Include(relation => relation.Course)
                .AsNoTracking()
                .ToList();
        }

        public Models.Course? GetById(int id)
        {
            return academyWebAppContext
                .Courses
                .FirstOrDefault(course =>
                    course.CourseId == id &&
                    course.IsDeleted == false);
        }

        public bool Insert(Models.Course entity)
        {
            try
            {
                academyWebAppContext.Courses.Add(entity);
                academyWebAppContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Models.Course entity)
        {
            try
            {
                academyWebAppContext.Courses.Update(entity);
                academyWebAppContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var course = GetById(id);
                if (course != null)
                {
                    course.IsDeleted = true;
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
