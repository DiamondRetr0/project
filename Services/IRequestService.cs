using RepairSystem.Models;

namespace RepairSystem.Services
{
    public interface IRequestService
    {
        List<UserRequest> GetAllRequests();

        UserRequest GetRequestById(Guid id);

        void CreateRequest(UserRequest request);

        void UpdateRequest(UserRequest request);

        void DeleteRequest(Guid id);
    }
}