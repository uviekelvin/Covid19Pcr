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
    public class GetTestDayQuery : IRequest<ApiResponse<TestDaysWithLocationVm>>
    {
        public long Id { get; set; }
    }

    public class GetTestDayQueryHandler : IRequestHandler<GetTestDayQuery, ApiResponse<TestDaysWithLocationVm>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTestDayQueryHandler(IUnitofWork unitofWork, IMapper mapper)
        {
            this._unitOfWork = unitofWork;
            this._mapper = mapper;
        }

        public async Task<ApiResponse<TestDaysWithLocationVm>> Handle(GetTestDayQuery request, CancellationToken cancellationToken)
        {
            var testDay = await this._unitOfWork.Repository<TestDays>()
                 .GetFirstOrDefaultAsync(x => x.Id == request.Id, x => x.Lab, x => x.Lab.Location);
            if (testDay == null)
                return ResponseMessage.ErrorMessage<TestDaysWithLocationVm>("Testday not found");

            return ResponseMessage.SuccessMessage(this._mapper.Map<TestDaysWithLocationVm>(testDay));
        }
    }
}

