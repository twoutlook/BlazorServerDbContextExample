using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;
using Inventory.Grid;

namespace Inventory.Package1
{
    public class GetFilterContains
    {
        private static IQueryable<VCmdMst> _VCmdMst(IQueryable<VCmdMst> query, string col, string f1)//以  f1 替代了 2,3 等
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

        public static IQueryable<VCmdMst> VCmdMst(IQueryable<VCmdMst> query, IBaseFiltersV2 f)
        {
            for (int i = 0; i < f.FilterContainsCol.Length; i++)
            {
                if (f.FilterContainsCol[i] != null)//表示有值
                {
                    query= _VCmdMst(query, f.FilterContainsCol[i], f.FilterContains[i]);

                }
            }
            return query;
        }
    }
}
