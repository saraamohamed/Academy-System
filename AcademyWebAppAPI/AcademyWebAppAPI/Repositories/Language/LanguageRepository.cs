using AcademyWebAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebAppAPI.Repositories.Language
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly AcademyWebAppContext academyWebAppContext;

        public LanguageRepository(AcademyWebAppContext academyWebAppContext)
            => this.academyWebAppContext = academyWebAppContext;

        public List<Models.Language>? GetAll()
        {
            return academyWebAppContext
                .Languages
                .Where(language => language.IsDeleted == false)
                .AsNoTracking()
                .ToList();
        }

        public Models.Language? GetById(long id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Models.Language entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Models.Language entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
