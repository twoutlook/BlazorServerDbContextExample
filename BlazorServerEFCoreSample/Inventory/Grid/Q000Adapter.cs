using Inventory.Data;
using Inventory.Package1;
using Inventory.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inventory.Grid
{

    // NOTE by Mark, 2021-01-21, 
    // *** 不要直接改名, 要copy/paste改新增的,再刪掉或註釋掉舊的,以避免VS2019自動去改其它的引用
    //   public class Q015V2StockCurrentAdapter
    public class Q000Adapter

    {
        public IBaseFiltersV2 f;
        public string DefaultSortStr;
        public Q000Adapter(string baseUrl,string sort)
        {
            f = new BaseFiltersV2(); // 
            //f.PageHelper.BaseUrl = "/Q015V2StockCurrent/";
            //defaultSortStr = "Cpositioncode_1";   // *** 這裡要改
            f.PageHelper.BaseUrl = baseUrl;
            DefaultSortStr = sort;   // *** 這裡要改



        }




    }

}
