using ISLoans.Web.API_Helper;
using ISLoans.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISLoans.Web.API_Router
{
    public class LoanDocumentService
    {
        const string ApiConfig = "https://localhost:44374/";

        public static async Task<bool> InsertDocument(DocumentRepositoryViewModel model)
        {
            return await HttpHelper.InsertAsync(new Uri($"{ApiConfig}api/LoanDocument/InsertDocument"), model);
        }

        public static async Task<List<UserDocumentViewModel>> GetUserDocuments(string IDNumber)
        {
            return await HttpHelper.GetAsync<List<UserDocumentViewModel>>(new Uri($"{ApiConfig}api/LoanDocument/GetUserDocuments?IDNumber={IDNumber}"));
        }

        public static async Task<bool> DeleteUserDocument(int DocumentRepositoryID, string DeleteByUserID)
        {
            return await HttpHelper.GetAsync<bool>(new Uri($"{ApiConfig}api/LoanDocument/DeleteUserDocument?DocumentRepositoryID={DocumentRepositoryID}&DeleteByUserID={DeleteByUserID}"));
        }

        public static async Task<UserDocumentViewModel> UserDocuments(int DocumentRepositoryID)
        {
            return await HttpHelper.GetAsync<UserDocumentViewModel>(new Uri($"{ApiConfig}api/LoanDocument/UserDocument?DocumentRepositoryID={DocumentRepositoryID}"));
        }
    }
}
