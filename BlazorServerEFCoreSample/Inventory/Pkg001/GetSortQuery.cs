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

            string[] words = sortStr.Split('_');


            switch (words[0])
            {
                case "WmsTskId":
                    query = words[1] == "1" ? query.OrderBy(x => x.WmsTskId)
                   : query.OrderByDescending(c => c.WmsTskId);
                    return query;
                default:
                    return query;
            }

        }
    }
}
