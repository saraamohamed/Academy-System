namespace AcademyWebAppAPI.Repositories.Transaction
{
    public interface ITransactionRepository
    {
        public List<Models.Transaction>? GetAllCoursesTransactionsOfTrainee(long traineeId);
        public IEnumerable<dynamic>? GetAllAccountStatementsOfTraineeCourses(long traineeId);
        public bool InsertTransactionOfTraineeCourse(Models.Transaction transaction);
        public bool DeleteTransactionOfTraineeCourse(long transactionId);
    }
}
