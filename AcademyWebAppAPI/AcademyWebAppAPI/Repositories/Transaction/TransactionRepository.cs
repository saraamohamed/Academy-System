using AcademyWebAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebAppAPI.Repositories.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AcademyWebAppContext academyWebAppContext;

        public TransactionRepository(AcademyWebAppContext academyWebAppContext)
            => this.academyWebAppContext = academyWebAppContext;

        public List<Models.Transaction>? GetAllCoursesTransactionsOfTrainee(long traineeId)
        {
            return academyWebAppContext.Transactions
                .Where(transaction => transaction.TraineeId == traineeId && transaction.IsDeleted == false)
                .Include(transaction => transaction.Course)
                .OrderBy(transaction => transaction.Course.CourseName)
                .ToList();
        }

        public IEnumerable<dynamic>? GetAllAccountStatementsOfTraineeCourses(long traineeId)
        {
            return GetAllCoursesTransactionsOfTrainee(traineeId)?
                .GroupBy(transaction => transaction.Course.CourseName,
                         transaction => new
                         {
                             transaction.Course.CourseName,
                             transaction.Course.CourseCost,
                             transaction.ReceivedMoneyAmount
                         },
                         (key, values) => new
                         {
                             CourseName = key,
                             values.First().CourseCost,
                             TotalReceivedMoneyAmount = values.Sum(row => row.ReceivedMoneyAmount)
                         });
        }

        public bool InsertTransactionOfTraineeCourse(Models.Transaction transaction)
        {
            try
            {
                academyWebAppContext.Transactions.Add(transaction);
                academyWebAppContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTransactionOfTraineeCourse(long transactionId)
        {
            var courseTransaction = academyWebAppContext.Transactions.Find(transactionId);

            if (courseTransaction != null)
            {
                academyWebAppContext.Attach(courseTransaction);
                courseTransaction.IsDeleted = true;
                academyWebAppContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
