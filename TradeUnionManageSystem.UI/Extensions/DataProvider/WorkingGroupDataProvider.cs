using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradeUnionManageSystem.BLL;
using TradeUnionManageSystem.BLL.Models;

namespace TradeUnionManageSystem.UI.Extensions.DataProvider
{
    public class WorkingGroupDataProvider
    {
        public static List<WorkingGroup> GetAll()
        {
            using (MyContext db = new MyContext())
            {
                List<WorkingGroup> result = db.WorkingGroups.ToList();
                return result;
            }
        }
    }
}