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

    //   public class Q006OutbillGridQueryAdapter
    // public class Q008OutbillDGridQueryAdapter
    // public class Q009StockCurrentGridQueryAdapter
    // public class Q010StockCurrentGridQueryAdapter
    //  public class Q011StockCurrentGridQueryAdapter
    // public class Q014StockCurrentAdapter
    public class Q015V2StockCurrentAdapter

    {
        /// <summary>
        /// Holds state of the grid.
        /// </summary>
        //private readonly ILocationFilters _controls;
        private readonly IBaseFiltersV2 _controls;
        public IBaseFiltersV2 f;






        /// 
        private readonly string FilterTextF1;


        // NOTE by Mark, 2021-01-18
        private ApplicationFilterColumns DEFAULT_SORT_COL = ApplicationFilterColumns.CmdSno;


        //   public PartGridQueryAdapter(ILocationFilters controls)
        //public Q006OutbillGridQueryAdapter(IBaseFilters controls)
        public Q015V2StockCurrentAdapter()
        {
            //    _controls = controls;
            _controls = new BaseFiltersV2(); // 
            f = _controls;
            _controls.PageHelper.BaseUrl = "/Q015V2StockCurrent/";

            //_controls.FilterColumn = ApplicationFilterColumns.CmdSno;
            //_controls.SortColumn = ApplicationFilterColumns.CmdSno;
            //  _controls.FilterColumn = DEFAULT_SORT_COL;
            //      _controls.SortColumn = DEFAULT_SORT_COL; // NOTE by Mark, 因為 string or int , 不能混用

            // make it as default, for most of the cases
            //            f.SortType = AppSortType.TYPE_STR;
            f.SortType = AppSortType.TYPE_STR;   // default as WmsTskId

            _controls.DefaultColumn = ApplicationFilterColumns.Cticketcode;
            _controls.SortColumn = ApplicationFilterColumns.Cticketcode;


        }

        string getContains(string col, string val)
        {
            return String.Format(" and {0}.Contains(\"{1}\")", col, val);
        }
        public async Task<ICollection<StockCurrent>> FetchAsyncV5(TaiweiContext context)
        {
            //   .Where("MyColumn.Contains(@0)", myArray)
            //string v1 = "001";
            //string strWhere = String.Format(@" Cticketcode.Contains(@0),v1 ";

            string strWhere = " 1==1 ";


            for (int i = 0; i < 9; i++)
            {
                if (f.FilterContains[i] != null)
                {
                    // NOTE by Mark, 2021-01-20
                    // 在前端, 可以和 control 挷定
                    // 那就在這裡處理空白
                    f.FilterContains[i] = f.FilterContains[i].Trim();
                    if (f.FilterContains[i] != "")
                        strWhere += getContains(f.FilterContainsCol[i], f.FilterContains[i]);
                }
            }





            if (f.SortStr == null) // QUICK FIX: 不知道為何使用  browser fresh, sortStr becomes null
            {
                f.SortStr = "Cpositioncode_1";
            }

            string[] str = f.SortStr.Split('_');
            //string desc = str[1] == "2" ? " desc" : "";


            string strOrderBy = str[0];
            if (str[1] == "2") strOrderBy += " desc";


            //调整
            var qry = context.StockCurrent.Where(strWhere).OrderBy(strOrderBy);
            await CountAsync(qry);//更新總筆數
                                  //var collection = await context.StockCurrent.Where(strWhere).OrderBy(strOrderBy).ToListAsync();

            //var collection = await qry.ToListAsync();
            var collection = await FetchPageQuery(qry).ToListAsync();//獲得分頁的內容


            _controls.PageHelper.PageItems = collection.Count;//更新返回的筆數
            return collection;

        }




        //更新總筆數
        public async Task CountAsync(IQueryable<StockCurrent> query)
        {
            _controls.PageHelper.TotalItemCount = await query.CountAsync();
        }

        //獲得分頁的內容
        public IQueryable<StockCurrent> FetchPageQuery(IQueryable<StockCurrent> query)
        {
            return query
                .Skip(_controls.PageHelper.Skip)
                .Take(_controls.PageHelper.PageSize)
                .AsNoTracking();
        }



    }

}
