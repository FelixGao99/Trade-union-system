using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUnionManageSystem.BLL.Models
{
    public class WorkingGroup
    {
        [Key]
        public int ID { get; set; }

        [Display(Name="团体名称")]
        public string WorkingGroupName { get; set; }
    }
}
