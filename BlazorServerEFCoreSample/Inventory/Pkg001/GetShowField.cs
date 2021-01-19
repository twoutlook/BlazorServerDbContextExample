using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;
using Inventory.Shared;

namespace Inventory.Package1
{
    public class GetShowField


    {

        public static List<ShowField> Q001VCmdMst()
        {
            // NOTE by Mark, 2021-01-19
            // 這部份, 要從 DbContext 獲得基本模板再微調
            // 如能仿 EF Core Power Tool 那就更好//
            //
            // 以這份為基準, 可以生成 篩選排序的 代碼
            //
            var showFields = new List<ShowField>();
            showFields.Add(new ShowField(1, "WmsTskId", "WmsTskId", 1));
            showFields.Add(new ShowField(2, "CmdSno", "CmdSno", 2));
            showFields.Add(new ShowField(3, "StnNo", "站點", 3));
            showFields.Add(new ShowField(4, "Loc", "原始儲位", 4));
            showFields.Add(new ShowField(5, "NewLoc", "目的儲位", 5));
            showFields.Add(new ShowField(6, "Cticketcode", "單據號", 6));
            showFields.Add(new ShowField(7, "Remark", "備註", 7));
            return showFields;

            //var fieldMappers = new List<FieldMapper>();
            //fieldMappers.Add(new FieldMapper { Id = "WmsTskId", Name = "WmsTskId", Index = -1 });
            //fieldMappers.Add(new FieldMapper { Id = "CmdSno", Name = "CmdSno", Index = -1 });
            ////命令編號 箱號/ 棧板號  線別 站點  原始儲位 目的儲位    單據號 命令類型    
            ////    備註 命令狀態    TaskNO 接收時間    開始時間 完成時間    返回狀態 資訊
            //fieldMappers.Add(new FieldMapper { Id = "StnNo", Name = "站點", Index = -1 });

            //fieldMappers.Add(new FieldMapper { Id = "Loc", Name = "原始儲位", Index = -1 });
            //fieldMappers.Add(new FieldMapper { Id = "NewLoc", Name = "目的儲位", Index = -1 });
            //fieldMappers.Add(new FieldMapper { Id = "Cticketcode", Name = "單據號", Index = -1 });
            //fieldMappers.Add(new FieldMapper { Id = "Remark", Name = "備註", Index = -1 });
            //return fieldMappers;
        }

    }
}
