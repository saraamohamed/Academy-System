using AcademyWebAppAPI.DataTransferObjectsManagers.TraineeCourseRelationDtosManager.TraineeCourseDtos;
using AcademyWebAppAPI.DataTransferObjectsManagers.TraineeCourseRelationsDtosManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AcademyWebAppAPI.Controllers
{
    [Route("academy-api/trainee-course-relation")]
    [ApiController]
    public class TraineeCourseRelationController : ControllerBase
    {
        private ITraineeCourseRelationDtosManager traineeCourseRelationDtosManager;

        public TraineeCourseRelationController(ITraineeCourseRelationDtosManager traineeCourseRelationDtosManager)
            => this.traineeCourseRelationDtosManager = traineeCourseRelationDtosManager;


        [HttpGet("all/{traineeId}")]
        public IActionResult GetAll(int traineeId)
        {
            var coursesDtos = traineeCourseRelationDtosManager.GetAllCoursesDtos(traineeId);
            return coursesDtos.IsNullOrEmpty() ? NotFound() : Ok(coursesDtos);
        }

       
        [HttpPost("insert")]
        public IActionResult Insert(TraineeCourseRelationDto traineeCourseRelationDto)
        {
            return traineeCourseRelationDtosManager.InsertTraineeCourseRelation(traineeCourseRelationDto) ?
                Ok() : BadRequest();
        }


        [HttpPut("delete")]
        public IActionResult Delete(TraineeCourseRelationDto traineeCourseRelationDto)
        {
            return traineeCourseRelationDtosManager.DeleteTraineeCourseRelation(traineeCourseRelationDto) ?
                Ok() : BadRequest();
        }
    }
}
