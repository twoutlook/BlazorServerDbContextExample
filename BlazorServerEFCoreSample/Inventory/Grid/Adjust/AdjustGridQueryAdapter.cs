using Inventory.Data;
using Inventory.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inventory.Grid.Adjust
{
    /// <summary>
    /// Creates the right expressions to filter and sort.
    /// </summary>
    //public class PartGridQueryAdapter
    public class AdjustGridQueryAdapter
    {
        /// <summary>
        /// Holds state of the grid.
        /// </summary>
        //private readonly ILocationFilters _controls;
        private readonly IAdjustFilters _controls;


        /// <summary>
        /// Expressions for sorting.
        /// </summary>
        private readonly Dictionary<ApplicationFilterColumns, Expression<Func<StockCurrentAdjust, string>>> _expressions
            = new Dictionary<ApplicationFilterColumns, Expression<Func<StockCurrentAdjust, string>>>
            {
                { ApplicationFilterColumns.Cticketcode, c => c.Cticketcode },
                //{ ApplicationFilterColumns.Cposition, c => c.Cposition },
                //{ ApplicationFilterColumns.Cinvcode, c => c.Cinvcode },
                //{ ApplicationFilterColumns.Cinvname, c => c.Cinvname },
                //{ ApplicationFilterColumns.Iqty, c => c.Iqty },

            };

        /// <summary>
        /// Queryables for filtering.
        /// 
        /// https://stackoverflow.com/questions/14775658/how-to-use-func-with-iqueryable-that-returns-iorderedqueryable
        /// </summary>
        private readonly Dictionary<ApplicationFilterColumns, Func<IQueryable<StockCurrentAdjust>, IQueryable<StockCurrentAdjust>>> _filterQueries;

        /// 
        private readonly string FilterTextF1;


        //   public PartGridQueryAdapter(ILocationFilters controls)
        public AdjustGridQueryAdapter(IAdjustFilters controls)
        {
            _controls = controls;


            // set up queries
            _filterQueries = new Dictionary<ApplicationFilterColumns, Func<IQueryable<StockCurrentAdjust>, IQueryable<StockCurrentAdjust>>>
            {
                // NOTE by Mark, 2021-01-13, 按這機制有標準的篩選功能
                // 要注意基本的 F1, F2
                { ApplicationFilterColumns.Cticketcode, cs => cs.Where(c => c.Cticketcode.Contains(_controls.FilterTextF1)) },
                //{ ApplicationFilterColumns.Cposition, cs => cs.Where(c => c.Cposition.Contains(_controls.FilterTextF2)) },
                //{ ApplicationFilterColumns.Cinvcode, cs => cs.Where(c => c.Cinvcode.Contains(_controls.FilterTextF3)) },
                //{ ApplicationFilterColumns.Cinvname, cs => cs.Where(c => c.Cinvname.Contains(_controls.FilterTextF4)) },
             };
        }



        public async Task<ICollection<StockCurrentAdjust>> FetchAsyncV4(IQueryable<StockCurrentAdjust> query)
        {
            // NOTE by Mark, 2021-01-15, 
            // 先使用這種簡明的 LINQ
            //   query = FilterAndQueryV4(query);

            //https://www.youtube.com/watch?v=2BAueSEuMbY

            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF1))
            {
                query = query.Where(x => x.Cticketcode.Contains(_controls.FilterTextF1));
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




        public async Task CountAsync(IQueryable<StockCurrentAdjust> query)
        {
            _controls.PageHelper.TotalItemCount = await query.CountAsync();
        }


        public IQueryable<StockCurrentAdjust> FetchPageQuery(IQueryable<StockCurrentAdjust> query)
        {
            return query
                .Skip(_controls.PageHelper.Skip)
                .Take(_controls.PageHelper.PageSize)
                .AsNoTracking();
        }







        ////https://www.radzen.com/documentation/blazor/filter-by-multiple-fields/

        //}



        private IQueryable<StockCurrentAdjust> FilterAndQueryV4(IQueryable<StockCurrentAdjust> root)
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
