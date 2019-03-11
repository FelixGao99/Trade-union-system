using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeUnionManageSystem.UI.Models.DisplayModel
{
    public class WorkingCongressDisplayModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "届")]
        public int CongressSession { get; set; }

        [Display(Name = "次")]
        public int CongressTime { get; set; }

        [Display(Name = "单位编号")]
        public string UnitCode { get; set; }

        [Display(Name = "召开日期")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "正式代表人数")]
        public int RepresentAmount { get; set; }

        [Display(Name = "列席代表人数")]
        public int AttendanceAmount { get; set; }

        [Display(Name = "提案数")]
        public int ProposalAmount { get; set; }
    }
}