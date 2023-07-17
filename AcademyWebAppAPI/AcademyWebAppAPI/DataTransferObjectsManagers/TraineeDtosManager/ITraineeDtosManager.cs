using AcademyWebAppAPI.DataTransferObjectsManagers.TraineeDtosManager.TraineeDtos;
using AcademyWebAppAPI.Repositories.Trainee.Enums;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.TraineeDtosManager
{
    public interface ITraineeDtosManager
    {
        List<TraineeDto> GetAllDtos();

        List<TraineeDto>? GetAllDtosBasedOnBranchId(int branchId);

        TraineeDto? GetDtoById(long traineeId);

        bool InsertEntityUsingDto(TraineeDto entity);

        bool UpdateEntityUsingDto(TraineeDto entity);

        bool DeactivateEntity(long traineeId);

        bool DeleteEntity(long traineeId);

        // Separator.

        List<string> GetReligionComboBoxValues();

        List<string> GetGenderComboBoxValues();

        List<string> GetMilitaryStatusComboBoxValues();

        List<int> GetAllYearsNumbersWithStartAndEndSpecified();
    }
}
