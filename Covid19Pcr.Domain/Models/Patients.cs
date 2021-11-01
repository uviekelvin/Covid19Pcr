

namespace Covid19Pcr.Domain.Models
{
    public class Patients : BaseEntity
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
