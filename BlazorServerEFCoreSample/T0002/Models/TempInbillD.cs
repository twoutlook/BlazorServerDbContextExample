﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0002.Models
{
    public partial class TempInbillD
    {
        public string Ids { get; set; }
        public string Id { get; set; }
        public string Cstatus { get; set; }
        public string Cinvcode { get; set; }
        public string Cinvname { get; set; }
        public decimal? Iquantity { get; set; }
        public string Cinvbarcode { get; set; }
        public string Cerpcodeline { get; set; }
        public string Cmemo { get; set; }
        public string Cpositioncode { get; set; }
        public string Cposition { get; set; }
        public DateTime Dindate { get; set; }
        public string Cinpersoncode { get; set; }
        public decimal? Iasnline { get; set; }
        public decimal? Cdefine1 { get; set; }
        public string Cdefine2 { get; set; }
        public DateTime? Ddefine3 { get; set; }
        public DateTime? Ddefine4 { get; set; }
        public decimal? Idefine5 { get; set; }
        public string Stockcurrentdetailid { get; set; }
        public string Inbillcticketcode { get; set; }
        public decimal? LineQty { get; set; }
        public decimal? Sntype { get; set; }
        public string AsnDIds { get; set; }
        public decimal? Scantype { get; set; }
        public string SnCode20 { get; set; }
        public string Site { get; set; }
        public string Wire { get; set; }
        public string Worktype { get; set; }
        public string PalletCode { get; set; }
        public string Rulecode { get; set; }
        /// <summary>
        /// 是否暂存入  0： 不是  1：是
        /// </summary>
        public string IsTemporary { get; set; }
    }
}