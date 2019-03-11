using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradeUnionManageSystem.BLL;
using TradeUnionManageSystem.BLL.Models;

namespace TradeUnionManageSystem.UI.Extensions.DataProvider
{
    public class PositionDataProvider
    {
        public static List<Position> GetAll()
        {
            using (MyContext db = new MyContext())
            {
                List<Position> result = db.Positions.ToList();
                return result;
            }
        }
    }
}