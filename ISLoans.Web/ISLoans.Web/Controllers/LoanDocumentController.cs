using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ISLoans.Web.Models;
using ISLoans.Web.API_Router;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ISLoans.Web.Controllers
{
    public class LoanDocumentController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> UserDocuments(string idNumber)
        {
            var DocumentViewModel = new DocumentViewModel();
            if (!string.IsNullOrEmpty(idNumber))
            {
                DocumentViewModel.UserDocumentList = await LoanDocumentService.GetUserDocuments(idNumber);
                DocumentViewModel.IDNumber = idNumber;
                return View(DocumentViewModel);
            }
            else
            {
                DocumentViewModel.UserDocumentList = await LoanDocumentService.GetUserDocuments(idNumber);
                DocumentViewModel.IDNumber = idNumber;
                return View(DocumentViewModel);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Upload(string IDNumber)
        {
            var DocumentViewModel = new DocumentViewModel();
            DocumentViewModel.IDNumber = IDNumber;
            return View(DocumentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile myFile, DocumentViewModel model)
        {
            if (myFile.Length > 0)
            {
                var document = new DocumentRepositoryViewModel
                {
                    ImgName = myFile.FileName,
                    ImgContentType = myFile.ContentType,
                    ImgLength = Convert.ToInt32(myFile.Length),
                    CreatedByUserID = model.IDNumber
                };
                var dataStream = new MemoryStream();
                await myFile.CopyToAsync(dataStream);
                document.ImgData = dataStream.ToArray();
                await LoanDocumentService.InsertDocument(document);
            }

            return RedirectToAction("UserDocuments", "LoanDocument", new { idNumber = model.IDNumber });
        }
        [HttpGet]
        public async Task<IActionResult> DeleteFiles(int DocumentRepositoryID, string IDNumber)
        {
            var result = await LoanDocumentService.DeleteUserDocument(DocumentRepositoryID, IDNumber);
            return RedirectToAction("UserDocuments", "LoanDocument", new { idNumber = IDNumber});
        }

        [HttpGet]
        public async Task<IActionResult> Download(int DocumentRepositoryID)
        {
            var documents = await LoanDocumentService.UserDocuments(DocumentRepositoryID);
            return File(documents.imgData, documents.imgContentType);
        }
    }
}
