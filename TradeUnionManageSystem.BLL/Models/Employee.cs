using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUnionManageSystem.BLL.Models
{
    /// <summary>
    /// 职工
    /// </summary>
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Display(Name="职工姓名")]
        public string Name { get; set; }

        [Display(Name = "职工性别")]
        public int Gender { get; set; }

        [Display(Name = "出生日期")]
        public DateTime Birthday { get; set; }

        [Display(Name = "岗位编号")]
        public string JobCode { get; set; }

        [Display(Name = "单位编号")]
        public string UnitCode { get; set; }

        [Display(Name = "团体编号")]
        public string GroupCode { get; set; }

        [Display(Name = "就业状况")]
        public string WorkingStatus { get; set; }
    }
}
