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
    public class GetTestDaysQuery : IRequest<ApiResponse<IEnumerable<TestDaysWithLocationVm>>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }

    public class GetTestDaysQueryHandler : IRequestHandler<GetTestDaysQuery, ApiResponse<IEnumerable<TestDaysWithLocationVm>>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTestDaysQueryHandler(IUnitofWork unitofWork, IMapper mapper)
        {
            this._unitOfWork = unitofWork;
            this._mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<TestDaysWithLocationVm>>> Handle(GetTestDaysQuery request, CancellationToken cancellationToken)
        {
            var testDays = await this._unitOfWork.Repository<TestDays>().GetAllAsync(null, null, x => x.Lab, l => l.Lab.Location);
            return ResponseMessage.SuccessMessage(_mapper.Map<IEnumerable<TestDaysWithLocationVm>>(testDays));
        }
    }
}
