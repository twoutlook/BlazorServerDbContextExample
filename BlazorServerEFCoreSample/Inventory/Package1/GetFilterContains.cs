using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;

namespace Inventory.Package1
{
    public class GetFilterContains
    {
        public static IQueryable<VCmdMst> VCmdMst(IQueryable<VCmdMst> query, string col, string f1)
        {
            if (string.IsNullOrWhiteSpace(f1))
                return query;

            //if (col == "Loc")
            //    return query.Where(x => x.Loc.Contains(f1));

            //if (col == "Cticketcode")
            //    return query.Where(x => x.Loc.Contains(f1));

            //if (col == "Remark")
            //    return query.Where(x => x.Loc.Contains(f1));

            switch (col)
            {
                case "Loc": 
                    return query.Where(x => x.Loc.Contains(f1));
                case "Cticketcode":
                    return query.Where(x => x.Cticketcode.Contains(f1));
                case "Remark":
                    return query.Where(x => x.Remark.Contains(f1));
                default:
                    return query;
            }
        }
    }
}
