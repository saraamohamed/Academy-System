using AcademyWebAppAPI.DataTransferObjectsManagers.LanguageDtosManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AcademyWebAppAPI.Controllers
{
    [Route("academy-api/language")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageDtosManager languageDtosManager;

        public LanguageController(ILanguageDtosManager languageDtosManager)
            => this.languageDtosManager = languageDtosManager;

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var languages = languageDtosManager.GetAll();
            return languages.IsNullOrEmpty() ? NotFound() : Ok(languages);
        }
    }
}
