using Inventory.Shared;
using System;

namespace Inventory.Grid
{
    /// <summary>
    /// State of grid filters.
    /// </summary>

    //public class ParameterFilters : IBaseFilters
    // public class BaseFilters : IBaseFilters
    public class BaseFiltersV2 : IBaseFiltersV2
    {
        //  private const int V = 10;

        /// <summary>
        /// Keep state of paging.
        /// </summary>
        public IPageHelper PageHelper { get; set; }

        //public LocationFilters(IPageHelper pageHelper)
        public BaseFiltersV2()

        {

            //PageHelper = pageHelper;

            // NOTE by Mark, 2021-01-14
            // 直接使用元件

            PageHelper = new PageHelper();

            PageHelper.PageSize = 10;
            PageHelper.BaseUrl = "/base/"; // NOTE by Mark, 解決了可以共同  PageHelper, 可以各自定 PageSize 和 BaseUrl

            // NOTE by Mark, 2021-01-19, 基本功, 先設十組
            FilterContains = new string[10];
            FilterContainsCol = new string[10];
            FilterContainsColName = new string[10];

        }

        /// <summary>
        /// Avoid multiple concurrent requests.
        /// </summary>
        public bool Loading { get; set; }


        /// <summary>
        /// Column to sort by.
        /// </summary>
        public ApplicationFilterColumns SortColumn { get; set; }


        /// <summary>
        /// True when sorting ascending, otherwise sort descending.
        /// </summary>
        public bool SortAscending { get; set; } = true;

        /// <summary>
        /// Column filtered text is against.
        /// </summary>
        public ApplicationFilterColumns FilterColumn { get; set; }



        public DateTime FilterDt1 { get; set; }
        public DateTime FilterDt2 { get; set; }

        /// <summary>
        /// Text to filter on.
        /// </summary>
        public string SortStr { get; set; }
        public string FilterText { get; set; }
        public string[] FilterContains { get; set; }
        public string[] FilterContainsCol { get; set; }
        public string[] FilterContainsColName { get; set; }

        public string FilterTextF1 { get; set; }
        public string FilterTextF2 { get; set; }
        public string FilterTextF3 { get; set; }
        public string FilterTextF4 { get; set; }
        public string FilterTextF5 { get; set; }
        public string FilterTextF6 { get; set; }
        public string FilterTextF7 { get; set; }
        //public string FilterLastName { get; set ; }

        public string WorkWith { get; set; }
        public string ErrMsg { get; set; }
        public ApplicationFilterColumns DefaultColumn { get; set; }
        public AppSortType SortType { get; set; }

    }
}
