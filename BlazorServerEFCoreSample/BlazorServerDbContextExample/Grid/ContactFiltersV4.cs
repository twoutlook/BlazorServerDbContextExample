namespace BlazorServerDbContextExample.Grid
{
    /// <summary>
    /// State of grid filters.
    /// </summary>
    public class ContactFiltersV4 : IContactFiltersV4
    {
        private const int V = 10;

        /// <summary>
        /// Keep state of paging.
        /// </summary>
        public IPageHelperV4 PageHelper { get; set; }

        public ContactFiltersV4(IPageHelperV4 pageHelper)
        {
            PageHelper = pageHelper;

            PageHelper.PageSize = V;
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
        public ContactFilterColumnsV4 SortColumn { get; set; }
            = ContactFilterColumnsV4.LastName;

        /// <summary>
        /// True when sorting ascending, otherwise sort descending.
        /// </summary>
        public bool SortAscending { get; set; } = true;

        /// <summary>
        /// Column filtered text is against.
        /// </summary>
        public ContactFilterColumnsV4 FilterColumn { get; set; }
            = ContactFilterColumnsV4.LastName;

        /// <summary>
        /// Text to filter on.
        /// </summary>
        public string FilterText { get; set; }
    }
}
