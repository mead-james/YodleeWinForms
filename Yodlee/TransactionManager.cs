using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Yodlee
{
    public class TransactionManager
    {
        /// <summary>
        /// Gets transactions for an account within a given date-range
        /// </summary>
        /// <param name="authToken">Authorization token to access the Yodlee API through a user</param>
        /// <param name="fromDate">Start date of the range</param>
        /// <param name="toDate">End date of the range</param>
        /// <returns></returns>
        public async Task<Transactions> GetTransactions(string authToken, string accountSelected, string fromDate, string toDate)
        {
            string tokenRequestUri = @"https://sandbox.api.yodlee.com:443/ysl/transactions"
                + @"?accountId=" + accountSelected + @"&fromDate=" + fromDate + @"&toDate=" + toDate;

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
            var result = JsonConvert.DeserializeObject<Transactions>(jsonString);

            // Convert the response to a string
            return result;
        }
    }
}
