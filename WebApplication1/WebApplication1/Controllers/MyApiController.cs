using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IO;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class MyApiController : Controller
    {
        private readonly ILibraryService _libraryService;

        public MyApiController(ILibraryService libraryService)
        {
            this._libraryService = libraryService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var filePaths = _libraryService.GetFilePaths("Files");
            var fileDbDatas = _libraryService.GetFileDbDatas(filePaths);
            var viewDatas = _libraryService.GetViewDatas(fileDbDatas);

            return View(viewDatas);
        }
        //沒有使用注入服務的_library
        [HttpGet]
        public List<MyApiViewModel> GetInitInformation2()
        {
            var directoryPath = Libs.Library.FolderPath("Files");
            string[] filePaths = Directory.GetFiles(directoryPath);
            var fileDetails = Libs.Library.GetFileDatas(filePaths);

            return fileDetails;
        }
        //使用注入服務的_library
        [HttpGet]
        public List<MyApiViewModel> GetInitInformation()
        {          
            var filePaths = _libraryService.GetFilePaths("Files");
            var fileDatas = _libraryService.GetFileDbDatas(filePaths);
            var viewDatas = _libraryService.GetViewDatas(fileDatas);

            return viewDatas;
        }
        [HttpGet]
        public List<MyApiViewModel> GetInitInformationByService()
        {
            var filePaths = _libraryService.GetFilePaths("Files");
            var fileDatas = _libraryService.GetFileDbDatas(filePaths);
            var viewDatas = _libraryService.GetViewDatas(fileDatas);

            return viewDatas;
        }
        [HttpPost]
        public List<MyApiViewModel> Creat()
        {
            _libraryService.CreateNewTxt();
            var viewData = Get();

            return new List<MyApiViewModel>();
        }
        [HttpPost]
        public List<MyApiViewModel> GetOrderBySelection(List<MyApiViewModel> viewModelData, string sortOption)
        {
            var sortedList = _libraryService.GetSortDatas(viewModelData, sortOption);

            return sortedList;
        }
        [HttpGet]
        public string UpdateData()
        {
            return "EDIT";
        }
        [HttpGet]
        public string DeleteData()
        {
            return "Delete";
        }
    }
}
