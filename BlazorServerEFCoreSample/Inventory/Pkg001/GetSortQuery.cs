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
                default:
                    return query;
            }

        }
    }
}
