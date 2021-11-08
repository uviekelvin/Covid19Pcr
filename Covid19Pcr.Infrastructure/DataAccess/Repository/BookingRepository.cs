using Covid19Pcr.Application.Interfaces;
using Covid19Pcr.Application.ViewModels;
using Covid19Pcr.Common.ViewModels;
using Covid19Pcr.Domain.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Infrastructure.DataAccess.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IUnitofWork _unitOfWork;

        public BookingRepository(IUnitofWork unitofWork)
        {
            this._unitOfWork = unitofWork;
        }

        public ApiResponse<IEnumerable<BookingVm>> GetBookings(DateTime from, DateTime to, int page, int pageSize)
        {

            SqlParameter param1 = new SqlParameter("@startDate", from.Date);
            SqlParameter param2 = new SqlParameter("@endDate", to.Date);
            SqlParameter param3 = new SqlParameter("@pageindex", page);
            SqlParameter param4 = new SqlParameter("@pagesize", pageSize);
            SqlParameter param5 = new SqlParameter("@totalCount", System.Data.SqlDbType.Int);
            param5.Direction = System.Data.ParameterDirection.Output;
            var bookings = this._unitOfWork.Repository<BookingVm>().SqlQuery<BookingVm>($"EXEC sp_getBookings {param1},{param2},{param3},{param4},@totalCount out", param1, param2, param3, param4, param5);

            var apiResponse = new ApiResponse<IEnumerable<BookingVm>>();
            apiResponse.Data = bookings;
            apiResponse.TotalCount = Convert.ToInt32(param5.Value);
            return apiResponse;
        }

        public ApiResponse<IEnumerable<TestResultVm>> GetTestResults(int page, int pageSize, LabResultTypes? resultType)
        {
            SqlParameter param1 = new SqlParameter("@pageindex", page);
            SqlParameter param2 = new SqlParameter("@pagesize", pageSize);
            SqlParameter param3 = new SqlParameter("@resultType", !resultType.HasValue ? null : resultType.Value);
            SqlParameter param4 = new SqlParameter("@totalCount", System.Data.SqlDbType.Int);
            param4.Direction = System.Data.ParameterDirection.Output;
            param3.IsNullable = true;
            var testResults = this._unitOfWork.Repository<TestResultVm>().SqlQuery<TestResultVm>($"EXEC sp_getTestResults {param1},{param2},{param3},@totalCount out", param1, param2, param3, param4);

            var apiResponse = new ApiResponse<IEnumerable<TestResultVm>>();
            apiResponse.Data = testResults;
            apiResponse.TotalCount = Convert.ToInt32(param3.Value);
            return apiResponse;
        }
    }
}
