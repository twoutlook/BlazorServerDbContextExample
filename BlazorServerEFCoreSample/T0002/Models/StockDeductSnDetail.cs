﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0002.Models
{
    public partial class StockDeductSnDetail
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public DateTime? CreateTimes { get; set; }
        public string CreateOwner { get; set; }
        public string Cticketcode { get; set; }
        public string SnId { get; set; }
        public string Sncode { get; set; }
        public string DeductPosition { get; set; }
        public string Cinvcode { get; set; }
        public string Cpositioncode { get; set; }
        public string Ctopositioncode { get; set; }
        public decimal? BeginQty { get; set; }
        public decimal? TransQty { get; set; }
        public decimal? FinalQty { get; set; }
        public string ProcName { get; set; }
        public string Memo { get; set; }
        public string Cdefine1 { get; set; }
        public string Cdefine2 { get; set; }
    }
}