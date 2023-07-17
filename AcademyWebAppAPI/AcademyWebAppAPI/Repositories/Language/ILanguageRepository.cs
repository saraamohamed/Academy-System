namespace AcademyWebAppAPI.Repositories.Language
{
    public interface ILanguageRepository
    {
        List<Models.Language>? GetAll();

       Models.Language? GetById(long id);

       bool Insert(Models.Language entity);

       bool Update(Models.Language entity);

       bool Delete(long id);
    }
}
