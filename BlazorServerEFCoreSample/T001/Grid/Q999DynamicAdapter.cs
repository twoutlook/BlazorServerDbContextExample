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
    //public class Q015
//    public class Q021SysParameterAdapter
 public class Q999DynamicAdapter

    {
        public IBaseFiltersV2 f;
        private string defaultSortStr;

        public Q999DynamicAdapter()
        {
            f = new BaseFiltersV2(); // 
            f.PageHelper.BaseUrl = "/Q021SysParameter/";
            defaultSortStr = "FlagId_1";   // *** 這裡要改 i.e

        }

        string GetContains(string col, string val)
        {
            return String.Format(" and {0}.Contains(\"{1}\")", col, val);
        }
        public async Task<ICollection<SysParameter>> FetchAsyncV5(TaiweiContext context)
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
            var qry = context.SysParameter.Where(strWhere).OrderBy(strOrderBy);


            //   await CountAsync(qry);//更新總筆數
            //var collection = await context.SysParameter.Where(strWhere).OrderBy(strOrderBy).ToListAsync();


            f.PageHelper.TotalItemCount = await qry.CountAsync();

            //var collection = await qry.ToListAsync();
            //   var collection = await FetchPageQuery(qry).ToListAsync();//獲得分頁的內容

            var collection = await qry.Skip(f.PageHelper.Skip)
                .Take(f.PageHelper.PageSize)
                .AsNoTracking().ToListAsync();



            f.PageHelper.PageItems = collection.Count;//更新返回的筆數
            return collection;

        }

        //public async Task<ICollection<Object>> FetchAsyncV999(TaiweiContext context)
      //  public async Task<ICollection<Object>> FetchAsyncV999(dynamic context) // is it possible to use dynamic here?
        public async Task<ICollection<Object>> FetchAsyncV999(TaiweiContext context) // is it possible to use dynamic here?
        {
            string strWhere = " 1==1 "; // 使用傳統的做法
            var qry = context.SysParameter.Where(strWhere);

            qry = ApplyFilter(qry);
            
            f.PageHelper.TotalItemCount = await qry.CountAsync();

            var collection = await qry.Skip(f.PageHelper.Skip)
                .Take(f.PageHelper.PageSize)
                .AsNoTracking().ToListAsync<Object>();

            f.PageHelper.PageItems = collection.Count;//更新返回的筆數
            return collection;

        }



     
       //// https://stackoverflow.com/questions/38879017/passing-an-iqueryable-as-a-parameter
       // protected static IQueryable<T> ApplyGridFilter<T>(IQueryable<T> query)
       // {
       //     var qText = "id == 1";

       //     query = query.Where(qText);
       //     return query;
       // }

        protected  IQueryable<T> ApplyFilter<T>(IQueryable<T> query)
        {
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
            var qry = query.Where(strWhere).OrderBy(strOrderBy);
            return qry;
        }



        //public async Task CountAsync(IQueryable<Inbill> query)
        //{
        //    f.PageHelper.TotalItemCount = await query.CountAsync();
        //}


        //public IQueryable<Inbill> FetchPageQuery(IQueryable<Inbill> query)
        //{
        //    return query
        //        .Skip(f.PageHelper.Skip)
        //        .Take(f.PageHelper.PageSize)
        //        .AsNoTracking();
        //}



    }

}
