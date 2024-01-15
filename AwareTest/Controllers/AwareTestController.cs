using AwareTest.Model.Model;
using AwareTest.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace AwareTest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AwareTestController : ControllerBase
    {
        private readonly IDummyService _dummyService;
        public AwareTestController(IDummyService dummyService) 
        {
            _dummyService = dummyService;
        }

        [HttpGet("CallFreeApi/GetDummyEmployee")]
        public async Task<string> GetDummyEmployee()
        {
            try
            {
                string result = string.Empty;
                result = await _dummyService.GetDummyEmployee();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetDummyEmployee : " + ex);
                return string.Empty;
            }
        }
    }
}
