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
        public int Page { get; set; } =1;
        public int PageSize { get; set; } = 10;
        public int? ResultType { get; set; }
    }


    public class GetTestResultsQueryHandler : IRequestHandler<GetTestResultsQuery, ApiResponse<IEnumerable<TestResultVm>>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;

        public GetTestResultsQueryHandler(IUnitofWork unitofWork, IMapper mapper, IBookingRepository bookingRepository)
        {
            this._unitOfWork = unitofWork;
            this._mapper = mapper;
            this._bookingRepository = bookingRepository;
        }

        public async Task<ApiResponse<IEnumerable<TestResultVm>>> Handle(GetTestResultsQuery request, CancellationToken cancellationToken)
        {
            return this._bookingRepository.GetTestResults(request.Page, request.PageSize, request.ResultType);

        }
    }
}
