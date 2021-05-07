using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Yodlee
{
    public class TokenManager
    {
        /// <summary>
        /// Creates an authorization token based on the selected user.
        /// </summary>
        /// <param name="userId">Selected user's user ID</param>
        /// <returns>Authorization token to access Yodlee APIs for the selected user</returns>
        public async Task<string> CreateAuthToken(string userId)
        {
            const string tokenRequestUri = @"https://sandbox.api.yodlee.com:443/ysl/auth/token";
            const string clientId = "yUDD4TKHA76onJwviRtTHAGUimKt4soC";
            const string secret = "pUoJYfR4ykr5MqF0";

            // Create the request to send to Yodlee
            var request = new HttpRequestMessage(HttpMethod.Post, tokenRequestUri);

            // Build the content and add it to the request
            var payload = "clientId=" + clientId + "&secret=" + secret;
            var stringContent = new StringContent(payload, Encoding.UTF8, "application/x-www-form-urlencoded");
            request.Content = stringContent;

            // Add header to the request with the required loginName
            request.Content.Headers.Add("loginName", userId);

            // Create the HttpClient object and add the version header
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("API-VERSION", "1.1");

            // Use the HttpClient created to send the request
            var response = await client.SendAsync(request);

            // Convert the response to a string
            var jsonString = await response.Content.ReadAsStringAsync();

            // Convert the Json string to an object
            AuthorizationToken result = JsonConvert.DeserializeObject<AuthorizationToken>(jsonString);

            // Extract the access token from the result object and return it
            return result.token.accessToken;
        }
    }
}
