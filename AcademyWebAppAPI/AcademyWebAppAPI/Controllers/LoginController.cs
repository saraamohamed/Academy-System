using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using AcademyWebAppAPI.DataTransferObjectsManagers.UserDtosManager.UserDtos;
using AcademyWebAppAPI.DataTransferObjectsManagers.UserDtosManager;
using AcademyWebAppAPI.Validators;

namespace AcademyWebAppAPI.Controllers
{
    [Route("academy-api/login")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IUserDtosManager userDtosManager;

        public LoginController(IUserDtosManager userDtosManager)
            => this.userDtosManager = userDtosManager;
        
        [HttpPost]
        public IActionResult AuthenticateLogger(UserCredentialsDto userCredentials)
        {   
            var user = userDtosManager
                .GetDtoByCredentials(userCredentials);

            if (user != null)
            {
                GlobalSessionValidator.IsInSession = true;

                // Start making a token for the current user, then return it as a stringified one.

                // Define identity claims for the current user.
                List<Claim> userIdentityClaims = new()
                {
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.SerialNumber, user.UserId.ToString()),
                    new Claim("AcademyInNumbersPage", user.AcademyInNumbersPage.ToString()),
                    new Claim("GroupsPage", user.GroupsPage.ToString()),
                    new Claim("UsersPage", user.UsersPage.ToString()),
                    new Claim("BranchesPage", user.BranchesPage.ToString()),
                    new Claim("CoursesPage", user.CoursesPage.ToString()),
                    new Claim("SubjectsPage", user.SubjectsPage.ToString()),
                    new Claim("TraineeAdditionPage", user.TraineeAdditionPage.ToString()),
                    new Claim("CoursesToTraineeAdditionPage", user.CoursesToTraineeAdditionPage.ToString()),
                    new Claim("TraineeCombinedAccountStatementPage", user.TraineeCombinedAccountStatementPage.ToString())
                };

                // Define a secret key for the current token.
                string secretKey = "AcademyWebAppAPIDevelopedByOurTeam";
                var encodedSecretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

                // Write the token.
                var signingCredentials = new SigningCredentials(encodedSecretKey, SecurityAlgorithms.HmacSha256);
                
                var token = new JwtSecurityToken(
                    claims: userIdentityClaims,
                    signingCredentials: signingCredentials,
                    expires: DateTime.Now.AddDays(1));
                
                var stringifiedToken = new JwtSecurityTokenHandler().WriteToken(token);

                // Return the token with status code of 200.
                return Ok(new { generatedJwtToken = stringifiedToken });
            }

            return Unauthorized();
        }
    }
}
