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

        public static List<FieldMapper> Q001StockCurrent()
        {
            var fieldMappers = new List<FieldMapper>();
            fieldMappers.Add(new FieldMapper { Id = "Cpositioncode", Name = "儲位編碼", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Cposition", Name = "儲位名稱", Index = -1 });
            //單據號	出庫通知單單號	出庫類型	制單人	制單日期	出庫日期	扣帳時間	狀態	編
            fieldMappers.Add(new FieldMapper { Id = "Cinvcode", Name = "物料編碼", Index = -1 });

            fieldMappers.Add(new FieldMapper { Id = "Cinvname", Name = "物料名稱", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Iqty", Name = "數量", Index = -1 });
            return fieldMappers;
        }

        public static List<FieldMapper> Q016V2StockCurrentAdjust()
        {
            var fieldMappers = new List<FieldMapper>();
            fieldMappers.Add(new FieldMapper { Id = "Cticketcode", Name = "庫存調整單", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Reason", Name = "理由", Index = -1 });
            //單據號	出庫通知單單號	出庫類型	制單人	制單日期	出庫日期	扣帳時間	狀態	編
            fieldMappers.Add(new FieldMapper { Id = "Createownername", Name = "製單人", Index = -1 });

            fieldMappers.Add(new FieldMapper { Id = "Createtime", Name = "製單日期", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Cstatusname", Name = "狀態", Index = -1 });
            return fieldMappers;
        }
        public static List<FieldMapper> Q017VInasn()
        {
            var fieldMappers = new List<FieldMapper>();
            fieldMappers.Add(new FieldMapper { Id = "Cticketcode", Name = "入庫通知單", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Typename", Name = "入庫類型", Index = -1 });
            //單據號	入庫類型	入庫理由碼	制單人	制單日期	狀態
            fieldMappers.Add(new FieldMapper { Id = "Reasoncontent", Name = "入庫理由碼", Index = -1 });

            fieldMappers.Add(new FieldMapper { Id = "Ccreateownercode", Name = "制單人", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Dcreatetime", Name = "製單日期", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Statusname", Name = "狀態", Index = -1 });
            return fieldMappers;
        }
        public static List<FieldMapper> Q018VOutasnlist()
        {
            var fieldMappers = new List<FieldMapper>();
            fieldMappers.Add(new FieldMapper { Id = "Cticketcode", Name = "出庫通知單", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Typename", Name = "出庫類型", Index = -1 });
            //單據號	出庫類型	制單人	制單日期	狀態
            //  fieldMappers.Add(new FieldMapper { Id = "Reasoncontent", Name = "入庫理由碼", Index = -1 });

            fieldMappers.Add(new FieldMapper { Id = "Ccreateownercode", Name = "制單人", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Dcreatetime", Name = "製單日期", Index = -1 });

            // NOTE by Mark, 2021-01-21, WHY??? 這兩個都對不上?
            // 是不是 view VOutasnlist 有問題???
            fieldMappers.Add(new FieldMapper { Id = "Cstatusname", Name = "狀態", Index = -1 });
            //fieldMappers.Add(new FieldMapper { Id = "FlagName", Name = "狀態", Index = -1 });


            return fieldMappers;
        }

        public static List<FieldMapper> Q019V2Outasn()
        {
            var fieldMappers = new List<FieldMapper>();
            fieldMappers.Add(new FieldMapper { Id = "Cticketcode", Name = "出庫通知單", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Typename", Name = "出庫類型", Index = -1 });
            //單據號	出庫類型	制單人	制單日期	狀態
            //  fieldMappers.Add(new FieldMapper { Id = "Reasoncontent", Name = "入庫理由碼", Index = -1 });

            fieldMappers.Add(new FieldMapper { Id = "Ccreateownername", Name = "制單人", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Dcreatetime", Name = "製單日期", Index = -1 });

            // NOTE by Mark, 2021-01-21, WHY??? 這兩個都對不上?
            // 是不是 view VOutasnlist 有問題???
            fieldMappers.Add(new FieldMapper { Id = "Cstatusname", Name = "狀態", Index = -1 });
            //fieldMappers.Add(new FieldMapper { Id = "FlagName", Name = "狀態", Index = -1 });


            return fieldMappers;
        }


        public static List<FieldMapper> Q017SysParameter()
        {
            var fieldMappers = new List<FieldMapper>();
            fieldMappers.Add(new FieldMapper { Id = "FlagId", Name = "FlagId", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "FlagName", Name = "FlagName", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "FlagType", Name = "FlagType", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Sortid", Name = "Sortid", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Memo", Name = "Memo", Index = -1 });

            return fieldMappers;
        }

        public static List<FieldMapper> byEntityName(string entity)
        {
            if (entity == "SysParameter") return Q021SysParameter();
            return new List<FieldMapper>();
        }
            public static List<FieldMapper> Q021SysParameter()
        {
            var fieldMappers = new List<FieldMapper>();
            fieldMappers.Add(new FieldMapper { Id = "FlagId", Name = "FlagId", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "FlagName", Name = "FlagName", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "FlagType", Name = "FlagType", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Sortid", Name = "Sortid", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Memo", Name = "Memo", Index = -1 });

            return fieldMappers;
        }
        public static List<FieldMapper> Q023SysConfig()
        {
            var fieldMappers = new List<FieldMapper>();
            fieldMappers.Add(new FieldMapper { Id = "Type", Name = "Type", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Code", Name = "Code", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "ConfigDesc", Name = "ConfigDesc", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "ConfigValue", Name = "ConfigValue", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Memo", Name = "Memo", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "TypeMemo", Name = "TypeMemo", Index = -1 });
            fieldMappers.Add(new FieldMapper { Id = "Status", Name = "Status", Index = -1 });

            return fieldMappers;
        }
    }
}
