﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    public partial class BarCartonM
    {
        public BarCartonM()
        {
            BarCartonD = new HashSet<BarCartonD>();
        }

        public string Id { get; set; }
        public string CartonNo { get; set; }
        public string CartonName { get; set; }
        public string TypeId { get; set; }
        public DateTime? Createtime { get; set; }
        public string Createowner { get; set; }
        public DateTime? Lastmodifytime { get; set; }
        public string Lastmodifyownere { get; set; }

        public virtual ICollection<BarCartonD> BarCartonD { get; set; }
    }
}