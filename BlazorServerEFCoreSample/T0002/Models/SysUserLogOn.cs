﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0002.Models
{
    /// <summary>
    /// 用户登录信息表
    /// </summary>
    public partial class SysUserLogOn
    {
        /// <summary>
        /// 用户登录主键
        /// </summary>
        public string FId { get; set; }
        /// <summary>
        /// 用户主键
        /// </summary>
        public string FUserId { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string FUserPassword { get; set; }
        /// <summary>
        /// 用户秘钥
        /// </summary>
        public string FUserSecretkey { get; set; }
        /// <summary>
        /// 允许登录时间开始
        /// </summary>
        public DateTime? FAllowStartTime { get; set; }
        /// <summary>
        /// 允许登录时间结束
        /// </summary>
        public DateTime? FAllowEndTime { get; set; }
        /// <summary>
        /// 暂停用户开始日期
        /// </summary>
        public DateTime? FLockStartDate { get; set; }
        /// <summary>
        /// 暂停用户结束日期
        /// </summary>
        public DateTime? FLockEndDate { get; set; }
        /// <summary>
        /// 第一次访问时间
        /// </summary>
        public DateTime? FFirstVisitTime { get; set; }
        /// <summary>
        /// 上一次访问时间
        /// </summary>
        public DateTime? FPreviousVisitTime { get; set; }
        /// <summary>
        /// 最后访问时间
        /// </summary>
        public DateTime? FLastVisitTime { get; set; }
        /// <summary>
        /// 最后修改密码日期
        /// </summary>
        public DateTime? FChangePasswordDate { get; set; }
        /// <summary>
        /// 允许同时有多用户登录
        /// </summary>
        public bool? FMultiUserLogin { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int? FLogOnCount { get; set; }
        /// <summary>
        /// 在线状态
        /// </summary>
        public bool? FUserOnLine { get; set; }
        /// <summary>
        /// 密码提示问题
        /// </summary>
        public string FQuestion { get; set; }
        /// <summary>
        /// 密码提示答案
        /// </summary>
        public string FAnswerQuestion { get; set; }
        /// <summary>
        /// 是否访问限制
        /// </summary>
        public bool? FCheckIpaddress { get; set; }
        /// <summary>
        /// 系统语言
        /// </summary>
        public string FLanguage { get; set; }
        /// <summary>
        /// 系统样式
        /// </summary>
        public string FTheme { get; set; }
    }
}