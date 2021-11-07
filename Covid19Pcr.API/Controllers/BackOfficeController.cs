using Covid19Pcr.Application.Commands;
using Covid19Pcr.Application.Queries;
using Covid19Pcr.Application.ViewModels;
using Covid19Pcr.Common.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Covid19Pcr.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class BackOfficeController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<TestDaysWithLocationVm>), 200)]
        public async Task<IActionResult> AllocateTestDay([FromBody] AllocateTestDayCommand allocateTestDayCommand)
        {
            return CustomResponse(await this.Mediator.Send(allocateTestDayCommand));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<TestDaysWithLocationVm>), 200)]
        public async Task<IActionResult> GetTestDays([FromQuery] GetTestDaysQuery getTestDaysQuery)
        {
            return CustomResponse(await this.Mediator.Send(getTestDaysQuery));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ApiResponse<TestDaysWithLocationVm>), 200)]
        public async Task<IActionResult> GetTestDay([FromRoute] long id)
        {
            return CustomResponse(await this.Mediator.Send(new GetTestDayQuery { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<BookingVm>), 200)]
        public async Task<IActionResult> AddTestResult([FromBody] AddTestResultCommand addTestResultCommand)
        {
            return CustomResponse(await this.Mediator.Send(addTestResultCommand));
        }
    }
}
