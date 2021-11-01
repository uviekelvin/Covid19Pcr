using Microsoft.EntityFrameworkCore;

namespace Covid19Pcr.Infrastructure.DataAccess
{
    public class Covid19PcrContext : DbContext
    {

        public Covid19PcrContext(DbContextOptions<Covid19PcrContext> options) : base(options) { }

    }
}
