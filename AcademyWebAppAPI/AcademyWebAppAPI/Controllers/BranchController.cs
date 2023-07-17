using AcademyWebAppAPI.DataTransferObjectsManagers.BranchDtosManager;
using AcademyWebAppAPI.DataTransferObjectsManagers.BranchDtosManager.BranchDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AcademyWebAppAPI.Controllers
{
    [Route("academy-api/branch")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchDtosManager branchDtosManager;

        public BranchController(IBranchDtosManager branchDtosManager)
            => this.branchDtosManager = branchDtosManager;


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var branches = branchDtosManager.GetAllDtos();
            return branches.IsNullOrEmpty() ? NotFound() : Ok(branches);
        }


        [HttpGet("{branchId}")]
        public IActionResult GetById(int branchId)
        {
            var branch = branchDtosManager.GetDtoById(branchId);
            return branch is null ? NotFound() : Ok(branch);
        }


        [HttpPost("insert")]
        public IActionResult Insert(BranchDto branchDto)
        {
            return branchDtosManager.InsertEntityUsingDto(branchDto) ?
                Ok()
                : BadRequest();
        }


        [HttpPost("update")]
        public IActionResult Update(BranchDto branchDto)
        {
            return branchDtosManager.UpdateEntityUsingDto(branchDto) ?
                Ok()
                : BadRequest();
        }


        [HttpDelete("delete/{branchId}")]
        public IActionResult Delete(int branchId)
        {
            return branchDtosManager.DeleteEntity(branchId) ?
                Ok()
                : BadRequest();
        }
    }
}
