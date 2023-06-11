using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IO;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Controllers
{
    public class MyApiController : Controller
    {
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
        [HttpPost]
        public List<MyApiViewModel> GetOrderBySelection(List<MyApiViewModel> viewModelData, string sortOption)
        {
            var sortedList = Libs.Library.GetSortDatas(viewModelData, sortOption);
            return sortedList;
        }
    }
}
