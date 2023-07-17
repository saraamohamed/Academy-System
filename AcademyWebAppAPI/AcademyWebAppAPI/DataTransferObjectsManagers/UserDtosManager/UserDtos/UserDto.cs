namespace AcademyWebAppAPI.DataTransferObjectsManagers.UserDtosManager.UserDtos
{
    // Used for Inserting or Updating User's Table Data.
    public sealed record UserDto(
        string Username,
        string Password,
        string FullName,
        string Email,
        string PhoneNumber,
        int GroupId,
        long LanguageId,
        int BranchId,
        bool IsActive = true,
        int UserId = 0);
}
