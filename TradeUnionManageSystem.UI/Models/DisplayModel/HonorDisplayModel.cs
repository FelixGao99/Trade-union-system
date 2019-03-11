using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeUnionManageSystem.UI.Models.DisplayModel
{
    /// <summary>
    /// 荣誉展示类
    /// </summary>
    public class HonorDisplayModel
    {
        [Display(Name = "荣誉ID")]
        public int ID { get; set; }

        [Display(Name = "获奖对象")]
        public string HonorTarget { get; set; }

        [Display(Name = "职工")]
        public string HonorEmployeeName { get; set; }

        [Display(Name = "性别")]
        public string HonorEmployeeGender { get; set; }

        [Display(Name = "出生日期")]
        public string HonorEmployeeBirthday { get; set; }

        [Display(Name = "从事岗位")]
        public string HonorEmployeeWorkingPosition { get; set; }

        [Display(Name = "单位")]
        public string HonorEmployeeWorkingUnit { get; set; }

        [Display(Name = "团体名称")]
        public string HonorEmployeeWorkingGroup { get; set; }

        [Display(Name = "获奖称号")]
        public string HonorName { get; set; }

        [Display(Name = "称号级别")]
        public int HonorLevel { get; set; }

        [Display(Name = "获奖时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "发证机关")]
        public string CreateDeptName { get; set; }




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