using AcademyWebAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebAppAPI.Repositories.Branch
{
    public class BranchRepository : IBranchRepository
    {
        private readonly AcademyWebAppContext academyWebAppContext;

        public BranchRepository(AcademyWebAppContext academyWebAppContext)
            => this.academyWebAppContext = academyWebAppContext;

        public List<Models.Branch>? GetAll()
        {
            return academyWebAppContext
                .Branches
                .Where(branch => branch.IsDeleted == false)
                .AsNoTracking()
                .ToList();
        }

        public Models.Branch? GetById(int id)
        {
            return academyWebAppContext
                .Branches
                .FirstOrDefault(branch =>
                    branch.BranchId == id &&
                    branch.IsDeleted == false);
        }

        public bool Insert(Models.Branch entity)
        {
            try
            {
                academyWebAppContext.Branches.Add(entity);
                academyWebAppContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Models.Branch entity)
        {
            try
            {
                academyWebAppContext.Branches.Update(entity);
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
            try
            {
                var branch = GetById(id);
                if (branch != null)
                {
                    branch.IsDeleted = true;
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
    }
}
