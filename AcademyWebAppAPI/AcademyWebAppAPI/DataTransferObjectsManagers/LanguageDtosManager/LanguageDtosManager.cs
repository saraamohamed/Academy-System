using AcademyWebAppAPI.DataTransferObjectsManagers.LanguageDtosManager.LanguageDtos;
using AcademyWebAppAPI.Repositories.Language;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.LanguageDtosManager
{
    public class LanguageDtosManager : ILanguageDtosManager
    {
        private readonly ILanguageRepository languageRepository;

        public LanguageDtosManager(ILanguageRepository languageRepository)
            => this.languageRepository = languageRepository;

        public List<LanguageDto> GetAll()
        {
            var languages = languageRepository.GetAll();
            var languageDtos = new List<LanguageDto>();

            languages?.ForEach(language =>
            {
                languageDtos.Add(new LanguageDto(
                    language.LanguageName,
                    language.LanguageId));
            });

            return languageDtos;
        }
    }
}
