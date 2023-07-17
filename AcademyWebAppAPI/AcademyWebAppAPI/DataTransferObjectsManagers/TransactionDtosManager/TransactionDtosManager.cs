using AcademyWebAppAPI.DataTransferObjectsManagers.TransactionDtosManager.TransactionDtos;
using AcademyWebAppAPI.Repositories.Transaction;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.TransactionDtosManager
{
    public class TransactionDtosManager : ITransactionDtosManager
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionDtosManager(ITransactionRepository transactionRepository)
            => this.transactionRepository = transactionRepository;
        
        public List<TransactionDto>? GetAllDtosOfTraineeCoursesTransactions(long traineeId)
        {
            var traineeTransactions = transactionRepository.GetAllCoursesTransactionsOfTrainee(traineeId);
            var traineeTransactionsDtos = new List<TransactionDto>();

            traineeTransactions?.ForEach(transaction =>
                traineeTransactionsDtos.Add(new TransactionDto(
                    transaction.Course.CourseName,
                    transaction.TransactionDateTime,
                    transaction.ReceivedMoneyAmount,
                    transaction.DashboardUser,
                    transaction.Notes,
                    transaction.TraineeId,
                    transaction.CourseId,
                    transaction.TransactionId)
                )
            );

            return traineeTransactionsDtos;
        }

        public List<CourseAccountStatementDto>? GetAllDtosOfAccountStatementsOfTraineeCourses(long traineeId)
        {
            var accountStatementsOfTraineeCourses = transactionRepository.GetAllAccountStatementsOfTraineeCourses(traineeId);
            var accountStatementsOfTraineeCoursesDtos = new List<CourseAccountStatementDto>();

            accountStatementsOfTraineeCourses?.ToList().ForEach(accountStatement =>
            {
                var remainingMoneyAmount = accountStatement.CourseCost - accountStatement.TotalReceivedMoneyAmount;
                var paymentStatus = remainingMoneyAmount < 0 ? "Fully Paid, and Has Change!"
                                      : remainingMoneyAmount == 0 ? "Fully Paid"
                                      : remainingMoneyAmount > 0 && remainingMoneyAmount < accountStatement.CourseCost ? "Partially Paid"
                                      : "Not Paid";

                accountStatementsOfTraineeCoursesDtos.Add(new CourseAccountStatementDto(
                   accountStatement.CourseName,
                   accountStatement.CourseCost,
                   accountStatement.TotalReceivedMoneyAmount,
                   remainingMoneyAmount,
                   paymentStatus));
            });

            return accountStatementsOfTraineeCoursesDtos;
        }

        public bool InsertTransactionOfTraineeCourse(TransactionDto transactionDto)
        {
            return transactionRepository.InsertTransactionOfTraineeCourse(new Models.Transaction()
            {
                TransactionId = transactionDto.TransactionId,
                TransactionDateTime = transactionDto.TransactionDateTime,
                ReceivedMoneyAmount = transactionDto.ReceivedMoneyAmount,
                DashboardUser = transactionDto.DashboardUser,
                Notes = transactionDto.Notes,
                TraineeId = transactionDto.TraineeId,
                CourseId = transactionDto.CourseId
            });
        }

        public bool DeleteTransactionOfTraineeCourse(long transactionId)
        {
            return transactionRepository.DeleteTransactionOfTraineeCourse(transactionId);
        }
    }
}
