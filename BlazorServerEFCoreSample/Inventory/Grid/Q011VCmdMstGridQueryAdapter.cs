using Inventory.Data;
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
        public IQueryable<VCmdMst> GetSortQuery(IQueryable<VCmdMst> query, string sortStr)
        {

            string[] words = sortStr.Split('_');


            switch (words[0])
            {
                case "WmsTskId":
                    query = words[1] == "1" ? query.OrderBy(x => x.WmsTskId)
                   : query.OrderByDescending(c => c.WmsTskId);
                    return query;
                default:
                    return query;
            }

        }

        public async Task<ICollection<VCmdMst>> FetchAsyncV4(IQueryable<VCmdMst> query)
        {


            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF1))
            {
                //query = query.Where(x => x.Caccountid == _controls.FilterTextF1);
                query = query.Where(x => x.Loc.Contains(_controls.FilterTextF1));

            }

            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF2))
            {
                //query = query.Where(x => x.Caccountid == _controls.FilterTextF1);
                query = query.Where(x => x.Cticketcode.Contains(_controls.FilterTextF2));

            }

            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF3))
            {
                //query = query.Where(x => x.Caccountid == _controls.FilterTextF1);
                query = query.Where(x => x.Remark.Contains(_controls.FilterTextF3));

            }



            // NOTE by Mark, 2021-01-18, 必需要有指定的預設排序欄位
            // 如果沒有, 會報錯, 是不是可能 智能指定一個?
            // System.Collections.Generic.KeyNotFoundException: The given key 'Code' was not present in the dictionary.
            //         at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
            //at Inventory.Grid.Q011VCmdMstGridQueryAdapter.FetchAsyncV4(IQueryable`1 query) in 
            //  var expression = _expressions[_controls.SortColumn];

            //string[] words = f.SortStr.Split('_');
            //_controls.SortAscending = words[1] == "1" ? true : false;

            
            //switch (words[0])
            //{
            //    case "WmsTskId":
            //        query = words[1] == "1" ? query.OrderBy(x => x.WmsTskId)
            //       : query.OrderByDescending(c => c.WmsTskId);
            //        break;
            //}

            query = GetSortQuery(query, f.SortStr);



            //var sortDir = _controls.SortAscending ? "ASC" : "DESC";
            //f.ErrMsg = "";
            //if (f.SortType == AppSortType.TYPE_STR)
            //{
            //    var expression = _expressions[ApplicationFilterColumns.CmdSno];

            //    if (_expressions.ContainsKey(_controls.SortColumn))
            //    {
            //        expression = _expressions[_controls.SortColumn];
            //    }
            //    else
            //    {
            //        // the key doesn't exist.
            //        // NOTE by Mark, 2021-01-18, how to feedback to page for developer
            //        // to fix this wrong sorting?
            //        f.ErrMsg = " *** 開發人員請注意見 *** 使用的排序欄位, 還沒有在排序的 dictionary (string) 裡定義!";
            //    }




            //    query = _controls.SortAscending ? query.OrderBy(expression)
            //        : query.OrderByDescending(expression);

            //}

            //if (f.SortType == AppSortType.TYPE_INT)
            //{
            //    var expressionInt = _expressionsInt[ApplicationFilterColumns.WmsTskId];
            // //   f.ErrMsg = "";
            //    if (_expressionsInt.ContainsKey(_controls.SortColumn))
            //    {
            //        expressionInt = _expressionsInt[_controls.SortColumn];
            //    }
            //    else
            //    {
            //        // the key doesn't exist.
            //        // NOTE by Mark, 2021-01-18, how to feedback to page for developer
            //        // to fix this wrong sorting?
            //        f.ErrMsg = " *** 開發人員請注意見 *** 使用的排序欄位, 還沒有在排序的 dictionary (int) 裡定義!";
            //    }


            //    query = _controls.SortAscending ? query.OrderBy(expressionInt)
            //        : query.OrderByDescending(expressionInt);
            //}












            await CountAsync(query);
            var collection = await FetchPageQuery(query)
                .ToListAsync();
            _controls.PageHelper.PageItems = collection.Count;
            return collection;
        }




        public async Task CountAsync(IQueryable<VCmdMst> query)
        {
            _controls.PageHelper.TotalItemCount = await query.CountAsync();
        }


        public IQueryable<VCmdMst> FetchPageQuery(IQueryable<VCmdMst> query)
        {
            return query
                .Skip(_controls.PageHelper.Skip)
                .Take(_controls.PageHelper.PageSize)
                .AsNoTracking();
        }



    }

}
