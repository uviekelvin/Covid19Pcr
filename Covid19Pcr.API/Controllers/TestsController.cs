using Covid19Pcr.Application.Commands;
using Covid19Pcr.Application.Queries;
using Covid19Pcr.Application.ViewModels;
using Covid19Pcr.Common.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Covid19Pcr.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class TestsController : BaseController
    {
        private readonly IMediator _mediator;

        public TestsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public async Task<IActionResult> Schedule([FromBody] ScheduleTestCommand bookTestCommand)
        {

            return CustomResponse(await this._mediator.Send(bookTestCommand));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public async Task<IActionResult> CancelBooking([FromBody] CancelBookingCommand cancelBookingCommand)
        {
            return CustomResponse(await this._mediator.Send(cancelBookingCommand));
        }
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<GetTestTypeVm>>), 200)]
        public async Task<IActionResult> GetTestTypes()
        {
            return CustomResponse(await this._mediator.Send(new GetTestTypesQuery()));
        }

        [HttpGet]

        [ProducesResponseType(typeof(ApiResponse<IEnumerable<GetlocationsAndLabWithTestDayVm>>), 200)]
        public async Task<IActionResult> GetLabLocationsAndTestDays()
        {
            return CustomResponse(await this._mediator.Send(new GetLocationandLabsWithTestDaysQuery()));
        }


        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<BookingVm>), 200)]
        public async Task<IActionResult> GetBookings([FromQuery] GetBookingsQuery getBookingsQuery)
        {
            return CustomResponse(await this.Mediator.Send(getBookingsQuery));
        }
    }
}
