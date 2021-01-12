using BlazorServerDbContextExample.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorServerDbContextExample.Grid
{
    /// <summary>
    /// Creates the right expressions to filter and sort.
    /// </summary>
    public class GridQueryAdapterV4
    {
        /// <summary>
        /// Holds state of the grid.
        /// </summary>
        private readonly IContactFiltersV4 _controls;
        

        /// <summary>
        /// Expressions for sorting.
        /// </summary>
        private readonly Dictionary<ContactFilterColumnsV4, Expression<Func<Contact, string>>> _expressions
            = new Dictionary<ContactFilterColumnsV4, Expression<Func<Contact, string>>>
            {
                { ContactFilterColumnsV4.City, c => c.City },
                { ContactFilterColumnsV4.Phone, c => c.Phone },
                { ContactFilterColumnsV4.LastName, c => c.LastName },
                { ContactFilterColumnsV4.FirstName, c => c.FirstName },
                { ContactFilterColumnsV4.State, c => c.State },
                { ContactFilterColumnsV4.Street, c => c.Street },
                { ContactFilterColumnsV4.ZipCode, c => c.ZipCode }
            };

        /// <summary>
        /// Queryables for filtering.
        /// 
        /// https://stackoverflow.com/questions/14775658/how-to-use-func-with-iqueryable-that-returns-iorderedqueryable
        /// </summary>
        private readonly Dictionary<ContactFilterColumnsV4, Func<IQueryable<Contact>, IQueryable<Contact>>> _filterQueries;

        /// <summary>
        /// Creates a new instance of the <see cref="GridQueryAdapter"/> class.
        /// </summary>
        /// <param name="controls">The <see cref="IContactFilters"/> to use.</param>
        /// 
        private readonly string FilterTextF1;

        Func<IQueryable<Contact>, IQueryable<Contact>> filterByPhone;
        public GridQueryAdapterV4(IContactFiltersV4 controls)
        {
            _controls = controls;

            FilterTextF1 = controls.FilterTextF1;


            Func<IQueryable<Contact>, IQueryable<Contact>> filterByPhone = cs => cs.Where(c => c.Phone.Contains(_controls.FilterTextF1));


            // set up queries
            _filterQueries = new Dictionary<ContactFilterColumnsV4, Func<IQueryable<Contact>, IQueryable<Contact>>>
            {
                { ContactFilterColumnsV4.City, cs => cs.Where(c => c.City.Contains(_controls.FilterText)) },
                { ContactFilterColumnsV4.Phone, cs => cs.Where(c => c.Phone.Contains(_controls.FilterText)) },
                //{ ContactFilterColumnsV4.Name, cs => cs.Where(c => c.FirstName.Contains(_controls.FilterText) || c.LastName.Contains(_controls.FilterText)) },
                //{ ContactFilterColumnsV4.LastName, cs => cs.Where(c => c.LastName.Contains(_controls.FilterText)) },
//{ ContactFilterColumnsV4.LastName, cs => cs.Where(c => c.LastName.Contains(_controls.FilterLastName)) },
{ ContactFilterColumnsV4.LastName, cs => cs.Where(c => c.LastName.Contains(_controls.FilterText)) },

                { ContactFilterColumnsV4.FirstName, cs => cs.Where(c => c.FirstName.Contains(_controls.FilterText)) },
                { ContactFilterColumnsV4.State, cs => cs.Where(c => c.State.Contains(_controls.FilterText)) },
                { ContactFilterColumnsV4.Street, cs => cs.Where(c => c.Street.Contains(_controls.FilterText)) },
                { ContactFilterColumnsV4.ZipCode, cs => cs.Where(c => c.ZipCode.Contains(_controls.FilterText)) }
            };
        }

        /// <summary>
        /// Uses the query to return a count and a page.
        /// </summary>
        /// <param name="query">The <see cref="IQueryable{Contact}"/> to work from.</param>
        /// <returns>The resulting <see cref="ICollection{Contact}"/>.</returns>
        public async Task<ICollection<Contact>> FetchAsync(IQueryable<Contact> query)
        {
            query = FilterAndQuery(query);
            await CountAsync(query);
            var collection = await FetchPageQuery(query)
                .ToListAsync();
            _controls.PageHelper.PageItems = collection.Count;
            return collection;
        }

        public async Task<ICollection<Contact>> FetchAsyncV4(IQueryable<Contact> query)
        {
            query = FilterAndQueryV4(query);




            await CountAsync(query);
            var collection = await FetchPageQuery(query)
                .ToListAsync();
            _controls.PageHelper.PageItems = collection.Count;
            return collection;
        }



        /// <summary>
        /// Get total filtered items count.
        /// </summary>
        /// <param name="query">The <see cref="IQueryable{Contact}"/> to use.</param>
        /// <returns>Asynchronous <see cref="Task"/>.</returns>
        public async Task CountAsync(IQueryable<Contact> query)
        {
            _controls.PageHelper.TotalItemCount = await query.CountAsync();
        }

        /// <summary>
        /// Build the query to bring back a single page.
        /// </summary>
        /// <param name="query">The <see cref="IQueryable{Contact}"/> to modify.</param>
        /// <returns>The new <see cref="IQueryable{Contact}"/> for a page.</returns>
        public IQueryable<Contact> FetchPageQuery(IQueryable<Contact> query)
        {
            return query
                .Skip(_controls.PageHelper.Skip)
                .Take(_controls.PageHelper.PageSize)
                .AsNoTracking();
        }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <param name="root">The <see cref="IQueryable{Contact}"/> to start with.</param>
        /// <returns>
        /// The resulting <see cref="IQueryable{Contact}"/> with sorts and
        /// filters applied.
        /// </returns>
        private IQueryable<Contact> FilterAndQuery(IQueryable<Contact> root)
        {
            var sb = new System.Text.StringBuilder();

            // apply a filter?
            if (!string.IsNullOrWhiteSpace(_controls.FilterText))
            {
                var filter = _filterQueries[_controls.FilterColumn];
                sb.Append($"Filter: '{_controls.FilterColumn}' ");
                root = filter(root);
            }

            if (!string.IsNullOrWhiteSpace(_controls.FilterLastName))
            {
                var filter = _filterQueries[ContactFilterColumnsV4.LastName];
                sb.Append($"Filter LastName: '{_controls.FilterLastName}' ");
                root = filter(root);
            }



            // apply the expression
            var expression = _expressions[_controls.SortColumn];
            sb.Append($"Sort: '{_controls.SortColumn}' ");

            // fix up name
            //if (_controls.SortColumn == ContactFilterColumnsV4.Name && _controls.ShowFirstNameFirst)
            //{
            //    sb.Append($"(first name first) ");
            //    expression = c => c.FirstName;
            //}



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


        //Func<IQueryable<Contact>, IQueryable<Contact>> filterByPhone = cs => cs.Where(c => c.Phone.Contains("123"));
      
        private IQueryable<Contact> FilterAndQueryV4(IQueryable<Contact> root)
        {
            var sb = new System.Text.StringBuilder();

            // apply a filter?

            
            if (!string.IsNullOrWhiteSpace(_controls.FilterTextF1))
            {
                //var filter = _filterQueries[_controls.FilterColumn];
                var filter = _filterQueries[ContactFilterColumnsV4.LastName];


                sb.Append($"Filter: '{_controls.FilterColumn}' ");
                root = filter(root);
                //root = filterByPhone(root);

            }


        //    root = cs => cs.Where(c => c.Phone.Contains(_controls.FilterText));


            // apply the expression
            var expression = _expressions[_controls.SortColumn];
            sb.Append($"Sort: '{_controls.SortColumn}' ");

            // fix up name
            //if (_controls.SortColumn == ContactFilterColumnsV4.Name && _controls.ShowFirstNameFirst)
            //{
            //    sb.Append($"(first name first) ");
            //    expression = c => c.FirstName;
            //}



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
