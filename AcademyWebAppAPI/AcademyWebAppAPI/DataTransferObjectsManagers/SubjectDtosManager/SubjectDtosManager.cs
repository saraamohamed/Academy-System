using AcademyWebAppAPI.DataTransferObjectsManagers.SubjectDtosManager.SubjectDtos;
using AcademyWebAppAPI.Models;
using AcademyWebAppAPI.Repositories.Subject;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.SubjectDtosManager
{
    public class SubjectDtosManager : ISubjectDtosManager
    {
        private readonly ISubjectRepository subjectRepository;

        public SubjectDtosManager(ISubjectRepository subjectRepository)
            => this.subjectRepository = subjectRepository;

        public List<SubjectDto> GetAllDtosByCourseId(int courseId)
        {
            var subjects = subjectRepository.GetAllByCourseId(courseId);
            var subjectsDtos = new List<SubjectDto>();

            subjects.ForEach(subject =>
            {
                subjectsDtos.Add(new SubjectDto(
                    subject.SubjectName,
                    subject.CourseId,
                    subject.Course.CourseName,
                    subject.SubjectId));
            });

            return subjectsDtos;
        }

        public SubjectDto? GetDtoById(long subjectId)
        {
            var subject = subjectRepository.GetById(subjectId);

            return subject is null ?
                null
                : new SubjectDto(
                    subject.SubjectName,
                    subject.CourseId,
                    subject.Course.CourseName,
                    subject.SubjectId);
        }

        public bool InsertEntityUsingDto(SubjectDto entity)
        {
            return subjectRepository.Insert(new Subject()
            {
                SubjectName = entity.SubjectName,
                CourseId = entity.CourseId
            });
        }

        public bool UpdateEntityUsingDto(SubjectDto entity)
        {
            return subjectRepository.Update(new Subject()
            {
                SubjectId = entity.SubjectId,
                SubjectName = entity.SubjectName,
                CourseId = entity.CourseId
            });
        }

        public bool DeleteEntity(long subjectId)
        {
            return subjectRepository.Delete(subjectId);
        }
    }
}
