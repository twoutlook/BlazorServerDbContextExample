

# Jeremy Likness,08/14/2020, 在官網文檔介紹了 ASP.NET Core Blazor Server with Entity Framework Core (EFCore)

https://docs.microsoft.com/en-us/aspnet/core/blazor/blazor-server-ef-core?view=aspnetcore-5.0

---

> 這部份的代碼範例, 簡單 dotnet restore 後就可以正常運行,連絡人的增刪改查的功能都有。從代碼看使用了 Repository Pattern , 算是中高級別。
> 查詢的部分包括了,(1)篩選(2)排序(3)分頁,這三種功能。為了準備後續的交流, 我在建立新的頁面都保留之前的功能, 可以參照優化前和優化後。由於頁面上顯示20筆在我電腦上的畫面還要下接, 於是先改為10筆，這個算是基本功。重點是在保留原本仍然是20筆,只是有版本V2才顯示10筆。然後進一步調整欄位的順序和欄位名稱中文以及圖標。突然發現,排序的功能失效了,雖然解決了三角和倒三角表示正序或反序的排法, 但是沒有功能。在實做裡, 受到時間限制時, 這種情況也不是太不尋常, 與其放著沒有功能, 不如先隱藏掉。
> #### Note by Mark陳炳陵, 2020-01-11




### 1. 官網截屏
<img src="1.PNG" />
---
### 2. 代碼所在截屏
https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/common/samples/5.x/BlazorServerEFCoreSample
![]("2.PNG")
---
### 3. 這是範例
![](3.PNG "3.PNG")
---
### 4. 先改每頁只顯示十筆
![](4.PNG "4.PNG")
---
### 5. 調整欄位
![](5.PNG "5.PNG")
---
### 6. 調整欄位顯示名稱
![](6.PNG "6.PNG")
---

### 7. 第三個版本終於做對了
![](7.PNG "7.PNG")
---
### 8. 篩選是立即觸發,不必再按任何提交
![](8.PNG "8.PNG")
---
### 9. 按一個篩選欄位也是可運行的
![](9.PNG "9.PNG")
---


### 教程:
https://youtu.be/_3QiR07dfL4

### 代碼:
https://github.com/rstropek/htl-leo-csharp-4/blob/master/exercises/9110-tournament-planner/sample-solution/TournamentPlanner/Program.cs
