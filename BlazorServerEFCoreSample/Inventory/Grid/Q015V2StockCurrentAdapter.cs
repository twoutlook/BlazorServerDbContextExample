﻿using Inventory.Data;
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
    public class Q015V2StockCurrentAdapter

    {
        public IBaseFiltersV2 f;
        private string defaultSortStr;
        public Q015V2StockCurrentAdapter()
        {
            f = new BaseFiltersV2(); // 
            f.PageHelper.BaseUrl = "/Q015V2StockCurrent/";
            defaultSortStr = "Cpositioncode_1";   // *** 這裡要改

        }

        string GetContains(string col, string val)
        {
            return String.Format(" and {0}.Contains(\"{1}\")", col, val);
        }
        public async Task<ICollection<StockCurrent>> FetchAsyncV5(TaiweiContext context)
        {
            //   .Where("MyColumn.Contains(@0)", myArray)
            //string v1 = "001";
            //string strWhere = String.Format(@" Cticketcode.Contains(@0),v1 ";

            string strWhere = " 1==1 "; // 使用傳統的做法

            for (int i = 0; i < 9; i++)
            {
                if (f.FilterContains[i] != null)
                {
                    // NOTE by Mark, 2021-01-20
                    // 在前端, 可以和 control 挷定
                    // 那就在這裡處理空白
                    f.FilterContains[i] = f.FilterContains[i].Trim();
                    if (f.FilterContains[i] != "")
                        strWhere += GetContains(f.FilterContainsCol[i], f.FilterContains[i]);
                }
            }

            // NOTE by Mark, 2021-01-21
            // 需要一個 default SortStr,
            // 就像 PageHelper 要設 URL
            if (f.SortStr == null)
            {
                //f.SortStr = "Cpositioncode_1";   // *** 這裡要改
                f.SortStr = defaultSortStr;

            }
            string[] str = f.SortStr.Split('_');

            string strOrderBy = str[0];
            if (str[1] == "2") strOrderBy += " desc";


            //调整
            var qry = context.StockCurrent.Where(strWhere).OrderBy(strOrderBy);


            //   await CountAsync(qry);//更新總筆數
            //var collection = await context.StockCurrent.Where(strWhere).OrderBy(strOrderBy).ToListAsync();


            f.PageHelper.TotalItemCount = await qry.CountAsync();

            //var collection = await qry.ToListAsync();
            //   var collection = await FetchPageQuery(qry).ToListAsync();//獲得分頁的內容

            var collection = await qry.Skip(f.PageHelper.Skip)
                .Take(f.PageHelper.PageSize)
                .AsNoTracking().ToListAsync();



            f.PageHelper.PageItems = collection.Count;//更新返回的筆數
            return collection;

        }




        //更新總筆數
        //public async Task CountAsync(IQueryable<StockCurrent> query)
        //{
        //    f.PageHelper.TotalItemCount = await query.CountAsync();
        //}

        //獲得分頁的內容
        //public IQueryable<StockCurrent> FetchPageQuery(IQueryable<StockCurrent> query)
        //{
        //    return query
        //        .Skip(f.PageHelper.Skip)
        //        .Take(f.PageHelper.PageSize)
        //        .AsNoTracking();
        //}



    }

}
