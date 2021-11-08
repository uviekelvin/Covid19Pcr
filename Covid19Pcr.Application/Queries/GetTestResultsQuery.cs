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

namespace Covid19Pcr.Application.Queries
{
    public class GetTestResultsQuery : IRequest<ApiResponse<IEnumerable<TestResultVm>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public LabResultTypes? ResultType { get; set; }
    }


    public class GetTestResultsQueryHandler : IRequestHandler<GetTestResultsQuery, ApiResponse<IEnumerable<TestResultVm>>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTestResultsQueryHandler(IUnitofWork unitofWork, IMapper mapper)
        {
            this._unitOfWork = unitofWork;
            this._mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<TestResultVm>>> Handle(GetTestResultsQuery request, CancellationToken cancellationToken)
        {
            var testResultsQuery = await this._unitOfWork.Repository<Bookings>()
                .GetAllAsync(x => x.Status == BookingStatus.Completed || (request.ResultType.HasValue
                 && x.TestResult.ResultType == request.ResultType.Value), null,
                x => x.TestDay, x => x.TestDay.Lab, x => x.TestDay.Lab.Location, p => p.Patient);

            return ResponseMessage.SuccessMessage(this._mapper.Map<IEnumerable<TestResultVm>>(testResultsQuery));

        }
    }
}
