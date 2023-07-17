namespace AcademyWebAppAPI.DataTransferObjectsManagers.CourseDtosManager.CourseDtos
{
    public sealed record CourseDto(
        string CourseName,
        string CourseDescription,
        decimal CourseCost,
        int CourseDurationInHours,
        int CourseId = 0);
}
