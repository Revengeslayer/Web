using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FileViewModel
    {
        public string? FileName { get; set; }
        public DateTime? LastWriteTime { get; set; }
        public string? Path { get; set; }
    }

    public class MyApiController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var model = GetInitInformation();
            return View(model); 
        }
        [HttpGet]
        public JsonResult GetInitInformation()
        {
            var directoryPath = Libs.Library.FolderPath("Files");
            string[] filePaths = Directory.GetFiles(directoryPath);
            var fileDetails= Libs.Library.GetFileDatas(filePaths);
            return new JsonResult(fileDetails);
        }
    }
}
