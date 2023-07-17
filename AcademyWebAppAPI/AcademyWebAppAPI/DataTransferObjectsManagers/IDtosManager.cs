using AcademyWebAppAPI.DataTransferObjectsManagers.UserDtosManager;

namespace AcademyWebAppAPI.DataTransferObjectsManagers
{
    public interface IDtosManager<T>
    {
        T? GetDtoById(int id);
        bool InsertEntityUsingDto(T entity);
        bool UpdateEntityUsingDto(T entity);
        bool DeleteEntity(int id);
    }
}
