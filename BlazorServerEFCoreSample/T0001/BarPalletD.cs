﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    public partial class BarPalletD
    {
        public string Ids { get; set; }
        public string Id { get; set; }
        public string Cartonid { get; set; }
        public string Cartoncode { get; set; }
        public decimal? Qty { get; set; }
        public string Createuser { get; set; }
        public DateTime? Createtime { get; set; }
        public DateTime? Lastmodifytime { get; set; }
        public string Lastmodifyowner { get; set; }
        public decimal? HandleStatus { get; set; }

        public virtual BarPalletM IdNavigation { get; set; }
    }
}