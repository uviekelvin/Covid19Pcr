using AutoMapper;
using Covid19Pcr.Application.Interfaces;
using Covid19Pcr.Application.ViewModels;
using Covid19Pcr.Common.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.Queries
{
    public class GetLocationandLabsWithTestDaysQuery : IRequest<ApiResponse<IEnumerable<GetlocationsAndLabWithTestDayVm>>>
    {
    }


    public class GetLocationandLabsWithTestDaysQueryHandler :
        IRequestHandler<GetLocationandLabsWithTestDaysQuery, ApiResponse<IEnumerable<GetlocationsAndLabWithTestDayVm>>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetLocationandLabsWithTestDaysQueryHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            this._patientRepository = patientRepository;
            this._mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<GetlocationsAndLabWithTestDayVm>>> Handle(GetLocationandLabsWithTestDaysQuery request, CancellationToken cancellationToken)
        {
            var locations = await this._patientRepository.GetLocationWithLabsAndTestDays();

            return ResponseMessage.SuccessMessage(_mapper.Map<IEnumerable<GetlocationsAndLabWithTestDayVm>>(locations));
        }
    }
}
