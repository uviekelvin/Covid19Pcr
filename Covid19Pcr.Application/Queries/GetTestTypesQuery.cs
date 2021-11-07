using Covid19Pcr.Application.Interfaces;
using Covid19Pcr.Application.ViewModels;
using Covid19Pcr.Common.ViewModels;
using Covid19Pcr.Domain.Models;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.Queries
{
    public class GetTestTypesQuery : IRequest<ApiResponse<IEnumerable<GetTestTypeVm>>>
    {
    }

    public class GetTestTypeQueryHandler : IRequestHandler<GetTestTypesQuery, ApiResponse<IEnumerable<GetTestTypeVm>>>
    {
        private readonly IUnitofWork _unitOfWork;

        public GetTestTypeQueryHandler(IUnitofWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<GetTestTypeVm>>> Handle(GetTestTypesQuery request, CancellationToken cancellationToken)
        {

            var testTypes = await this._unitOfWork.Repository<TestTypes>().Find(x => !x.IsDeleted);

            return ResponseMessage.SuccessMessage(testTypes.Select(t => new GetTestTypeVm { Id = t.Id, Name = t.Name }));
        }
    }
}
