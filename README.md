# WEB

在此專案中 我使用了基本的MVC架構，
我自己創立了一個"MyApi"controller，裡面有GET和POST
GET做初始值得讀取
POST用到了AJAX 和 jQuery來實踐 我的功能(使用一個dropdownlist 來使得丟出一個POST到後段給 GetOrderBySelection)，回傳List<MyApiViewModel>給前端最後做顯示邏輯。
<pre>
[HttpGet]  
public IActionResult Get()  
{  
  var model = GetInitInformation();  
  return View(model);   
}  
</pre>
此段中我從"GetInitInformation"獲取資料夾內的訊息並轉為"List<MyApiViewModel>"的資料型態，其中"MyApiViewModel"是我創立給前端使用的Model類別好讓前段和和端的Model獨立。
<pre>
[HttpGet]
public List<MyApiViewModel> GetInitInformation()
{
  var directoryPath = Libs.Library.FolderPath("Files");
  string[] filePaths = Directory.GetFiles(directoryPath);
  var fileDetails= Libs.Library.GetFileDatas(filePaths);
  return fileDetails;
}
</pre>
此段是獲取資料夾的資料。
<pre>
[HttpPost]
public List<MyApiViewModel> GetOrderBySelection(List<MyApiViewModel> viewModelData, string sortOption)
{
  var sortedList = Libs.Library.GetSortDatas(viewModelData, sortOption);
  return sortedList;
}
</pre>
此段是我獲取前端的"sortOption" 和 "viewModelData"再傳入後端內做排序。

其中的"Libs"是我存放我自己的函式庫的地方
<pre>
public static List<MyApiViewModel> GetFileDatas(string[] filepaths)
{
    //Database Datas load
    var fileInformationProvider = new FileInformationProvider();
    var dbDataLists = GetDBDataLists(filepaths, fileInformationProvider);
    //ViewData load
    var dataConverter = new MyApiViewModelConverter();
    var viewDataLists = GetViewDataLists(dbDataLists, dataConverter);

    return viewDataLists;
}
</pre>
此段我使用了"依賴反轉"讓程式不會有太多的依賴。

新增功能1
---
<pre>
builder.Services.AddTransient<IDataConvertService<Datas,MyApiViewModel>, DataConvertService>();
builder.Services.AddTransient<IFileProvideService, FileProvideService>();
builder.Services.AddTransient<ILibraryService, LibraryService>();
</pre>
我在Program中新增3個service 並在 LibraryService 中使用"注入" 來獲取這些服務
<pre>
public class LibraryService : ILibraryService
{
    private readonly IFileProvideService fileProvideService;
    private readonly IDataConvertService<Datas, MyApiViewModel> dataConvertService;
    public LibraryService(IFileProvideService fileProvideService,IDataConvertService<Datas,MyApiViewModel> dataConvertService) 
    {
        this.fileProvideService = fileProvideService;
        this.dataConvertService = dataConvertService;
    }
    //...
}
</pre>
新增功能2
---
使用"Code First" 從現有的code專案中創立出資料庫和資料表
使用了套件
<pre>
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore
</pre>
使用了C# IDE的 套件管理主控台
<pre>
Add-Migration InitialCreate //創建Migrations資料夾的"InitialCreate"修改的歷程記錄
Update-Database             //更新資料庫的狀態
//使用此段程式來做資料庫的設定
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
        ...
}
</pre>

      
