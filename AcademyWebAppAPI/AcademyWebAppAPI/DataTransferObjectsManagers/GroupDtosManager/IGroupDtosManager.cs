
using AcademyWebAppAPI.DataTransferObjectsManagers.GroupDtosManager.GroupDtos;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.GroupDtosManager
{
    public interface IGroupDtosManager : IDtosManager<GroupDto>
    {
        public List<GroupDto>? GetAllDtos();
    }
}
