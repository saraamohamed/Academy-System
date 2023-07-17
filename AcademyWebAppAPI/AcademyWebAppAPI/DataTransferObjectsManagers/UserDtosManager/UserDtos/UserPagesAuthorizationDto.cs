namespace AcademyWebAppAPI.DataTransferObjectsManagers.UserDtosManager.UserDtos
{
    public sealed record UserPagesAuthorizationDto(
        int UserId,
        string FullName,
        bool AcademyInNumbersPage,
        bool GroupsPage,
        bool UsersPage,
        bool BranchesPage,
        bool CoursesPage,
        bool SubjectsPage,
        bool TraineeAdditionPage,
        bool CoursesToTraineeAdditionPage,
        bool TraineeCombinedAccountStatementPage);
}
