﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    /// <summary>
    /// 模块表单
    /// </summary>
    public partial class SysModuleForm
    {
        /// <summary>
        /// 表单主键
        /// </summary>
        public string FId { get; set; }
        /// <summary>
        /// 模块主键
        /// </summary>
        public string FModuleId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string FEnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FFullName { get; set; }
        /// <summary>
        /// 表单控件Json
        /// </summary>
        public string FFormJson { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int? FSortCode { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        public bool? FDeleteMark { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>
        public bool? FEnabledMark { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string FDescription { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? FCreatorTime { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public string FCreatorUserId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? FLastModifyTime { get; set; }
        /// <summary>
        /// 最后修改用户
        /// </summary>
        public string FLastModifyUserId { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? FDeleteTime { get; set; }
        /// <summary>
        /// 删除用户
        /// </summary>
        public string FDeleteUserId { get; set; }
    }
}