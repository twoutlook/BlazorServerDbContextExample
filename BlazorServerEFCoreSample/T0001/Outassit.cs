﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    public partial class Outassit
    {
        public Outassit()
        {
            OutassitD = new HashSet<OutassitD>();
        }

        public string Id { get; set; }
        public string Ccreateownercode { get; set; }
        public DateTime Dcreatetime { get; set; }
        public string Cticketcode { get; set; }
        public string Cstatus { get; set; }
        public string Coutasnid { get; set; }
        public string Cmemo { get; set; }
        public string Cdefine1 { get; set; }
        public string Cdefine2 { get; set; }
        public DateTime? Ddefine3 { get; set; }
        public DateTime? Ddefine4 { get; set; }
        public decimal? Idefine5 { get; set; }
        public decimal? IsMerge { get; set; }
        public decimal? CriticalPart { get; set; }

        public virtual ICollection<OutassitD> OutassitD { get; set; }
    }
}