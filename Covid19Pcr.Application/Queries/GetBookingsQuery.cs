using AutoMapper;
using Covid19Pcr.Application.Interfaces;
using Covid19Pcr.Application.ViewModels;
using Covid19Pcr.Common.ViewModels;
using Covid19Pcr.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.Queries
{
    public class GetBookingsQuery : IRequest<ApiResponse<IEnumerable<BookingVm>>>
    {
        public DateTime From { get; set; } = DateTime.Now.AddMonths(-1);
        public DateTime To { get; set; } = DateTime.Now;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 2;
    }

    public class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery, ApiResponse<IEnumerable<BookingVm>>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public GetBookingsQueryHandler(IUnitofWork unitofWork, IBookingRepository bookingRepository, IMapper mapper)
        {
            this._unitOfWork = unitofWork;
            this._bookingRepository = bookingRepository;
            this._mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<BookingVm>>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {

            //var bookings = await this._unitOfWork.Repository<Bookings>()
            //    .GetAllAsync(x => x.DateCreated.Date >= request.From.Date &&
            //    x.DateCreated.Date <= request.To.Date, null,
            //    x => x.TestDay, x => x.TestDay.Lab, x => x.TestDay.Lab.Location, x => x.TestType, p => p.Patient);


            return this._bookingRepository.GetBookings(request.From, request.To, request.Page, request.PageSize);
        }
    }
}
