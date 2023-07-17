namespace AcademyWebAppAPI.Repositories.TraineeCourseRelation
{
    public interface ITraineeCourseRelationRepository
    {
        IQueryable<dynamic>? GetAllTraineeCourses(long traineeId);
        bool InsertTraineeCourse(Models.TraineeCourseRelation traineeCourseRelation);
        bool DeleteTraineeCourse(Models.TraineeCourseRelation traineeCourseRelation);
    }
}
