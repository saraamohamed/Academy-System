namespace AcademyWebAppAPI.DataTransferObjectsManagers.TraineeDtosManager.TraineeDtos
{
    public sealed record TraineeDto(
        string TraineeNationalId,
        string ArabicFullName,
        string EnglishFullName,
        string Religion,
        string Address,
        string Gender,
        DateTime? BirthDate,
        string FirstPhoneNumber,
        string SecondPhoneNumber,
        string LandlineNumber,
        string Recommender,
        string AcademicQualification,
        int QualificationObtainingYear,
        int? AcademicYear,
        string MilitaryStatus,
        string PersonalPhoto,
        string NationalIdCardCopy,
        string AcademicQualificationCopy,
        int BranchId,
        string BranchName = "",
        bool IsActive = true,
        long TraineeId = 0);
}
