namespace AcademyWebAppAPI.DataTransferObjectsManagers.TraineeCourseRelationDtosManager.TraineeCourseDtos
{
    // Used for the display only.
    public sealed record TraineeCourseDto(
        string CourseName,
        string CourseDescription,
        DateTime? RegistrationDate,
        int CourseDurationInHours,
        decimal CourseCost,
        int CourseId=0);
}
