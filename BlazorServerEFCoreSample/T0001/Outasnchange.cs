﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    public partial class Outasnchange
    {
        public Outasnchange()
        {
            OutasnchangeD = new HashSet<OutasnchangeD>();
        }

        public string Id { get; set; }
        public string Cticketcode { get; set; }
        public string Cstatus { get; set; }
        public string Erpcode { get; set; }
        public string DataSources { get; set; }
        public string ExecuteOwner { get; set; }
        public DateTime? ExecuteTime { get; set; }
        public string Cauditperson { get; set; }
        public DateTime? Daudittime { get; set; }
        public string CreateOwner { get; set; }
        public DateTime? CreateTime { get; set; }
        public string LastUpdOwner { get; set; }
        public DateTime? LastUpdTime { get; set; }
        public string Cmemo { get; set; }
        public string Changetype { get; set; }
        public string OutasnCticketcode { get; set; }

        public virtual ICollection<OutasnchangeD> OutasnchangeD { get; set; }
    }
}