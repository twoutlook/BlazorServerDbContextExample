﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    public partial class BarSnSplitD
    {
        public string Ids { get; set; }
        public string Id { get; set; }
        public string SplitSn { get; set; }
        public decimal SplitSnQty { get; set; }
        public string Createowner { get; set; }
        public DateTime? Createtime { get; set; }

        public virtual BarSnSplit IdNavigation { get; set; }
    }
}