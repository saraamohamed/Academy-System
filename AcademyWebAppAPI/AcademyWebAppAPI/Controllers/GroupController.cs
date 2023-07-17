using AcademyWebAppAPI.DataTransferObjectsManagers.GroupDtosManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AcademyWebAppAPI.DataTransferObjectsManagers.GroupDtosManager.GroupDtos;

namespace AcademyWebAppAPI.Controllers
{
    [Route("academy-api/group")]
    [ApiController]
    //[Authorize(Policy = "GroupsPage")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupDtosManager groupDtosManager;

        public GroupController(IGroupDtosManager groupDtosManager)
            => this.groupDtosManager = groupDtosManager;
        

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var groupsDtos = groupDtosManager.GetAllDtos();
            return groupsDtos != null ? Ok(groupsDtos) : NotFound();
        }

        
        [HttpGet("{groupId}")]
        public IActionResult GetById(int groupId)
        {
            var groupDto = groupDtosManager.GetDtoById(groupId);
            return groupDto != null ? Ok(groupDto) : NotFound();
        }

        
        [HttpPost("insert")]
        public IActionResult Insert(GroupDto group)
        {
            return groupDtosManager.InsertEntityUsingDto(group) ? Ok() : BadRequest();
        }

        
        [HttpPut("update")]
        public IActionResult Update(GroupDto group)
        {
            return groupDtosManager.UpdateEntityUsingDto(group) ? Ok() : BadRequest();
        }


        [HttpDelete("delete/{groupId}")]
        public IActionResult Delete(int groupId)
        {
            return groupDtosManager.DeleteEntity(groupId) ? Ok() : BadRequest();
        }
    }
}
