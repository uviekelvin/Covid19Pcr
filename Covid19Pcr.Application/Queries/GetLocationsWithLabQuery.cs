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
    public class GetLocationsWithLabQuery : IRequest<ApiResponse<IEnumerable<GetlocationsAndLabWithTestDayVm>>>
    {

    }

    public class GetLocationsAndLabQueryHandler : IRequestHandler<GetLocationsWithLabQuery, ApiResponse<IEnumerable<GetlocationsAndLabWithTestDayVm>>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLocationsAndLabQueryHandler(IUnitofWork unitofWork, IMapper mapper)
        {
            this._unitOfWork = unitofWork;
            this._mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<GetlocationsAndLabWithTestDayVm>>> Handle(GetLocationsWithLabQuery request, CancellationToken cancellationToken)
        {
            var locationsWithLabs = await this._unitOfWork.Repository<Locations>().GetAllAsync(null, null, x => x.Labs);

            return ResponseMessage.SuccessMessage(this._mapper.Map<IEnumerable<GetlocationsAndLabWithTestDayVm>>(locationsWithLabs));
        }
    }
}
