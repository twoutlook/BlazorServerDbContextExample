﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    public partial class OutbillDHis
    {
        public string Ids { get; set; }
        public string Id { get; set; }
        public string Cstatus { get; set; }
        public decimal? Iquantity { get; set; }
        public string Cpositioncode { get; set; }
        public string Cposition { get; set; }
        public string Cinvbarcode { get; set; }
        public string Cinvcode { get; set; }
        public string Cinvname { get; set; }
        public string Cerpcodeline { get; set; }
        public DateTime? Doutdate { get; set; }
        public string Coutpersoncode { get; set; }
        public string Cmemo { get; set; }
        public decimal? Ioutasnline { get; set; }
        public string Cdefine1 { get; set; }
        public string Cdefine2 { get; set; }
        public DateTime? Ddefine3 { get; set; }
        public string Ddefine4 { get; set; }
        public decimal? Idefine5 { get; set; }
        public decimal? LineQty { get; set; }

        public virtual OutbillHis IdNavigation { get; set; }
    }
}