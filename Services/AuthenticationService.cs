using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SwanCity.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;
        private const string FirebaseApiKey = "AIzaSyClbVS4RHgi976KOGnXVlBoBwzt0-sZ6BM";
        private const string FirebaseAuthUrl = "https://identitytoolkit.googleapis.com/v1/accounts:";

        public AuthenticationService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string?> RegisterUserAsync(string? email, string? password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Email and password cannot be null or empty");
            }

            var request = new
            {
                email,
                password,
                returnSecureToken = true
            };

            var jsonContent = JsonSerializer.Serialize(request);
            if (jsonContent == null)
            {
                throw new InvalidOperationException("Failed to serialize authentication request");
            }

            var response = await _httpClient.PostAsync(
                $"{FirebaseAuthUrl}signUp?key={FirebaseApiKey}",
                new StringContent(jsonContent, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            var authResponse = JsonSerializer.Deserialize<FirebaseAuthResponse>(responseData);
            return authResponse?.IdToken ?? throw new InvalidOperationException("Authentication failed: No ID token received");
        }

        public async Task<string> LoginUserAsync(string? email, string? password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Email and password cannot be null or empty");
            }

            var request = new
            {
                email,
                password,
                returnSecureToken = true
            };

            var jsonContent = JsonSerializer.Serialize(request);
            if (jsonContent == null)
            {
                throw new InvalidOperationException("Failed to serialize authentication request");
            }

            try
            {
                var response = await _httpClient.PostAsync(
                    $"{FirebaseAuthUrl}signInWithPassword?key={FirebaseApiKey}",
                    new StringContent(jsonContent, Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Firebase authentication failed: {response.StatusCode} - {errorContent}");
                }

                var responseData = await response.Content.ReadAsStringAsync();
                var authResponse = JsonSerializer.Deserialize<FirebaseAuthResponse>(responseData);
                
                if (authResponse?.IdToken == null)
                {
                    throw new InvalidOperationException("Authentication failed: No ID token received. Response: " + responseData);
                }

                return authResponse.IdToken;
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Network error during authentication: " + ex.Message, ex);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Failed to parse authentication response: " + ex.Message, ex);
            }
        }

        public async Task ResetPasswordAsync(string? email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be null or empty");
            }

            var request = new
            {
                requestType = "PASSWORD_RESET",
                email
            };

            var jsonContent = JsonSerializer.Serialize(request);
            if (jsonContent == null)
            {
                throw new InvalidOperationException("Failed to serialize password reset request");
            }

            var response = await _httpClient.PostAsync(
                $"{FirebaseAuthUrl}sendOobCode?key={FirebaseApiKey}",
                new StringContent(jsonContent, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        private class FirebaseAuthResponse
        {
            [JsonPropertyName("idToken")]
            public string? IdToken { get; set; }
            
            [JsonPropertyName("localId")]
            public string? LocalId { get; set; }
            
            [JsonPropertyName("email")]
            public string? Email { get; set; }
            
            [JsonPropertyName("refreshToken")]
            public string? RefreshToken { get; set; }
            
            [JsonPropertyName("expiresIn")]
            public string? ExpiresIn { get; set; }
        }

        public async Task<string?> GetCurrentUserIdAsync()
        {
            var idToken = await GetCurrentIdTokenAsync();
            if (string.IsNullOrEmpty(idToken))
            {
                return null;
            }

            var response = await _httpClient.PostAsync(
                $"{FirebaseAuthUrl}lookup?key={FirebaseApiKey}",
                new StringContent(JsonSerializer.Serialize(new { idToken }), 
                                Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            var authResponse = JsonSerializer.Deserialize<FirebaseAuthResponse>(responseData);
            return authResponse?.LocalId;
        }

        private async Task<string?> GetCurrentIdTokenAsync()
        {
            // TODO: Implement token retrieval from secure storage
            return await Task.FromResult<string?>(null);
        }
    }
}
