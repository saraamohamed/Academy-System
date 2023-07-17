using AcademyWebAppAPI.DataTransferObjectsManagers.BranchDtosManager.BranchDtos;
using AcademyWebAppAPI.DataTransferObjectsManagers.BranchDtosManager;
using AcademyWebAppAPI.DataTransferObjectsManagers.TraineeDtosManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using AcademyWebAppAPI.DataTransferObjectsManagers.TraineeDtosManager.TraineeDtos;

namespace AcademyWebAppAPI.Controllers
{
    [Route("academy-api/trainee")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        private ITraineeDtosManager traineeDtosManager;

        public TraineeController(ITraineeDtosManager traineeDtosManager)
            => this.traineeDtosManager = traineeDtosManager;


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var trainees = traineeDtosManager.GetAllDtos();
            return trainees.IsNullOrEmpty() ? NotFound() : Ok(trainees);
        }


        [HttpGet("all-by-branch-id/{branchId}")]
        public IActionResult GetAllDtosByBranchId(int branchId)
        {
            var trainees = traineeDtosManager.GetAllDtosBasedOnBranchId(branchId);
            return trainees != null ? Ok(trainees) : NotFound();
        }


        [HttpGet("{traineeId}")]
        public IActionResult GetById(long traineeId)
        {
            var trainee = traineeDtosManager.GetDtoById(traineeId);
            return trainee is null ? NotFound() : Ok(trainee);
        }


        [HttpPost("insert")]
        public IActionResult Insert(TraineeDto traineeDto)
        {
            return traineeDtosManager.InsertEntityUsingDto(traineeDto) ?
                Ok()
                : BadRequest();
        }


        [HttpPut("update")]
        public IActionResult Update(TraineeDto traineeDto)
        {
            return traineeDtosManager.UpdateEntityUsingDto(traineeDto) ?
                Ok()
                : BadRequest();
        }


        [HttpHead("deactivate/{traineeId}")]
        public IActionResult Deactivate(long traineeId)
        {
            return traineeDtosManager.DeactivateEntity(traineeId) ?
                Ok()
                : BadRequest();
        }


        [HttpDelete("delete/{traineeId}")]
        public IActionResult Delete(long traineeId)
        {
            return traineeDtosManager.DeleteEntity(traineeId) ?
                Ok()
                : BadRequest();
        }

        // Separator.

        [HttpGet("religion-combobox-values")]
        public IActionResult GetReligionComboBoxValues()
        {
            return Ok(traineeDtosManager.GetReligionComboBoxValues());
        }


        [HttpGet("gender-combobox-values")]
        public IActionResult GetGenderComboBoxValues()
        {
            return Ok(traineeDtosManager.GetGenderComboBoxValues());
        }


        [HttpGet("military-status-combobox-values")]
        public IActionResult GetMilitaryStatusComboBoxValues()
        {
            return Ok(traineeDtosManager.GetMilitaryStatusComboBoxValues());
        }


        [HttpGet("years-from-1980-till-now")]
        public IActionResult GetAllYearsNumbersWithStartAndEndSpecified()
        {
            return Ok(traineeDtosManager.GetAllYearsNumbersWithStartAndEndSpecified());
        }
    }
}
