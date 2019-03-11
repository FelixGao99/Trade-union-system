using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUnionManageSystem.BLL.Models
{
    public class ModelWorker
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "职工ID")]
        public int EmployeeID { get; set; }

        [Display(Name = "就业状况")]
        public string WorkStatus { get; set; }

        [Display(Name = "现（离退休）工作单位")]
        public int WorkingUnitCode { get; set; }

        [Display(Name = "现（离退休）职务")]
        public int WorkingPositionCode { get; set; }

        [Display(Name = "劳模类型")]
        public string ModelWorkderType { get; set; }

        [Display(Name = "劳模级别")]
        public string ModelWorkerLevel { get; set; }

        [Display(Name = "荣获劳模时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "月工资收入")]
        public double SalaryPerMonth { get; set; }

        [Display(Name = "其它收入")]
        public double OtherIncome { get; set; }

        [Display(Name = "是否享受劳模退休荣誉津贴")]
        public bool HaveAllowance { get; set; }

        [Display(Name = "是否享受劳模医疗待遇")]
        public bool HaveMedicalTreatment { get; set; }

        [Display(Name = "单位所属市区")]
        public string UnitLocation { get; set; }

        [Display(Name = "现家庭住址")]
        public string Address { get; set; }

        [Display(Name = "家庭电话")]
        public string PhoneNumber { get; set; }
    }
}
