using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Common.Helpers
{
    public static class Utility
    {
        public static string GenerateRandomString(int length, string allowedChars = "abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ123456789")
        {
            if (length < 0)
            {
                return "";
            }

            if (string.IsNullOrEmpty(allowedChars))
            {
                allowedChars = "abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ123456789";
            }

            const int byteSize = 256;
            var allowedCharSet = new HashSet<char>(allowedChars).ToArray();
            if (byteSize < allowedCharSet.Length)
            {
                allowedCharSet = new HashSet<char>(allowedChars.Substring(0, byteSize)).ToArray();
            }
            var result = new StringBuilder();
            var buf = new byte[128];
            while (result.Length < length)
            {
                var rng = RandomNumberGenerator.Create();
                rng.GetBytes(buf);
                for (var i = 0; i < buf.Length && result.Length < length; ++i)
                {

                    var outOfRangeStart = byteSize - (byteSize % allowedCharSet.Length);
                    if (outOfRangeStart <= buf[i]) continue;
                    result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
                }
            }
            return result.ToString();
        }

    }
}
