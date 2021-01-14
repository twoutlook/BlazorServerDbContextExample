using Inventory.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inventory.Grid.Location
{
    /// <summary>
    /// Creates the right expressions to filter and sort.
    /// </summary>
    //public class PartGridQueryAdapter
    public class LocationGridQueryAdapterV2
    {
        /// <summary>
        /// Holds state of the grid.
        /// </summary>
        //private readonly ILocationFilters _controls;
        //        private readonly ILocationFilters _controls;
        public IAppFilters Filters;
        public IAppFilters _controls;



        /// <summary>
        /// Expressions for sorting.
        /// </summary>
        private readonly Dictionary<AppFilterColumns, Expression<Func<StockCurrent, string>>> _expressions
            = new Dictionary<AppFilterColumns, Expression<Func<StockCurrent, string>>>
            {
                { AppFilterColumns.Cpositioncode, c => c.Cpositioncode },
                { AppFilterColumns.Cposition, c => c.Cposition },
                { AppFilterColumns.Cinvcode, c => c.Cinvcode },
                { AppFilterColumns.Cinvname, c => c.Cinvname },
                //{ AppFilterColumns.Iqty, c => c.Iqty },

            };

        /// <summary>
        /// Queryables for filtering.
        /// 
        /// https://stackoverflow.com/questions/14775658/how-to-use-func-with-iqueryable-that-returns-iorderedqueryable
        /// </summary>
        private readonly Dictionary<AppFilterColumns, Func<IQueryable<StockCurrent>, IQueryable<StockCurrent>>> _filterQueries;

        /// 
        private readonly string FilterTextF1;


        //   public PartGridQueryAdapter(ILocationFilters controls)
      //  public LocationGridQueryAdapter(ILocationFilters controls)
        public LocationGridQueryAdapterV2()
        {
            //_controls = controls;
            _controls = new AppFilters();
            Filters = _controls;

            // set up queries
            _filterQueries = new Dictionary<AppFilterColumns, Func<IQueryable<StockCurrent>, IQueryable<StockCurrent>>>
            {
                // NOTE by Mark, 2021-01-13, 按這機制有標準的篩選功能
                // 要注意基本的 F1, F2
                { AppFilterColumns.Cpositioncode, cs => cs.Where(c => c.Cpositioncode.Contains(_controls.FilterTextF1)) },
                { AppFilterColumns.Cposition, cs => cs.Where(c => c.Cposition.Contains(_controls.FilterTextF2)) },
                { AppFilterColumns.Cinvcode, cs => cs.Where(c => c.Cinvcode.Contains(_controls.FilterTextF3)) },
                { AppFilterColumns.Cinvname, cs => cs.Where(c => c.Cinvname.Contains(_controls.FilterTextF4)) },
             };
        }



        public async Task<ICollection<StockCurrent>> FetchAsyncV4(IQueryable<StockCurrent> query)
        {
            query = FilterAndQueryV4(query);

            //https://www.youtube.com/watch?v=2BAueSEuMbY

            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF1))
            {
                query = query.Where(x => x.Cpositioncode.Contains(_controls.FilterTextF1));
            }
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF2))
            {
                query = query.Where(x => x.Cposition.Contains(_controls.FilterTextF2));
            }
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF3))
            {
                query = query.Where(x => x.Cinvcode.Contains(_controls.FilterTextF3));
            }

            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF4))
            {
                query = query.Where(x => x.Cinvcode.Contains(_controls.FilterTextF4));
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




        public async Task CountAsync(IQueryable<StockCurrent> query)
        {
            _controls.PageHelper.TotalItemCount = await query.CountAsync();
        }


        public IQueryable<StockCurrent> FetchPageQuery(IQueryable<StockCurrent> query)
        {
            return query
                .Skip(_controls.PageHelper.Skip)
                .Take(_controls.PageHelper.PageSize)
                .AsNoTracking();
        }







        ////https://www.radzen.com/documentation/blazor/filter-by-multiple-fields/

        //}



        private IQueryable<StockCurrent> FilterAndQueryV4(IQueryable<StockCurrent> root)
        {
            var sb = new System.Text.StringBuilder();

            // apply a filter?

            // TODO 
            // NOTE by Mark, 2021-01-14, 這裡要如何自動化?

            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF1))
            {
                var filter = _filterQueries[AppFilterColumns.Cpositioncode];
                root = filter(root);
            }
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF2))
            {
                var filter = _filterQueries[AppFilterColumns.Cposition];
                root = filter(root);
            }
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF3))
            {
                var filter = _filterQueries[AppFilterColumns.Cinvcode];
                root = filter(root);
            }
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF4))
            {
                var filter = _filterQueries[AppFilterColumns.Cinvname];
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
