using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Selise.AppSuite.Common;

namespace FreeSound
{
    public class Identity // response
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
    }

    public class TokenIssuer // request
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string grant_type { get; set; }
        public string refresh_token { get; set; }

        public static TokenIssuer CreateNew(string _client_id, string _client_secret, string _grant_type, string _refresh_token)
        {
            return new TokenIssuer()
            {
                client_id = _client_id,
                refresh_token = _refresh_token,
                client_secret = _client_secret,
                grant_type = _grant_type
            };
        }
    }
    public class Authentication
    {

        public static Identity idendity = new Identity(); 
        public static void InitIdentity()
        {
            idendity.access_token = ConfigurationSettings.AppSettings.Get("access_token");
            idendity.token_type = ConfigurationSettings.AppSettings["token_type"];
            idendity.expires_in = ConfigurationSettings.AppSettings["expires_in"];
            idendity.refresh_token = ConfigurationSettings.AppSettings["refresh_token"];
            idendity.scope = ConfigurationSettings.AppSettings["scope"];
        }


        public static void IssueNewToken()
        {
            TokenIssuer tokenIssuer = TokenIssuer.CreateNew(ConfigurationSettings.AppSettings["client_id"], ConfigurationSettings.AppSettings["client_secret"], "refresh_token", idendity.refresh_token);
            RestClient<TokenIssuer> restClient = new RestClient<TokenIssuer>(HttpMethod.Post,
                ConfigurationSettings.AppSettings["AuthBaseUrl"], String.Empty, tokenIssuer,
                MediaTypes.ApplicationXUrlEncoded);
            HttpRequestMessage postData = restClient.CreateHttpRequest();

            return;
            HttpClient client = new HttpClient();
            var response = client.SendAsync(postData).Result;
            var stringContent =  response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                idendity = JsonConvert.DeserializeObject<Identity>(stringContent);
            }
            else
            {
                Console.WriteLine("Failed to get new token");
            }
        }
    }
}
