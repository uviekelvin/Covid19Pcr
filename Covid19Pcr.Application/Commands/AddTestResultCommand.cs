using AutoMapper;
using Covid19Pcr.Application.Interfaces;
using Covid19Pcr.Application.ViewModels;
using Covid19Pcr.Common.ViewModels;
using Covid19Pcr.Domain.Enums;
using Covid19Pcr.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.Commands
{
    public class AddTestResultCommand : IRequest<ApiResponse<BookingVm>>
    {

        public string BookingCode { get; set; }

        public LabResultTypes ResultType { get; set; }

        public string Remarks { get; set; }
    }

    public class AddTestCommandHandler : IRequestHandler<AddTestResultCommand, ApiResponse<BookingVm>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddTestCommandHandler(IUnitofWork unitofWork, IMapper mapper)
        {
            this._unitOfWork = unitofWork;
            this._mapper = mapper;
        }

        public async Task<ApiResponse<BookingVm>> Handle(AddTestResultCommand request, CancellationToken cancellationToken)
        {
            var booking = await this._unitOfWork.Repository<Bookings>()
                .GetFirstOrDefaultAsync(x => x.BookingCode == request.BookingCode,
                l => l.TestDay, l => l.TestDay.Lab,
                l => l.TestDay.Lab.Location, p => p.Patient,
                ty => ty.TestType);
            if (booking == null)
                return ResponseMessage.ErrorMessage<BookingVm>("Invalid Booking Code");

            booking.AddTestResult(request.ResultType, request.Remarks);
            await this._unitOfWork.Complete();
            return ResponseMessage.SuccessMessage(this._mapper.Map<BookingVm>(booking), "Test result added");
        }
    }
}
