using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;
namespace Inventory.Package1
{
    public class GetSortQuery
    {
        public static IQueryable<VCmdMst> VCmdMst(IQueryable<VCmdMst> query, string sortStr)
        {

            if (sortStr == null) // QUICK FIX: 不知道為何使用  browser fresh, sortStr becomes null
            {
                sortStr = "WmsTskId_1";
            }

            string[] str = sortStr.Split('_');


            switch (str[0])
            {
                case "WmsTskId":
                    if (str[1] == "1") return query.OrderBy(x => x.WmsTskId);
                    if (str[1] == "2") return query.OrderByDescending(x => x.WmsTskId);
                    return query;
                case "CmdSno":
                    if (str[1] == "1") return query.OrderBy(x => x.CmdSno);
                    if (str[1] == "2") return query.OrderByDescending(x => x.CmdSno);
                    return query;
                case "StnNo":
                    if (str[1] == "1") return query.OrderBy(x => x.StnNo);
                    if (str[1] == "2") return query.OrderByDescending(x => x.StnNo);
                    return query;
                case "Loc":
                    if (str[1] == "1") return query.OrderBy(x => x.Loc);
                    if (str[1] == "2") return query.OrderByDescending(x => x.Loc);
                    return query;
                case "NewLoc":
                    if (str[1] == "1") return query.OrderBy(x => x.NewLoc);
                    if (str[1] == "2") return query.OrderByDescending(x => x.NewLoc);
                    return query;
                case "Cticketcode":
                    if (str[1] == "1") return query.OrderBy(x => x.Cticketcode);
                    if (str[1] == "2") return query.OrderByDescending(x => x.Cticketcode);
                    return query;
                case "Remark":
                    if (str[1] == "1") return query.OrderBy(x => x.Remark);
                    if (str[1] == "2") return query.OrderByDescending(x => x.Remark);
                    return query;
                default:
                    return query;
            }

        }
        public static IQueryable<V2Outbill> V2Outbill(IQueryable<V2Outbill> query, string sortStr)
        {

            if (sortStr == null) // QUICK FIX: 不知道為何使用  browser fresh, sortStr becomes null
            {
                sortStr = "Cticketcode_1";
            }

            string[] str = sortStr.Split('_');


            switch (str[0])
            {
                case "Cticketcode":
                    if (str[1] == "1") return query.OrderBy(x => x.Cticketcode);
                    if (str[1] == "2") return query.OrderByDescending(x => x.Cticketcode);
                    return query;
                default:
                    return query;
            }

        }

    }
}
