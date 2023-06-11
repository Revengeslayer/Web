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
        private readonly ILibraryService library;
        public MyApiController(ILibraryService library) 
        {
            this.library = library;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var model = GetInitInformation();

            return View(model); 
        }
        [HttpGet]
        public List<MyApiViewModel> GetInitInformation()
        {
            var directoryPath = Libs.Library.FolderPath("Files");
            string[] filePaths = Directory.GetFiles(directoryPath);
            var fileDetails= Libs.Library.GetFileDatas(filePaths);

            return fileDetails;
        }
        [HttpGet]
        public List<MyApiViewModel> GetInitInformationByService()
        {
            var directoryPath = library.FolderPath("Files");
            string[] filePaths = Directory.GetFiles(directoryPath);
            var fileDetails =library.GetFileDatas(filePaths);

            return fileDetails;
        }
        [HttpPost]
        public List<MyApiViewModel> GetOrderBySelection(List<MyApiViewModel> viewModelData, string sortOption)
        {
            var sortedList = library.GetSortDatas(viewModelData, sortOption);

            return sortedList;
        }
    }
}
