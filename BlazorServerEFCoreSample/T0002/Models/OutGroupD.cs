﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0002.Models
{
    public partial class OutGroupD
    {
        public string Ids { get; set; }
        public string Id { get; set; }
        public string Cinvcode { get; set; }
        public string Cinvname { get; set; }
        public string Cdefine1 { get; set; }
        public string Cdefine2 { get; set; }
        public string CreateOwner { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual OutGroup IdNavigation { get; set; }
    }
}