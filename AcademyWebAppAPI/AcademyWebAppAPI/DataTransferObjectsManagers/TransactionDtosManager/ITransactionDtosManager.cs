using AcademyWebAppAPI.DataTransferObjectsManagers.TransactionDtosManager.TransactionDtos;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.TransactionDtosManager
{
    public interface ITransactionDtosManager
    {
        public List<TransactionDto>? GetAllDtosOfTraineeCoursesTransactions(long traineeId);
        public List<CourseAccountStatementDto>? GetAllDtosOfAccountStatementsOfTraineeCourses(long traineeId);
        public bool InsertTransactionOfTraineeCourse(TransactionDto transactionDto);
        public bool DeleteTransactionOfTraineeCourse(long transactionId);
    }
}
