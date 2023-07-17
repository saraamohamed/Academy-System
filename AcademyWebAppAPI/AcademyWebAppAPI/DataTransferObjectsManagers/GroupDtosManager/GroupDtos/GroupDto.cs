namespace AcademyWebAppAPI.DataTransferObjectsManagers.GroupDtosManager.GroupDtos
{
    public sealed record GroupDto(
        string GroupName,
        bool AcademyInNumbersPage,
        bool GroupsPage,
        bool UsersPage,
        bool BranchesPage,
        bool CoursesPage,
        bool SubjectsPage,
        bool TraineeAdditionPage,
        bool CoursesToTraineeAdditionPage,
        bool TraineeCombinedAccountStatementPage,
        int GroupId = 0);
}
