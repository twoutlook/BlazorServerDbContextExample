﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0002.Models
{
    public partial class BarRepackRecord
    {
        public string Id { get; set; }
        public string PackNo { get; set; }
        public decimal? PackType { get; set; }
        public string DemolishNo { get; set; }
        public string DemolishItem { get; set; }
        public string DemolishSn { get; set; }
        public decimal? Qty { get; set; }
        public DateTime? RepackDate { get; set; }
        public string RepackOwner { get; set; }
        public decimal? HandleType { get; set; }
    }
}