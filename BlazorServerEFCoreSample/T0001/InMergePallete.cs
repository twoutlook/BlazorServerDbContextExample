﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    public partial class InMergePallete
    {
        public string Id { get; set; }
        /// <summary>
        /// 要做拼板入库的入库通知单号
        /// </summary>
        public string Inasncode { get; set; }
        /// <summary>
        /// 栈板编号
        /// </summary>
        public string Palletcode { get; set; }
        public string Erpcode { get; set; }
        /// <summary>
        /// 依据栈板号出库的出库通知单
        /// </summary>
        public string OutasncodePallet { get; set; }
        /// <summary>
        /// 依据栈板号出库的出库单
        /// </summary>
        public string OutbillcodePallet { get; set; }
        /// <summary>
        /// 依据栈板号入库的入库通知单
        /// </summary>
        public string InasncodePallet { get; set; }
        /// <summary>
        /// 依据栈板号入库的入库单
        /// </summary>
        public string InbillcodePallet { get; set; }
        /// <summary>
        /// 状态（0=未处理，已生出库单  2=处理中，已生成入库通知单 3=已完成，已生出入库单）
        /// </summary>
        public string Cstatus { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Createuser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Createtime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string Modifyuser { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? Modifytime { get; set; }
        public string Cdefine1 { get; set; }
        public string Cdefine2 { get; set; }
        public string Cdefine3 { get; set; }
        public string Cdefine4 { get; set; }
        public string Remark { get; set; }
    }
}