﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0002.Models
{
    public partial class InassitD
    {
        public string Ids { get; set; }
        public string Id { get; set; }
        public string Cstatus { get; set; }
        public decimal Inum { get; set; }
        public string Cpositioncode { get; set; }
        public string Cposition { get; set; }
        public string Cinvbarcode { get; set; }
        public string Cinvcode { get; set; }
        public string Cinvname { get; set; }
        public string Cbatch { get; set; }
        public string Cmemo { get; set; }
        public string Coperatorcode { get; set; }
        public string Coperator { get; set; }
        public string Casnid { get; set; }
        public decimal? Iasnline { get; set; }
        public string Cdefine1 { get; set; }
        public string Cdefine2 { get; set; }
        public DateTime? Ddefine3 { get; set; }
        public DateTime? Ddefine4 { get; set; }
        public decimal? Idefine5 { get; set; }
        public int? CriticalPart { get; set; }

        public virtual Inassit IdNavigation { get; set; }
    }
}