using ISLoans.Web.API_Helper;
using ISLoans.Web.Models;
using System;
using System.Threading.Tasks;

namespace ISLoans.Web.API_Router
{
    public class UserService
    {
        const string ApiConfig = "https://localhost:44374/";

        public static async Task<bool> Register(Users model)
        {
            return await HttpHelper.InsertAsync(new Uri($"{ApiConfig}api/User/Register"), model);
        }

        public static async Task<Users> Login(string IDNumber)
        {
            return await HttpHelper.GetAsync<Users>(new Uri($"{ApiConfig}api/User/Login?ID={IDNumber}"));
        }

        public static async Task<Users> CheckIfIDExist(string IDNumber)
        {
            return await HttpHelper.GetAsync<Users>(new Uri($"{ApiConfig}api/User/CheckIfIDExist?IDNumber={IDNumber}"));
        }
    }
}
