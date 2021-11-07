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

namespace Covid19Pcr.Application.Commands
{
    public class CancelBookingCommand : IRequest<ApiResponse<BookingVm>>
    {
        public string Email { get; set; }
        public string BookingCode { get; set; }
    }


    public class CancelBookingCommandHandler : IRequestHandler<CancelBookingCommand, ApiResponse<BookingVm>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;

        public CancelBookingCommandHandler(IPatientRepository patientRepository, 
            IMapper mapper,
            IUnitofWork unitofWork)
        {
            this._patientRepository = patientRepository;
            this._mapper = mapper;
            this._unitOfWork = unitofWork;
        }

        public async Task<ApiResponse<BookingVm>> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            var patient = await this._patientRepository.GetPatientWithBooking(request.Email, request.BookingCode);
            if (patient == null)
                return ResponseMessage.ErrorMessage<BookingVm>("Patient not found");
            patient.CancelBooking(request.BookingCode);
            await this._unitOfWork.Complete();
            return ResponseMessage.SuccessMessage(this._mapper.Map<BookingVm>(patient.Bookings.FirstOrDefault()), "Booking Cancelled");
        }
    }
}
