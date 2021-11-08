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
    public class GetTestResultQuery : IRequest<ApiResponse<TestResultVm>>
    {
        public string BookingCode { get; set; }

        public string Email { get; set; }
    }


    public class GetTestResltQueryHandler : IRequestHandler<GetTestResultQuery, ApiResponse<TestResultVm>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTestResltQueryHandler(IUnitofWork unitofWork, IMapper mapper)
        {
            this._unitOfWork = unitofWork;
            this._mapper = mapper;
        }

        public async Task<ApiResponse<TestResultVm>> Handle(GetTestResultQuery request, CancellationToken cancellationToken)
        {
            var testResult = await this._unitOfWork.Repository<Bookings>()
                .GetFirstOrDefaultAsync(x => x.Patient.Email == request.Email && x.BookingCode == request.BookingCode, x => x.TestDay,
                l => l.TestDay.Lab, l => l.TestDay.Lab.Location, p => p.Patient);

            if (testResult == null)
                return ResponseMessage.ErrorMessage<TestResultVm>("Invalid Booking code");

            testResult.ViewTestResult();

            return ResponseMessage.SuccessMessage(this._mapper.Map<TestResultVm>(testResult));
        }
    }
}
