using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;
using Inventory.Shared;

namespace Inventory.Pkg1
{

    public class PageShowField
    {
        public PageShowField(string pageName, string entityName, List<ShowField> showField)
        {
            PageName = pageName;
            EntityName = entityName;
            ShowField = showField;
        }
        public string PageName { get; set; }
        public string EntityName { get; set; }
        public List<ShowField> ShowField { get; set; }
    }

    public class GetShowField


    {

        public static List<ShowField> Q011VCmdMst()
        {
            // NOTE by Mark, 2021-01-19
            // 這部份, 要從 DbContext 獲得基本模板再微調
            // 如能仿 EF Core Power Tool 那就更好//
            //
            // 以這份為基準, 可以生成 篩選排序的 代碼
            //
            var showFields = new List<ShowField>();
            showFields.Add(new ShowField(1, "WmsTskId", "WmsTskId", 1,0));
            showFields.Add(new ShowField(2, "CmdSno", "CmdSno", 2,1));
            showFields.Add(new ShowField(3, "StnNo", "站點", 3,2));
            showFields.Add(new ShowField(4, "Loc", "原始儲位",4, 3));
            showFields.Add(new ShowField(5, "NewLoc", "目的儲位",5, 4));
            showFields.Add(new ShowField(6, "Cticketcode", "單據號",6, 5));
            showFields.Add(new ShowField(7, "Remark", "備註",7, 6));
            return showFields;

        }

        public static List<ShowField> Q011VCmdMstV2()
        {
             var showFields = new List<ShowField>();
            showFields.Add(new ShowField(1, "WmsTskId", "WmsTskId---V2", 1, 0));
            showFields.Add(new ShowField(2, "CmdSno", "CmdSno", 2, 1));
            showFields.Add(new ShowField(3, "StnNo", "站點", 3, 2));
            showFields.Add(new ShowField(4, "Loc", "原始儲位", 4, 3));
            showFields.Add(new ShowField(5, "NewLoc", "目的儲位", 5, 4));
            showFields.Add(new ShowField(6, "Cticketcode", "單據號", 6, 5));
            showFields.Add(new ShowField(7, "Remark", "備註", 7, 6));
            return showFields;

        }

    }
}
