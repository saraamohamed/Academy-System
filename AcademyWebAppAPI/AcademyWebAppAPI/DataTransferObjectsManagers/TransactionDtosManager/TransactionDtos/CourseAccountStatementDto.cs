namespace AcademyWebAppAPI.DataTransferObjectsManagers.TransactionDtosManager.TransactionDtos
{
    public sealed record CourseAccountStatementDto(
        string CourseName,
        decimal CourseCost,
        decimal TotalReceivedMoneyAmount,
        decimal RemainingMoneyAmount,
        string PaymentStatus);
}
