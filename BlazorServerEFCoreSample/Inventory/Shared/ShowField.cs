
using System;
using System.Collections.Generic;



namespace Inventory.Shared
{
    public  class ShowField
    {
        public ShowField(int seq,string id, string name, int sortSeq,int filterSeq)
        {
            Seq = seq; // 顯示時的欄位順序, 123...
            Id = id;   // entity 的欄位名, 注意不是 db table 的欄位名
            Name = name; // 顯示名, 按客戶需求
            SortSeq = sortSeq; //頁面排序下拉的順序, 123, 0表示不做
            FilterSeq = filterSeq;//頁面篩選的控件, 123, 0表示不做

            Index = -1;// 留著給和 Entity 互動使用, 一律為-1
        }
        public int Seq { get; set; } // 1,2,3
        public string Id { get; set; }
        public string Name { get; set; }
        public int SortSeq { get; set; } // 1,2,3 0 is not show
        public int FilterSeq { get; set; } // 1,2,3 0 is not show

        public int Index { get; set; } // mapping to ef elements, default = -1

    }
}