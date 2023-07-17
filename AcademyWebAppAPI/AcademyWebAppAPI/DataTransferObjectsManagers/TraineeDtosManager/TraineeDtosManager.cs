using AcademyWebAppAPI.DataTransferObjectsManagers.TraineeDtosManager.TraineeDtos;
using AcademyWebAppAPI.Models;
using AcademyWebAppAPI.Repositories.Trainee;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.TraineeDtosManager
{
    public class TraineeDtosManager : ITraineeDtosManager
    {
        private readonly ITraineeRepository traineeRepository;

        public TraineeDtosManager(ITraineeRepository traineeRepository)
            => this.traineeRepository = traineeRepository;

        public List<TraineeDto> GetAllDtos()
        {
            var trainees = traineeRepository.GetAll();
            var traineeDtos = new List<TraineeDto>();

            trainees?.ForEach(trainee =>
                traineeDtos.Add(new TraineeDto(
                    trainee.TraineeNationalId,
                    trainee.ArabicFullName,
                    trainee.EnglishFullName,
                    trainee.Religion,
                    trainee.Address,
                    trainee.Gender,
                    trainee.BirthDate,
                    trainee.FirstPhoneNumber,
                    trainee.SecondPhoneNumber,
                    trainee.LandlineNumber,
                    trainee.Recommender,
                    trainee.AcademicQualification,
                    trainee.QualificationObtainingYear,
                    trainee.AcademicYear,
                    trainee.MilitaryStatus,
                    trainee.PersonalPhoto,
                    trainee.NationalIdCardCopy,
                    trainee.AcademicQualificationCopy,
                    trainee.BranchId,
                    trainee.Branch.BranchName,
                    trainee.IsActive,
                    trainee.TraineeId)
                )
            );

            return traineeDtos;
        }

        public List<TraineeDto>? GetAllDtosBasedOnBranchId(int branchId)
        {
            var trainees = traineeRepository.GetAllBasedOnBranchId(branchId);
            var traineeDtos = new List<TraineeDto>();

            trainees?.ForEach(trainee =>
                traineeDtos.Add(new TraineeDto(
                    trainee.TraineeNationalId,
                    trainee.ArabicFullName,
                    trainee.EnglishFullName,
                    trainee.Religion,
                    trainee.Address,
                    trainee.Gender,
                    trainee.BirthDate,
                    trainee.FirstPhoneNumber,
                    trainee.SecondPhoneNumber,
                    trainee.LandlineNumber,
                    trainee.Recommender,
                    trainee.AcademicQualification,
                    trainee.QualificationObtainingYear,
                    trainee.AcademicYear,
                    trainee.MilitaryStatus,
                    trainee.PersonalPhoto,
                    trainee.NationalIdCardCopy,
                    trainee.AcademicQualificationCopy,
                    trainee.BranchId,
                    trainee.Branch.BranchName,
                    trainee.IsActive,
                    trainee.TraineeId)
                )
            );

            return traineeDtos;
        }

        public TraineeDto? GetDtoById(long traineeId)
        {
            var trainee = traineeRepository.GetById(traineeId);

            return trainee is null ?
                null
                : new TraineeDto(
                    trainee.TraineeNationalId,
                    trainee.ArabicFullName,
                    trainee.EnglishFullName,
                    trainee.Religion,
                    trainee.Address,
                    trainee.Gender,
                    trainee.BirthDate,
                    trainee.FirstPhoneNumber,
                    trainee.SecondPhoneNumber,
                    trainee.LandlineNumber,
                    trainee.Recommender,
                    trainee.AcademicQualification,
                    trainee.QualificationObtainingYear,
                    trainee.AcademicYear,
                    trainee.MilitaryStatus,
                    trainee.PersonalPhoto,
                    trainee.NationalIdCardCopy,
                    trainee.AcademicQualificationCopy,
                    trainee.BranchId,
                    trainee.Branch.BranchName,
                    trainee.IsActive,
                    trainee.TraineeId);
        }

        public bool InsertEntityUsingDto(TraineeDto entity)
        {
            return traineeRepository.Insert(new Trainee()
            {
                TraineeNationalId = entity.TraineeNationalId,
                ArabicFullName = entity.ArabicFullName,
                EnglishFullName = entity.EnglishFullName,
                Religion = entity.Religion,
                Address = entity.Address,
                Gender = entity.Gender,
                BirthDate = entity.BirthDate,
                FirstPhoneNumber = entity.FirstPhoneNumber,
                SecondPhoneNumber = entity.SecondPhoneNumber,
                LandlineNumber = entity.LandlineNumber,
                Recommender = entity.Recommender,
                AcademicQualification = entity.AcademicQualification,
                QualificationObtainingYear = entity.QualificationObtainingYear,
                AcademicYear = entity.AcademicYear,
                MilitaryStatus = entity.MilitaryStatus,
                PersonalPhoto = entity.PersonalPhoto,
                NationalIdCardCopy = entity.NationalIdCardCopy,
                AcademicQualificationCopy = entity.AcademicQualificationCopy,
                BranchId = entity.BranchId,
                IsActive = entity.IsActive
            });
        }

        public bool UpdateEntityUsingDto(TraineeDto entity)
        {
            return traineeRepository.Update(new Trainee()
            {
                TraineeId = entity.TraineeId,
                TraineeNationalId = entity.TraineeNationalId,
                ArabicFullName = entity.ArabicFullName,
                EnglishFullName = entity.EnglishFullName,
                Religion = entity.Religion,
                Address = entity.Address,
                Gender = entity.Gender,
                BirthDate = entity.BirthDate,
                FirstPhoneNumber = entity.FirstPhoneNumber,
                SecondPhoneNumber = entity.SecondPhoneNumber,
                LandlineNumber = entity.LandlineNumber,
                Recommender = entity.Recommender,
                AcademicQualification = entity.AcademicQualification,
                QualificationObtainingYear = entity.QualificationObtainingYear,
                AcademicYear = entity.AcademicYear,
                MilitaryStatus = entity.MilitaryStatus,
                PersonalPhoto = entity.PersonalPhoto,
                NationalIdCardCopy = entity.NationalIdCardCopy,
                AcademicQualificationCopy = entity.AcademicQualificationCopy,
                BranchId = entity.BranchId
            });
        }

        public bool DeactivateEntity(long traineeId)
        {
            return traineeRepository.Deactivate(traineeId);
        }

        public bool DeleteEntity(long traineeId)
        {
            return traineeRepository.Delete(traineeId);
        }

        // Separator.

        public List<string> GetReligionComboBoxValues()
        {
            return traineeRepository.GetReligionComboBoxValues();
        }

        public List<string> GetGenderComboBoxValues()
        {
            return traineeRepository.GetGenderComboBoxValues();
        }

        public List<string> GetMilitaryStatusComboBoxValues()
        {
            return traineeRepository.GetMilitaryStatusComboBoxValues();
        }

        public List<int> GetAllYearsNumbersWithStartAndEndSpecified()
        {
            return traineeRepository.GetAllYearsNumbersWithStartAndEndSpecified();
        }
    }
}
