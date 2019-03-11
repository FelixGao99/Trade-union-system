using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUnionManageSystem.BLL.Models
{
    /// <summary>
    /// 班组
    /// </summary>
    public class WorkingTeam
    {
        [Key]
        public int ID { get; set; }

        [Display(Name="单位")]
        public string UnitCode { get; set; }

        [Display(Name = "班组名称")]
        public string TeamName { get; set; }

        [Display(Name = "车辆数")]
        public int CarCount { get; set; }

        [Display(Name = "人数")]
        public int EmployeeCount { get; set; }

        [Display(Name = "班长职工编号")]
        public int MonitorEmployeeID { get; set; }

        [Display(Name = "班长政治面貌")]
        public string MonitorPoliticalStatus { get; set; }

        [Display(Name = "副班长职工编号")]
        public int SubMonitorEmployeeID { get; set; }

        [Display(Name = "副班长政治面貌")]
        public string SubMonitorPoliticalStatus { get; set; }
    }
}
