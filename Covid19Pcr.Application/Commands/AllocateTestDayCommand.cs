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

namespace Covid19Pcr.Application.Commands
{
    public class AllocateTestDayCommand : IRequest<ApiResponse<TestDaysWithLocationVm>>
    {
        public long LabId { get; set; }
        public int AvailableSpace { get; set; }
        public DateTime Date { get; set; }

    }
    public class AllocateTestDayCommandHandler : IRequestHandler<AllocateTestDayCommand, ApiResponse<TestDaysWithLocationVm>>
    {
        private readonly IUnitofWork _unitOfWork;

        public AllocateTestDayCommandHandler(IUnitofWork unitofWork)
        {
            this._unitOfWork = unitofWork;
        }

        public async Task<ApiResponse<TestDaysWithLocationVm>> Handle(AllocateTestDayCommand request, CancellationToken cancellationToken)
        {
            var Lab = await this._unitOfWork.Repository<Labs>().GetFirstOrDefaultAsync(x => x.Id == request.LabId, x => x.Location);

            if (Lab == null)
                return ResponseMessage.ErrorMessage<TestDaysWithLocationVm>("Test Lab not found");
            Lab.AddTestDays(request.Date, request.AvailableSpace);

            return ResponseMessage.SuccessMessage(new TestDaysWithLocationVm
            {
                Id = Lab.TestDays.LastOrDefault().Id,
                Date = Lab.TestDays.LastOrDefault().Date,
                Lab = Lab.Name,
                AvailableSpace = Lab.TestDays.LastOrDefault().AvailableSpace,
                Location = Lab.Location.Name

            }, "Test day allocated successfully");
        }
    }
}
