
using AcademyWebAppAPI.DataTransferObjectsManagers.LanguageDtosManager.LanguageDtos;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.LanguageDtosManager
{
    public interface ILanguageDtosManager
    {
        List<LanguageDto> GetAll();
    }
}
