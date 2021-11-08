using Covid19Pcr.Application.ViewModels;
using Covid19Pcr.Common.ViewModels;
using Covid19Pcr.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.Interfaces
{
    public interface IBookingRepository
    {

        public ApiResponse<IEnumerable<BookingVm>> GetBookings(DateTime from, DateTime to, int page, int pageSize);
        public ApiResponse<IEnumerable<TestResultVm>> GetTestResults(int page, int pageSize, LabResultTypes? resultType);
    }
}
