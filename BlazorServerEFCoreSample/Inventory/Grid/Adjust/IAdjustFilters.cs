using Inventory.Shared;

namespace Inventory.Grid.Adjust
{
    /// <summary>
    /// Interface for filtering.
    /// </summary>
    public interface IAdjustFilters
    {
        /// <summary>
        /// The <see cref="ContactFilterColumns"/> being filtered on.
        /// </summary>
        ApplicationFilterColumns FilterColumn { get; set; }

        /// <summary>
        /// Loading indicator.
        /// </summary>
        bool Loading { get; set; }

        /// <summary>
        /// The text of the filter.
        /// </summary>

        string FilterText { get; set; }

        string FilterTextF1 { get; set; }


        string FilterTextF2 { get; set; }
        string FilterTextF3 { get; set; }
        string FilterTextF4 { get; set; }


        string FilterTextF5 { get; set; }
        string FilterTextF6 { get; set; }
        string FilterTextF7 { get; set; }


        //string FilterLastName { get; set; }


        /// <summary>
        /// Paging state in <see cref="PageHelper"/>.
        /// </summary>
        IPageHelper PageHelper { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the name is rendered first name first.
        /// </summary>
        bool ShowFirstNameFirst { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the sort is ascending or descending.
        /// </summary>
        bool SortAscending { get; set; }

        /// <summary>
        /// The <see cref="ContactFilterColumns"/> being sorted.
        /// </summary>
        ApplicationFilterColumns SortColumn { get; set; }
    }
}
