using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUnionManageSystem.BLL.Models
{
    /// <summary>
    /// 荣誉
    /// </summary>
    public class Honor
    {
        [Key]
        public int ID { get; set; }

        [Display(Name="获奖对象")]
        public string HonorTarget { get; set; }

        [Display(Name = "获奖称号")]
        public string HonorName { get; set; }

        [Display(Name = "称号级别")]
        public int HonorLevel { get; set; }

        [Display(Name = "获奖时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "发证部门编号")]
        public string CreateDeptCode { get; set; }

        [Display(Name = "职工ID")]
        public int EmployeeID { get; set; }

        [Display(Name = "从事岗位编号")]
        public int EmployeeJobCode { get; set; }

        [Display(Name = "单位编号")]
        public int EmployeeUnitCode { get; set; }

        [Display(Name = "团体编号")]
        public int EmployeeGroupCode { get; set; }
    }
}
