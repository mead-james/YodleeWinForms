using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Yodlee
{
    public class AccountManager
    {
        /// <summary>
        /// Gets data for all of a user's accounts.
        /// </summary>
        /// <returns>Data about all of a user's accounts</returns>
        public async Task<Accounts> GetAccounts(string authToken)
        {
            const string tokenRequestUri = @"https://sandbox.api.yodlee.com:443/ysl/accounts";

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
            var result = JsonConvert.DeserializeObject<Accounts>(jsonString);

            // Convert the response to a string
            return result;
        }

        /// <summary>
        /// Deletes an account
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteAccount(string authToken, string accountId)
        {
            string tokenRequestUri = @"https://sandbox.api.yodlee.com:443/ysl/accounts/" + accountId;

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
