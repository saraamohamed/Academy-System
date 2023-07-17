namespace AcademyWebAppAPI.DataTransferObjectsManagers.SubjectDtosManager.SubjectDtos
{
    public sealed record SubjectDto(
        string SubjectName,
        int CourseId,
        string CourseName="",
        long SubjectId = 0);
}
