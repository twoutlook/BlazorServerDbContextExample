﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    public partial class BaseBarcodeRule
    {
        public string Id { get; set; }
        /// <summary>
        /// 条码规则编号
        /// </summary>
        public string Rulecode { get; set; }
        /// <summary>
        /// 条码规则名称
        /// </summary>
        public string Rulename { get; set; }
        /// <summary>
        /// 总位数
        /// </summary>
        public int? Rulelen { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string Ruletype { get; set; }
        /// <summary>
        /// 状态(0=启用 1=禁用)
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Createuser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Createdate { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public string Modifyuser { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? Modifydate { get; set; }
        /// <summary>
        /// 启用人
        /// </summary>
        public string Enableuser { get; set; }
        /// <summary>
        /// 启用时间
        /// </summary>
        public DateTime? Enabledate { get; set; }
        /// <summary>
        /// 禁用人
        /// </summary>
        public string Disableuser { get; set; }
        /// <summary>
        /// 禁用时间
        /// </summary>
        public DateTime? Disabledate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        public string DefaultPrintId { get; set; }
    }
}