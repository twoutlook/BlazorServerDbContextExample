﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    public partial class WipDiscreteJobsV
    {
        public string WipEntityName { get; set; }
        public string WipEntityId { get; set; }
        public string ItemName { get; set; }
        public string ItemId { get; set; }
        public string ItemDescription { get; set; }
        public decimal? StartQuantity { get; set; }
        public decimal? QuantityCompleted { get; set; }
        public decimal? OpenQuantity { get; set; }
        public string IsCompleteFlag { get; set; }
        public decimal? ProcessQty { get; set; }
    }
}