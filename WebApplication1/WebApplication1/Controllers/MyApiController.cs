using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IO;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Service.Interface;

namespace WebApplication1.Controllers
{
    public class MyApiController : Controller
    {
        private readonly ILibraryService _library;
        private readonly DatasDbContext _dbContext;

        public MyApiController(ILibraryService library, DatasDbContext datasDbContext)
        {
            this._library = library;
            this._dbContext = datasDbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var model = GetInitInformation();
            if (_library.CheckTableIsNULL(_dbContext))
            {
                Console.WriteLine("表示空的");
            }

            return View(model);
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
            var directoryPath = _library.FolderPath("Files");
            string[] filePaths = Directory.GetFiles(directoryPath);
            var fileDetails = _library.GetFileDatas(filePaths);

            return fileDetails;
        }
        [HttpGet]
        public List<MyApiViewModel> GetInitInformationByService()
        {
            var directoryPath = _library.FolderPath("Files");
            string[] filePaths = Directory.GetFiles(directoryPath);
            var fileDetails = _library.GetFileDatas(filePaths);

            return fileDetails;
        }
        [HttpPost]
        public List<MyApiViewModel> GetOrderBySelection(List<MyApiViewModel> viewModelData, string sortOption)
        {
            var sortedList = _library.GetSortDatas(viewModelData, sortOption);

            return sortedList;
        }
        [HttpGet]
        public string Edit()
        {
            return "EDIT";
        }
        [HttpGet]
        public string Delete()
        {
            return "Delete";
        }
    }
}
