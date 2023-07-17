using AcademyWebAppAPI.DataTransferObjectsManagers.BranchDtosManager;
using AcademyWebAppAPI.DataTransferObjectsManagers.UserDtosManager;
using AcademyWebAppAPI.DataTransferObjectsManagers.UserDtosManager.UserDtos;
using AcademyWebAppAPI.Repositories.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace AcademyWebAppAPI.Controllers
{
    [Route("academy-api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserDtosManager userDtosManager;

        public UserController(IUserDtosManager userDtosManager)
            => this.userDtosManager = userDtosManager;


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var usersDtos = userDtosManager.GetAllDtos();
            return usersDtos != null ? Ok(usersDtos) : NotFound();
        }


        [HttpGet("all-users-full-names")]
        public IActionResult GetAllSystemUsersNames()
        {
            var users = userDtosManager.GetAllSystemUsersNames();
            return users.IsNullOrEmpty() ? NotFound() : Ok(users);
        }


        [HttpGet("{userId}")]
        public IActionResult GetById(int userId)
        {
            var userDto = userDtosManager.GetDtoById(userId);
            return userDto != null ? Ok(userDto) : NotFound();
        }


        [HttpPost("insert")]
        public IActionResult Insert(UserDto userDto)
        {
            return userDtosManager.InsertEntityUsingDto(userDto) ? Ok() : BadRequest();
        }


        [HttpPut("update")]
        public IActionResult Update(UserDto userDto)
        {
            return userDtosManager.UpdateEntityUsingDto(userDto) ? Ok() : BadRequest();
        }


        [HttpHead("deactivate/{userId}")]
        public IActionResult Deactivate(int userId)
        {
            return userDtosManager.DeactivateEntity(userId) ? Ok() : BadRequest();
        }


        [HttpDelete("delete/{userId}")]
        public IActionResult Delete(int userId)
        {
            return userDtosManager.DeleteEntity(userId) ? Ok() : BadRequest();
        }
    }
}
