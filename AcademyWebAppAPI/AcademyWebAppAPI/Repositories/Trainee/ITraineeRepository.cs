using AcademyWebAppAPI.Models;
using AcademyWebAppAPI.Repositories.Trainee.Enums;

namespace AcademyWebAppAPI.Repositories.Trainee
{
    public interface ITraineeRepository
    {
        List<Models.Trainee>? GetAll();

        List<Models.Trainee>? GetAllBasedOnBranchId(int branchId);

        Models.Trainee? GetById(long id);

        bool Insert(Models.Trainee entity);

        bool Update(Models.Trainee entity);

        bool Deactivate(long id);

        bool Delete(long id);

        // Separator.

        List<string> GetReligionComboBoxValues();

        List<string> GetGenderComboBoxValues();

        List<string> GetMilitaryStatusComboBoxValues();

        List<int> GetAllYearsNumbersWithStartAndEndSpecified();
    }
}

