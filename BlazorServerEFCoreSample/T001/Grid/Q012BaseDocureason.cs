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
    // public class Q009BaseDocureasonGridQueryAdapter
    // public class Q010BaseDocureasonGridQueryAdapter
   // public class Q011BaseDocureasonGridQueryAdapter
    public class Q012BaseDocureasonGridQueryAdapter
    {
        /// <summary>
        /// Holds state of the grid.
        /// </summary>
        //private readonly ILocationFilters _controls;
        private readonly IBaseFilters _controls;


        /// <summary>
        /// Expressions for sorting.
        /// </summary>
        private readonly Dictionary<ApplicationFilterColumns, Expression<Func<BaseDocureason, string>>> _expressions
            = new Dictionary<ApplicationFilterColumns, Expression<Func<BaseDocureason, string>>>
            {
                //{ ApplicationFilterColumns.Cticketcode, c => c.Cticketcode },
                //{ ApplicationFilterColumns.Cstatus, c => c.Cstatus },
                ////{ ApplicationFilterColumns.Memo, c => c.Memo },
                //{ ApplicationFilterColumns.FlagId, c => c.FlagId },
                { ApplicationFilterColumns.Reasoncode, c => c.Reasoncode },
                //{ ApplicationFilterColumns.Cinvname, c => c.Cinvname },
                //{ ApplicationFilterColumns.Iqty, c => c.Iqty },

            };

        /// 
        private readonly string FilterTextF1;

        public IBaseFilters f;

        //   public PartGridQueryAdapter(ILocationFilters controls)
        //public Q006OutbillGridQueryAdapter(IBaseFilters controls)
            public Q012BaseDocureasonGridQueryAdapter()
            {
            //    _controls = controls;
            _controls = new BaseFilters();
            f = _controls;
            _controls.PageHelper.BaseUrl = "/BaseDocureason/";

            _controls.FilterColumn = ApplicationFilterColumns.Reasoncode;
            _controls.SortColumn = ApplicationFilterColumns.Reasoncode;
     
        }



        public async Task<ICollection<BaseDocureason>> FetchAsyncV4(IQueryable<BaseDocureason> query)
        {
     

            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF1))
            {
                //query = query.Where(x => x.Caccountid == _controls.FilterTextF1);
                query = query.Where(x => x.Reasoncode.Contains(_controls.FilterTextF1));

            }


            // NOTE by Mark, 2021-01-18, 必需要有指定的預設排序欄位
            // 如果沒有, 會報錯, 是不是可能 智能指定一個?

            var expression = _expressions[_controls.SortColumn];
  




            var sortDir = _controls.SortAscending ? "ASC" : "DESC";
    

            query = _controls.SortAscending ? query.OrderBy(expression)
                : query.OrderByDescending(expression);




            await CountAsync(query);
            var collection = await FetchPageQuery(query)
                .ToListAsync();
            _controls.PageHelper.PageItems = collection.Count;
            return collection;
        }




        public async Task CountAsync(IQueryable<BaseDocureason> query)
        {
            _controls.PageHelper.TotalItemCount = await query.CountAsync();
        }


        public IQueryable<BaseDocureason> FetchPageQuery(IQueryable<BaseDocureason> query)
        {
            return query
                .Skip(_controls.PageHelper.Skip)
                .Take(_controls.PageHelper.PageSize)
                .AsNoTracking();
        }



    }

}
