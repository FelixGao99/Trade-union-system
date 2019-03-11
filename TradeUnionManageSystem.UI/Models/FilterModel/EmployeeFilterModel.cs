using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeUnionManageSystem.UI.Models.FilterModel
{
    /// <summary>
    /// 会员查询条件类
    /// </summary>
    public class EmployeeFilterModel
    {
        public string EmployeeName { get; set; }

        public int EmployeeGender { get; set; }

        public DateTime BirthdayStart { get; set; }

        public DateTime BirthdayEnd { get; set; }

        public string WorkingPositionName { get; set; }

        public string WorkingUnitName { get; set; }

        public string WorkingGroupName { get; set; }

        public string WorkingStatus { get; set; }

    }
}