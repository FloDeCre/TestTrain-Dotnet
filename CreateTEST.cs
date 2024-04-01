using System;
using System.Threading.Tasks;
using UserDtoName;
using SimulationAPI;

namespace CreateTestName
{
    public static class CreateTest
    {
        private static readonly ApiIntegrationTests _apiIntegrationTests = new();

        public static async Task<Simulation<UserDTO>?> CreateUser(UserDTO userDTO)
        {
            return await _apiIntegrationTests.SendRequest("/Users", userDTO, HttpMethodType.Post);
        }

        public static async Task<bool> GetById(int userId)
        {
            return await _apiIntegrationTests.SendRequestForSuccess($"/Users/{userId}", HttpMethodType.Get);
        }

        public static async Task<Simulation<UserDTO[]>?> GetAllUser()
        {
            return await _apiIntegrationTests.SendRequest<UserDTO[]>("/Users", default(UserDTO[]), HttpMethodType.Get);
        }

        public static async Task<bool> DeleteById(int userId)
        {
            return await _apiIntegrationTests.SendRequestForSuccess($"/Users/{userId}", HttpMethodType.Delete);
        }

        public static async Task<bool> UpdateUser(UserDTO userDTO)
        {
            return await _apiIntegrationTests.SendRequestForSuccess($"/Users/{userDTO.Id}", HttpMethodType.Put, userDTO);
        }
    }
}
