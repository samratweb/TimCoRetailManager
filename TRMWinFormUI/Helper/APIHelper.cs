using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TRMWinFormUI.Helper
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient ApiClient { get; set; }
        private ILoggedInUser _loggedInUser;
        public APIHelper()
        {
            InitializedClient();
            _loggedInUser = new LoggedInUser();
        }
        private void InitializedClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(api);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type","password"),
                new KeyValuePair<string, string>("username",username),
                new KeyValuePair<string, string>("password",password),
            });
            HttpResponseMessage response = await ApiClient.PostAsync("/Token", data);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                await GetLoggedInUserInfo(result.Access_Token);
                return result;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task GetLoggedInUserInfo(string token)
        {
            ApiClient.DefaultRequestHeaders.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage response = await ApiClient.GetAsync("/api/User");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<LoggedInUser>();
                _loggedInUser.CreatedDate = result.CreatedDate;
                _loggedInUser.EmailAddress = result.EmailAddress;
                _loggedInUser.FirstName = result.FirstName;
                _loggedInUser.Id = result.Id;
                _loggedInUser.LastName = result.LastName;
                _loggedInUser.Token = token;
                frmMain._loggedInUser = _loggedInUser;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
