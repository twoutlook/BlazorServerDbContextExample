﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0002.Models
{
    public partial class Inasn
    {
        public string Id { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public string Ccreateownercode { get; set; }
        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime Dcreatetime { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string Cauditpersoncode { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? Dauditdate { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        public string Cticketcode { get; set; }
        /// <summary>
        /// 状态（0 未处理,1,装箱中，2,入库中，3 已完成,）
        /// </summary>
        public string Cstatus { get; set; }
        /// <summary>
        /// po号
        /// </summary>
        public string Cpo { get; set; }
        /// <summary>
        /// 入库类型
        /// </summary>
        public string Itype { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Cmemo { get; set; }
        /// <summary>
        /// 主表ERP单号
        /// </summary>
        public string Cerpcode { get; set; }
        /// <summary>
        /// 贸易代码
        /// </summary>
        public string Cdefine1 { get; set; }
        /// <summary>
        /// 币别
        /// </summary>
        public string Cdefine2 { get; set; }
        /// <summary>
        /// 判退
        /// </summary>
        public string Ddefine3 { get; set; }
        /// <summary>
        /// 数量来源 ( 0 : WMS，1 :oracle ERP )
        /// </summary>
        public string Ddefine4 { get; set; }
        /// <summary>
        /// 特殊元件退料 0:正常 1:特殊
        /// </summary>
        public decimal? Idefine5 { get; set; }
        /// <summary>
        /// 供应商编码
        /// </summary>
        public string Cvendercode { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Cvender { get; set; }
        /// <summary>
        /// 预入库通知单ID
        /// </summary>
        public string InasnIaId { get; set; }
        /// <summary>
        /// 1-工单整盘退料 0-其他
        /// </summary>
        public decimal? SpecilReturn { get; set; }
        /// <summary>
        /// 0-一般 1 急料
        /// </summary>
        public decimal? CriticalPart { get; set; }
        /// <summary>
        /// 理由码编号
        /// </summary>
        public string Reasoncode { get; set; }
        /// <summary>
        /// 理由码说明
        /// </summary>
        public string Reasoncontent { get; set; }
        public string Worktype { get; set; }
        public string Splitcaseno { get; set; }
        /// <summary>
        /// 过账日期
        /// </summary>
        public DateTime? Docdate { get; set; }
        /// <summary>
        /// 到期日
        /// </summary>
        public DateTime? DocDueDate { get; set; }
        /// <summary>
        /// 合约单号
        /// </summary>
        public string Hynum { get; set; }
        /// <summary>
        /// 采购员名称
        /// </summary>
        public string Slpname { get; set; }
    }
}