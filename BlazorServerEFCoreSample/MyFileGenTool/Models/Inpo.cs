﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0002.Models
{
    public partial class Inpo
    {
        public Inpo()
        {
            InpoD = new HashSet<InpoD>();
        }

        public string Id { get; set; }
        public string Pono { get; set; }
        public string Potype { get; set; }
        public DateTime? Podate { get; set; }
        public string Vendorid { get; set; }
        public string Vendorname { get; set; }
        public string Currency { get; set; }
        public string Paymentterm { get; set; }
        public string Shipfrom { get; set; }
        public string Shipto { get; set; }
        public decimal? Status { get; set; }
        public decimal? Source { get; set; }
        public string Memo { get; set; }
        public string Define1 { get; set; }
        public string Define2 { get; set; }
        public string Define3 { get; set; }
        public DateTime? Define4 { get; set; }
        public decimal? Define5 { get; set; }
        public DateTime? Createtime { get; set; }
        public string Createowner { get; set; }
        public DateTime? Lastupdatetime { get; set; }
        public string Lastupdateowner { get; set; }

        public virtual ICollection<InpoD> InpoD { get; set; }
    }
}