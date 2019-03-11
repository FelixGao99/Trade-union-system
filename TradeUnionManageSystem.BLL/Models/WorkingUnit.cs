using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUnionManageSystem.BLL.Models
{
    public class WorkingUnit
    {
        [Key]
        public int ID { get; set; }

        [Display(Name="单位名称")]
        public string WorkingUnitName { get; set; }
    }
}
