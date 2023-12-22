using System.Security.Cryptography;
using System.Text;
namespace DoAn_WebAcc.Areas.Admin.Utilities
{
    public class Functions
    {

        public static int _AdminUserID = 0;
        public static string _AdminUserName = string.Empty;
        public static string _Message = string.Empty;
        public static string _Email = string.Empty;

        public static string MD5Hash(string text)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(text);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder strBuilder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    strBuilder.Append(hashBytes[i].ToString("x2"));
                }
                return strBuilder.ToString();
            }
        }

        public static string MD5Password(string text)
        {
            string str = MD5Hash(text);
            for (int i = 0; i <= 5; i++)
                str = MD5Hash(str + "_" + str);
            return str;
        }
        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Functions._AdminUserName) || string.IsNullOrEmpty(Functions._Email) || (Functions._AdminUserID <= 0))
                return false;
            return true;
        }


    }
}
