/*****************************************************************************************************
 * 
 * 패스워드 암호화 클래스
 * 
 *****************************************************************************************************/

using System.Text;

namespace RestaurantApp.DataBase.Service
{
    public class PasswordEncryptor
    {
        /// <summary>
        /// 암호화
        /// </summary>
        /// <param name="password"></param>
        /// <returns>
        /// 
        /// </returns>
        public static string PasswordEncrypt(string password)
        {
            StringBuilder builder = new();
            foreach (char s in password)
            {
                builder.Append((int)s);
            }

            return builder.ToString();
        }
    }
}
