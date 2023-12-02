// UserService.cs

using System.Net.Http;
using System.Threading.Tasks;
using FinalFN.Data;
using FinalFN.Pages;

//NOT IMPLEMENTED YET

namespace FinalFN.Services
{
    public class UserService
    {


        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserProfile>> GetUserProfiles()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<UserProfile>>("http://localhost:80/user-profiles/");
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
                return new List<UserProfile>();
            }
        }

        public async Task<UserProfile> GetUserProfile(int userId)
        {
            return await _httpClient.GetFromJsonAsync<UserProfile>($"http://localhost:80/user-profiles/{userId}");
        }

        public async Task UpdateUserProfile(UserProfile updatedProfile)
        {
            await _httpClient.PutAsJsonAsync($"http://localhost:80/user-profiles/{updatedProfile.UserId}", updatedProfile);
        }
    }
}
