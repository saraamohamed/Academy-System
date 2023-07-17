using AcademyWebAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebAppAPI.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AcademyWebAppContext academyWebAppContext;

        public UserRepository(AcademyWebAppContext academyWebAppContext)
            => this.academyWebAppContext = academyWebAppContext;

        public List<Models.User>? GetAll()
        {
            return academyWebAppContext.Users.Where(user => user.IsDeleted == false)
                .Include(user => user.Group)
                .Include(user => user.Language)
                .Include(user => user.Branch)
                .OrderByDescending(user => user.IsActive).ToList();
        }

        public List<string> GetAllSystemUsersNames()
        {
            return academyWebAppContext
                .Users
                .Where(user => user.IsDeleted == false)
                .Select(user => user.FullName)
                .AsNoTracking()
                .ToList();
        }

        public Models.User? GetById(int id)
        {
            var users = GetAll();
            return users != null ? users.FirstOrDefault(user => user.UserId == id) : null;
        }

        public Models.User? GetByCredentials(string username, string password)
        {
            var user = academyWebAppContext
                .Users
                .Where(user => user.Username == username &&
                       user.Password == password &&
                       user.IsDeleted == false)
                .Include(user => user.Group)
                .FirstOrDefault();
            return user;
        }

        public bool Insert(Models.User entity)
        {
            try
            {
                if (academyWebAppContext.Users.FirstOrDefault(user => user.Username == entity.Username) != null)
                    throw new Exception("Duplicate username found in the database!");
                academyWebAppContext.Users.Add(entity);
                academyWebAppContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Models.User entity)
        {
            try
            {
                academyWebAppContext.Users.Update(entity);
                academyWebAppContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Deactivate(int id)
        {
            try
            {
                var user = GetById(id);

                if (user != null)
                {
                    if (user.IsActive == true)
                    {
                        user.IsActive = false;
                        academyWebAppContext.SaveChanges();
                        return true;
                    }

                    user.IsActive = true;
                    academyWebAppContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var user = GetById(id);

            if (user != null && user.IsDeleted == false)
            {
                academyWebAppContext.Attach(user);
                user.IsDeleted = true;
                academyWebAppContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
