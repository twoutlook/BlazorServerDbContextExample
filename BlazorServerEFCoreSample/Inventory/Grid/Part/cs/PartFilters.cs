

namespace Inventory.Grid.Part
{
    /// <summary>
    /// State of grid filters.
    /// </summary>
   // public class LocationFilters : ILocationFilters
    public class PartFilters : IPartFilters
    {
        private const int V = 10;

        /// <summary>
        /// Keep state of paging.
        /// </summary>
        public IPageHelper PageHelper { get; set; }

        public PartFilters(IPartPageHelper pageHelper)
        {
            //PageHelper = pageHelper;

            PageHelper = new PageHelper();
            PageHelper.PageSize = V;
            PageHelper.BaseUrl = "/part/"; // NOTE by Mark, 解決了可以共同  PageHelper, 可以各自定 PageSize 和 BaseUrl


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
        public PartFilterColumns SortColumn { get; set; }
            = PartFilterColumns.Cpartnumber;

        /// <summary>
        /// True when sorting ascending, otherwise sort descending.
        /// </summary>
        public bool SortAscending { get; set; } = true;

        /// <summary>
        /// Column filtered text is against.
        /// </summary>
        public PartFilterColumns FilterColumn { get; set; }
            = PartFilterColumns.Cpartnumber;

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
        public string FilterLastName { get; set ; }
    }
}
