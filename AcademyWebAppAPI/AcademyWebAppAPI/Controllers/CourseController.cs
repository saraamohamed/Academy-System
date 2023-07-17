using AcademyWebAppAPI.DataTransferObjectsManagers.BranchDtosManager.BranchDtos;
using Microsoft.AspNetCore.Mvc;
using AcademyWebAppAPI.DataTransferObjectsManagers.CourseDtosManager;
using Microsoft.IdentityModel.Tokens;
using AcademyWebAppAPI.DataTransferObjectsManagers.CourseDtosManager.CourseDtos;

namespace AcademyWebAppAPI.Controllers
{
    [Route("academy-api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseDtosManager courseDtosManager;

        public CourseController(ICourseDtosManager courseDtosManager)
            => this.courseDtosManager = courseDtosManager;


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var courses = courseDtosManager.GetAllDtos();
            return courses.IsNullOrEmpty() ? NotFound() : Ok(courses);
        }


        [HttpGet("all-trainee-courses/{traineeId}")]
        public IActionResult GetAllByTraineeId(long traineeId)
        {
            var courses = courseDtosManager.GetAllDtosByTraineeId(traineeId);
            return courses.IsNullOrEmpty() ? NotFound() : Ok(courses);
        }


        [HttpGet("{courseId}")]
        public IActionResult GetById(int courseId)
        {
            var course = courseDtosManager.GetDtoById(courseId);
            return course is null ? NotFound() : Ok(course);
        }


        [HttpPost("insert")]
        public IActionResult Insert(CourseDto courseDto)
        {
            return courseDtosManager.InsertEntityUsingDto(courseDto) ?
                Ok()
                : BadRequest();
        }


        [HttpPost("update")]
        public IActionResult Update(CourseDto courseDto)
        {
            return courseDtosManager.UpdateEntityUsingDto(courseDto) ?
                Ok()
                : BadRequest();
        }


        [HttpDelete("delete/{courseId}")]
        public IActionResult Delete(int courseId)
        {
            return courseDtosManager.DeleteEntity(courseId) ?
                Ok()
                : BadRequest();
        }
    }
}
