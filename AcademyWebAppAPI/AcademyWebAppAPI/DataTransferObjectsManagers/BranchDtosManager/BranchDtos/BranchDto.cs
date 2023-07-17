namespace AcademyWebAppAPI.DataTransferObjectsManagers.BranchDtosManager.BranchDtos
{
    public sealed record BranchDto(
        string Name,
        string SupervisorName,
        string SupervisorPhoneNumber,
        string SupervisorLandlineNumber,
        int Id = 0);
}
