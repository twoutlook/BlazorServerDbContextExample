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
    public class LocationGridQueryAdapter
    {
        /// <summary>
        /// Holds state of the grid.
        /// </summary>
        //private readonly ILocationFilters _controls;
        private readonly ILocationFilters _controls;


        /// <summary>
        /// Expressions for sorting.
        /// </summary>
        private readonly Dictionary<LocationFilterColumns, Expression<Func<StockCurrent, string>>> _expressions
            = new Dictionary<LocationFilterColumns, Expression<Func<StockCurrent, string>>>
            {
                { LocationFilterColumns.Cpositioncode, c => c.Cpositioncode },
                { LocationFilterColumns.Cposition, c => c.Cposition },
                { LocationFilterColumns.Cinvcode, c => c.Cinvcode },
                { LocationFilterColumns.Cinvname, c => c.Cinvname },
                //{ LocationFilterColumns.Iqty, c => c.Iqty },

            };

        /// <summary>
        /// Queryables for filtering.
        /// 
        /// https://stackoverflow.com/questions/14775658/how-to-use-func-with-iqueryable-that-returns-iorderedqueryable
        /// </summary>
        private readonly Dictionary<LocationFilterColumns, Func<IQueryable<StockCurrent>, IQueryable<StockCurrent>>> _filterQueries;

        /// 
        private readonly string FilterTextF1;


        //   public PartGridQueryAdapter(ILocationFilters controls)
        public LocationGridQueryAdapter(ILocationFilters controls)
        {
            _controls = controls;


            // set up queries
            _filterQueries = new Dictionary<LocationFilterColumns, Func<IQueryable<StockCurrent>, IQueryable<StockCurrent>>>
            {
                // NOTE by Mark, 2021-01-13, 按這機制有標準的篩選功能
                // 要注意基本的 F1, F2
                { LocationFilterColumns.Cpositioncode, cs => cs.Where(c => c.Cpositioncode.Contains(_controls.FilterTextF1)) },
                { LocationFilterColumns.Cposition, cs => cs.Where(c => c.Cposition.Contains(_controls.FilterTextF2)) },
                { LocationFilterColumns.Cinvcode, cs => cs.Where(c => c.Cinvcode.Contains(_controls.FilterTextF3)) },
                { LocationFilterColumns.Cinvname, cs => cs.Where(c => c.Cinvname.Contains(_controls.FilterTextF4)) },
             };
        }



        public async Task<ICollection<StockCurrent>> FetchAsyncV4(IQueryable<StockCurrent> query)
        {
            query = FilterAndQueryV4(query);




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
                var filter = _filterQueries[LocationFilterColumns.Cpositioncode];
                root = filter(root);
            }
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF2))
            {
                var filter = _filterQueries[LocationFilterColumns.Cposition];
                root = filter(root);
            }
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF3))
            {
                var filter = _filterQueries[LocationFilterColumns.Cinvcode];
                root = filter(root);
            }
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF4))
            {
                var filter = _filterQueries[LocationFilterColumns.Cinvname];
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
