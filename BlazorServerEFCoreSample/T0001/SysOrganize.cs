﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    /// <summary>
    /// 组织表
    /// </summary>
    public partial class SysOrganize
    {
        /// <summary>
        /// 组织主键
        /// </summary>
        public string FId { get; set; }
        /// <summary>
        /// 父级
        /// </summary>
        public string FParentId { get; set; }
        /// <summary>
        /// 层次
        /// </summary>
        public int? FLayers { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string FEnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FFullName { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public string FShortName { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string FCategoryId { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string FManagerId { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string FTelePhone { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string FMobilePhone { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        public string FWeChat { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string FFax { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string FEmail { get; set; }
        /// <summary>
        /// 归属区域
        /// </summary>
        public string FAreaId { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string FAddress { get; set; }
        /// <summary>
        /// 允许编辑
        /// </summary>
        public bool? FAllowEdit { get; set; }
        /// <summary>
        /// 允许删除
        /// </summary>
        public bool? FAllowDelete { get; set; }
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