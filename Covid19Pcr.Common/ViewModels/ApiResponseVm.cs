using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Common.ViewModels
{
    public class ApiResponse
    {
        public ApiResponseCodes Code { get; set; }
        public string Message { get; set; }
    }

    public class ApiResponse<T> : ApiResponse //where T : class
    {
        public T Data { get; set; } = default(T);
        public int TotalCount { get; set; }
        public List<string> ErrorList = new List<string>();
        public ApiResponse(T result, ApiResponseCodes responseCode, string message, List<string> validationMessages = null)
        {
            Data = result;
            Message = message;
            Code = responseCode;
            ErrorList = validationMessages;
        }

        public ApiResponse()
        {
        }

    }

    public enum ApiResponseCodes
    {
        NOT_FOUND = 4,
        ValidationError = 3,
        [Description("FAIL")]
        FAIL = 2,
        [Description("SUCCESS")]
        OK = 1
    }

    public static class ResponseCodeHelper
    {
        public const int OK = 200;

        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                        Attribute.GetCustomAttribute(field,
                            typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }
}
