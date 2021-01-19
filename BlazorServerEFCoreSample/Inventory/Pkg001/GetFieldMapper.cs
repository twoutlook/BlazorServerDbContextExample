using System;
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

            var showFields = new List<ShowField>();
            showFields.Add(new ShowField("WmsTskId", "WmsTskId", 1,0));


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

    }
}
