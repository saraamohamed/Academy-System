using AcademyWebAppAPI.DataTransferObjectsManagers.UserDtosManager.UserDtos;
using AcademyWebAppAPI.Models;
using AcademyWebAppAPI.Repositories.Branch;
using AcademyWebAppAPI.Repositories.User;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.UserDtosManager
{
    public class UserDtosManager : IUserDtosManager
    {
        private readonly IUserRepository userRepository;

        public UserDtosManager(IUserRepository userRepository)
            => this.userRepository = userRepository;

        public List<UserGroupLanguageBranchDto>? GetAllDtos()
        {
            var users = userRepository.GetAll();
            var usersDtos = new List<UserGroupLanguageBranchDto>();

            users?.ForEach(user =>
                usersDtos.Add(new UserGroupLanguageBranchDto(
                    user.Username,
                    user.Password,
                    user.FullName,
                    user.Email,
                    user.PhoneNumber,
                    user.Group.GroupName,
                    user.Language.LanguageName,
                    user.Branch.BranchName,
                    user.IsActive,
                    user.UserId)
                )
            );

            return usersDtos;
        }

        public List<string> GetAllSystemUsersNames()
        {
            return userRepository.GetAllSystemUsersNames();
        }

        public UserDto? GetDtoById(int userId)
        {
            var user = userRepository.GetById(userId);

            if (user != null)
                return new UserDto(
                    user.Username,
                    user.Password,
                    user.FullName,
                    user.Email,
                    user.PhoneNumber,
                    user.GroupId,
                    user.LanguageId,
                    user.BranchId,
                    user.IsActive,
                    user.UserId);
            return null;
        }

        public UserPagesAuthorizationDto? GetDtoByCredentials(UserCredentialsDto userCredentialsDto)
        {
            var user = userRepository.GetByCredentials(userCredentialsDto.Username,
                                                            userCredentialsDto.Password);

            return user == null ?
                null
                : new UserPagesAuthorizationDto(
                    user.UserId,
                    user.FullName,
                    user.Group.AcademyInNumbersPage,
                    user.Group.GroupsPage,
                    user.Group.UsersPage,
                    user.Group.BranchesPage,
                    user.Group.CoursesPage,
                    user.Group.SubjectsPage,
                    user.Group.TraineeAdditionPage,
                    user.Group.CoursesToTraineeAdditionPage,
                    user.Group.TraineeCombinedAccountStatementPage);
        }

        public bool InsertEntityUsingDto(UserDto userDto)
        {
            var user = new User()
            {
                Username = userDto.Username,
                Password = userDto.Password,
                FullName = userDto.FullName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                GroupId = userDto.GroupId,
                LanguageId = userDto.LanguageId,
                BranchId = userDto.BranchId,
                IsActive = userDto.IsActive
            };

            return userRepository.Insert(user);
        }

        public bool UpdateEntityUsingDto(UserDto userDto)
        {
            var user = new User()
            {
                UserId = userDto.UserId,
                Username = userDto.Username,
                Password = userDto.Password,
                FullName = userDto.FullName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                GroupId = userDto.GroupId,
                LanguageId = userDto.LanguageId,
                BranchId = userDto.BranchId,
                IsActive = userDto.IsActive
            };

            return userRepository.Update(user);
        }

        public bool DeactivateEntity(int userId)
        {
            return userRepository.Deactivate(userId);
        }

        public bool DeleteEntity(int userId)
        {
            return userRepository.Delete(userId);
        }
    }
}
