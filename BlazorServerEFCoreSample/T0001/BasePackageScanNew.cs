﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    public partial class BasePackageScanNew
    {
        public int Id { get; set; }
        public string PackageNo { get; set; }
        public string Ip { get; set; }
        public string MachineId { get; set; }
        public string MachineName { get; set; }
        public int? Status { get; set; }
        public int? ScanType { get; set; }
        public string Remark { get; set; }
        public string Cdefine1 { get; set; }
        public string Cdefine2 { get; set; }
        public string Cdefine3 { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreateUser { get; set; }
    }
}