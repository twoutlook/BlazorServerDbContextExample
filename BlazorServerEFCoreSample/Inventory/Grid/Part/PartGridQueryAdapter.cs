using Inventory.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inventory.Grid.Part
{
    /// <summary>
    /// Creates the right expressions to filter and sort.
    /// </summary>
    public class PartGridQueryAdapter
    {
        /// <summary>
        /// Holds state of the grid.
        /// </summary>
        private readonly IPartFilters _controls;
        

        /// <summary>
        /// Expressions for sorting.
        /// </summary>
        private readonly Dictionary<PartFilterColumns, Expression<Func<BasePart, string>>> _expressions
            = new Dictionary<PartFilterColumns, Expression<Func<BasePart, string>>>
            {
                { PartFilterColumns.Cpartnumber, c => c.Cpartnumber },
                { PartFilterColumns.Cpartname, c => c.Cpartname },
            };

        /// <summary>
        /// Queryables for filtering.
        /// 
        /// https://stackoverflow.com/questions/14775658/how-to-use-func-with-iqueryable-that-returns-iorderedqueryable
        /// </summary>
        private readonly Dictionary<PartFilterColumns, Func<IQueryable<BasePart>, IQueryable<BasePart>>> _filterQueries;

        /// 
        private readonly string FilterTextF1;


        public PartGridQueryAdapter(IPartFilters controls)
        {
            _controls = controls;


            // set up queries
            _filterQueries = new Dictionary<PartFilterColumns, Func<IQueryable<BasePart>, IQueryable<BasePart>>>
            {
                // NOTE by Mark, 2021-01-13, 按這機制有標準的篩選功能
                // 要注意基本的 F1, F2
                { PartFilterColumns.Cpartnumber, cs => cs.Where(c => c.Cpartnumber.Contains(_controls.FilterTextF1)) }, 
                { PartFilterColumns.Cpartname, cs => cs.Where(c => c.Cpartname.Contains(_controls.FilterTextF2)) },
             };
        }

   

        public async Task<ICollection<BasePart>> FetchAsyncV4(IQueryable<BasePart> query)
        {
            query = FilterAndQueryV4(query);




            await CountAsync(query);
            var collection = await FetchPageQuery(query)
                .ToListAsync();
            _controls.PageHelper.PageItems = collection.Count;
            return collection;
        }




        public async Task CountAsync(IQueryable<BasePart> query)
        {
            _controls.PageHelper.TotalItemCount = await query.CountAsync();
        }


        public IQueryable<BasePart> FetchPageQuery(IQueryable<BasePart> query)
        {
            return query
                .Skip(_controls.PageHelper.Skip)
                .Take(_controls.PageHelper.PageSize)
                .AsNoTracking();
        }







        ////https://www.radzen.com/documentation/blazor/filter-by-multiple-fields/

        //}


       
        private IQueryable<BasePart> FilterAndQueryV4(IQueryable<BasePart> root)
        {
            var sb = new System.Text.StringBuilder();

            // apply a filter?


            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF1))
            {
                var filter = _filterQueries[PartFilterColumns.Cpartnumber];
                root = filter(root);
            }
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF2))
            {
                var filter = _filterQueries[PartFilterColumns.Cpartname];
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
