﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0002.Models
{
    public partial class WcsagvcallBackNotice
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 请求编号
        /// </summary>
        public string Reqcode { get; set; }
        /// <summary>
        /// 请求时间戳
        /// </summary>
        public DateTime Reqtime { get; set; }
        /// <summary>
        /// 客户端编号
        /// </summary>
        public string Clientcode { get; set; }
        /// <summary>
        /// 令牌号
        /// </summary>
        public string Tokencode { get; set; }
        /// <summary>
        /// TCP 协议必传，REST 协议不用传， 传了也不影响
        /// </summary>
        public string Interfacename { get; set; }
        /// <summary>
        /// 方法名, 可使用任务类型做为方法名由 RCS任务模板配置后并告知上层系统
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// 当前任务单号
        /// </summary>
        public string Taskcode { get; set; }
        /// <summary>
        /// 工作位，与 RCS 端配置的位置名称一致
        /// </summary>
        public string Wbcode { get; set; }
        /// <summary>
        /// 货架编号
        /// </summary>
        public string Podcode { get; set; }
        /// <summary>
        /// 货架所在区域编号
        /// </summary>
        public string Areacode { get; set; }
        /// <summary>
        /// 物料批次
        /// </summary>
        public string Materiallot { get; set; }
        /// <summary>
        /// 当前位置编号
        /// </summary>
        public string Currentpositioncode { get; set; }
        /// <summary>
        /// 自定义字段
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? Createtime { get; set; }
    }
}