﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    public partial class BaseBarcodePrint
    {
        public string Id { get; set; }
        /// <summary>
        /// 打印规则编号
        /// </summary>
        public string PrintCode { get; set; }
        /// <summary>
        /// 打印规则名称
        /// </summary>
        public string PrintName { get; set; }
        public string BarCodeType { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Cstatus { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 启用人
        /// </summary>
        public string EnableUser { get; set; }
        /// <summary>
        /// 启用时间
        /// </summary>
        public DateTime? EnableTime { get; set; }
        /// <summary>
        /// 作废人
        /// </summary>
        public string DisableUser { get; set; }
        /// <summary>
        /// 作废时间
        /// </summary>
        public DateTime? DisableTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}