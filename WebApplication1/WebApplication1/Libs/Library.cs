using WebApplication1.Models;

namespace WebApplication1.Libs
{
    public class Library
    {
        public static List<Datas> GetFileDatas(string[] filepaths)
        {
            var dataLists = new List<Datas>();
            foreach (var filepath in filepaths)
            {
                Datas data = new Datas();
                FileInfo fileInformation = new FileInfo(filepath);
                data.name = fileInformation.Name;
                data.lastWriteTime = fileInformation.LastWriteTimeUtc;
                data.path = filepath;
                dataLists.Add(data);
            }
            return dataLists;
        }

        public static string FolderPath(string filename)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(currentPath, filename);
            return folderPath;
        }
    }
}
