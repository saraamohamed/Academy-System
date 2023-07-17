using AcademyWebAppAPI.DataTransferObjectsManagers.BranchDtosManager.BranchDtos;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.BranchDtosManager
{
    public interface IBranchDtosManager : IDtosManager<BranchDto>
    {
        List<BranchDto> GetAllDtos();
    }
}
