using System.Security.Cryptography;
using System.Text;

namespace VemDeZap.Domain.Extencions
{
    public static class StringExtensions
    {
        public static string ConvertToMD5(this string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "";

            var password = (text += "|e66a6508-3a1a-4bc9-a407-cd05415bd821");
            var md5 = MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var item in data)
                sbString.Append(item.ToString());
            
            return sbString.ToString();
        }
    }
}
