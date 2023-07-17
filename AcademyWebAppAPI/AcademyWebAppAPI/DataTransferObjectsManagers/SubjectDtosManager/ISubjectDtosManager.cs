using AcademyWebAppAPI.DataTransferObjectsManagers.SubjectDtosManager.SubjectDtos;
using AcademyWebAppAPI.Repositories.Subject;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.SubjectDtosManager
{
    public interface ISubjectDtosManager
    {
        List<SubjectDto> GetAllDtosByCourseId(int courseId);

        SubjectDto? GetDtoById(long subjectId);

        bool InsertEntityUsingDto(SubjectDto entity);

        bool UpdateEntityUsingDto(SubjectDto entity);

        bool DeleteEntity(long subjectId);
    }
}
