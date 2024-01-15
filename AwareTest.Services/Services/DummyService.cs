using AwareTest.Common;
using AwareTest.Model.Model;
using AwareTest.Services.IService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AwareTest.Services.Services
{
    public class DummyService :IDummyService
    {
        private AppSettingsModel _appSettings;
        private static IConfiguration _configuration = null;
        private string baseUrl = string.Empty;

        public DummyService(IConfiguration configuration)
        {
            _configuration = configuration;
            _appSettings = new AppSettingsModel();

            if (string.IsNullOrEmpty(_configuration.GetSection("DummyAPI:BaseUrl").Value))
            {
                throw new Exception("Dummy url is null");
            }
            else
            {
                _appSettings.BaseUrl = _configuration.GetSection("DummyAPI:BaseUrl").Value;
            }

            if (string.IsNullOrEmpty(_configuration.GetSection("DummyAPI:GetAll").Value))
            {
                throw new Exception("Dummy url GetAll is null");
            }
            else
            {
                _appSettings.GetEmployeeAll = _configuration.GetSection("DummyAPI:GetAll").Value;
            }
        }
        public async Task<string> GetDummyEmployee()
        {
            string result = string.Empty;
            try
            {
                
                using (var httpClient = new HttpClient())
                {
                    string urlPath = _appSettings.BaseUrl;
                    string route = _appSettings.GetEmployeeAll;
                    UriBuilder builder = new UriBuilder(String.Format("{0}{1}", urlPath, route));
                    HttpResponseMessage response = await httpClient.GetAsync(builder.Uri);
                    if (response.IsSuccessStatusCode)
                    {
                        HttpContent httpContent = response.Content;
                        result = await httpContent.ReadAsStringAsync();
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("GetDummyEmployee : " + ex);
            }
            return result;
        }
    }
}
