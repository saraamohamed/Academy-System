using Microsoft.EntityFrameworkCore;
using AcademyWebAppAPI.Models;
using Microsoft.Identity.Client;

namespace AcademyWebAppAPI.Repositories.TraineeCourseRelation
{
    public class TraineeCourseRelationRepository : ITraineeCourseRelationRepository
    {
        private readonly AcademyWebAppContext academyWebAppContext;

        public TraineeCourseRelationRepository(AcademyWebAppContext academyWebAppContext)
            => this.academyWebAppContext = academyWebAppContext;

        public IQueryable<dynamic>? GetAllTraineeCourses(long traineeId)
        {
            return academyWebAppContext.Trainees.Where(trainee => trainee.TraineeId == traineeId && trainee.IsDeleted == false)
                .Join(academyWebAppContext.TraineeCourseRelations,
                      trainee => trainee.TraineeId,
                      relation => relation.TraineeId,
                      (trainee, relation) => new { relation.CourseId, relation.RegistrationDate })
                .Join(academyWebAppContext.Courses,
                      relation => relation.CourseId,
                      course => course.CourseId,
                      (relation, course) => new
                      {
                          course.CourseName,
                          course.CourseDescription,
                          relation.RegistrationDate,
                          course.CourseDurationInHours,
                          course.CourseCost
                      });
        }

        public bool InsertTraineeCourse(Models.TraineeCourseRelation traineeCourseRelation)
        {
            try
            {
                academyWebAppContext.TraineeCourseRelations.Add(traineeCourseRelation);
                academyWebAppContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTraineeCourse(Models.TraineeCourseRelation traineeCourseRelation)
        {
            try
            {
                academyWebAppContext.TraineeCourseRelations.Remove(traineeCourseRelation);
                academyWebAppContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
