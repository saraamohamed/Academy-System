using AcademyWebAppAPI.DataTransferObjectsManagers.BranchDtosManager.BranchDtos;
using AcademyWebAppAPI.DataTransferObjectsManagers.BranchDtosManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AcademyWebAppAPI.DataTransferObjectsManagers.SubjectDtosManager;
using Microsoft.IdentityModel.Tokens;
using AcademyWebAppAPI.DataTransferObjectsManagers.SubjectDtosManager.SubjectDtos;

namespace AcademyWebAppAPI.Controllers
{
    [Route("academy-api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectDtosManager subjectDtosManager;

        public SubjectController(ISubjectDtosManager subjectDtosManager)
            => this.subjectDtosManager = subjectDtosManager;


        [HttpGet("all/{courseId}")]
        public IActionResult GetAllByCourseId(int courseId)
        {
            var subjects = subjectDtosManager.GetAllDtosByCourseId(courseId);
            return subjects.IsNullOrEmpty() ? NotFound() : Ok(subjects);
        }


        [HttpGet("{subjectId}")]
        public IActionResult GetById(long subjectId)
        {
            var subject = subjectDtosManager.GetDtoById(subjectId);
            return subject is null ? NotFound() : Ok(subject);
        }


        [HttpPost("insert")]
        public IActionResult Insert(SubjectDto subjectDto)
        {
            return subjectDtosManager.InsertEntityUsingDto(subjectDto) ?
                Ok()
                : BadRequest();
        }


        [HttpPost("update")]
        public IActionResult Update(SubjectDto subjectDto)
        {
            return subjectDtosManager.UpdateEntityUsingDto(subjectDto) ?
                Ok()
                : BadRequest();
        }


        [HttpDelete("delete/{subjectId}")]
        public IActionResult Delete(long subjectId)
        {
            return subjectDtosManager.DeleteEntity(subjectId) ?
                Ok()
                : BadRequest();
        }
    }
}
