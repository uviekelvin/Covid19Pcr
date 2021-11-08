using Covid19Pcr.Application.Interfaces;
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
    public class AddMoreSpaceCommand : IRequest<ApiResponse<int>>
    {
        public int Space { get; set; }
        public long TestDayId { get; set; }
    }


    public class AddMoreSpaceCommandHandler : IRequestHandler<AddMoreSpaceCommand, ApiResponse<int>>
    {
        private readonly IUnitofWork unitofWork;

        public AddMoreSpaceCommandHandler(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        public async Task<ApiResponse<int>> Handle(AddMoreSpaceCommand request, CancellationToken cancellationToken)
        {
            var testDay = await this.unitofWork.Repository<TestDays>().GetFirstOrDefaultAsync(x => x.Id == request.TestDayId);
            if (testDay == null) return ResponseMessage.ErrorMessage<int>("Invalid Test Day");
            testDay.AddMoreSpace(request.Space);
            await this.unitofWork.Complete();
            return ResponseMessage.SuccessMessage<int>(testDay.AvailableSpace, "Space added");
        }
    }
}
