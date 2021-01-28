﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0001
{
    public partial class CmdAgvTask
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
        /// 请求时间截
        /// </summary>
        public string Reqtime { get; set; }
        /// <summary>
        /// 客户端编号，如 PDA，HCWMS 等。由 RCS告知上层系统
        /// </summary>
        public string Clientcode { get; set; }
        /// <summary>
        /// 令牌号, 由调度系统颁发。 由RCS告知上层系统
        /// </summary>
        public string Tokencode { get; set; }
        /// <summary>
        /// TCP 协议必传，REST 协议不用传， 传了也不影响
        /// </summary>
        public string Interfacename { get; set; }
        /// <summary>
        /// 任务类型，与在 RCS端配置的主任务类型编号一致。
        /// </summary>
        public string Tasktyp { get; set; }
        /// <summary>
        /// 工作位
        /// </summary>
        public string Wbcode { get; set; }
        /// <summary>
        /// 货架编号，不指定货架可以为空
        /// </summary>
        public string Podcode { get; set; }
        /// <summary>
        /// “180”,”0”,”90”,”-90” 分别代表”左”,”
        /// </summary>
        public string Poddir { get; set; }
        /// <summary>
        /// 货架类型, 找满货架时传空, 找空货架时必传-1: 代表不关心货架类型, 找到空货架即可.-2: 代表从工作位获取关联货架类型, 如果未配置, 只找空货架.货架类型编号: 只找该货架类型的空货架
        /// </summary>
        public string Podtyp { get; set; }
        /// <summary>
        /// 物料批次或货架上的物料唯一编码, 生成任务单时,货架与物料直接绑定时使用
        /// </summary>
        public string Materiallot { get; set; }
        /// <summary>
        /// 优先级，从（1~5）级，最大优先级最高
        /// </summary>
        public string Priority { get; set; }
        /// <summary>
        /// 任务单号, 选填, 不填系统自动生成，必须为 32 位 UUID
        /// </summary>
        public string Taskcode { get; set; }
        /// <summary>
        /// AGV 编号，填写表示指定某一编号的 AGV 执行该任务
        /// </summary>
        public string Agvcode { get; set; }
        public string Data { get; set; }
        /// <summary>
        /// 0agv尚未调用, 1agv调用成功, 2小车状态任务开始，3小车状态走出储位，4小车状态任务结束   5小车任务单取消
        /// </summary>
        public string Status { get; set; }
        public string Vendorname { get; set; }
        /// <summary>
        /// 任务生成者
        /// </summary>
        public string CreateOwner { get; set; }
        /// <summary>
        /// 任务生成时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}