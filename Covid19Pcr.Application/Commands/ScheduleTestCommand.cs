using Covid19Pcr.Application.Interfaces;
using Covid19Pcr.Common.ViewModels;
using Covid19Pcr.Domain.Models;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.Commands
{
    public class ScheduleTestCommand : IRequest<ApiResponse<string>>
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long TestTypeId { get; set; }
        public long TestDayId { get; set; }
    }

    public class ScheduleTestCommandHandler : IRequestHandler<ScheduleTestCommand, ApiResponse<string>>
    {
        private readonly IUnitofWork _unitOfWork;

        public ScheduleTestCommandHandler(IUnitofWork unitofWork)
        {
            this._unitOfWork = unitofWork;
        }

        public async Task<ApiResponse<string>> Handle(ScheduleTestCommand request, CancellationToken cancellationToken)
        {

            var testDay = await this._unitOfWork.Repository<TestDays>().GetFirstOrDefaultAsync(x => x.Id == request.TestDayId,
                l => l.Lab, l => l.Lab.Location);
            if (testDay == null)
                return ResponseMessage.ErrorMessage("The selected test day is not found");

            var testType = await this._unitOfWork.Repository<TestTypes>().GetFirstOrDefaultAsync(x => x.Id == request.TestTypeId);
            if (testType == null)
                return ResponseMessage.ErrorMessage("The selected test type is not found");

            var patient = await this._unitOfWork.Repository<Patients>()
                .GetFirstOrDefaultAsync(x => !string.IsNullOrEmpty(x.Email) && x.Email == request.Email || x.PhoneNumber == x.PhoneNumber);

            if (patient == null)
            {
                patient = new Patients(request.FirstName, request.SurName, request.Email, request.PhoneNumber);
                this._unitOfWork.Repository<Patients>().Add(patient);
            }
            patient.CreateBooking(testDay, request.TestTypeId);
            await this._unitOfWork.Complete();
            return ResponseMessage.SuccessMessage(patient.Bookings.LastOrDefault().BookingCode, "Booking scheduled successfully");

        }
    }
}
