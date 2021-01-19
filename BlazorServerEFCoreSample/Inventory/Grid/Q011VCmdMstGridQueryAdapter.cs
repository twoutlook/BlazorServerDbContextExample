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
    // public class Q009VCmdMstGridQueryAdapter
    // public class Q010VCmdMstGridQueryAdapter
    public class Q011VCmdMstGridQueryAdapter
    {
        /// <summary>
        /// Holds state of the grid.
        /// </summary>
        //private readonly ILocationFilters _controls;
        private readonly IBaseFiltersV2 _controls;
        public IBaseFiltersV2 f;


        /// <summary>
        /// Expressions for sorting.
        /// </summary>
        private readonly Dictionary<ApplicationFilterColumns, Expression<Func<VCmdMst, string>>> _expressions
            = new Dictionary<ApplicationFilterColumns, Expression<Func<VCmdMst, string>>>
            {
                //{ ApplicationFilterColumns.Cticketcode, c => c.Cticketcode },
                //{ ApplicationFilterColumns.Cstatus, c => c.Cstatus },
                ////{ ApplicationFilterColumns.Memo, c => c.Memo },
                //{ ApplicationFilterColumns.FlagId, c => c.FlagId },
                { ApplicationFilterColumns.CmdSno, c => c.CmdSno },
             

                //{ ApplicationFilterColumns.Cinvname, c => c.Cinvname },
                //{ ApplicationFilterColumns.Iqty, c => c.Iqty },

            };

        private readonly Dictionary<ApplicationFilterColumns, Expression<Func<VCmdMst, int>>> _expressionsInt
            = new Dictionary<ApplicationFilterColumns, Expression<Func<VCmdMst, int>>>
            {
             
                { ApplicationFilterColumns.WmsTskId, c => c.WmsTskId },

        
            };



        /// 
        private readonly string FilterTextF1;

        
        // NOTE by Mark, 2021-01-18
        private ApplicationFilterColumns DEFAULT_SORT_COL =  ApplicationFilterColumns.CmdSno;
        
       
        //   public PartGridQueryAdapter(ILocationFilters controls)
        //public Q006OutbillGridQueryAdapter(IBaseFilters controls)
        public Q011VCmdMstGridQueryAdapter()
        {
            //    _controls = controls;
            _controls = new BaseFiltersV2(); // 
            f = _controls;
            _controls.PageHelper.BaseUrl = "/vcmdmst/";

            //_controls.FilterColumn = ApplicationFilterColumns.CmdSno;
            //_controls.SortColumn = ApplicationFilterColumns.CmdSno;
            _controls.FilterColumn = DEFAULT_SORT_COL;
            //      _controls.SortColumn = DEFAULT_SORT_COL; // NOTE by Mark, 因為 string or int , 不能混用

            // make it as default, for most of the cases
//            f.SortType = AppSortType.TYPE_STR;
            f.SortType = AppSortType.TYPE_INT;   // default as WmsTskId

            _controls.DefaultColumn = ApplicationFilterColumns.WmsTskId;
            _controls.SortColumn = ApplicationFilterColumns.WmsTskId;


        }

        //class Mark<T>
        //{
        //    public T GetExpress(T query,string str,bool isAscending)
        //    {
        //        switch (str)
        //        {
        //            case "WmsTskId":
        //                query = isAscending ? query.OrderBy(x => x.WmsTskId)
        //               : query.OrderByDescending(c => c.WmsTskId);
        //                break;
        //        }

        //    }
        //}



        // TODO , USING CODE GENERATION TO MAKE SUCH FUNCTION FOR EACH PAGE
        //public IQueryable<VCmdMst> VCmdMst (IQueryable<VCmdMst> query, string sortStr)
        //{

        //    string[] words = sortStr.Split('_');


        //    switch (words[0])
        //    {
        //        case "WmsTskId":
        //            query = words[1] == "1" ? query.OrderBy(x => x.WmsTskId)
        //           : query.OrderByDescending(c => c.WmsTskId);
        //            return query;
        //        default:
        //            return query;
        //    }

        //}



        //public static IQueryable<VCmdMst> GetFilterContains(IQueryable<VCmdMst> query, string col,string f1)
        //{
        //    if (!string.IsNullOrWhiteSpace(f1) && col =="Loc")
        //    {
        //        return query.Where(x => x.Loc.Contains(f1));

        //    }
            

        //    return query;
        //}



        public async Task<ICollection<VCmdMst>> FetchAsyncV4(IQueryable<VCmdMst> query)
        {
            // *** 準備自動生成 ***
            // 處理 篩選 WHERE
            query = GetFilterContains.VCmdMst(query, "Loc", _controls.FilterTextF1);
            query = GetFilterContains.VCmdMst(query, "Cticketcode", _controls.FilterTextF2);
            query = GetFilterContains.VCmdMst(query, "Remark", _controls.FilterTextF3);

            // *** 準備自動生成 ***
            // *** 準備接受兩個甚至三個排序 ***
            // 處理 排序 Order By
            query = GetSortQuery.VCmdMst(query, f.SortStr);

            // 這部分是固定的
            // 處理 分頁
            await CountAsync(query);//更新總筆數
            var collection = await FetchPageQuery(query).ToListAsync();//獲得分頁的內容
            _controls.PageHelper.PageItems = collection.Count;//更新返回的筆數
            return collection;//返回分頁的內容
        }



        //更新總筆數
        public async Task CountAsync(IQueryable<VCmdMst> query)
        {
            _controls.PageHelper.TotalItemCount = await query.CountAsync();
        }

        //獲得分頁的內容
        public IQueryable<VCmdMst> FetchPageQuery(IQueryable<VCmdMst> query)
        {
            return query
                .Skip(_controls.PageHelper.Skip)
                .Take(_controls.PageHelper.PageSize)
                .AsNoTracking();
        }



    }

}
