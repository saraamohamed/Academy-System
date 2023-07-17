using AcademyWebAppAPI.DataTransferObjectsManagers.GroupDtosManager.GroupDtos;
using AcademyWebAppAPI.Repositories.Group;
using System.Text.RegularExpressions;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.GroupDtosManager
{
    public class GroupDtosManager : IGroupDtosManager
    {
        private readonly IGroupRepository groupRepository;

        public GroupDtosManager(IGroupRepository groupRepository)
            => this.groupRepository = groupRepository;

        public List<GroupDto>? GetAllDtos()
        {
            var groups = groupRepository.GetAll();
            var groupsDtos = new List<GroupDto>();

            groups?.ForEach(group =>
                groupsDtos.Add(new GroupDto(
                        group.GroupName,
                        group.AcademyInNumbersPage,
                        group.GroupsPage,
                        group.UsersPage,
                        group.BranchesPage,
                        group.CoursesPage,
                        group.SubjectsPage,
                        group.TraineeAdditionPage,
                        group.CoursesToTraineeAdditionPage,
                        group.TraineeCombinedAccountStatementPage,
                        group.GroupId)
                )
            );

            return groupsDtos;
        }

        public GroupDto? GetDtoById(int id)
        {
            var group = groupRepository.GetById(id);

            if (group == null)
                return null;

            return new GroupDto(
                        group.GroupName,
                        group.AcademyInNumbersPage,
                        group.GroupsPage,
                        group.UsersPage,
                        group.BranchesPage,
                        group.CoursesPage,
                        group.SubjectsPage,
                        group.TraineeAdditionPage,
                        group.CoursesToTraineeAdditionPage,
                        group.TraineeCombinedAccountStatementPage,
                        group.GroupId);
        }

        public bool InsertEntityUsingDto(GroupDto groupDto)
        {
            var group = new Models.Group()
            {
                GroupName = groupDto.GroupName,
                AcademyInNumbersPage = groupDto.AcademyInNumbersPage,
                GroupsPage = groupDto.GroupsPage,
                UsersPage = groupDto.UsersPage,
                BranchesPage = groupDto.BranchesPage,
                CoursesPage = groupDto.CoursesPage,
                SubjectsPage = groupDto.SubjectsPage,
                TraineeAdditionPage = groupDto.TraineeAdditionPage,
                CoursesToTraineeAdditionPage = groupDto.CoursesToTraineeAdditionPage,
                TraineeCombinedAccountStatementPage = groupDto.TraineeCombinedAccountStatementPage
            };

            return groupRepository.Insert(group);
        }

        public bool UpdateEntityUsingDto(GroupDto groupDto)
        {
            var group = new Models.Group()
            {
                GroupId = groupDto.GroupId,
                GroupName = groupDto.GroupName,
                AcademyInNumbersPage = groupDto.AcademyInNumbersPage,
                GroupsPage = groupDto.GroupsPage,
                UsersPage = groupDto.UsersPage,
                BranchesPage = groupDto.BranchesPage,
                CoursesPage = groupDto.CoursesPage,
                SubjectsPage = groupDto.SubjectsPage,
                TraineeAdditionPage = groupDto.TraineeAdditionPage,
                CoursesToTraineeAdditionPage = groupDto.CoursesToTraineeAdditionPage,
                TraineeCombinedAccountStatementPage = groupDto.TraineeCombinedAccountStatementPage
            };

            return groupRepository.Update(group);
        }

        public bool DeleteEntity(int id)
        {
            return groupRepository.Delete(id);
        }

    }
}
