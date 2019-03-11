using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeUnionManageSystem.UI.Models.FilterModel
{
    /// <summary>
    /// 荣誉查询条件类
    /// </summary>
    public class HonorFilterModel
    {
        public string HonorName { get; set; }

        public int HonorLevel { get; set; }

        public string EmployeeName { get; set; }

        public int EmployeeWorkingUnitID { get; set; }

        public int EmployeeWorkingPositionID { get; set; }

        public int EmployeeGender { get; set; }

        public DateTime HonorStartTime { get; set; }

        public DateTime HonorEndTime { get; set; }

        public string HonorTarget { get; set; }
    }
}