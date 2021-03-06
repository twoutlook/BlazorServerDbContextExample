﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0002.Models
{
    /// <summary>
    /// 角色授权表
    /// </summary>
    public partial class SysRoleAuthorize
    {
        /// <summary>
        /// 角色授权主键
        /// </summary>
        public string FId { get; set; }
        /// <summary>
        /// 项目类型1-模块2-按钮3-列表
        /// </summary>
        public int? FItemType { get; set; }
        /// <summary>
        /// 项目主键
        /// </summary>
        public string FItemId { get; set; }
        /// <summary>
        /// 对象分类1-角色2-部门-3用户
        /// </summary>
        public int? FObjectType { get; set; }
        /// <summary>
        /// 对象主键
        /// </summary>
        public string FObjectId { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int? FSortCode { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? FCreatorTime { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public string FCreatorUserId { get; set; }
    }
}