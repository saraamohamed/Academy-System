using AcademyWebAppAPI.DataTransferObjectsManagers.UserDtosManager.UserDtos;
using AcademyWebAppAPI.Repositories.User;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.UserDtosManager
{
    public interface IUserDtosManager : IDtosManager<UserDto>
    {
        public List<UserGroupLanguageBranchDto>? GetAllDtos();
        List<string> GetAllSystemUsersNames();
        public UserPagesAuthorizationDto? GetDtoByCredentials(UserCredentialsDto userCredentialsDto);
        bool DeactivateEntity(int userId);
    }
}
