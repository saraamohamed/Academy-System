namespace AcademyWebAppAPI.DataTransferObjectsManagers.UserDtosManager.UserDtos
{
    // Used for the display only.
    public sealed record UserGroupLanguageBranchDto(
        string Username,
        string Password,
        string FullName,
        string Email,
        string PhoneNumber,
        string GroupName,
        string LanguageName,
        string BranchName,
        bool IsActive,
        int UserId);
}
