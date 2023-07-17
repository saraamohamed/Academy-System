using AcademyWebAppAPI.Models;
using System.Text.RegularExpressions;

namespace AcademyWebAppAPI.Repositories.Group
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AcademyWebAppContext academyWebAppContext;

        public GroupRepository(AcademyWebAppContext academyWebAppContext)
            => this.academyWebAppContext = academyWebAppContext;

        public List<Models.Group>? GetAll()
        {
            return academyWebAppContext.Groups.Where(group => group.IsDeleted == false).ToList();
        }

        public Models.Group? GetById(int id)
        {
            return academyWebAppContext.Groups.Find(id);
        }

        public bool Insert(Models.Group entity)
        {
            try
            {
                academyWebAppContext.Groups.Add(entity);
                academyWebAppContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Models.Group entity)
        {
            try
            {
                if (!academyWebAppContext.Groups.Any(group => group.GroupId == entity.GroupId))
                    throw new Exception("The key of the provided object is not found in the Group relation!");
                academyWebAppContext.Groups.Update(entity);
                academyWebAppContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var group = GetById(id);

            if (group != null && group.IsDeleted == false)
            {
                academyWebAppContext.Attach(group);
                group.IsDeleted = true;
                academyWebAppContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
