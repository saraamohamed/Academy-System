using AcademyWebAppAPI.DataTransferObjectsManagers.TransactionDtosManager;
using AcademyWebAppAPI.DataTransferObjectsManagers.TransactionDtosManager.TransactionDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyWebAppAPI.Controllers
{
    [Route("academy-api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ITransactionDtosManager transactionDtosManager;

        public TransactionController(ITransactionDtosManager transactionDtosManager)
            => this.transactionDtosManager = transactionDtosManager;


        [HttpGet("all/{traineeId}")]
        public IActionResult GetAllTraineeTransactions(long traineeId)
        {
            var traineeTransactions = transactionDtosManager.GetAllDtosOfTraineeCoursesTransactions(traineeId);
            return traineeTransactions != null ? Ok(traineeTransactions) : NoContent();
        }


        [HttpGet("courses-accounts-statements/{traineeId}")]
        public IActionResult GetAllAccountStatementsOfTraineeCourses(long traineeId)
        {
            var accountStatements = transactionDtosManager.GetAllDtosOfAccountStatementsOfTraineeCourses(traineeId);
            return accountStatements != null ? Ok(accountStatements) : NoContent();
        }


        [HttpPost("insert")]
        public IActionResult InsertTraineeCourseTransaction(TransactionDto transactionDto)
        {
            return transactionDtosManager.InsertTransactionOfTraineeCourse(transactionDto) ? Ok() : BadRequest();
        }


        [HttpDelete("delete/{transactionId}")]
        public IActionResult DeleteTraineeCourseTransaction(long transactionId)
        {
            return transactionDtosManager.DeleteTransactionOfTraineeCourse(transactionId) ? Ok() : BadRequest();
        }
    }
}
