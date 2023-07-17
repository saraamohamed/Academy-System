namespace AcademyWebAppAPI.DataTransferObjectsManagers.TraineeCourseRelationDtosManager.TraineeCourseDtos
{
    // Used for Inserting Data In the TraineeCourseRelation Table.
    public sealed record TraineeCourseRelationDto(
        long TraineeId,
        int CourseId,
        DateTime? RegistrationDate);
}
