using RepairSystem.Models;
using RepairSystem.Repositories;

namespace RepairSystem.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repository;

        public RequestService(IRequestRepository repository)
        {
            _repository = repository;
        }

        public List<UserRequest> GetAllRequests()
        {
            return _repository.GetAll();
        }

        public UserRequest GetRequestById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void CreateRequest(UserRequest request)
        {
            _repository.Add(request);
        }

        public void UpdateRequest(UserRequest request)
        {
            _repository.Update(request);
        }

        public void DeleteRequest(Guid id)
        {
            _repository.Delete(id);
        }
    }
}