﻿using Inventory.Shared;
using System;

namespace Inventory.Grid
{
    /// <summary>
    /// Interface for filtering.
    /// </summary>
    public interface IBaseFiltersV2
    {
        /// <summary>
        /// The <see cref="ContactFilterColumns"/> being filtered on.
        /// </summary>
        ApplicationFilterColumns FilterColumn { get; set; }

        ApplicationFilterColumns DefaultColumn { get; set; }
        AppSortType SortType { get; set; }
        string ErrMsg { get; set; } 

        /// <summary>
        /// Loading indicator.
        /// </summary>
        bool Loading { get; set; }

        /// <summary>
        /// The text of the filter.
        /// </summary>

        DateTime FilterDt1 { get; set; }
        DateTime FilterDt2 { get; set; }

        string WorkWith { get; set; } // to enforce this new IBaseFilter

        string FilterText { get; set; }

        string[] FilterContains { get; set; }
        string[] FilterContainsCol { get; set; }
        string[] FilterContainsColName { get; set; }

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
        /// Gets or sets a value indicating if the sort is ascending or descending.
        /// </summary>
        bool SortAscending { get; set; }
        string SortStr { get; set; }

        /// <summary>
        /// The <see cref="ContactFilterColumns"/> being sorted.
        /// </summary>
        ApplicationFilterColumns SortColumn { get; set; }
    }
}
