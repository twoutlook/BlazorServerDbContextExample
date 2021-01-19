using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;

namespace Inventory.Package1
{
    public class GetFilterContains
    {
        public static IQueryable<VCmdMst> VCmdMst(IQueryable<VCmdMst> query, string col, string f1)//以  f1 替代了 2,3 等
        {
            if (string.IsNullOrWhiteSpace(f1)) //如果沒有值, 不處理, 簡單明瞭
                return query;

            switch (col) // 有值的話,也是一映對到欄位。集中管理,反而單純
            {
                case "Loc": return query.Where(x => x.Loc.Contains(f1));
                case "Cticketcode": return query.Where(x => x.Cticketcode.Contains(f1));
                case "Remark": return query.Where(x => x.Remark.Contains(f1));
                default: return query;
            }
        }
    }
}
