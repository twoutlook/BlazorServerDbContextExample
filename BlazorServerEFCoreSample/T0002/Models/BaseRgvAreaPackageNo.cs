﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0002.Models
{
    public partial class BaseRgvAreaPackageNo
    {
        public string Id { get; set; }
        /// <summary>
        /// 线别
        /// </summary>
        public string Lineid { get; set; }
        /// <summary>
        /// 区域编号
        /// </summary>
        public string Rgvareaid { get; set; }
        /// <summary>
        /// 栈板编号
        /// </summary>
        public string Packageno { get; set; }
        public string Createuser { get; set; }
        public DateTime? Createtime { get; set; }
        public DateTime? Modifytime { get; set; }
        public string Remark { get; set; }
    }
}