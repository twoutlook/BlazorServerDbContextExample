using Inventory.Data;
using Inventory.Package1;
using Inventory.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inventory.Grid
{

    //   public class Q006OutbillGridQueryAdapter
    // public class Q008OutbillDGridQueryAdapter
    // public class Q009V2OutbillGridQueryAdapter
    // public class Q010V2OutbillGridQueryAdapter
  //  public class Q011V2OutbillGridQueryAdapter
    public class Q014V2OutbillAdapter
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
        private ApplicationFilterColumns DEFAULT_SORT_COL =  ApplicationFilterColumns.CmdSno;
        
       
        //   public PartGridQueryAdapter(ILocationFilters controls)
        //public Q006OutbillGridQueryAdapter(IBaseFilters controls)
        public Q014V2OutbillAdapter()
        {
            //    _controls = controls;
            _controls = new BaseFiltersV2(); // 
            f = _controls;
            _controls.PageHelper.BaseUrl = "/V2Outbill/";

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



        public async Task<ICollection<V2Outbill>> FetchAsyncV4(IQueryable<V2Outbill> query)
        {
            // 處理 篩選 WHERE
      
            query = GetFilterContains.V2Outbill(query, f);

            // 處理 排序 Order By
            query = GetSortQuery.V2Outbill(query, f.SortStr);

            // 這部分是固定的
            // 處理 分頁
            await CountAsync(query);//更新總筆數
            var collection = await FetchPageQuery(query).ToListAsync();//獲得分頁的內容
            _controls.PageHelper.PageItems = collection.Count;//更新返回的筆數
            return collection;//返回分頁的內容
        }



        //更新總筆數
        public async Task CountAsync(IQueryable<V2Outbill> query)
        {
            _controls.PageHelper.TotalItemCount = await query.CountAsync();
        }

        //獲得分頁的內容
        public IQueryable<V2Outbill> FetchPageQuery(IQueryable<V2Outbill> query)
        {
            return query
                .Skip(_controls.PageHelper.Skip)
                .Take(_controls.PageHelper.PageSize)
                .AsNoTracking();
        }



    }

}
