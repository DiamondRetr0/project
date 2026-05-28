using RepairSystem.Models;

namespace RepairSystem.Repositories
{
    public interface IRequestRepository
    {
        List<UserRequest> GetAll();

        UserRequest GetById(Guid id);

        void Add(UserRequest request);

        void Update(UserRequest request);

        void Delete(Guid id);
    }
}