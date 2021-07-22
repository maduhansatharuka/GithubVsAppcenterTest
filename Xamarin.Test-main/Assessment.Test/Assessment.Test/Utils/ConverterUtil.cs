using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assessment.Test.Utils
{
    public static class ConverterUtil
    {
        public static string StreamTobase64(Stream stream)
        {
            string result;
            try
            {

                byte[] bytes;
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    bytes = memoryStream.ToArray();
                }
                result = Convert.ToBase64String(bytes);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
