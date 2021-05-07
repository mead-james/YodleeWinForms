using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Yodlee
{
    public class UserManager
    {
        /// <summary>
        /// Gets data for a user by their user ID
        /// </summary>
        /// <returns>Data about a user</returns>
        public async Task<Users> GetUser(string authToken)
        {
            const string tokenRequestUri = @"https://sandbox.api.yodlee.com:443/ysl/user";

            // Create the request to send to Yodlee
            var request = new HttpRequestMessage(HttpMethod.Get, tokenRequestUri);

            // Create the HttpClient object and add the version header
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("API-VERSION", "1.1");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            // Use the HttpClient created to send the request
            var response = await client.SendAsync(request);

            // Convert the response to a string
            var jsonString = await response.Content.ReadAsStringAsync();

            // Convert the Json string to an object
            var result = JsonConvert.DeserializeObject<Users>(jsonString);

            return result;
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <returns></returns>
        public async Task<bool> UpdateUser(string authToken, Users userObj)
        {
            string tokenRequestUri = @"https://sandbox.api.yodlee.com:443/ysl/user";

            // NEED TO CREATE JSON TO SENT and SERIALIZE IT
            var userJson = JsonConvert.SerializeObject(userObj);

            // Create the request to send to Yodlee
            var request = new HttpRequestMessage(HttpMethod.Put, tokenRequestUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(userJson);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Create the HttpClient object and add the version header
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("API-VERSION", "1.1");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            // Use the HttpClient created to send the request
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteUser(string authToken)
        {
            string tokenRequestUri = @"https://sandbox.api.yodlee.com:443/ysl/user/unregister";

            // Create the request to send to Yodlee
            var request = new HttpRequestMessage(HttpMethod.Delete, tokenRequestUri);

            // Create the HttpClient object and add the version header
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("API-VERSION", "1.1");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            // Use the HttpClient created to send the request
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
