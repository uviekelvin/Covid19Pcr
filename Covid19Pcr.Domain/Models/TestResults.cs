using Covid19Pcr.Domain.Enums;
using System;

namespace Covid19Pcr.Domain.Models
{
    public class TestResults
    {
        public LabResultTypes ResultType { get; set; }
        public string Remarks { get; set; }
        public DateTime DateCreated { get; private set; }

        public TestResults() { }

        public TestResults(LabResultTypes resultType, string remarks)
        {
            this.ResultType = resultType;
            this.Remarks = remarks;
            this.DateCreated = DateTime.Now;
        }
    }
}
