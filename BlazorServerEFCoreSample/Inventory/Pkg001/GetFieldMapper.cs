﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;
using Inventory.Shared;

namespace Inventory.Package1
{
    public class GetFieldMapper


    {

        public static List<FieldMapper> Q001VCmdMst()
        {
            var fieldMappers = new List<FieldMapper>();
            fieldMappers.Add(new FieldMapper { Id = "WmsTskId", Name = "WmsTskId", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "CmdSno", Name = "CmdSno", Index = -1 });
            //命令編號 箱號/ 棧板號  線別 站點  原始儲位 目的儲位    單據號 命令類型    
            //    備註 命令狀態    TaskNO 接收時間    開始時間 完成時間    返回狀態 資訊
            fieldMappers.Add(new FieldMapper { Id = "StnNo", Name = "站點", Index = -1 });

            fieldMappers.Add(new FieldMapper { Id = "Loc", Name = "原始儲位", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "NewLoc", Name = "目的儲位", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Cticketcode", Name = "單據號", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Remark", Name = "備註", Index = -1 });
            return fieldMappers;
        }
        public static List<FieldMapper> Q001V2Outbill()
        {
            var fieldMappers = new List<FieldMapper>();
            fieldMappers.Add(new FieldMapper { Id = "Cticketcode", Name = "出庫單", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Coutasn", Name = "出庫通知單", Index = -1 });
            //單據號	出庫通知單單號	出庫類型	制單人	制單日期	出庫日期	扣帳時間	狀態	編
            fieldMappers.Add(new FieldMapper { Id = "Outtype", Name = "出庫類型", Index = -1 });

            fieldMappers.Add(new FieldMapper { Id = "Ccreateownername", Name = "制單人", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Dindate", Name = "制單日期", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Debittime", Name = "扣帳時間", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Cstatusname", Name = "狀態", Index = -1 });
            return fieldMappers;
        }

    }
}
