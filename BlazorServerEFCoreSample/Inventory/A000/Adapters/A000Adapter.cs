using DreamAITek.T001.Adapter.Shared;
using DreamAITek.T001.Shared;
using Inventory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;

namespace DreamAITek.T001.Adapter
{
    // NOTE by Mark, 2021-01-21, 
    // *** 不要直接改名, 要copy/paste改新增的,再刪掉或註釋掉舊的,以避免VS2019自動去改其它的引用
    // public class Q998DynamicAdapter
    // public class Q997DynamicAdapter
    //public class Q029Adapter
    public class A000Adapter
    {
        //https://www.youtube.com/watch?v=e9uQpd25yII
    
        public IFiltersA000 f;
        public string defaultSortStr;


        //public Q028Adapter() { }

        public void ReadJson(Type type ,string PRE, string ENT)
        {
            try
            {
                //同一個ENT 可能有不同的顯示方式,用前綴區分
                var str = System.IO.File.ReadAllText(@"D:\ZZZ\ENT2\" + PRE + ENT + ".json");
                var array = JsonConvert.DeserializeObject<List<A000FieldMapper>>(str);

                f.FieldMappers = new();

                foreach (var item in array)
                {
                    f.FieldMappers.Add(item);
                }

            }
            catch
            {
              //  Type type = typeof(VCmdMst);
                PropertyInfo[] properties = type.GetProperties();

                //  var auto = new List<FieldMapper>();
                f.FieldMappers = new();
                foreach (PropertyInfo property in properties.Take(7))// DOING
                {
                    string y = property.Name;

                    f.FieldMappers.Add(new A000FieldMapper { Id = y, Name = y, Index = -1 });
                }
                WriteJson(PRE,ENT);
            }




        }

        public void WriteJson(string PRE, string ENT)
        {

            // string json = JsonConvert.SerializeObject(_data.ToArray(), Formatting.Indented);

            //        string json = JsonConvert.SerializeObject(QueryAdapter.f.FieldMappers.ToArray());
            string json = JsonConvert.SerializeObject(f.FieldMappers.ToArray(), Formatting.Indented);

            //write string to file
            System.IO.File.WriteAllText(@"D:\ZZZ\ENT2\" + PRE + ENT + ".json", json);
        }

        public A000Adapter()
        {
            //https://docs.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-5.0#stateful-reconnection-after-prerendering
            //   _cache = memoryCache;
               f = new FiltersA000(); // 
          //  f = filter;
            f.PageHelper.BaseUrl = "/Base_TOCHANGE/";    // *** 這裡要改 
            defaultSortStr = "TOCHANGE_1";   // *** 這裡要改 
        }

        string GetContains(string col, string val)
        {
            return String.Format(" and {0}.Contains(\"{1}\")", col, val);
        }

        private string GetWhereString()
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
            return strWhere;
        }

        private string GetSortString() // Field_1 => Field ,  Field_2 => Field desc
        {
            if (f.SortStr == null)
            {
                // BUG
                // NOTE by Mark, 2021-01-23
                // 不知為何, 會殘留上個頁面的值?
                // 在這裡, 再強制一
                defaultSortStr = f.FieldMappers[0].Id + "_1";

                f.SortStr = defaultSortStr;


            }
            string[] str = f.SortStr.Split('_');
            string strOrderBy = str[0];

            // BUG 仍會使用到殘存的 f.SortStr
            // TODO 要核對看看是否 是合法欄位



            if (str[1] == "2") strOrderBy += " desc";
            return strOrderBy;
        }

        private string GetSortString2() // Field_1 => Field ,  Field_2 => Field desc
        {
            if (f.SortStr2 == null || f.SortStr2 == "")
            {
                return "";
            }

            string[] str = f.SortStr2.Split('_');
            string strOrderBy = "," + str[0];
            if (str[1] == "2") strOrderBy += " desc";
            return strOrderBy;
        }


        //public async Task<ICollection<Object>> FetchAsyncV998(TaiweiContext context, string entity)
        //{
        //    string strWhere = GetWhereString();
        //    string strOrderBy = GetSortString() + GetSortString2();

        //    List<Object> collection = new();

        //    // NOTE by Mark, 2021-01-22, 目前為止這是最簡約的寫法
        //    // 可以根據 Context 自動生成這部份的代碼
        //    switch (entity)
        //    {
        //        case "SysConfig":
        //            f.PageHelper.TotalItemCount = await context.SysConfig.Where(strWhere).CountAsync();
        //            collection = context.SysConfig.Where(strWhere).OrderBy(strOrderBy).Skip(f.PageHelper.Skip).Take(f.PageHelper.PageSize).ToList<Object>();
        //            f.PageHelper.PageItems = collection.Count;
        //            return collection;
        //        default:
        //            return collection;

        //    }
        //}


        public async Task<ICollection<Object>> FetchAsyncQ029SysConfig(TaiweiContext context, string entity)
        {
            return await FetchAsyncV997(context, entity);
        }


        public async Task<ICollection<Object>> FetchAsyncV997(TaiweiContext context, string entity)
        {
            string strWhere = GetWhereString();
            //string strOrderBy = GetSortString();
            string strOrderBy = GetSortString() + GetSortString2();

            List<Object> collection = new();



            // NOTE by Mark, 2021-01-23 共用 Adapter running the same method, 造成使用殘留的 sort str
            //
            // NOTE by Mark, 2021-01-22, 目前為止這是最簡約的寫法
            // 可以根據 Context 自動生成這部份的代碼
            switch (entity)
            {
                case "SysConfig":
                    f.PageHelper.TotalItemCount = await context.SysConfig.Where(strWhere).CountAsync();
                    collection = context.SysConfig.Where(strWhere).OrderBy(strOrderBy).Skip(f.PageHelper.Skip).Take(f.PageHelper.PageSize).ToList<Object>();
                    break;
                case "SysParameter":
                    f.PageHelper.TotalItemCount = await context.SysParameter.Where(strWhere).CountAsync();
                    collection = context.SysParameter.Where(strWhere).OrderBy(strOrderBy).Skip(f.PageHelper.Skip).Take(f.PageHelper.PageSize).ToList<Object>();
                    break;
                case "VInasn":
                    f.PageHelper.TotalItemCount = await context.VInasn.Where(strWhere).CountAsync();
                    collection = context.VInasn.Where(strWhere).OrderBy(strOrderBy).Skip(f.PageHelper.Skip).Take(f.PageHelper.PageSize).ToList<Object>();
                    break;
                case "V2Outasn":
                    f.PageHelper.TotalItemCount = await context.V2Outasn.Where(strWhere).CountAsync();
                    collection = context.V2Outasn.Where(strWhere).OrderBy(strOrderBy).Skip(f.PageHelper.Skip).Take(f.PageHelper.PageSize).ToList<Object>();
                    break;
                case "BaseDocureason":
                    f.PageHelper.TotalItemCount = await context.BaseDocureason.Where(strWhere).CountAsync();
                    collection = context.BaseDocureason.Where(strWhere).OrderBy(strOrderBy).Skip(f.PageHelper.Skip).Take(f.PageHelper.PageSize).ToList<Object>();
                    break;
                case "VCmdMst":
                    f.PageHelper.TotalItemCount = await context.VCmdMst.Where(strWhere).CountAsync();
                    collection = context.VCmdMst.Where(strWhere).OrderBy(strOrderBy).Skip(f.PageHelper.Skip).Take(f.PageHelper.PageSize).ToList<Object>();
                    break;
                default:
                    break;

            }
            f.PageHelper.PageItems = collection.Count;
            return collection;


        }
    }

}
