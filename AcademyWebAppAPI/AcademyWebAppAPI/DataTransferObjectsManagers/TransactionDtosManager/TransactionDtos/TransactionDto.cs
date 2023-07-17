namespace AcademyWebAppAPI.DataTransferObjectsManagers.TransactionDtosManager.TransactionDtos
{
    public sealed record TransactionDto(
        string? CourseName,
        DateTime TransactionDateTime,
        decimal ReceivedMoneyAmount,
        string DashboardUser,
        string Notes,
        long TraineeId,
        int CourseId,
        long TransactionId = 0);
}
