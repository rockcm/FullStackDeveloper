namespace FinalFN.Services
{
    // SkinService.cs
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks; 
    using FinalFN.Data;
    using Newtonsoft.Json;
    public class SkinService
    {
        private readonly HttpClient _httpClient;

        public SkinService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Skin>> GetAllSkins()
        {
            return await _httpClient.GetFromJsonAsync<List<Skin>>("http://localhost:80/skins/");
        }

        public async Task AddUserSkin(Skin newSkin)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(newSkin), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:80/skins/", jsonContent);

            response.EnsureSuccessStatusCode();
        }

        public async Task<Skin> DeleteSkin(int skinId)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:80/skins/{skinId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Skin>();
            }
            else
            {
                // Handle the error accordingly
                return null;
            }
        }

        public async Task<Skin> GetSkinById(int id)
        {
            var apiUrl = $"http://localhost:80/skins/{id}";

            using (var response = await _httpClient.GetAsync(apiUrl))
            {
                response.EnsureSuccessStatusCode();

                // Deserialize the response content to Skin type
                return await response.Content.ReadFromJsonAsync<Skin>();
            }
        }

        public async Task<Skin> UpdateSkin(int skinId, SkinUpdate updatedSkin)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(updatedSkin), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"http://localhost:80/skins/{skinId}", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Skin>();
            }
            else
            {
                // Handle the error accordingly
                return null;
            }
        }


        public async Task<List<Skin>> GetUserSkins()
        {
            return await _httpClient.GetFromJsonAsync<List<Skin>>("http://localhost:80/user-skins/");
        }

        public async Task<Skin> AddUsersSkin(Skin newSkin)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(newSkin), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:80/user-skins/", jsonContent);

            response.EnsureSuccessStatusCode();
            return newSkin;
        }

        public async Task<Skin> DeleteUserSkin(int userSkinId)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:80/user-skins/{userSkinId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Skin>();
            }
            else
            {
                
                return null;
            }
        }

        public async Task<Skin> UpdateUserSkin(int userSkinId, SkinUpdate updatedUserSkin)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(updatedUserSkin), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"http://localhost:80/user-skins/{userSkinId}", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Skin>();
            }
            else
            {
                
                return null;
            }
        }

        public async Task<Skin> AddUserSkin2(Skin newSkin)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(newSkin), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:80/user-skins/", jsonContent);

            response.EnsureSuccessStatusCode();
            return newSkin;
        }



        public async Task<Skin> AddUserSkinByName(string skinName)
        {
            try
            {
                // Call the service to add a new user skin by name
                var apiUrl = "http://localhost:80/user-skins/";

                // Create a new Skin object with the provided name
                var newSkin = new SkinUpdate { Name = skinName };

                // Serialize the newSkin object to JSON
                var jsonContent = new StringContent(JsonConvert.SerializeObject(newSkin), Encoding.UTF8, "application/json");

                // Make the POST request to add the user skin
                var response = await _httpClient.PostAsync(apiUrl, jsonContent);

                response.EnsureSuccessStatusCode();

                // Deserialize the response content to Skin type
                return await response.Content.ReadFromJsonAsync<Skin>();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error in AddUserSkinByName: {ex.Message}");
                return null;
            }
        }

        public async Task<Skin> GetSkinByName(string name)
        {
            try
            {
                // Call the service to get a skin by its name
                var apiUrl = $"http://localhost:80/skins?name={name}";

                using (var response = await _httpClient.GetAsync(apiUrl))
                {
                    response.EnsureSuccessStatusCode();

                    // Deserialize the response content to Skin type
                    return await response.Content.ReadFromJsonAsync<Skin>();
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error in GetSkinByName: {ex.Message}");
                return null;
            }
        }

        public async Task<Skin> AddUserSkinById(int skinId)
        {
            try
            {
                var apiUrl = "http://localhost:80/user-skins/";

                // Create a new Skin object with the provided ID
                var newSkin = new SkinUpdate { Id = skinId };

                var jsonContent = new StringContent(JsonConvert.SerializeObject(newSkin), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(apiUrl, jsonContent);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Skin>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddUserSkinById: {ex.Message}");
                return null;
            }
        }

        // New method to add a user skin based on the selected skin's ID
        public async Task<Skin> AddUserSkinBySelectedSkin(Skin selectedSkin)
        {
            try
            {
                Console.WriteLine($"Adding user skin by selected skin: {JsonConvert.SerializeObject(selectedSkin)}");
                if (selectedSkin == null)
                {
                    Console.WriteLine("Selected skin is null.");
                    return null;
                }

                var apiUrl = "http://localhost:80/user-skins/";

                // Create a new SkinUpdate object with the ID of the selected skin
                var newSkin = new SkinUpdate { Id = selectedSkin.Id };

                var jsonContent = new StringContent(JsonConvert.SerializeObject(newSkin), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(apiUrl, jsonContent);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Skin>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddUserSkinBySelectedSkin: {ex.Message}");
                return null;
            }
        }
        public async Task<Skin> GetSkinById2(int id)
        {
            try
            {
                // Call the service to get a skin by ID
                var apiUrl = $"http://localhost:80/skins/{id}";

                using (var response = await _httpClient.GetAsync(apiUrl))
                {
                    response.EnsureSuccessStatusCode();

                    // Deserialize the response content to Skin type
                    return await response.Content.ReadFromJsonAsync<Skin>();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error in GetSkinById: {ex.Message}");
                return null;
            }
        }

       

    }



}
