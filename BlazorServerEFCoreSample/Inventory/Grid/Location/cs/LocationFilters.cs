﻿namespace Inventory.Grid.Location
{
    /// <summary>
    /// State of grid filters.
    /// </summary>
    public class LocationFilters : ILocationFilters
    {
        //  private const int V = 10;

        /// <summary>
        /// Keep state of paging.
        /// </summary>
        public IPageHelper PageHelper { get; set; }

        //public LocationFilters(IPageHelper pageHelper)
        public LocationFilters()

        {

            //PageHelper = pageHelper;

            // NOTE by Mark, 2021-01-14
            // 直接使用元件

            PageHelper = new PageHelper();

            PageHelper.PageSize = 10;
            PageHelper.BaseUrl = "/location/"; // NOTE by Mark, 解決了可以共同  PageHelper, 可以各自定 PageSize 和 BaseUrl


        }

        /// <summary>
        /// Avoid multiple concurrent requests.
        /// </summary>
        public bool Loading { get; set; }

        /// <summary>
        /// Firstname Lastname, or Lastname, Firstname.
        /// </summary>
        public bool ShowFirstNameFirst { get; set; }

        /// <summary>
        /// Column to sort by.
        /// </summary>
        public LocationFilterColumns SortColumn { get; set; }
            = LocationFilterColumns.Cposition;

        /// <summary>
        /// True when sorting ascending, otherwise sort descending.
        /// </summary>
        public bool SortAscending { get; set; } = true;

        /// <summary>
        /// Column filtered text is against.
        /// </summary>
        public LocationFilterColumns FilterColumn { get; set; }
            = LocationFilterColumns.Cposition;

        /// <summary>
        /// Text to filter on.
        /// </summary>
        public string FilterText { get; set; }
        public string FilterTextF1 { get; set; }
        public string FilterTextF2 { get; set; }
        public string FilterTextF3 { get; set; }
        public string FilterTextF4 { get; set; }
        public string FilterTextF5 { get; set; }
        public string FilterTextF6 { get; set; }
        public string FilterTextF7 { get; set; }
        //public string FilterLastName { get; set ; }
    }
}
