using AcademyWebAppAPI.Models;
using AcademyWebAppAPI.Repositories.Trainee.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AcademyWebAppAPI.Repositories.Trainee
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly AcademyWebAppContext academyWebAppContext;

        public TraineeRepository(AcademyWebAppContext academyWebAppContext)
            => this.academyWebAppContext = academyWebAppContext;

        public List<Models.Trainee>? GetAll()
        {
            return academyWebAppContext
                .Trainees
                .Where(trainee => trainee.IsDeleted == false)
                .Include(trainee => trainee.Branch)
                .OrderByDescending(trainee => trainee.IsActive)
                .AsNoTracking()
                .ToList();
        }

        public List<Models.Trainee>? GetAllBasedOnBranchId(int branchId)
        {
            return academyWebAppContext.Trainees
                .Where(trainee => trainee.BranchId == branchId && trainee.IsDeleted == false)
                .Include(trainee => trainee.Branch)
                .OrderByDescending(trainee => trainee.IsActive)
                .AsNoTracking()
                .ToList();
        }

        public Models.Trainee? GetById(long id)
        {
            return academyWebAppContext
                .Trainees
                .Where(trainee =>
                    trainee.TraineeId == id &&
                    trainee.IsDeleted == false)
                .Include(trainee => trainee.Branch)
                .FirstOrDefault();
        }

        public bool Insert(Models.Trainee entity)
        {
            try
            {
                academyWebAppContext.Trainees.Add(entity);
                academyWebAppContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Models.Trainee entity)
        {
            try
            {
                academyWebAppContext.Trainees.Update(entity);
                academyWebAppContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Deactivate(long id)
        {
            try
            {
                var trainee = GetById(id);
                if (trainee != null)
                {
                    if (trainee.IsActive == true)
                    {
                        trainee.IsActive = false;
                        academyWebAppContext.SaveChanges();
                        return true;
                    }

                    trainee.IsActive = true;
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

        public bool Delete(long id)
        {
            try
            {
                var trainee = GetById(id);
                if (trainee != null)
                {
                    trainee.IsDeleted = true;
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

        // Separator.

        private List<string> GetAllEnumValuesAsList<TEnum>() where TEnum : Enum
            => ((TEnum[])Enum.GetValues(typeof(TEnum)))
               .Select(value => value.ToString())
               .ToList();

        public List<string> GetReligionComboBoxValues()
            => GetAllEnumValuesAsList<Religion>();

        public List<string> GetGenderComboBoxValues()
            => GetAllEnumValuesAsList<Gender>();

        public List<string> GetMilitaryStatusComboBoxValues()
            => GetAllEnumValuesAsList<MilitaryStatus>();

        public List<int> GetAllYearsNumbersWithStartAndEndSpecified()
            => Enumerable
               .Range(1980, DateTime.Now.Year - 1979)
               .ToList();
    }
}
