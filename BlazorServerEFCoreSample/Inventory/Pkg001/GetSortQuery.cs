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
