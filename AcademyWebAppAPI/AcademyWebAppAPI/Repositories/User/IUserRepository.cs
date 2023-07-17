
namespace AcademyWebAppAPI.Repositories.User
{
    public interface IUserRepository : IRepository<Models.User>
    {
        List<string> GetAllSystemUsersNames();
        Models.User? GetByCredentials(string username, string password);
        bool Deactivate(int userId);
    }
}
