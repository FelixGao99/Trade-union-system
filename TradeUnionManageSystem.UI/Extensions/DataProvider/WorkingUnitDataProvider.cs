using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradeUnionManageSystem.BLL;
using TradeUnionManageSystem.BLL.Models;

namespace TradeUnionManageSystem.UI.Extensions.DataProvider
{
    public class WorkingUnitDataProvider
    {
        public static List<WorkingUnit> GetAll()
        {
            using (MyContext db = new MyContext())
            {
                List<WorkingUnit> result = db.WorkingUnits.ToList();
                return result;
            }
        }
    }
}