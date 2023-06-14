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
        private readonly IDatabaseAccessService _databaseAccessService;
        private readonly DatasDbContext _dbContext;

        public MyApiController(ILibraryService libraryService, DatasDbContext datasDbContext, IDatabaseAccessService databaseAccessService)
        {
            this._libraryService = libraryService;
            this._dbContext = datasDbContext;
            this._databaseAccessService = databaseAccessService;
        }
        [HttpGet]
        public IActionResult Get()
        {      
            if(_databaseAccessService.CheckTableIsNull())
            {
                Console.WriteLine("空的");
                

                var model = GetInitInformation2();
                return View(model);
            }
            else
            {
                Console.WriteLine("有的");
                var model = GetInitInformation2();
                return View(model);
            }
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
            var fileDatas = _libraryService.GetFileDatas(filePaths);
            var viewDatas = _libraryService.GetViewDatas(fileDatas);

            return viewDatas;
        }
        [HttpGet]
        public List<MyApiViewModel> GetInitInformationByService()
        {
            var filePaths = _libraryService.GetFilePaths("Files");
            var fileDatas = _libraryService.GetFileDatas(filePaths);
            var viewDatas = _libraryService.GetViewDatas(fileDatas);

            return viewDatas;
        }
        [HttpPost]
        public List<MyApiViewModel> GetOrderBySelection(List<MyApiViewModel> viewModelData, string sortOption)
        {
            var sortedList = _libraryService.GetSortDatas(viewModelData, sortOption);

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
