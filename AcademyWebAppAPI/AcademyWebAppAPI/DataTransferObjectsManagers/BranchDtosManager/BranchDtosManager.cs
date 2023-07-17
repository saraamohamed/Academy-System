using AcademyWebAppAPI.DataTransferObjectsManagers.BranchDtosManager.BranchDtos;
using AcademyWebAppAPI.Repositories.Branch;

namespace AcademyWebAppAPI.DataTransferObjectsManagers.BranchDtosManager
{
    public class BranchDtosManager : IBranchDtosManager
    {
        private readonly IBranchRepository branchRepository;

        public BranchDtosManager(IBranchRepository branchRepository)
            => this.branchRepository = branchRepository;

        public List<BranchDto> GetAllDtos()
        {
            var branches = branchRepository.GetAll();
            var branchesDtos = new List<BranchDto>();

            branches?.ForEach(branch =>
            {
                branchesDtos.Add(new BranchDto(
                    branch.BranchName,
                    branch.SupervisorName,
                    branch.SupervisorPhoneNumber,
                    branch.SupervisorLandlineNumber,
                    branch.BranchId));
            });

            return branchesDtos;
        }

        public BranchDto? GetDtoById(int id)
        {
            var branch = branchRepository.GetById(id);

            return branch is null ?
                null
                : new BranchDto(
                    branch.BranchName,
                    branch.SupervisorName,
                    branch.SupervisorPhoneNumber,
                    branch.SupervisorLandlineNumber,
                    branch.BranchId);
        }

        public bool InsertEntityUsingDto(BranchDto entity)
        {
            return branchRepository.Insert(new Models.Branch()
            {
                BranchName = entity.Name,
                SupervisorName = entity.SupervisorName,
                SupervisorPhoneNumber = entity.SupervisorPhoneNumber,
                SupervisorLandlineNumber = entity.SupervisorLandlineNumber
            });
        }

        public bool UpdateEntityUsingDto(BranchDto entity)
        {
            return branchRepository.Update(new Models.Branch()
            {
                BranchId = entity.Id,
                BranchName = entity.Name,
                SupervisorName = entity.SupervisorName,
                SupervisorPhoneNumber = entity.SupervisorPhoneNumber,
                SupervisorLandlineNumber = entity.SupervisorLandlineNumber
            });
        }

        public bool DeleteEntity(int id)
        {
            return branchRepository.Delete(id);
        }
    }
}
