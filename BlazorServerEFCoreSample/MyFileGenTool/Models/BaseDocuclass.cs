﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0002.Models
{
    public partial class BaseDocuclass
    {
        public string Id { get; set; }
        /// <summary>
        /// 单据别编号
        /// </summary>
        public string Docutypecode { get; set; }
        /// <summary>
        /// 单据名称
        /// </summary>
        public string Docuname { get; set; }
        /// <summary>
        /// 模组别
        /// </summary>
        public string Moduletype { get; set; }
        /// <summary>
        /// 模组名称
        /// </summary>
        public string Modulename { get; set; }
        /// <summary>
        /// 单据性质
        /// </summary>
        public string Docunature { get; set; }
        /// <summary>
        /// 对应作业编号
        /// </summary>
        public string Jobnumber { get; set; }
        /// <summary>
        /// 作业名称
        /// </summary>
        public string Jobname { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Dcreatetime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Ccreateownercode { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? Lastupdatetime { get; set; }
        /// <summary>
        /// 最后更新人
        /// </summary>
        public string Lastupdateowner { get; set; }
    }
}