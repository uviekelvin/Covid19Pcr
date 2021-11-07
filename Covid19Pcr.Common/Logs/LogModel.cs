using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Common.Logs
{
    public class LogModel
    {
        public string RequestUrl { get; set; }
        public object Request { get; set; }

        public object Response { get; set; }
        public DateTime RequestTime { get; set; } = DateTime.Now;
        public DateTime ResponseTime { get; set; }
        public string TimeTaken { get; set; }

        public LogModel() { }
        public LogModel(string url, object request)
        {
            this.Request = request;
            this.RequestUrl = url;
            RequestTime = DateTime.Now;
        }
        public void CalculateTime(object response = null)
        {
            ResponseTime = DateTime.Now;
            TimeSpan timeTaken = ResponseTime - RequestTime;
            TimeTaken = $"{timeTaken.TotalSeconds} Secs";
            Response = response;

        }
    }
}
