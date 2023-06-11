# WEB
 
在此專案中 我使用了基本的MVC架構，
我自己創立了一個"MyApi"controller，裡面有GET和POST
GET做初始值得讀取
POST用到了AJAX 和 jQuery來實踐 我的功能(使用一個dropdownlist 來使得丟出一個POST到後段給 GetOrderBySelection)，回傳List<MyApiViewModel>給前端最後做顯示邏輯。
 
 [HttpGet]
 public IActionResult Get()
 {
     var model = GetInitInformation();
     return View(model); 
 }
此段中我從"GetInitInformation"獲取資料夾內的訊息並轉為"List<MyApiViewModel>"的資料型態，其中"MyApiViewModel"是我創立給前端使用的Model類別好讓前段和和端的Model獨立。
 
 [HttpPost]
 public List<MyApiViewModel> GetOrderBySelection(string sortOption)
 {
     var model = GetInitInformation();
     var sortedList = Libs.Library.GetSortDatas(model, sortOption);
     return sortedList;
 }
 此段是我獲取前端的"sortOption"再跟資料內的
