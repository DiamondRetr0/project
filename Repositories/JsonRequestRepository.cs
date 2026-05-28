using System.Text.Json;
using RepairSystem.Models;

namespace RepairSystem.Repositories
{
    public class JsonRequestRepository : IRequestRepository
    {
        private readonly string _filePath = "Data/requests.json";

        public List<UserRequest> GetAll()
        {
            if (!File.Exists(_filePath))
                return new List<UserRequest>();

            var json = File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<List<UserRequest>>(json)
                   ?? new List<UserRequest>();
        }

        public UserRequest GetById(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void Add(UserRequest request)
        {
            var requests = GetAll();
            requests.Add(request);
            Save(requests);
        }

        public void Update(UserRequest request)
        {
            var requests = GetAll();

            var existing = requests.FirstOrDefault(x => x.Id == request.Id);

            if (existing != null)
            {
                requests.Remove(existing);
                requests.Add(request);
                Save(requests);
            }
        }

        public void Delete(Guid id)
        {
            var requests = GetAll();

            var request = requests.FirstOrDefault(x => x.Id == id);

            if (request != null)
            {
                requests.Remove(request);
                Save(requests);
            }
        }

        private void Save(List<UserRequest> requests)
        {
            var json = JsonSerializer.Serialize(requests,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(_filePath, json);
        }
    }
}