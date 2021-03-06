﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0002.Models
{
    /// <summary>
    /// 数据库备份
    /// </summary>
    public partial class SysDbBackup
    {
        /// <summary>
        /// 备份主键
        /// </summary>
        public string FId { get; set; }
        /// <summary>
        /// 备份类型
        /// </summary>
        public string FBackupType { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string FDbName { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FFileName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public string FFileSize { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FFilePath { get; set; }
        /// <summary>
        /// 备份时间
        /// </summary>
        public DateTime? FBackupTime { get; set; }
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