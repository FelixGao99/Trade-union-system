using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradeUnionManageSystem.BLL;
using TradeUnionManageSystem.BLL.Models;

namespace TradeUnionManageSystem.UI.Extensions.DataProvider
{
    public static class EmployeeDataProvider
    {
        public static List<Employee> GetAll()
        {
            using(MyContext db = new MyContext())
            {
                List<Employee> result = db.Employees.ToList();
                return result;
            }
        }
    }
}