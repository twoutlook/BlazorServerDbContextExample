using Inventory.Data;
using Inventory.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inventory.Grid.Parameter
{
    /// <summary>
    /// Creates the right expressions to filter and sort.
    /// </summary>
    //public class PartGridQueryAdapter
    public class Q005InBillGridQueryAdapter
    {
        /// <summary>
        /// Holds state of the grid.
        /// </summary>
        //private readonly ILocationFilters _controls;
        private readonly IBaseFilters _controls;


        /// <summary>
        /// Expressions for sorting.
        /// </summary>
        private readonly Dictionary<ApplicationFilterColumns, Expression<Func<SysParameter, string>>> _expressions
            = new Dictionary<ApplicationFilterColumns, Expression<Func<SysParameter, string>>>
            {
                { ApplicationFilterColumns.FlagType, c => c.FlagType },
                { ApplicationFilterColumns.FlagName, c => c.FlagName },
                { ApplicationFilterColumns.Memo, c => c.Memo },
                { ApplicationFilterColumns.FlagId, c => c.FlagId },
                //{ ApplicationFilterColumns.Cinvcode, c => c.Cinvcode },
                //{ ApplicationFilterColumns.Cinvname, c => c.Cinvname },
                //{ ApplicationFilterColumns.Iqty, c => c.Iqty },

            };

        /// <summary>
        /// Queryables for filtering.
        /// 
        /// https://stackoverflow.com/questions/14775658/how-to-use-func-with-iqueryable-that-returns-iorderedqueryable
        /// </summary>
        private readonly Dictionary<ApplicationFilterColumns, Func<IQueryable<SysParameter>, IQueryable<SysParameter>>> _filterQueries;

        /// 
        private readonly string FilterTextF1;


        //   public PartGridQueryAdapter(ILocationFilters controls)
        public Q005InBillGridQueryAdapter(IBaseFilters controls)
        {
            _controls = controls;


            // set up queries
            _filterQueries = new Dictionary<ApplicationFilterColumns, Func<IQueryable<SysParameter>, IQueryable<SysParameter>>>
            {
                // NOTE by Mark, 2021-01-13, 按這機制有標準的篩選功能
                // 要注意基本的 F1, F2
                { ApplicationFilterColumns.FlagType, cs => cs.Where(c => c.FlagType.Contains(_controls.FilterTextF1)) },
                //{ ApplicationFilterColumns.Cposition, cs => cs.Where(c => c.Cposition.Contains(_controls.FilterTextF2)) },
                //{ ApplicationFilterColumns.Cinvcode, cs => cs.Where(c => c.Cinvcode.Contains(_controls.FilterTextF3)) },
                //{ ApplicationFilterColumns.Cinvname, cs => cs.Where(c => c.Cinvname.Contains(_controls.FilterTextF4)) },
             };
        }



        public async Task<ICollection<SysParameter>> FetchAsyncV4(IQueryable<SysParameter> query)
        {
            // NOTE by Mark, 2021-01-15, 
            // 先使用這種簡明的 LINQ
            //   query = FilterAndQueryV4(query);

            //https://www.youtube.com/watch?v=2BAueSEuMbY

            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF1))
            {
                query = query.Where(x => x.FlagType.Contains(_controls.FilterTextF1));
            }
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF2))
            {
                query = query.Where(x => x.FlagName.Contains(_controls.FilterTextF2));
            }
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF3))
            {
                query = query.Where(x => x.Memo.Contains(_controls.FilterTextF3));
            }


            // apply the expression
            var expression = _expressions[_controls.SortColumn];
          //  sb.Append($"Sort: '{_controls.SortColumn}' ");




            var sortDir = _controls.SortAscending ? "ASC" : "DESC";
            //sb.Append(sortDir);
            //sb.Append("目前輸入的值是:" + _controls.FilterText);

            //Debug.WriteLine(sb.ToString());
            //Debug.WriteLine("...by Mark, what is filter? " + _controls.FilterText);

            // return the unfiltered query for total count, and the filtered for fetching
            //return _controls.SortAscending ? root.OrderBy(expression)
                //: root.OrderByDescending(expression);

            query = _controls.SortAscending ? query.OrderBy(expression)
                : query.OrderByDescending(expression);




            await CountAsync(query);
            var collection = await FetchPageQuery(query)
                .ToListAsync();
            _controls.PageHelper.PageItems = collection.Count;
            return collection;
        }




        public async Task CountAsync(IQueryable<SysParameter> query)
        {
            _controls.PageHelper.TotalItemCount = await query.CountAsync();
        }


        public IQueryable<SysParameter> FetchPageQuery(IQueryable<SysParameter> query)
        {
            return query
                .Skip(_controls.PageHelper.Skip)
                .Take(_controls.PageHelper.PageSize)
                .AsNoTracking();
        }







        ////https://www.radzen.com/documentation/blazor/filter-by-multiple-fields/

        //}



        private IQueryable<SysParameter> FilterAndQueryV4(IQueryable<SysParameter> root)
        {
            var sb = new System.Text.StringBuilder();

            // apply a filter?

            // TODO 
            // NOTE by Mark, 2021-01-14, 這裡要如何自動化?

            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF1))
            {
                var filter = _filterQueries[ApplicationFilterColumns.Cpositioncode];
                root = filter(root);
            }
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF2))
            {
                var filter = _filterQueries[ApplicationFilterColumns.Cposition];
                root = filter(root);
            }
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF3))
            {
                var filter = _filterQueries[ApplicationFilterColumns.Cinvcode];
                root = filter(root);
            }
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF4))
            {
                var filter = _filterQueries[ApplicationFilterColumns.Cinvname];
                root = filter(root);
            }





            // apply the expression
            var expression = _expressions[_controls.SortColumn];
            sb.Append($"Sort: '{_controls.SortColumn}' ");




            var sortDir = _controls.SortAscending ? "ASC" : "DESC";
            sb.Append(sortDir);
            sb.Append("目前輸入的值是:" + _controls.FilterText);

            Debug.WriteLine(sb.ToString());
            Debug.WriteLine("...by Mark, what is filter? " + _controls.FilterText);

            // return the unfiltered query for total count, and the filtered for fetching
            return _controls.SortAscending ? root.OrderBy(expression)
                : root.OrderByDescending(expression);


            //https://www.radzen.com/documentation/blazor/filter-by-multiple-fields/

        }
    }

}
