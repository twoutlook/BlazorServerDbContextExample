﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    public partial class Outbill
    {
        public string Id { get; set; }
        public string Ccreateownercode { get; set; }
        public DateTime Dcreatetime { get; set; }
        public string Cauditperson { get; set; }
        public DateTime? Daudittime { get; set; }
        public string Cticketcode { get; set; }
        public string Cstatus { get; set; }
        public string Cerpcode { get; set; }
        public string Coutasnid { get; set; }
        public string Cmemo { get; set; }
        public DateTime Dindate { get; set; }
        public string Cdefine1 { get; set; }
        public string Cdefine2 { get; set; }
        public DateTime? Ddefine3 { get; set; }
        public string Ddefine4 { get; set; }
        /// <summary>
        /// 是否整板出  0:部分出  1:整板出
        /// </summary>
        public decimal? Idefine5 { get; set; }
        public string Cclientcode { get; set; }
        public string Cclient { get; set; }
        public decimal Otype { get; set; }
        public string Cso { get; set; }
        public DateTime? Debittime { get; set; }
        public string Debitowner { get; set; }
        public string Palletcode { get; set; }
        /// <summary>
        /// 作业方式 0：平库 1：立库
        /// </summary>
        public string Worktype { get; set; }
        /// <summary>
        /// 操作类型 0：正常流程 1：补单流程
        /// </summary>
        public int? Operationtype { get; set; }
        public string Wo { get; set; }
        public string IsTemporary { get; set; }
    }
}